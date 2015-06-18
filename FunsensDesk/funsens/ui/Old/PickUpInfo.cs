using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funsens.api;
using funsens.common;
using funsens.order.vo;
using funsens.servicedesk.vo;

namespace funsens.ui
{
    public partial class PickUpInfo : Form
    {
        //超过该时间的即列为旧订单
        private const int TIMEOUT = 1000 * 60 * 5;

        private delegate void _Delegate();

        private List<OrderVO> newOrderList;

        private List<OrderVO> oldOrderList;

        public PickUpInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载订单列表
        /// </summary>
        private void loadData()
        {
            GetPackagedOrdersHandler handler = new GetPackagedOrdersHandler(this.handleFinish);
            handler.handle();
        }

        private void loadCommonData()
        {
            this.hp.Visible = true;

            GetServiceDesksHandler handler = new GetServiceDesksHandler(this.handleFinish);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            if (type == API.T_PACKAGED_ORDERS)
            {
                List<OrderVO> orderList = (List<OrderVO>)content;
                int count = orderList.Count;
                this.oldOrderList = new List<OrderVO>();
                this.newOrderList = new List<OrderVO>();
                for (int i = 0; i < count; i++)
                {
                    OrderVO vo = orderList[i];
                    if(vo.IsAllReady)
                    {
                        TimeSpan ts = DateTime.Now - vo.Created;
                        if (ts.Seconds > TIMEOUT)
                            this.oldOrderList.Add(vo);
                        else
                            this.newOrderList.Add(vo);
                    }
                }

                _Delegate _delegate = new _Delegate(this.uiRefreshOrderDGV);
                this.Invoke(_delegate);
            }
            else if (type == API.T_SERVICE_DESKS)
            {
                List<ServiceDeskVO> voList = (List<ServiceDeskVO>)content;
                CommonData.getInstance().setServiceDeskList(voList);

                _Delegate _delegate = new _Delegate(this.uiHideHP);
                this.Invoke(_delegate);

                //启动定时加载订单列表的定时器
                this.t.Start();
            }
        }

        private void uiRefreshOrderDGV()
        {
            this.orderDGV1.setData(this.newOrderList);
            this.orderDGV2.setData(this.oldOrderList);
        }

        private void uiHideHP()
        {
            this.hp.Visible = false;
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 10;
            int w2 = (w - spacing * 4) / 2;
            int h2 = h - spacing * 2;

            this.orderDGV1.Location = new Point(spacing, spacing);
            this.orderDGV1.Size = new Size(w2, h2);

            this.orderDGV2.Location = new Point(w2 + spacing * 3, spacing);
            this.orderDGV2.Size = new Size(w2, h2);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        private void PickUpInfo_Load(object sender, EventArgs e)
        {
            this.uiResize();

            this.loadCommonData();
        }

        private void PickUpInfo_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //使用定时器2分钟获取一次最新的订单列表
            this.loadData();
        }
    }
}
