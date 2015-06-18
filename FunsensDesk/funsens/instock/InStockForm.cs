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
using funsens.api;
using funsens.order.vo;
using funsens.stock.vo;

namespace instock
{
    public partial class InStockForm : Form
    {
        private delegate void _Delegate();

        private delegate void _ShowMessageDelegate(string message);

        private List<ShelfVO> shelfList;

        private ShelfVO shelfVO;

        private OrderVO orderVO;

        public InStockForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 入库成功的后续操作
        /// </summary>
        private void inStockSuccess()
        {
            //添加信息到订单列表
            this.uiOrderDGVAddRow();

            //清空当前所选的货架和订单信息
            this.orderVO = null;
            this.shelfVO = null;

            this.orderIdTB.Text = "";
            this.customerNameL.Text = "-";
            this.shelfIdTB.Text = "";

            //重新加载货架列表
            this.loadShelfList();
        }

        /// <summary>
        /// 入库
        /// </summary>
        private void inStock()
        {
            if (null == this.orderVO)
            {
                this.loadOrder();
                return;
            }

            if (null == this.shelfVO)
            {
                MessageBox.Show("请选择货架");
                return;
            }

            if (this.shelfVO.Status != 0)
            {
                MessageBox.Show("货架已被使用，请选择其它货架");
                return;
            }

            //入库，绑定货架和订单
            BindShelfOrderHandler handler = new BindShelfOrderHandler(this.handleFinish, this.orderVO.Id, this.shelfVO.Id);
            handler.handle();
        }

        /// <summary>
        /// 重置货架
        /// </summary>
        /// <param name="shelfId"></param>
        private void resetShelf(string shelfId)
        {
            ResetShelfHandler handler = new ResetShelfHandler(this.handleFinish, shelfId);
            handler.handle();
        }

        /// <summary>
        /// 加载订单信息完成
        /// </summary>
        private void loadOrderSuccess()
        {
            if (null != this.orderVO)
            {
                this.customerNameL.Text = this.orderVO.CustomerName;

                if(null != this.shelfVO)
                {
                    //入库，绑定货架和订单
                    BindShelfOrderHandler handler = new BindShelfOrderHandler(this.handleFinish, this.orderVO.Id, this.shelfVO.Id);
                    handler.handle();
                }
            }
        }

        /// <summary>
        /// 加载订单信息
        /// </summary>
        private void loadOrder()
        {
            string orderId = this.orderIdTB.Text;
            if (null == orderId || "".Equals(orderId))
            {
                MessageBox.Show("请输入订单号");
                return;
            }

            GetOrderHandler handler = new GetOrderHandler(this.handleFinish, orderId);
            handler.handle();
        }

        /// <summary>
        /// 加载货架列表
        /// 加载所有空闲的货架列表
        /// </summary>
        private void loadShelfList()
        {
            GetShelfsHandler handler = new GetShelfsHandler(this.handleFinish, "all");
            handler.handle();
        }

        /// <summary>
        /// API接口处理完成回调
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rc"></param>
        /// <param name="error"></param>
        /// <param name="content"></param>
        private void handleFinish(int type, int rc, string error, object content)
        {
            if (type == API.T_RESET_SHELF)
            {
                JO jo = (JO)content;
                int result = jo.getInt("result");
                if (result == 1)
                {
                    this.loadShelfList();
                }
                else
                {
                    _ShowMessageDelegate _delegate = new _ShowMessageDelegate(this.uiShowMessage);
                    this.Invoke(_delegate, new object[] { "重置失败" });
                }
            }
            else if (type == API.T_IN_STOCK)
            {
                JO jo = (JO)content;
                int result = jo.getInt("result");
                string message = null;
                switch (result)
                {
                    case 0:
                        message = "订单已取消";
                        break;
                    case -1:
                        message = "订单已删除";
                        break;
                    case -2:
                        message = "订单不存在";
                        break;
                    case -3:
                        message = "货架不存在";
                        break;
                    case -4:
                        message = "货架已被使用";
                        break;
                    case -5:
                        string shelfName = jo.getString("shelf_name");
                        message = "订单已被存放于货架[" + shelfName + "]，请先重置货架[" + shelfName + "]";
                        break;
                }

                if (null == message)
                {
                    //绑定成功后添加信息到订单列表
                    this.orderVO.ServiceDeskId = this.shelfVO.ServiceDeskId;
                    this.orderVO.ServiceDeskName = this.shelfVO.ServiceDeskName;

                    _Delegate _delegate = new _Delegate(this.inStockSuccess);
                    this.Invoke(_delegate);
                }
                else
                {
                    _ShowMessageDelegate _delegate = new _ShowMessageDelegate(this.uiShowMessage);
                    this.Invoke(_delegate, new object[] { message });
                }
            }
            else if (type == API.T_SHELFS)
            {
                if (rc == 1)
                {
                    this.shelfList = (List<ShelfVO>)content;

                    _Delegate _delegate = new _Delegate(this.uiReloadShelfDGV);
                    this.Invoke(_delegate);
                }
                else
                {
                    _ShowMessageDelegate _delegate = new _ShowMessageDelegate(this.uiShowMessage);
                    this.Invoke(_delegate, new object[] { "加载货架列表失败" });
                }
            }
            else if (type == API.T_ORDER)
            {
                if (rc == 1)
                {
                    this.orderVO = (OrderVO)content;

                        _Delegate _delegate = new _Delegate(this.loadOrderSuccess);
                        this.Invoke(_delegate);
                }
                else
                {
                    _ShowMessageDelegate _delegate = new _ShowMessageDelegate(this.uiShowMessage);
                    this.Invoke(_delegate, new object[] { "查找不到订单" });
                }
            }
        }

        /// <summary>
        /// 订单列表添加一行
        /// </summary>
        /// <param name="vo"></param>
        private void uiOrderDGVAddRow()
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
            idCell.Value = this.orderVO.Id;
            row.Cells.Add(idCell);

            DataGridViewTextBoxCell customerNameCell = new DataGridViewTextBoxCell();
            customerNameCell.Value = this.orderVO.CustomerName;
            row.Cells.Add(customerNameCell);

            DataGridViewTextBoxCell serviceDeskNameCell = new DataGridViewTextBoxCell();
            serviceDeskNameCell.Value = this.orderVO.ServiceDeskName;
            row.Cells.Add(serviceDeskNameCell);

            this.orderDGV.Rows.Add(row);
        }

        /// <summary>
        /// 重新加载货架列表控件的数据
        /// </summary>
        private void uiReloadShelfDGV()
        {
            this.shelfDGV.Rows.Clear();

            int count = this.shelfList.Count;
            for (int i = 0; i < count; i++)
            {
                ShelfVO vo = this.shelfList[i];

                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = vo.Name;
                row.Cells.Add(nameCell);

                DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();

                if (vo.Status == 1)
                    statusCell.Value = "已使用";
                else
                    statusCell.Value = "空闲";

                row.Cells.Add(statusCell);

                if (vo.Status == 1)
                {
                    DataGridViewButtonCell operationCell = new DataGridViewButtonCell();
                    operationCell.Value = "重置";
                    row.Cells.Add(operationCell);
                }
                else
                {
                    DataGridViewButtonCell operationCell = new DataGridViewButtonCell();
                    row.Cells.Add(operationCell);
                }

                this.shelfDGV.Rows.Add(row);
            }

            this.shelfDGV.ClearSelection();
        }

        private void uiShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 10;
            int w1 = w - spacing * 2;
            int w2 = (int)((w1 - spacing) * 0.35);
            int w3 = w1 - w2 - spacing;
            int generalGBH = this.generalGB.Height;
            int y2 = spacing * 2 + generalGBH;
            int h2 = h - spacing * 3 - generalGBH;

            int spacingL = 10;
            int spacingR = 10;
            int spacingT = 25;
            int spacingB = 10;
            int dgvH = h2 - spacingT - spacingB;

            this.generalGB.Location = new Point(spacing, spacing);
            this.generalGB.Size = new Size(w1, generalGBH);

            this.shelfGB.Location = new Point(spacing, y2);
            this.shelfGB.Size = new Size(w2, h2);

            this.shelfDGV.Location = new Point(spacingL, spacingT);
            this.shelfDGV.Size = new Size(w2 - spacingL - spacingR, dgvH);

            this.orderGB.Location = new Point(spacing * 2 + w2, y2);
            this.orderGB.Size = new Size(w3, h2);

            this.orderDGV.Location = new Point(spacingL, spacingT);
            this.orderDGV.Size = new Size(w3 - spacingL - spacingR, dgvH);
        }

        private void init()
        {
            this.uiResize();

            this.loadShelfList();
        }

        private void InStockForm_Load(object sender, EventArgs e)
        {
            this.init();
        }

        private void InStockForm_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void inStockB_Click(object sender, EventArgs e)
        {
            this.inStock();
        }

        private void shelfDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                this.shelfVO = this.shelfList[e.RowIndex];
                this.shelfIdTB.Text = this.shelfVO.Name;
            }
            else if (e.ColumnIndex == 2)
            {
                ShelfVO vo = this.shelfList[e.RowIndex];
                if (vo.Status == 1)
                    this.resetShelf(vo.Id);
            }
        }

        private void orderIdTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.inStock();
        }
    }
}
