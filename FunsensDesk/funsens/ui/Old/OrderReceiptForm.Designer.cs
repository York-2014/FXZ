namespace funsens.ui
{
    partial class OrderReceiptForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReceiptForm));
            this.printB = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.contentP = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sumP = new System.Windows.Forms.Panel();
            this.createdL = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.signatureL = new System.Windows.Forms.Label();
            this.couponL = new System.Windows.Forms.Label();
            this.taxL = new System.Windows.Forms.Label();
            this.totalL = new System.Windows.Forms.Label();
            this.paymentL = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.freightL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.itemP = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.addressL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.franchiseeL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contentP.SuspendLayout();
            this.sumP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // printB
            // 
            this.printB.Location = new System.Drawing.Point(6, 820);
            this.printB.Name = "printB";
            this.printB.Size = new System.Drawing.Size(254, 48);
            this.printB.TabIndex = 1;
            this.printB.Text = "打印";
            this.printB.UseVisualStyleBackColor = true;
            this.printB.Click += new System.EventHandler(this.printB_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // contentP
            // 
            this.contentP.Controls.Add(this.label1);
            this.contentP.Controls.Add(this.sumP);
            this.contentP.Controls.Add(this.itemP);
            this.contentP.Controls.Add(this.printB);
            this.contentP.Controls.Add(this.label5);
            this.contentP.Controls.Add(this.addressL);
            this.contentP.Controls.Add(this.label3);
            this.contentP.Controls.Add(this.franchiseeL);
            this.contentP.Controls.Add(this.pictureBox1);
            this.contentP.Controls.Add(this.label2);
            this.contentP.Location = new System.Drawing.Point(12, 3);
            this.contentP.Name = "contentP";
            this.contentP.Size = new System.Drawing.Size(269, 963);
            this.contentP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(127, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "400-881-0101";
            // 
            // sumP
            // 
            this.sumP.Controls.Add(this.createdL);
            this.sumP.Controls.Add(this.label20);
            this.sumP.Controls.Add(this.label19);
            this.sumP.Controls.Add(this.label18);
            this.sumP.Controls.Add(this.label17);
            this.sumP.Controls.Add(this.label16);
            this.sumP.Controls.Add(this.pictureBox2);
            this.sumP.Controls.Add(this.signatureL);
            this.sumP.Controls.Add(this.couponL);
            this.sumP.Controls.Add(this.taxL);
            this.sumP.Controls.Add(this.totalL);
            this.sumP.Controls.Add(this.paymentL);
            this.sumP.Controls.Add(this.label11);
            this.sumP.Controls.Add(this.label10);
            this.sumP.Controls.Add(this.label9);
            this.sumP.Controls.Add(this.label8);
            this.sumP.Controls.Add(this.freightL);
            this.sumP.Controls.Add(this.label6);
            this.sumP.Location = new System.Drawing.Point(10, 326);
            this.sumP.Name = "sumP";
            this.sumP.Size = new System.Drawing.Size(250, 488);
            this.sumP.TabIndex = 8;
            // 
            // createdL
            // 
            this.createdL.AutoSize = true;
            this.createdL.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.createdL.Location = new System.Drawing.Point(91, 459);
            this.createdL.Name = "createdL";
            this.createdL.Size = new System.Drawing.Size(159, 15);
            this.createdL.TabIndex = 16;
            this.createdL.Text = "2015.05.01 10:10:10";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(83, 408);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 15);
            this.label20.TabIndex = 15;
            this.label20.Text = "谢谢惠顾！";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(57, 340);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(142, 15);
            this.label19.TabIndex = 14;
            this.label19.Text = "风信子跨境直购商城";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(70, 433);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 15);
            this.label18.TabIndex = 13;
            this.label18.Text = "欢迎下次光临！";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(3, 459);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 15);
            this.label17.TabIndex = 12;
            this.label17.Text = "交易时间：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(46, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(159, 19);
            this.label16.TabIndex = 11;
            this.label16.Text = "www.funsens.com";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(49, 164);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 157);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // signatureL
            // 
            this.signatureL.AutoSize = true;
            this.signatureL.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.signatureL.Location = new System.Drawing.Point(39, 138);
            this.signatureL.Name = "signatureL";
            this.signatureL.Size = new System.Drawing.Size(177, 15);
            this.signatureL.TabIndex = 9;
            this.signatureL.Text = "就  要  淘  尽  世  界";
            // 
            // couponL
            // 
            this.couponL.AutoSize = true;
            this.couponL.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.couponL.Location = new System.Drawing.Point(133, 30);
            this.couponL.Name = "couponL";
            this.couponL.Size = new System.Drawing.Size(19, 19);
            this.couponL.TabIndex = 9;
            this.couponL.Text = "0";
            // 
            // taxL
            // 
            this.taxL.AutoSize = true;
            this.taxL.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taxL.Location = new System.Drawing.Point(133, 54);
            this.taxL.Name = "taxL";
            this.taxL.Size = new System.Drawing.Size(19, 19);
            this.taxL.TabIndex = 8;
            this.taxL.Text = "0";
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalL.Location = new System.Drawing.Point(133, 78);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(19, 19);
            this.totalL.TabIndex = 7;
            this.totalL.Text = "0";
            // 
            // paymentL
            // 
            this.paymentL.AutoSize = true;
            this.paymentL.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.paymentL.Location = new System.Drawing.Point(133, 103);
            this.paymentL.Name = "paymentL";
            this.paymentL.Size = new System.Drawing.Size(19, 19);
            this.paymentL.TabIndex = 6;
            this.paymentL.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(12, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "代金劵：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(12, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "店铺合计：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "本单税金：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(12, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "实付款：";
            // 
            // freightL
            // 
            this.freightL.AutoSize = true;
            this.freightL.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.freightL.Location = new System.Drawing.Point(133, 6);
            this.freightL.Name = "freightL";
            this.freightL.Size = new System.Drawing.Size(19, 19);
            this.freightL.TabIndex = 1;
            this.freightL.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "运费：";
            // 
            // itemP
            // 
            this.itemP.Location = new System.Drawing.Point(17, 257);
            this.itemP.Name = "itemP";
            this.itemP.Size = new System.Drawing.Size(239, 63);
            this.itemP.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(39, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "热线电话：";
            // 
            // addressL
            // 
            this.addressL.AutoSize = true;
            this.addressL.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addressL.Location = new System.Drawing.Point(3, 167);
            this.addressL.Name = "addressL";
            this.addressL.Size = new System.Drawing.Size(262, 15);
            this.addressL.TabIndex = 5;
            this.addressL.Text = "地址：南沙环市大道与双山大道交汇处";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(71, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "滨海隽城商业广场";
            // 
            // franchiseeL
            // 
            this.franchiseeL.AutoSize = true;
            this.franchiseeL.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.franchiseeL.Location = new System.Drawing.Point(56, 142);
            this.franchiseeL.Name = "franchiseeL";
            this.franchiseeL.Size = new System.Drawing.Size(96, 16);
            this.franchiseeL.TabIndex = 3;
            this.franchiseeL.Text = "商家：XXXXX";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "----------------------------------------";
            // 
            // OrderReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 1054);
            this.Controls.Add(this.contentP);
            this.MaximizeBox = false;
            this.Name = "OrderReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderReceiptForm";
            this.Load += new System.EventHandler(this.OrderReceiptForm_Load);
            this.contentP.ResumeLayout(false);
            this.contentP.PerformLayout();
            this.sumP.ResumeLayout(false);
            this.sumP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printB;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel contentP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sumP;
        private System.Windows.Forms.Label createdL;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label signatureL;
        private System.Windows.Forms.Label couponL;
        private System.Windows.Forms.Label taxL;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label paymentL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label freightL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel itemP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label addressL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label franchiseeL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}