using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using funsens.api;
using funsens.order.vo;
using funsens.util;

namespace funsens.ui
{
    /// <summary>
    /// 下单第三步：订单支付界面
    /// 下单成功后，显示后台拆分后的订单列表信息（实时刷新），可使用POS机扫描“子订单”列表中的条形码来进行支付
    /// </summary>
    public partial class AddOrderPayPanel : UserControl
    {
        private delegate void _Delegate();

        private delegate void ShowMessageDelegate(string message);

        private List<string> orderIdList;

        private List<OrderVO> orderList;

        public MainForm.MainFormCallback mainFormCallback;

        private ThreadStart threadStart;

        private Thread thread;

        //private bool isRunning;

        private List<OrderInfoForm> orderInfoFormList;

        private bool isFirst;

        //历史已交的税费
        private float historyPayedTax;

        //历史未交的税费
        private float historyUnPayTax;

        //所有订单（拆分后的子订单）总税费
        private float ordersTax;

        public AddOrderPayPanel()
        {
            InitializeComponent();
        }

        /*public void stopRefresh()
        {
            if (null != this.thread)
            {
                try
                {
                    this.thread.Abort();
                }
                catch (Exception e)
                {

                }

                this.isRunning = false;
                this.thread = null;
            }
        }*/

        public void setOrderIdList(List<string> orderIdList)
        {
            this.orderIdList = orderIdList;

            this.loadOrder();
        }

        /// <summary>
        /// 加载订单列表
        /// </summary>
        private void loadOrder()
        {
            if(null != this.orderIdList)
            {
                GetOrdersHandler handler = new GetOrdersHandler(this.handleFinish, -1, OrderVO.STATUS_NONE, this.orderIdList, 999999, 1);
                handler.handle();
            }
        }

        /// <summary>
        /// 加载订单列表任务（循环刷新订单列表）
        /// </summary>
        //private void loadOrderTask()
        //{
        //    _Delegate loadDelegate = new _Delegate(this.loadOrder);
        //    _Delegate showHPDelegate = new _Delegate(this.uiShowHP);
        //    _Delegate hideHPDelegate = new _Delegate(this.uiHideHP);

        //    while(true)
        //    {
        //        this.Invoke(showHPDelegate);
        //        this.Invoke(loadDelegate);
        //        this.Invoke(hideHPDelegate);

        //        try
        //        {
        //            Thread.Sleep(30000);
        //        }
        //        catch(Exception e)
        //        {
        //        }
        //    }
        //}

        /// <summary>
        /// 回调：接口处理完成
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rc"></param>
        /// <param name="error"></param>
        /// <param name="content"></param>
        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(this.uiHideHP);
            ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.uiShowMessage);

            JO jo = null;

            if (null == content)
            {
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回空内容" });
                return;
            }
            else if("0".Equals(content.ToString()))
            {
                return;
            }
            else if ((jo = new JO(content.ToString())).isNull())
            {
                MessageBox.Show("服务器异常，返回值为:\n" + content.ToString());
                this.Invoke(_delegate);
                return;
            }

            if (type == API.T_ORDERS)
            {
                if (rc == Handler.RC_SUCCESS)
                {
                    JA orderJA = jo.getJA("orderList");

                    this.historyPayedTax = jo.getFloat("historyPayedTax");
                    this.historyUnPayTax = jo.getFloat("historytax");
                    this.ordersTax = 0.0f;

                    int count = orderJA.size();
                    this.orderList = new List<OrderVO>();
                    for (int i = 0; i < count; i++)
                    {
                        JO orderJO = orderJA.getJO(i);
                        OrderVO orderVO = new OrderVO(orderJO);
                        orderVO.PaiedTax = this.historyPayedTax;
                        orderVO.UnPayTax = this.historyUnPayTax;

                        this.ordersTax += orderVO.TaxTotal;

                        this.orderList.Add(orderVO);
                    }

                    for (int i = 0; i < count; i++)
                        this.orderList[i].OrdersTax = this.ordersTax;

                    _delegate = new _Delegate(this.uiReloadOrderDGV);
                    this.Invoke(_delegate);
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "网络异常，请稍后再试" });
                }
            }
        }

        private void uiShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void uiShowHP()
        {
            this.hp.Visible = true;
        }

        private void uiHideHP()
        {
            this.hp.Visible = false;
        }

        /// <summary>
        /// 重新加载订单列表控件
        /// </summary>
        private void uiReloadOrderDGV()
        {
            this.orderDGV.Rows.Clear();

            /*while(this.orderInfoFormList.Count > 0)
            {
                OrderInfoForm orderInfoForm = this.orderInfoFormList[0];
                orderInfoForm.Close();
                this.orderInfoFormList.RemoveAt(0);
            }*/

            //刷新订单列表
            int count = this.orderList.Count;
            for(int i=0;i<count;i++)
            {
                OrderVO vo = this.orderList[i];

                DataGridViewRow row = new DataGridViewRow();
                row.Height = 120;

                DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
                idCell.Value =  vo.Id;
                row.Cells.Add(idCell);
                

                DataGridViewTextBoxCell customerNameCell = new DataGridViewTextBoxCell();
                customerNameCell.Value = vo.CustomerName;
                row.Cells.Add(customerNameCell);

                float total = vo.Payment;
                if (vo.PaiedTax > 0)
                {
                    total += vo.TaxTotal;
                }
                else
                {
                    float tmp = vo.UnPayTax + vo.OrdersTax;
                    if (tmp > 50)
                        total += vo.TaxTotal;
                }

                DataGridViewTextBoxCell paymentCell = new DataGridViewTextBoxCell();
                paymentCell.Value = total;
                row.Cells.Add(paymentCell);

                DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();

                switch (vo.Status)
                {
                    case OrderVO.STATUS_CANCELED:
                        statusCell.Value = "已取消";
                        break;
                    case OrderVO.STATUS_DELETED:
                        statusCell.Value = "已删除";
                        break;
                    case OrderVO.STATUS_UN_PAY:
                        statusCell.Value = "等待付款";
                        break;
                    case OrderVO.STATUS_PAYED:
                        statusCell.Value = "已付款";
                        break;
                    case OrderVO.STATUS_DELIVED:
                        statusCell.Value = "已发货";
                        break;
                    case OrderVO.STATUS_FINISH:
                        statusCell.Value = "已完成";
                        break;
                    default:
                        statusCell.Value = "未知状态：" + vo.Status;
                        break;
                }

                row.Cells.Add(statusCell);

                //DataGridViewImageCell imageCell = new DataGridViewImageCell();
                //row.Cells.Add(imageCell);

                //BarcodeUtil bcu = new BarcodeUtil();
                //Image image = bcu.getBarcodeImage(450, 120, vo.Id);
                //imageCell.Value = image;

                DataGridViewButtonCell operationCell = new DataGridViewButtonCell();
                operationCell.Value = "支付";
                row.Cells.Add(operationCell);

                DataGridViewButtonCell receiptCell = new DataGridViewButtonCell();
                receiptCell.Value = "打印";
                row.Cells.Add(receiptCell);

               

                this.orderDGV.Rows.Add(row);

                this.orderDGV.ClearSelection();
            }

            //弹出订单支付界面
            if (this.isFirst)
            {
                for (int i = 0; i < count; i++)
                {
                    OrderVO vo = this.orderList[i];

                    OrderInfoForm infoForm = new OrderInfoForm();
                    infoForm.setOrder(vo);
                    this.orderInfoFormList.Add(infoForm);
                    infoForm.ShowDialog();
                } 

                this.isFirst = false;
            }

            this.unPayTaxL.Text = "￥" + this.historyUnPayTax;
        }

        /// <summary>
        /// 视图大小变更
        /// </summary>
        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 5;
            int titleH = this.titleP.ClientRectangle.Height;
            int footerW = this.footerP.ClientRectangle.Width;
            int footerH = this.footerP.ClientRectangle.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            this.orderDGV.Location = new Point(spacing, titleH);
            this.orderDGV.Size = new Size(w - spacing * 2, h - titleH - footerH - spacing);

            this.footerP.Location = new Point(w - footerW, h - footerH);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        /// <summary>
        /// 初始化视图
        /// </summary>
        private void uiInit()
        {
            this.titleP.setTitle("订单支付");
            this.hp.Visible = false;

            this.uiResize();
        }

        //private void startRefresh()
        //{
        //    if(null == this.thread)
        //    {
        //        //启动自动刷新列表线程
        //        //this.isRunning = true;
        //        this.threadStart = new ThreadStart(this.loadOrderTask);
        //        this.thread = new Thread(this.threadStart);
        //        this.thread.Start();
        //    }
        //}

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.orderInfoFormList = new List<OrderInfoForm>();
            this.isFirst = true;
            
            this.uiInit();

            //this.startRefresh();
        }

        private void AddOrderPayPanel_Load(object sender, EventArgs e)
        {
            this.orderDGV.Font = new Font("SimSun", Program.DGV_FONT_SIZE);
            this.init();
        }

        private void AddOrderPayPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void orderDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderVO orderVO = this.orderList[e.RowIndex];

            if (e.ColumnIndex == 4)
            {
                OrderInfoForm orderInfoForm = new OrderInfoForm();
                orderInfoForm.setOrder(orderVO);
                orderInfoForm.ShowDialog();

                Console.WriteLine(">>-" + e.RowIndex + " - " + orderVO.Id + "    " + orderVO.Total);
            }
            else if (e.ColumnIndex == 5)
            {
                this.loadOrder();
                OrderReceiptForm1 orderReceiptForm = new OrderReceiptForm1();
                orderReceiptForm.setOrder(orderVO);
                orderReceiptForm.ShowDialog();
            }
            
        }

        private void orderDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || null == this.orderList || this.orderList.Count <= e.RowIndex)
                return;

            OrderVO orderVO = this.orderList[e.RowIndex];
            if (orderVO.Status != OrderVO.STATUS_UN_PAY)
            {
                orderDGV.Rows[e.RowIndex].Cells[4] = new DataGridViewTextBoxCell();
                orderDGV.Rows[e.RowIndex].Cells[4].Value = "不出票重新支付";
            }
        }
    }
}
