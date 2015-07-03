using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.util;
using funsens.order.vo;
using funsens.ui;

namespace funsens.ui
{
    /// <summary>
    /// 小票打印界面
    /// </summary>
    public partial class OrderReceiptForm1 : Form
    {
        private int top = 30;
        private int h1;

        public OrderReceiptForm1()
        {
            InitializeComponent();
        }

        public void setOrder(OrderVO orderVO)
        {
            string content1 = this.richTextBox1.Text;

            //content1 = content1.Replace("FRANCHISEE_NAME", orderVO.FranchiseeName);
            AddOrderPanel t= new AddOrderPanel();

            content1 = content1.Replace("FRANCHISEE_NAME", AddOrderPanel.shopname);

            content1 = content1.Replace("ORDER_ID", "订单号：" + orderVO.Id);

            List<OrderDetailsVO> detailsList = orderVO.DetailsList;
            int count = detailsList.Count;
            string itemContent = "";
            double T = 0,q=0;
            for (int i = 0; i < count; i++)
            {
                OrderDetailsVO detailsVO = detailsList[i];

                //itemContent += detailsVO.Amount + this.formatName(detailsVO.ItemName) + "￥" + detailsVO.Total + "\r\n";
                itemContent += this.formatName(detailsVO.ItemName).Trim() + "\r\n " + string.Format("{0:##########}", detailsVO.Barcode).PadRight(15) + string.Format("{0:##########}", detailsVO.Amount).PadRight(9) + "￥" + detailsVO.Total + "\r\n";

                T += detailsVO.Amount;
                q += detailsVO.Total;
               // string  tr=detailsVO.
                /*int l = detailsVO.ItemName.Length;
                if (l > 10)
                    itemContent += ((i + 1) + " " + detailsVO.ItemName.Substring(0, 10) + "\r\n  " + detailsVO.ItemName.Substring(10) + " ￥" + detailsVO.Total + "\r\n");
                else
                    itemContent += ((i + 1) + " " + detailsVO.ItemName + " ￥" + detailsVO.Total + "\r\n");*/
            }

            content1 = content1.Replace("ITEM_LIST", itemContent);

            content1 = content1.Replace("FREIGHT", "" + (orderVO.EmsFreight + orderVO.ExpressFreight + orderVO.MailFreight));

            double tax = 0.00;
            if (orderVO.PaiedTax > 0)
            {
                tax = orderVO.TaxTotal;
            }
            else
            {
                double tmp = orderVO.UnPayTax + orderVO.OrdersTax;
                if (tmp > 50)
                    tax = orderVO.TaxTotal;
            }
            content1 = content1.Replace("ITEM_COUNT", "" + T + "".PadRight(7));
            content1 = content1.Replace("ITEM_AMOUNT", "￥" + q);
            content1 = content1.Replace("UN_PAY_TAX", "" + orderVO.UnPayTax);
            content1 = content1.Replace("TAX", "" + tax);
            double untax = 0.00;
            if (orderVO.UnPayTax > 50) untax = orderVO.UnPayTax;
           
            content1 = content1.Replace("PAYMENT", "" + Math.Round((orderVO.Payment + tax + untax),2));

            if (null != orderVO.ExpressType && !"".Equals(orderVO.ExpressType))
                content1 = content1.Replace("ADDRESS", this.formatAddress(orderVO.CustomerAddress));
            else
                content1 = content1.Replace("ADDRESS", "跨境直购体验中心自提");

            this.richTextBox1.Text = content1;

            string content2 = this.richTextBox2.Text;
            content2 = content2.Replace("CREATED", orderVO.Created.ToString("yyyy.MM.dd HH:mm:ss"));
            content2 = content2.Replace("PRINTED", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            
            this.richTextBox2.Text = content2;
        }

        private void printB_Click(object sender, EventArgs e)
        {
            try
            {
                this.printDocument1.Print();
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(this.richTextBox1.Text, this.richTextBox1.Font, Brushes.Black, new Point(20, this.top));
            e.Graphics.DrawImage(this.pictureBox1.Image, new Point(70, this.h1 + this.top - 30));
            e.Graphics.DrawString(this.richTextBox2.Text, this.richTextBox2.Font, Brushes.Black, new Point(20, this.top + this.h1 + this.pictureBox1.ClientRectangle.Height));
        }

        private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            h1 = e.NewRectangle.Height;
        }

        private void OrderReceiptForm1_Load(object sender, EventArgs e)
        {

        }

        private string formatName(string name)
        {
            if (S.blank(name))
                return name;

            int rowSize = 34;

            int count = name.Length;
            List<string> resultList = new List<string>();
            StringBuilder row = new StringBuilder();
            int tmpL;
            for (int i = 0; i < count; i++)
            {
                row.Append(name.Substring(i, 1));

                tmpL = Encoding.Default.GetByteCount(row.ToString());
                if (tmpL >= rowSize)
                {
                    if (tmpL == rowSize)
                        row.Append("  ");
                    else
                        row.Append(" ");

                    resultList.Add(row.ToString());
                    row = new StringBuilder();
                }
            }

            tmpL = Encoding.Default.GetByteCount(row.ToString());
            if (tmpL > 0)
            {
                int tmp = rowSize - tmpL;
                for (int i = 0; i < tmp; i++)
                    row.Append(" ");

                resultList.Add(row.ToString());
            }

            count = resultList.Count;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                    result.Append(" ");
                else
                    result.Append("   ");

                result.Append(resultList[i]);

                if (i < count - 1)
                    result.Append("\r\n");
            }

            return result.ToString();
        }

        private string formatAddress(string address)
        {
            if (S.blank(address))
                return S.EMPTY;

            int rowSize1 = 24;
            int rowSize2 = 32;

            int count = address.Length;
            List<string> resultList = new List<string>();
            StringBuilder row = new StringBuilder();
            int tmpL;
            for (int i = 0; i < count; i++)
            {
                row.Append(address.Substring(i, 1));

                tmpL = Encoding.Default.GetByteCount(row.ToString());
                int rowCount = resultList.Count;
                if ((rowCount < 1 && tmpL >= rowSize1) || (rowCount > 0 && tmpL >= rowSize2))
                {
                    if (rowCount > 0)
                        resultList.Add("  " + row.ToString());
                    else
                        resultList.Add(row.ToString());

                    row = new StringBuilder();
                }
            }

            tmpL = Encoding.Default.GetByteCount(row.ToString());
            if (tmpL > 0)
            {
                if (resultList.Count > 0)
                    resultList.Add("  " + row.ToString());
                else
                    resultList.Add(row.ToString());
            }

            count = resultList.Count;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(resultList[i]);

                if (i < count - 1)
                    result.Append("\r\n");
            }

            return result.ToString();
        }
    }
}
