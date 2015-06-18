using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using x.util;
using funsens.api;
using funsens.common;
using funsens.order.vo;
using funsens.servicedesk.vo;

namespace funsens.ui
{
    public partial class SorterForm : Form
    {
        private delegate void _Delegate();

        private delegate void _Delegate1(int rc);

        private delegate void ShowMessageDelegate(string message);

        private List<ServiceDeskVO> serviceDeskList;

        private ServiceDeskVO serviceDeskVO;

        private OrderVO orderVO;

        public SorterForm()
        {
            InitializeComponent();
        }

        private void addOrder()
        {
            string orderId = this.orderIdTB.Text;
            if(S.blank(orderId))
            {
                MessageBox.Show("请输入订单号");
                return;
            }

            this.hp.Visible = true;

            GetOrderHandler handler = new GetOrderHandler(this.handleFinish, orderId);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(this.uiHideHP);

            if (rc != Handler.RC_SUCCESS)
            {
                this.Invoke(_delegate);
                MessageBox.Show("网络异常，请稍后再试。12");
                return;
            }

            if (type == API.T_SERVICE_DESKS)
            {
                this.serviceDeskList = (List<ServiceDeskVO>)content;
                CommonData.getInstance().setServiceDeskList(this.serviceDeskList);

                this.Invoke(_delegate);

                _delegate = new _Delegate(this.uiRefreshServiceDeskCB);
                this.Invoke(_delegate);

                _delegate = new _Delegate(this.uiShowSelectDeskP);
                this.Invoke(_delegate);
            }
            else if (type == API.T_MODIFY_ORDER_STATUS)
            {
                this.Invoke(_delegate);

                int result = (new JO(content.ToString())).getInt("result");

                _Delegate1 _delegate1 = new _Delegate1(this.modifyOrderStatusResult);
                this.Invoke(_delegate1, new object[] { result });
            }
            else if (type == API.T_ORDER)
            {
                JO jo = (JO)content;
                int result = jo.getInt("result");
                if (result == Handler.RC_SUCCESS)
                {
                    this.orderVO = new OrderVO();
                    this.orderVO.loadFullJO(jo);

                    ModifyOrderStatusHandler handler = new ModifyOrderStatusHandler(this.handleFinish, this.orderVO.Id, 3);
                    handler.handle();
                }
                else
                {
                    this.Invoke(_delegate);

                    ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.showMessage);
                    this.Invoke(showMessageDelegate, new object[] { "订单不存在" });
                }
            }
        }

        private void modifyOrderStatusResult(int rc)
        {
            switch (rc)
            {
                case -3:
                    MessageBox.Show("您尚未登录");
                    break;
                case -2:
                    MessageBox.Show("订单状态错误");
                    break;
                case -1:
                    MessageBox.Show("参数有误");
                    break;
                case 0:
                    MessageBox.Show("操作失败");
                    break;
                case 1:
                    this.uiOrderDGVAddItem();
                    break;
            }
        }

        private void loadData()
        {
            this.hp.Visible = true;

            GetServiceDesksHandler handler = new GetServiceDesksHandler(this.handleFinish);
            handler.handle();
        }

        private void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void uiOrderDGVAddItem()
        {
            if (null == this.orderVO)
                return;

            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell orderIdCell = new DataGridViewTextBoxCell();
            orderIdCell.Value = this.orderVO.Id;
            row.Cells.Add(orderIdCell);

            DataGridViewTextBoxCell customerNameCell = new DataGridViewTextBoxCell();
            customerNameCell.Value = this.orderVO.CustomerName;
            row.Cells.Add(customerNameCell);

            DataGridViewTextBoxCell totalCell = new DataGridViewTextBoxCell();
            totalCell.Value = this.orderVO.Total.ToString();
            row.Cells.Add(totalCell);

            DataGridViewTextBoxCell createdCell = new DataGridViewTextBoxCell();
            createdCell.Value = this.orderVO.Created.ToString();
            row.Cells.Add(createdCell);

            this.orderDGV.Rows.Add(row);
        }

        private void uiRefreshServiceDeskCB()
        {
            this.serviceDeskCB.Items.Clear();

            int count = this.serviceDeskList.Count;
            for (int i = 0; i < count; i++)
            {
                ServiceDeskVO vo = this.serviceDeskList[i];
                this.serviceDeskCB.Items.Add(vo.Name);
            }
        }

        private void uiShowSelectDeskP()
        {
            this.selectDeskP.Visible = true;

            if (this.serviceDeskCB.Items.Count > 0)
                this.serviceDeskCB.SelectedIndex = 0;
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
            int w2 = w - spacing * 2;
            int generalGBH = this.generalGB.ClientRectangle.Height;
            
            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);

            this.selectDeskP.Location = new Point(0, 0);
            this.selectDeskP.Size = new Size(w, h);

            this.selectDeskGB.Location = new Point((w - this.selectDeskGB.ClientRectangle.Width) / 2, (h - this.selectDeskGB.ClientRectangle.Height) / 2);

            this.generalGB.Location = new Point(spacing, spacing);
            this.generalGB.Size = new Size(w2, generalGBH);

            this.orderDGV.Location = new Point(spacing, spacing * 2 + generalGBH);
            this.orderDGV.Size = new Size(w2, h - spacing * 3 - generalGBH);
        }

        private void uiInit()
        {
            this.hp.Visible = false;
            this.selectDeskP.Visible = false;
            this.generalGB.Visible = false;
            this.orderDGV.Visible = false;
        }

        private void ServiceDesk_Load(object sender, EventArgs e)
        {
            this.uiInit();
            this.uiResize();

            this.loadData();
        }

        private void ServiceDesk_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void selectB_Click(object sender, EventArgs e)
        {
            if(this.serviceDeskCB.SelectedIndex < 0)
            {
                MessageBox.Show("请选择服务台");
                return;
            }

            this.serviceDeskVO = this.serviceDeskList[this.serviceDeskCB.SelectedIndex];

            this.selectDeskP.Visible = false;
            this.generalGB.Visible = true;
            this.orderDGV.Visible = true;
        }

        private void orderIdTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.addOrder();
        }

        private void packageB_Click(object sender, EventArgs e)
        {
            this.addOrder();
        }
    }
}
