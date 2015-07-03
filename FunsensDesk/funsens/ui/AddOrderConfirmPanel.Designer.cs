namespace funsens.ui
{
    partial class AddOrderConfirmPanel
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
            this.orderP = new System.Windows.Forms.Panel();
            this.footerP = new System.Windows.Forms.Panel();
            this.paiedTaxL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.unPayTaxL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.taxTotalL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.freightTotalL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemTotalL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.payB = new System.Windows.Forms.Button();
            this.titleP = new funsens.ui.TitlePanel();
            this.hp = new funsens.ui.HandlePanel();
            this.footerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderP
            // 
            this.orderP.AutoScroll = true;
            this.orderP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.orderP.Location = new System.Drawing.Point(13, 56);
            this.orderP.Name = "orderP";
            this.orderP.Size = new System.Drawing.Size(825, 337);
            this.orderP.TabIndex = 7;
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.paiedTaxL);
            this.footerP.Controls.Add(this.label6);
            this.footerP.Controls.Add(this.unPayTaxL);
            this.footerP.Controls.Add(this.label2);
            this.footerP.Controls.Add(this.totalL);
            this.footerP.Controls.Add(this.label7);
            this.footerP.Controls.Add(this.taxTotalL);
            this.footerP.Controls.Add(this.label5);
            this.footerP.Controls.Add(this.freightTotalL);
            this.footerP.Controls.Add(this.label3);
            this.footerP.Controls.Add(this.itemTotalL);
            this.footerP.Controls.Add(this.label1);
            this.footerP.Controls.Add(this.payB);
            this.footerP.Location = new System.Drawing.Point(13, 399);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(1022, 80);
            this.footerP.TabIndex = 8;
            // 
            // paiedTaxL
            // 
            this.paiedTaxL.AutoSize = true;
            this.paiedTaxL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.paiedTaxL.Location = new System.Drawing.Point(141, 47);
            this.paiedTaxL.Name = "paiedTaxL";
            this.paiedTaxL.Size = new System.Drawing.Size(68, 19);
            this.paiedTaxL.TabIndex = 12;
            this.paiedTaxL.Text = "￥0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(243, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "今日未交税费：";
            // 
            // unPayTaxL
            // 
            this.unPayTaxL.AutoSize = true;
            this.unPayTaxL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unPayTaxL.Location = new System.Drawing.Point(391, 47);
            this.unPayTaxL.Name = "unPayTaxL";
            this.unPayTaxL.Size = new System.Drawing.Size(68, 19);
            this.unPayTaxL.TabIndex = 10;
            this.unPayTaxL.Text = "￥0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "今日已交税费：";
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalL.Location = new System.Drawing.Point(645, 10);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(74, 20);
            this.totalL.TabIndex = 8;
            this.totalL.Text = "￥0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(525, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "应付总计：";
            // 
            // taxTotalL
            // 
            this.taxTotalL.AutoSize = true;
            this.taxTotalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taxTotalL.Location = new System.Drawing.Point(618, 47);
            this.taxTotalL.Name = "taxTotalL";
            this.taxTotalL.Size = new System.Drawing.Size(68, 19);
            this.taxTotalL.TabIndex = 6;
            this.taxTotalL.Text = "￥0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(508, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "本单税费：";
            // 
            // freightTotalL
            // 
            this.freightTotalL.AutoSize = true;
            this.freightTotalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.freightTotalL.Location = new System.Drawing.Point(391, 12);
            this.freightTotalL.Name = "freightTotalL";
            this.freightTotalL.Size = new System.Drawing.Size(68, 19);
            this.freightTotalL.TabIndex = 4;
            this.freightTotalL.Text = "￥0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(319, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "运费：";
            // 
            // itemTotalL
            // 
            this.itemTotalL.AutoSize = true;
            this.itemTotalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemTotalL.Location = new System.Drawing.Point(141, 11);
            this.itemTotalL.Name = "itemTotalL";
            this.itemTotalL.Size = new System.Drawing.Size(68, 19);
            this.itemTotalL.TabIndex = 2;
            this.itemTotalL.Text = "￥0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品总价：";
            // 
            // payB
            // 
            this.payB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.payB.Location = new System.Drawing.Point(777, 10);
            this.payB.Name = "payB";
            this.payB.Size = new System.Drawing.Size(120, 37);
            this.payB.TabIndex = 0;
            this.payB.Text = "生成订单";
            this.payB.UseVisualStyleBackColor = true;
            this.payB.Click += new System.EventHandler(this.payB_Click);
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(13, -8);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(825, 50);
            this.titleP.TabIndex = 6;
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(13, 455);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(273, 74);
            this.hp.TabIndex = 5;
            // 
            // AddOrderConfirmPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.footerP);
            this.Controls.Add(this.orderP);
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Name = "AddOrderConfirmPanel";
            this.Size = new System.Drawing.Size(1297, 586);
            this.Load += new System.EventHandler(this.OrderConfirmPanel_Load);
            this.SizeChanged += new System.EventHandler(this.OrderConfirmPanel_SizeChanged);
            this.footerP.ResumeLayout(false);
            this.footerP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HandlePanel hp;
        private TitlePanel titleP;
        private System.Windows.Forms.Panel orderP;
        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.Button payB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label freightTotalL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label itemTotalL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label taxTotalL;
        private System.Windows.Forms.Label paiedTaxL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label unPayTaxL;
        private System.Windows.Forms.Label label2;
    }
}
