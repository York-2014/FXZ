using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funsens.order.vo;

namespace funsens.ui
{
    public partial class OrderReceiptForm : Form
    {
        public OrderReceiptForm()
        {
            InitializeComponent();

            /*OrderVO orderVO = new OrderVO();
            orderVO.FranchiseeName = "山姆店";
            orderVO.TaxTotal = 201.8f;
            orderVO.EmsFreight = 3;
            orderVO.ExpressFreight = 2.5f;
            orderVO.MailFreight = 0.3f;
            orderVO.Payment = 319.5f;
            orderVO.Total = 320.0f;
            orderVO.Created = DateTime.Now;

            OrderDetailsVO detailsVO1 = new OrderDetailsVO();
            detailsVO1.ItemName = "商品1";
            detailsVO1.Total = 23.8f;

            OrderDetailsVO detailsVO2 = new OrderDetailsVO();
            detailsVO2.ItemName = "商品2";
            detailsVO2.Total = 22.8f;

            List<OrderDetailsVO> detailsList = new List<OrderDetailsVO>();
            detailsList.Add(detailsVO1);
            detailsList.Add(detailsVO2);

            orderVO.DetailsList = detailsList;

            this.setOrder(orderVO);*/
        }

        public void setOrder(OrderVO orderVO)
        {
            int w = this.itemP.ClientRectangle.Width;
            int noW = (int)(w * 0.1f);
            int priceW = (int)(w * 0.2f);
            int nameW = (int)(w - noW - priceW);
            int rowH = 25;

            this.franchiseeL.Text = orderVO.FranchiseeName;
            this.franchiseeL.Location = new Point((this.contentP.ClientRectangle.Width - this.franchiseeL.ClientRectangle.Width) / 2, this.franchiseeL.Location.Y);

            this.freightL.Text = "" + (orderVO.EmsFreight + orderVO.ExpressFreight + orderVO.MailFreight);

            List<OrderDetailsVO> detailsList = orderVO.DetailsList;
            int count = detailsList.Count;
            for (int i = 0; i < count;i++ )
            {
                OrderDetailsVO detailsVO = detailsList[i];

                //添加商品信息
                int y = rowH * i;

                Label noL = new Label();
                noL.Location = new Point(0, y);
                noL.Size = new Size(noW, rowH);
                noL.Font = this.addressL.Font;
                noL.Text = "" + (i + 1);
                //noL.BackColor = Color.Red;
                this.itemP.Controls.Add(noL);

                Label nameL = new Label();
                nameL.Location = new Point(noW, y);
                nameL.Size = new Size(nameW, rowH);
                nameL.Font = this.addressL.Font;
                nameL.Text = detailsVO.ItemName;
                //nameL.BackColor = Color.Blue;
                this.itemP.Controls.Add(nameL);

                Label totalL = new Label();
                totalL.Location = new Point(noW + nameW, y);
                totalL.Size = new Size(priceW, rowH);
                totalL.Font = this.paymentL.Font;
                totalL.Text = "" + detailsVO.Total;
                //totalL.BackColor = Color.Yellow;
                this.itemP.Controls.Add(totalL);
            }

            int itemPH = rowH * count;
            this.itemP.Size = new Size(this.itemP.ClientRectangle.Width, itemPH);

            this.sumP.Location = new Point(this.sumP.Location.X, this.itemP.Location.Y + itemPH);

            this.taxL.Text = "" + orderVO.TaxTotal;
            this.totalL.Text = "" + orderVO.ItemTotal;
            this.paymentL.Text = "" + orderVO.Payment;

            this.contentP.Size = new Size(this.contentP.Size.Width, this.sumP.Location.Y + this.sumP.Size.Height + 300);

            this.createdL.Text = orderVO.Created.ToString("yyyy.MM.dd hh:mm:ss");

            int buttonY = (int)(this.sumP.Location.Y + this.sumP.ClientRectangle.Height + 10);
            int ii = this.printB.Location.X;
            this.printB.Location = new Point(this.printB.Location.X, buttonY);

            this.Size = new Size(this.ClientRectangle.Width, this.contentP.Location.Y + this.contentP.ClientRectangle.Height + 50);
        }

        private void printB_Click(object sender, EventArgs e)
        {
            this.printB.Visible = false;
            this.printDocument1.Print();
        }

        private void OrderReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bit = new Bitmap(this.Width, this.Height);
            this.contentP.DrawToBitmap(bit, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bit, 0, 0);
            bit.Dispose();
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
