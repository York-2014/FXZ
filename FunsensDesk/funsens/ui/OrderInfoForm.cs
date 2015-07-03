using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using funsens.api;
using funsens.mis;
using funsens.order.vo;
using funsens.util;

namespace funsens.ui
{
    /// <summary>
    /// 订单信息
    /// 在下单成功后的支付界面，每个订单都会弹出一个界面，通过POS机扫界面上的条形码（由订单号生成）来进行支付
    /// </summary>
    public partial class OrderInfoForm : Form
    {
        private delegate void _Delegate();

        private delegate void ShowMessageDelegate(string message);

        //private ThreadStart threadStart;

        //private Thread thread;

        private OrderVO orderVO;

        public OrderInfoForm()
        {
            InitializeComponent();
        }

        public void setOrder(OrderVO vo)
        {
            this.orderVO = vo;
            this.uiRefresh();

            /*if (null == thread)
            {
                //启动自动刷新列表线程
                this.threadStart = new ThreadStart(this.loadOrderTask);
                this.thread = new Thread(this.threadStart);
                this.thread.Start();
            }*/
        }

        /// <summary>
        /// 加载订单列表任务（循环刷新订单列表）
        /// </summary>
        /*private void loadOrderTask()
        {
            _Delegate loadDelegate = new _Delegate(this.loadOrder);

            while (true)
            {
                try
                {
                    this.Invoke(loadDelegate);
                }
                catch (Exception e)
                {

                }

                try
                {
                    Thread.Sleep(10000);
                }
                catch (Exception e)
                {
                }
            }
        }*/

        /// <summary>
        /// 加载订单信息
        /// </summary>
        private void loadOrder()
        {
            List<string> orderIdList = new List<string>();
            orderIdList.Add(this.orderVO.Id);

            GetOrdersHandler handler = new GetOrdersHandler(this.handleFinish, -1, OrderVO.STATUS_NONE, orderIdList, 999999, 1);
            handler.handle();
        }

        /// <summary>
        /// 回调：接口处理完成
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rc"></param>
        /// <param name="error"></param>
        /// <param name="content"></param>
        private void handleFinish(int type, int rc, string error, object content)
        {
            ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.uiShowMessage);
            _Delegate refreshDelegate = new _Delegate(this.uiRefresh);

            JO jo = null;

            if (null == content)
            {
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回空内容" });
                return;
            }
            else if ("0".Equals(content.ToString()))
            {
                return;
            }
            else if ((jo = new JO(content.ToString())).isNull())
            {
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回值为:\n" + content.ToString() });
                return;
            }

            if (type == API.T_ORDERS)
            {
                if (rc == Handler.RC_SUCCESS)
                {
                    JA orderJA = jo.getJA("orderList");
                    int count = orderJA.size();
                    if (count > 0)
                    {
                        this.orderVO = new OrderVO(orderJA.getJO(0));
                        this.Invoke(refreshDelegate);
                    }
                    else
                    {
                        this.Invoke(showMessageDelegate, new object[] { "加载订单信息失败，服务器返回：" + content.ToString() });
                    }
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "网络异常，请稍后再试" });
                }
            }
        }

        private void uiRefresh()
        {
            this.idL.Text = this.orderVO.Id;

            this.customerNameL.Text = this.orderVO.CustomerName;

            double total = this.orderVO.Payment;
            if (this.orderVO.PaiedTax > 0)
            {
                total += this.orderVO.TaxTotal;
            }
            else
            {
                double tmp = this.orderVO.UnPayTax + this.orderVO.OrdersTax;
                if (tmp > 50)
                    total += this.orderVO.TaxTotal;
            }

            this.itemTotalL.Text = "￥" + Math.Round(total,2);

            this.unPayL.Text = "￥" + this.orderVO.UnPayTax;

            switch (this.orderVO.Status)
            {
                case OrderVO.STATUS_CANCELED:
                    this.statusL.Text = "已取消";
                    break;
                case OrderVO.STATUS_DELETED:
                    this.statusL.Text = "已删除";
                    break;
                case OrderVO.STATUS_UN_PAY:
                    this.statusL.Text = "等待付款";
                    break;
                case OrderVO.STATUS_PAYED:
                    this.statusL.Text = "已付款";
                    break;
                case OrderVO.STATUS_DELIVED:
                    this.statusL.Text = "已发货";
                    break;
                case OrderVO.STATUS_FINISH:
                    this.statusL.Text = "已完成";
                    break;
                default:
                    this.statusL.Text = "未知状态：" + this.orderVO.Status;
                    break;
            }

            this.barcodePB.Image = null;

            BarcodeUtil bcu = new BarcodeUtil();
            Image image = bcu.getBarcodeImage(470, 300, this.orderVO.Id);
            this.barcodePB.Image = image;
        }

        private void uiShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void OrderInfoForm_Load(object sender, EventArgs e)
        {
        }

        private void payB_Click(object sender, EventArgs e)
        {
            string userId = this.userIdTB.Text;
            if(null == userId || "".Equals(userId))
            {
                MessageBox.Show("请填写POS操作员号");
                userIdTB.Focus();
                return;
            }

            Mis mis = new Mis(this.comPort);
            bool result = mis.orderPay(Math.Round(this.orderVO.Payment,2), this.orderVO.Created, userId, this.orderVO.Id);

            if (!result)
                MessageBox.Show("调用失败");

            else this.Close();
        }

        private void comPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int byteCount = this.comPort.BytesToRead;
            if (byteCount == 170)
            {
                byte[] buffer = new byte[byteCount];
                int readResult = this.comPort.Read(buffer, 0, byteCount);
                if (readResult > 0)
                {
                    MisResult result = new MisResult(buffer);
                    if (!result.isSuccess())
                        MessageBox.Show(result.Message);
                }
            }
        }
    }
}
