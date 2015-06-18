namespace funsens.ui
{
    partial class OrderInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customerNameL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idL = new System.Windows.Forms.Label();
            this.statusL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.itemTotalL = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.barcodePB = new System.Windows.Forms.PictureBox();
            this.unPayL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.payB = new System.Windows.Forms.Button();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.userIdTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(37, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "本单金额：";
            // 
            // customerNameL
            // 
            this.customerNameL.AutoSize = true;
            this.customerNameL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.customerNameL.Location = new System.Drawing.Point(121, 55);
            this.customerNameL.Name = "customerNameL";
            this.customerNameL.Size = new System.Drawing.Size(14, 14);
            this.customerNameL.TabIndex = 2;
            this.customerNameL.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(39, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "客户姓名：";
            // 
            // idL
            // 
            this.idL.AutoSize = true;
            this.idL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idL.Location = new System.Drawing.Point(121, 22);
            this.idL.Name = "idL";
            this.idL.Size = new System.Drawing.Size(14, 14);
            this.idL.TabIndex = 4;
            this.idL.Text = "-";
            // 
            // statusL
            // 
            this.statusL.AutoSize = true;
            this.statusL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusL.Location = new System.Drawing.Point(121, 163);
            this.statusL.Name = "statusL";
            this.statusL.Size = new System.Drawing.Size(14, 14);
            this.statusL.TabIndex = 5;
            this.statusL.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(38, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "订单状态：";
            // 
            // itemTotalL
            // 
            this.itemTotalL.AutoSize = true;
            this.itemTotalL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemTotalL.Location = new System.Drawing.Point(121, 129);
            this.itemTotalL.Name = "itemTotalL";
            this.itemTotalL.Size = new System.Drawing.Size(14, 14);
            this.itemTotalL.TabIndex = 7;
            this.itemTotalL.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(50, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "条形码：";
            // 
            // barcodePB
            // 
            this.barcodePB.Location = new System.Drawing.Point(119, 238);
            this.barcodePB.Name = "barcodePB";
            this.barcodePB.Size = new System.Drawing.Size(470, 311);
            this.barcodePB.TabIndex = 9;
            this.barcodePB.TabStop = false;
            // 
            // unPayL
            // 
            this.unPayL.AutoSize = true;
            this.unPayL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unPayL.Location = new System.Drawing.Point(121, 94);
            this.unPayL.Name = "unPayL";
            this.unPayL.Size = new System.Drawing.Size(14, 14);
            this.unPayL.TabIndex = 11;
            this.unPayL.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(14, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "今天未交税费：";
            // 
            // payB
            // 
            this.payB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.payB.Location = new System.Drawing.Point(230, 195);
            this.payB.Name = "payB";
            this.payB.Size = new System.Drawing.Size(74, 31);
            this.payB.TabIndex = 12;
            this.payB.Text = "支付";
            this.payB.UseVisualStyleBackColor = true;
            this.payB.Click += new System.EventHandler(this.payB_Click);
            // 
            // comPort
            // 
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comPort_DataReceived);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "POS操作员号：";
            // 
            // userIdTB
            // 
            this.userIdTB.Enabled = false;
            this.userIdTB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userIdTB.Location = new System.Drawing.Point(124, 199);
            this.userIdTB.Name = "userIdTB";
            this.userIdTB.Size = new System.Drawing.Size(100, 23);
            this.userIdTB.TabIndex = 14;
            this.userIdTB.Text = "01";
            // 
            // OrderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 595);
            this.Controls.Add(this.userIdTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.payB);
            this.Controls.Add(this.unPayL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.barcodePB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.itemTotalL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusL);
            this.Controls.Add(this.idL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customerNameL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "OrderInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单支付信息";
            this.Load += new System.EventHandler(this.OrderInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barcodePB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label customerNameL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label idL;
        private System.Windows.Forms.Label statusL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label itemTotalL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox barcodePB;
        private System.Windows.Forms.Label unPayL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button payB;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userIdTB;
    }
}