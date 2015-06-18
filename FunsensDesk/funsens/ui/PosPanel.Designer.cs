namespace funsens.ui
{
    partial class PosPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spendGB = new System.Windows.Forms.GroupBox();
            this.cancelSpendB = new System.Windows.Forms.Button();
            this.cancelSpendOrderIdTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.spendPaymentTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spendPayB = new System.Windows.Forms.Button();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.logOutB = new System.Windows.Forms.Button();
            this.logInB = new System.Windows.Forms.Button();
            this.generalB = new System.Windows.Forms.GroupBox();
            this.userIdTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.settleB = new System.Windows.Forms.Button();
            this.queryBalancesB = new System.Windows.Forms.Button();
            this.prePrintB = new System.Windows.Forms.Button();
            this.printSettleB = new System.Windows.Forms.Button();
            this.queryLastOrder = new System.Windows.Forms.Button();
            this.queryOrderGB = new System.Windows.Forms.GroupBox();
            this.queryOrderIdTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.queryOrderB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.spendGB.SuspendLayout();
            this.generalB.SuspendLayout();
            this.queryOrderGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // spendGB
            // 
            this.spendGB.Controls.Add(this.cancelSpendB);
            this.spendGB.Controls.Add(this.cancelSpendOrderIdTB);
            this.spendGB.Controls.Add(this.label4);
            this.spendGB.Controls.Add(this.spendPaymentTB);
            this.spendGB.Controls.Add(this.label1);
            this.spendGB.Controls.Add(this.spendPayB);
            this.spendGB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spendGB.Location = new System.Drawing.Point(21, 404);
            this.spendGB.Name = "spendGB";
            this.spendGB.Size = new System.Drawing.Size(743, 70);
            this.spendGB.TabIndex = 0;
            this.spendGB.TabStop = false;
            this.spendGB.Text = "消费";
            this.spendGB.Visible = false;
            // 
            // cancelSpendB
            // 
            this.cancelSpendB.Location = new System.Drawing.Point(662, 28);
            this.cancelSpendB.Name = "cancelSpendB";
            this.cancelSpendB.Size = new System.Drawing.Size(75, 30);
            this.cancelSpendB.TabIndex = 5;
            this.cancelSpendB.Text = "撤消";
            this.cancelSpendB.UseVisualStyleBackColor = true;
            this.cancelSpendB.Click += new System.EventHandler(this.cancelSpendB_Click);
            // 
            // cancelSpendOrderIdTB
            // 
            this.cancelSpendOrderIdTB.Location = new System.Drawing.Point(463, 28);
            this.cancelSpendOrderIdTB.Name = "cancelSpendOrderIdTB";
            this.cancelSpendOrderIdTB.Size = new System.Drawing.Size(193, 29);
            this.cancelSpendOrderIdTB.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "订单号：";
            // 
            // spendPaymentTB
            // 
            this.spendPaymentTB.Location = new System.Drawing.Point(117, 25);
            this.spendPaymentTB.Name = "spendPaymentTB";
            this.spendPaymentTB.Size = new System.Drawing.Size(135, 29);
            this.spendPaymentTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "支付金额：";
            // 
            // spendPayB
            // 
            this.spendPayB.Location = new System.Drawing.Point(275, 28);
            this.spendPayB.Name = "spendPayB";
            this.spendPayB.Size = new System.Drawing.Size(75, 30);
            this.spendPayB.TabIndex = 0;
            this.spendPayB.Text = "支付";
            this.spendPayB.UseVisualStyleBackColor = true;
            this.spendPayB.Click += new System.EventHandler(this.payPayB_Click);
            // 
            // logOutB
            // 
            this.logOutB.Location = new System.Drawing.Point(412, 25);
            this.logOutB.Name = "logOutB";
            this.logOutB.Size = new System.Drawing.Size(75, 30);
            this.logOutB.TabIndex = 1;
            this.logOutB.Text = "签退";
            this.logOutB.UseVisualStyleBackColor = true;
            this.logOutB.Click += new System.EventHandler(this.logOutB_Click);
            // 
            // logInB
            // 
            this.logInB.Location = new System.Drawing.Point(303, 25);
            this.logInB.Name = "logInB";
            this.logInB.Size = new System.Drawing.Size(75, 30);
            this.logInB.TabIndex = 2;
            this.logInB.Text = "签到";
            this.logInB.UseVisualStyleBackColor = true;
            this.logInB.Click += new System.EventHandler(this.logInB_Click);
            // 
            // generalB
            // 
            this.generalB.Controls.Add(this.userIdTB);
            this.generalB.Controls.Add(this.label2);
            this.generalB.Controls.Add(this.logOutB);
            this.generalB.Controls.Add(this.logInB);
            this.generalB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.generalB.Location = new System.Drawing.Point(21, 110);
            this.generalB.Name = "generalB";
            this.generalB.Size = new System.Drawing.Size(743, 66);
            this.generalB.TabIndex = 3;
            this.generalB.TabStop = false;
            this.generalB.Text = "基本操作";
            // 
            // userIdTB
            // 
            this.userIdTB.Enabled = false;
            this.userIdTB.Location = new System.Drawing.Point(115, 28);
            this.userIdTB.Name = "userIdTB";
            this.userIdTB.Size = new System.Drawing.Size(137, 29);
            this.userIdTB.TabIndex = 4;
            this.userIdTB.Text = "01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "操作员：";
            // 
            // settleB
            // 
            this.settleB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settleB.Location = new System.Drawing.Point(33, 198);
            this.settleB.Name = "settleB";
            this.settleB.Size = new System.Drawing.Size(75, 30);
            this.settleB.TabIndex = 4;
            this.settleB.Text = "结算";
            this.settleB.UseVisualStyleBackColor = true;
            this.settleB.Click += new System.EventHandler(this.settleB_Click);
            // 
            // queryBalancesB
            // 
            this.queryBalancesB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queryBalancesB.Location = new System.Drawing.Point(129, 198);
            this.queryBalancesB.Name = "queryBalancesB";
            this.queryBalancesB.Size = new System.Drawing.Size(108, 30);
            this.queryBalancesB.TabIndex = 5;
            this.queryBalancesB.Text = "查询余额";
            this.queryBalancesB.UseVisualStyleBackColor = true;
            this.queryBalancesB.Click += new System.EventHandler(this.queryBalancesB_Click);
            // 
            // prePrintB
            // 
            this.prePrintB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prePrintB.Location = new System.Drawing.Point(259, 198);
            this.prePrintB.Name = "prePrintB";
            this.prePrintB.Size = new System.Drawing.Size(156, 30);
            this.prePrintB.TabIndex = 6;
            this.prePrintB.Text = "重打印上一单";
            this.prePrintB.UseVisualStyleBackColor = true;
            this.prePrintB.Click += new System.EventHandler(this.prePrintB_Click);
            // 
            // printSettleB
            // 
            this.printSettleB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.printSettleB.Location = new System.Drawing.Point(433, 198);
            this.printSettleB.Name = "printSettleB";
            this.printSettleB.Size = new System.Drawing.Size(122, 30);
            this.printSettleB.TabIndex = 7;
            this.printSettleB.Text = "重打结算单";
            this.printSettleB.UseVisualStyleBackColor = true;
            this.printSettleB.Click += new System.EventHandler(this.printSettleB_Click);
            // 
            // queryLastOrder
            // 
            this.queryLastOrder.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queryLastOrder.Location = new System.Drawing.Point(579, 198);
            this.queryLastOrder.Name = "queryLastOrder";
            this.queryLastOrder.Size = new System.Drawing.Size(185, 30);
            this.queryLastOrder.TabIndex = 8;
            this.queryLastOrder.Text = "查询最后一笔交易";
            this.queryLastOrder.UseVisualStyleBackColor = true;
            this.queryLastOrder.Click += new System.EventHandler(this.queryLastOrder_Click);
            // 
            // queryOrderGB
            // 
            this.queryOrderGB.Controls.Add(this.queryOrderIdTB);
            this.queryOrderGB.Controls.Add(this.label3);
            this.queryOrderGB.Controls.Add(this.queryOrderB);
            this.queryOrderGB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queryOrderGB.Location = new System.Drawing.Point(21, 305);
            this.queryOrderGB.Name = "queryOrderGB";
            this.queryOrderGB.Size = new System.Drawing.Size(394, 74);
            this.queryOrderGB.TabIndex = 9;
            this.queryOrderGB.TabStop = false;
            this.queryOrderGB.Text = "交易查询";
            // 
            // queryOrderIdTB
            // 
            this.queryOrderIdTB.Location = new System.Drawing.Point(117, 31);
            this.queryOrderIdTB.Name = "queryOrderIdTB";
            this.queryOrderIdTB.Size = new System.Drawing.Size(135, 29);
            this.queryOrderIdTB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "订单号：";
            // 
            // queryOrderB
            // 
            this.queryOrderB.Location = new System.Drawing.Point(275, 31);
            this.queryOrderB.Name = "queryOrderB";
            this.queryOrderB.Size = new System.Drawing.Size(75, 30);
            this.queryOrderB.TabIndex = 0;
            this.queryOrderB.Text = "查询";
            this.queryOrderB.UseVisualStyleBackColor = true;
            this.queryOrderB.Click += new System.EventHandler(this.queryOrderB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(320, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "POS机操作界面";
            // 
            // PosPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.queryOrderGB);
            this.Controls.Add(this.queryLastOrder);
            this.Controls.Add(this.printSettleB);
            this.Controls.Add(this.prePrintB);
            this.Controls.Add(this.queryBalancesB);
            this.Controls.Add(this.settleB);
            this.Controls.Add(this.generalB);
            this.Controls.Add(this.spendGB);
            this.Name = "PosPanel";
            this.Size = new System.Drawing.Size(1130, 723);
            this.Load += new System.EventHandler(this.PosPanel_Load);
            this.SizeChanged += new System.EventHandler(this.PosPanel_SizeChanged);
            this.spendGB.ResumeLayout(false);
            this.spendGB.PerformLayout();
            this.generalB.ResumeLayout(false);
            this.generalB.PerformLayout();
            this.queryOrderGB.ResumeLayout(false);
            this.queryOrderGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox spendGB;
        private System.Windows.Forms.TextBox spendPaymentTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button spendPayB;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.Button logOutB;
        private System.Windows.Forms.Button logInB;
        private System.Windows.Forms.GroupBox generalB;
        private System.Windows.Forms.TextBox userIdTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button settleB;
        private System.Windows.Forms.Button queryBalancesB;
        private System.Windows.Forms.Button prePrintB;
        private System.Windows.Forms.Button printSettleB;
        private System.Windows.Forms.Button queryLastOrder;
        private System.Windows.Forms.GroupBox queryOrderGB;
        private System.Windows.Forms.TextBox queryOrderIdTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button queryOrderB;
        private System.Windows.Forms.Button cancelSpendB;
        private System.Windows.Forms.TextBox cancelSpendOrderIdTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
