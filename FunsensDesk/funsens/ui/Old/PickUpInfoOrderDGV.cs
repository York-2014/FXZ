using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funsens.order.vo;

namespace funsens.ui
{
    public partial class PickUpInfoOrderDGV : UserControl
    {
        //每屏显示的订单数量
        private const int ROW_COUNT = 20;

        private int rowH;

        private List<OrderVO> orderList;

        //当前显示的页码
        private int pageNo;

        public PickUpInfoOrderDGV()
        {
            InitializeComponent();
        }

        public void setData(List<OrderVO> orderList)
        {
            this.orderList = orderList;
            this.pageNo = 0;
        }

        private void timerTask()
        {
            if (null == this.orderList)
                return;

            int count = this.orderList.Count;
            int pageCount = 0;
            if (count % ROW_COUNT == 0)
                pageCount = count / ROW_COUNT;
            else
                pageCount = count / ROW_COUNT + 1;

            this.pageNo++;
            if (this.pageNo >= pageCount)
                this.pageNo = 0;

            this.uiReloadDGV();
        }

        private void uiReloadDGV()
        {
            this.orderDGV.Rows.Clear();

            int start = ROW_COUNT * this.pageNo;
            int end = ROW_COUNT * (this.pageNo + 1);
            int count = orderList.Count;
            if (end > count)
                end = count;

            for (int i = start; i < end; i++)
            {
                OrderVO vo = orderList[i];

                DataGridViewRow row = new DataGridViewRow();
                row.Height = this.rowH;

                DataGridViewTextBoxCell customerNameCell = new DataGridViewTextBoxCell();
                customerNameCell.Value = vo.CustomerName;
                row.Cells.Add(customerNameCell);

                DataGridViewTextBoxCell serviceDeskNameCell = new DataGridViewTextBoxCell();
                serviceDeskNameCell.Value = vo.ServiceDeskName;
                row.Cells.Add(serviceDeskNameCell);

                this.orderDGV.Rows.Add(row);
            }
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;

            this.orderDGV.Location = new Point(0, 0);
            this.orderDGV.Size = new Size(w, h);

            int contentH = h - this.orderDGV.ColumnHeadersHeight;
            this.rowH = contentH / ROW_COUNT;
        }

        private void PickUpInfoOrderDGV_Load(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void PickUpInfoOrderDGV_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //使用定时器10秒进行一次翻页
            this.timerTask();
        }
    }
}
