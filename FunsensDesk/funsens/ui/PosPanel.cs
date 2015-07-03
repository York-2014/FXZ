using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funsens.mis;
using x.util;

namespace funsens.ui
{
    public partial class PosPanel : UserControl
    {
        public PosPanel()
        {
            InitializeComponent();
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
        }

        private void PosPanel_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            this.uiResize();
        }

        private void PosPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logInB_Click(object sender, EventArgs e)
        {
            string userId = this.userIdTB.Text;
            if(null == userId || S.EMPTY.Equals(userId))
            {
                MessageBox.Show("请填写操作员号");
                return;
            }

            Mis mis = new Mis(this.comPort);
            bool result = mis.logIn(userId);
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 签退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOutB_Click(object sender, EventArgs e)
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.logOut();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settleB_Click(object sender, EventArgs e)
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.settle();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryBalancesB_Click(object sender, EventArgs e)
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.queryBalances();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void payPayB_Click(object sender, EventArgs e)
        {
            double payment = 0.00;

            try
            {
                payment = double.Parse(this.spendPaymentTB.Text);
            }
            catch (Exception e1)
            {
            }

            if (payment <= 0)
            {
                MessageBox.Show("请填写有效的支付金额");
                return;
            }

            Mis mis = new Mis(this.comPort);
            bool result = mis.spend(payment, "01");
            if (!result)
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 重打印上一单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prePrintB_Click(object sender, EventArgs e)
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.printPre();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 重打结算单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printSettleB_Click(object sender, EventArgs e)
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.printSettle();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 查询最后一笔交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryLastOrder_Click(object sender, EventArgs e)
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.queryLastOrder();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 查询交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryOrderB_Click(object sender, EventArgs e)
        {
            string orderId = this.queryOrderIdTB.Text;
            if(null == orderId || S.EMPTY.Equals(orderId))
            {
                MessageBox.Show("请输入订单号");
                return;
            }

            Mis mis = new Mis(this.comPort);
            bool result = mis.queryOrder(orderId);
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        /// <summary>
        /// 撤消（消费）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelSpendB_Click(object sender, EventArgs e)
        {
            string orderId = this.cancelSpendOrderIdTB.Text;
            if (null == orderId || S.EMPTY.Equals(orderId))
            {
                MessageBox.Show("请输入订单号");
                return;
            }

            Mis mis = new Mis(this.comPort);
            bool result = mis.cancelSpend(orderId);
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        private void button1_Click(object sender, EventArgs e)//汇总
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.printallOrder();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

        private void button2_Click(object sender, EventArgs e)//明细
        {
            Mis mis = new Mis(this.comPort);
            bool result = mis.printdetails();
            if (result)
                MessageBox.Show("请求成功");
            else
                MessageBox.Show("请求失败");
        }

                
    }
}
