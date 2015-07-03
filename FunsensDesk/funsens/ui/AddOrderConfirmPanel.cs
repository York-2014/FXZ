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
using x.util;
using funsens.api;
using funsens.common;
using funsens.common.vo;
using funsens.customer.vo;
using funsens.item.vo;
using funsens.order.vo;

namespace funsens.ui
{
    /// <summary>
    /// 下单第二步：确认订单
    /// 后台会根据第一步选择的商品进行分单，该界面显示分单后的各订单信息
    /// </summary>
    public partial class AddOrderConfirmPanel : UserControl
    {
        private delegate void _Delegate();

        private delegate void RefreshDGVDelegate();

        private delegate void ShowMessageDelegate(string message);

        private delegate void ReloadOrderDelegate();

        public MainForm.MainFormCallback mainFormCallback;

        private List<ItemVO> itemList;

        private List<OrderVO> orderList;

        private List<OrderConfirmItem> itemViewList;

        private int selectAddressIndex;

        //历史已交的税费
        private double historyPayedTotalTax;

        //历史未交的税费
        private double historyTaxTotal;

        //本次实际要交的税费
        private double taxTotal;

        public AddOrderConfirmPanel()
        {
            InitializeComponent();
        }

        public void setAddress(AddressVO addressVO)
            
        {
            
            this.itemViewList[this.selectAddressIndex].setAddress(addressVO);
        }

        public void setItemList(List<ItemVO> itemList)
        {
            this.itemList = itemList;

            this.countDetails();
        }

        public void resetAmount(string itemId, int itemAmount)
        {
            int count = this.itemList.Count;
            for(int i=0;i<count;i++)
            {
                ItemVO itemVO = this.itemList[i];
                if(itemVO.Id.Equals(itemId))
                {
                    itemVO.Amount += itemAmount;

                    if (itemVO.Amount < 1)

                        this.itemList.RemoveAt(i);
                        //itemVO.Amount = 0;
                  

                    break;
                }
            }

            this.countDetails();
        }

        public void refreshTotal()
        {
            this.uiRefreshTotal();
        }

        private void countDetails()
        {
            //提交商品列表到后台进行计算
            this.hp.Visible = true;
            CountOrderDetailsHandler handler = new CountOrderDetailsHandler(this.handleFinish, this.itemList);
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
            _Delegate _delegate = new _Delegate(this.uiHideHP);
            this.Invoke(_delegate);

            ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.uiShowMessage);
            ReloadOrderDelegate reloadOrderDelegate = new ReloadOrderDelegate(this.uiReloadOrderList);

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
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回值为:\n" + content.ToString() });
                return;
            }

            if (type == API.T_COUNT_ORDER_DETAILS)
            {
                JA orderJA = jo.getJA("cart");
                this.historyTaxTotal = jo.getdouble("historytax");
                this.historyPayedTotalTax = jo.getdouble("historyPayedTax");
                int count = orderJA.size();
                if (count > 0)
                {
                    this.orderList = new List<OrderVO>();
                    for (int i = 0; i < count; i++)
                    {
                        JO orderJO = orderJA.getJO(i);

                        OrderVO orderVO = new OrderVO();
                        orderVO.loadOrder(orderJO);
                        this.orderList.Add(orderVO);
                    }

                    this.Invoke(reloadOrderDelegate);
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "订单不能空，或者请重新下单！" });
                }
            }
            else if (type == API.T_ADD_ORDER)
            {
                if (rc == Handler.RC_SUCCESS)
                {
                    int result = jo.getInt("result");
                    bool isSuccess = false;
                    switch (result)
                    {
                        case 0:
                            this.Invoke(showMessageDelegate, new object[] { "您尚未登录" });
                            break;
                        case 1:
                            this.Invoke(showMessageDelegate, new object[] { "参数有误" });
                            break;
                        case 2:
                            JA outOfStockJA = jo.getJA("out_of_stock_list");
                            if (null == outOfStockJA)
                            {
                                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回值为:\n" + content.ToString() });
                                return;
                            }

                            int count = outOfStockJA.size();
                            StringBuilder sb = new StringBuilder();
                            sb.Append("商品");
                            for (int i = 0; i < count; i++)
                            {
                                if (i != 0)
                                    sb.Append(",");

                                JO _t = outOfStockJA.getJO(i);
                                sb.Append(_t.getString("name"));
                            }

                            sb.Append("缺货");

                            this.Invoke(showMessageDelegate, new object[] { sb.ToString() });
                            break;
                        case 3:
                            this.Invoke(showMessageDelegate, new object[] { "下单成功" });
                            isSuccess = true;
                            break;
                        default:
                            this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回内容：\n" + content.ToString() });
                            break;
                    }

                    if (isSuccess)
                    {
                        JA orderJA = jo.getJA("order_id");
                        int count = orderJA.size();
                        if (count > 0)
                        {
                            List<string> orderIdList = new List<string>();
                            for (int i = 0; i < count; i++)
                            {
                                string orderId = orderJA.getString(i);
                                orderIdList.Add(orderId);
                            }

                            Session.getInstance().OrderIdList = orderIdList;

                            this.mainFormCallback(MainForm.PT_ADD_ORDER_PAY);
                        }
                        else
                        {
                            this.Invoke(showMessageDelegate, new object[] { "服务器异常，订单数返回0，请重新下单！" });
                        }
                    }
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "网络异常，请稍后再试" });
                }
            }
        }

        private void save()
        {
            if (null == this.itemViewList || this.itemViewList.Count < 1)
            {
                MessageBox.Show("请选择商品");
                return;
            }

            int count = this.itemViewList.Count;
            JA ja = new JA();
            for(int i=0;i<count;i++)
            {
                JO jo = this.itemViewList[i].getInfo();
                if (null == jo)
                    return;

                ja.put(jo);
            }

            AddOrderHandler handler = new AddOrderHandler(this.handleFinish, ja);
            handler.handle();
        }

        private void uiReloadOrderList()
        {
            this.itemViewList = new List<OrderConfirmItem>();
            this.orderP.Controls.Clear();
            int y = 0;
            int count = this.orderList.Count;
            int w = this.orderP.ClientRectangle.Width;

            //计算总税费
            this.taxTotal = 0.00;
            for (int i = 0; i < count; i++)
            {
                OrderVO orderVO = this.orderList[i];
                this.taxTotal += orderVO.TaxTotal;
            }

            if(this.historyPayedTotalTax <= 0)
            {
                if ((this.taxTotal + this.historyTaxTotal) <= 50)
                    this.taxTotal = 0;
            }

            //刷新视图列表
            for (int i = 0; i < count; i++)
            {
                OrderVO orderVO = this.orderList[i];

                OrderConfirmItem item = new OrderConfirmItem(this);
                item.Location = new Point(0, y);
                item.Size = new Size(w, 0);
                item.setOrder(this.taxTotal, orderVO);
                y += item.ClientRectangle.Height + 1;
                item.mainFormCallback = this.mainFormCallback;
                this.orderP.Controls.Add(item);

                this.itemViewList.Add(item);
            }

            this.uiRefreshTotal();
        }

        private void uiRefreshTotal()
        {
            double itemTotal = 0.00;
            double freightTotal = 0.00;
            double total = 0.00;

            int count = this.itemViewList.Count;
            for (int i = 0; i < count; i++)
            {
                OrderConfirmItem item = this.itemViewList[i];
                OrderVO orderVO = this.orderList[i];

                itemTotal += Math.Round(item.ItemTotal,2);
                freightTotal += item.FreightTotal;
            }

            total = itemTotal + freightTotal + this.taxTotal;
            this.itemTotalL.Text = "￥" + itemTotal;
            this.freightTotalL.Text = "￥" + freightTotal;

            this.paiedTaxL.Text = "￥" + this.historyPayedTotalTax;
            this.unPayTaxL.Text = "￥" + this.historyTaxTotal;

            this.taxTotalL.Text = "￥" + this.taxTotal;
            if (this.taxTotal <= 0)
                this.taxTotalL.Font = new Font("SimSun", 14, FontStyle.Strikeout);
            else
                this.taxTotalL.Font = new Font("SimSun", 14);

            this.totalL.Text = "￥" + Math.Round(total,2);
        }

        private void uiShowHP()
        {
            this.hp.Visible = true;
        }

        private void uiHideHP()
        {
            this.hp.Visible = false;
        }

        private void uiShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int titleH = this.titleP.ClientRectangle.Height;
            int footerH = this.footerP.ClientRectangle.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            this.orderP.Location = new Point(0, titleH);
            this.orderP.Size = new Size(w, h - titleH - footerH);

            if (null != this.itemViewList)
            {
                int count = this.itemViewList.Count;
                for (int i = 0; i < count; i++)
                    this.itemViewList[i].uiResetWidth(w);
            }

            this.footerP.Location = new Point(w - this.footerP.ClientRectangle.Width, h - footerH);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        /// <summary>
        /// 初始化视图
        /// </summary>
        private void uiInit()
        {
            this.titleP.setTitle("订单确认");

            this.hp.Visible = false;

            this.uiResize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.uiInit();
        }

        private void OrderConfirmPanel_Load(object sender, EventArgs e)
        {
            this.init();
        }

        private void OrderConfirmPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void payB_Click(object sender, EventArgs e)
        {
            this.save();
        }

       
    }
}
