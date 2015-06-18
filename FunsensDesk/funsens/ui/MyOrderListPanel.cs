using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using funsens.api;
using funsens.common;
using funsens.order.vo;
using x.util;

namespace funsens.ui
{
    /// <summary>
    /// “我的订单”界面
    /// 显示当前商家的前500条订单记录
    /// </summary>
    public partial class MyOrderListPanel : UserControl
    {
        private delegate void _Delegate();

        private delegate void ShowMessageDelegate(string message);

        public MainForm.MainFormCallback mainFormCallback;

        private int pageNo = 1;

        private List<OrderVO> orderList;

        private OrderVO vo;

        //当前正在加载的订单要处理的类型
        //1：支付
        //2：打印小票
        private int handleType;

        public OrderVO Vo
        {
            get { return vo; }
        }

        public MyOrderListPanel()
        {
            InitializeComponent();

            this.uiInitView();
        }

        /// <summary>
        /// 加载订单列表
        /// </summary>
        public void loadData()
        {
            this.hp.Visible = true;

            GetOrdersOfFranchiseeHandler handler = new GetOrdersOfFranchiseeHandler(this.handleFinish, Session.getInstance().getFranchiseeId(),7 , this.pageNo);
            handler.handle();
            //GetOrdersHandler handler = new GetOrdersHandler(this.handleFinish, -1, OrderVO.STATUS_NONE, null, 99999, 1);
            //handler.handle();
        }

        /// <summary>
        /// 加载订单信息
        /// </summary>
        /// <param name="handleType">处理类型，1：支付；2：打印小票</param>
        /// <param name="orderId"></param>
        private void loadOrder(int handleType, string orderId)
        {
            this.hp.Visible = true;

            this.handleType = handleType;

            List<string> orderIdList = new List<string>();
            orderIdList.Add(orderId);

            GetOrdersHandler handler = new GetOrdersHandler(this.handleFinish, -1, OrderVO.STATUS_NONE, orderIdList, 999999, 1);
            handler.handle();
        }

        /// <summary>
        /// 接口回调
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rc"></param>
        /// <param name="error"></param>
        /// <param name="content"></param>
        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(uiHideHP);
            this.Invoke(_delegate);

            ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.uiShowMessage);

            JO jo = null;

            if (rc != Handler.RC_SUCCESS)
            {
                MessageBox.Show("网络异常，请稍后再试");
                return;
            }
            else if ((jo = new JO(content.ToString())).isNull())
            {
                MessageBox.Show("服务器异常，返回值为:\n" + content.ToString());
                this.Invoke(_delegate);
                return;
            }

            if (type == API.T_ORDERS_OF_FRANCHISEE)
            {
                if (rc == Handler.RC_SUCCESS)
                {
                    JA orderJA = jo.getJA("orderList");
                    int count = orderJA.size();
                    this.orderList = new List<OrderVO>();
                    for (int i = 0; i < count; i++)
                    {
                        JO orderJO = orderJA.getJO(i);
                        OrderVO orderVO = new OrderVO(orderJO);
                        this.orderList.Add(orderVO);
                    }

                    _delegate = new _Delegate(this.uiRefreshItemDGV);
                    this.Invoke(_delegate);
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "网络异常，请稍后再试" });
                }
            }
            else if(type == API.T_ORDERS)
            {
                if (rc == Handler.RC_SUCCESS)
                {
                    JA orderJA = jo.getJA("orderList");

                    float historyPayedTax = jo.getFloat("historyPayedTax");
                    float historyUnPayTax = jo.getFloat("historytax");

                    int count = orderJA.size();
                    for (int i = 0; i < count; i++)
                    {
                        JO orderJO = orderJA.getJO(i);
                        this.vo = new OrderVO(orderJO);
                        this.vo.PaiedTax = historyPayedTax;
                        this.vo.UnPayTax = historyUnPayTax;
                        this.vo.OrdersTax = vo.TaxTotal;
                    }

                    if (this.handleType == 1)
                        _delegate = new _Delegate(this.uiShowPayForm);
                    else
                        _delegate = new _Delegate(this.uiShowPrintForm);

                    this.Invoke(_delegate);
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "网络异常，请稍后再试" });
                }
            }
        }

        private void uiRefreshItemDGV()
        {
            this.itemDGV.Rows.Clear();

            int count = this.orderList.Count;
            for (int i = 0; i < count; i++)
            {
                OrderVO vo = this.orderList[i];

                DataGridViewRow row = new DataGridViewRow();
                row.ReadOnly = true;
                row.Height = 80;

                DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
                idCell.Value = vo.Id;
                row.Cells.Add(idCell);

                DataGridViewTextBoxCell customerNameCell = new DataGridViewTextBoxCell();
                customerNameCell.Value = vo.CustomerName;
                row.Cells.Add(customerNameCell);


                DataGridViewTextBoxCell totalCell = new DataGridViewTextBoxCell();
                totalCell.Value = vo.Total;
                row.Cells.Add(totalCell);

                DataGridViewTextBoxCell createdCell = new DataGridViewTextBoxCell();
                createdCell.Value = vo.Created.ToString();
                row.Cells.Add(createdCell);

                DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();
                switch (vo.Status)
                {
                    case OrderVO.STATUS_CANCELED:
                        statusCell.Value = "已取消";
                        break;
                    case OrderVO.STATUS_DELETED:
                        statusCell.Value = "已删除";
                        break;
                    case OrderVO.STATUS_DELIVED:
                        statusCell.Value = "已发货";
                        break;
                    case OrderVO.STATUS_FINISH:
                        statusCell.Value = "已完成";
                        break;
                    case OrderVO.STATUS_PAYED:
                        statusCell.Value = "已付款";
                        break;
                    case OrderVO.STATUS_UN_PAY:
                        statusCell.Value = "等待付款";
                        break;
                }

                row.Cells.Add(statusCell);

                DataGridViewButtonCell payCell = new DataGridViewButtonCell();
                payCell.Value = "支付";
                row.Cells.Add(payCell);

                DataGridViewButtonCell operationCell = new DataGridViewButtonCell();
                operationCell.Value = "详情";
                row.Cells.Add(operationCell);

                DataGridViewButtonCell printCell = new DataGridViewButtonCell();
                printCell.Value = "打印";
                row.Cells.Add(printCell);

                this.itemDGV.Rows.Add(row);
            }

            //刷新页码
            this.pageNoL.Text = S.EMPTY + this.pageNo;
        }

        /// <summary>
        /// 显示支付窗口
        /// </summary>
        private void uiShowPayForm()
        {
            OrderInfoForm orderInfoForm = new OrderInfoForm();
            orderInfoForm.setOrder(this.vo);
            orderInfoForm.ShowDialog();
        }

        /// <summary>
        /// 显示打印小票窗口
        /// </summary>
        private void uiShowPrintForm()
        {
            OrderReceiptForm1 receiptForm = new OrderReceiptForm1();
            receiptForm.setOrder(this.vo);
            receiptForm.ShowDialog();
        }

        private void uiShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void uiHideHP()
        {
            this.hp.Visible = false;
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 5;
            int titleH = this.titleP.ClientRectangle.Height;
            int footerH = this.footerP.ClientRectangle.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            //this.itemDGV.Location = new Point(spacing, titleH);
            //this.itemDGV.Size = new Size(w - spacing * 2, h - spacing * 2 - titleH - footerH);

            //this.footerP.Location = new Point(w - this.footerP.ClientRectangle.Width, h - footerH);


            this.footerP.Location = new Point(w - this.footerP.ClientRectangle.Width - 50, 5);
            this.itemDGV.Location = new Point(spacing * 2, titleH);
            this.itemDGV.Size = new Size(w - spacing * 2, h - spacing * 2 - titleH);

            this.hp.Location = new Point(spacing, spacing);
            this.hp.Size = new Size(w, h);
        }

        private void uiInitView()
        {
            this.titleP.setTitle("我的订单");

            this.hp.Visible = false;
        }

        private void PickUpOrderListPanel_Load(object sender, EventArgs e)
        {
            this.hp.BringToFront();

            this.itemDGV.Font = new Font("SimSun", Program.DGV_FONT_SIZE);

            this.uiResize();
        }

        private void PickUpOrderListPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void itemDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (null == this.orderList || this.orderList.Count < 1 || e.RowIndex < 0 || this.orderList.Count <= e.RowIndex)
                return;

            this.vo = this.orderList[e.RowIndex];

            if (e.ColumnIndex == 5)
            {
                if (this.vo.Status == OrderVO.STATUS_UN_PAY)
                {
                    this.loadOrder(1, this.vo.Id);
                }
            }
            else if (e.ColumnIndex == 6)
            {
                this.mainFormCallback(MainForm.PT_PICK_UP_ORDER_DETAILS);
            }
            else if (e.ColumnIndex == 7)
            {
                this.loadOrder(2, this.vo.Id);
            }
        }

        private void itemDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || null == this.orderList || this.orderList.Count <= e.RowIndex)
                return;

            OrderVO orderVO = this.orderList[e.RowIndex];
            if (orderVO.Status != OrderVO.STATUS_UN_PAY)
            {
                itemDGV.Rows[e.RowIndex].Cells[5] = new DataGridViewTextBoxCell();
                itemDGV.Rows[e.RowIndex].Cells[5].Value = "";
            }
        }

        private void itemDGV_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void prePageB_Click(object sender, EventArgs e)
        {
            if(this.pageNo > 1)
            {
                this.pageNo--;
                this.loadData();
            }
        }

        private void nextPageB_Click(object sender, EventArgs e)
        {
            this.pageNo++;
            this.loadData();
        }
    }
}
