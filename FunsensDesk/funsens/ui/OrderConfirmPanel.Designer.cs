namespace funsens.ui
{
    partial class OrderConfirmPanel
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
            this.pickupRB = new System.Windows.Forms.RadioButton();
            this.expressRB = new System.Windows.Forms.RadioButton();
            this.generalP = new System.Windows.Forms.Panel();
            this.selectAddressB = new System.Windows.Forms.Button();
            this.districtCB = new System.Windows.Forms.ComboBox();
            this.cityCB = new System.Windows.Forms.ComboBox();
            this.provinceCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zipCodeTB = new System.Windows.Forms.TextBox();
            this.addressTB = new System.Windows.Forms.TextBox();
            this.telTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemDGV = new System.Windows.Forms.DataGridView();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.franchiseeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.footerB = new System.Windows.Forms.Panel();
            this.totalL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.freightL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveB = new System.Windows.Forms.Button();
            this.hp = new funsens.ui.HandlePanel();
            this.titleP = new funsens.ui.TitlePanel();
            this.generalP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).BeginInit();
            this.footerB.SuspendLayout();
            this.SuspendLayout();
            // 
            // pickupRB
            // 
            this.pickupRB.AutoSize = true;
            this.pickupRB.Checked = true;
            this.pickupRB.Location = new System.Drawing.Point(12, 14);
            this.pickupRB.Name = "pickupRB";
            this.pickupRB.Size = new System.Drawing.Size(47, 16);
            this.pickupRB.TabIndex = 0;
            this.pickupRB.TabStop = true;
            this.pickupRB.Text = "自提";
            this.pickupRB.UseVisualStyleBackColor = true;
            this.pickupRB.CheckedChanged += new System.EventHandler(this.pickupRB_CheckedChanged);
            // 
            // expressRB
            // 
            this.expressRB.AutoSize = true;
            this.expressRB.Location = new System.Drawing.Point(66, 14);
            this.expressRB.Name = "expressRB";
            this.expressRB.Size = new System.Drawing.Size(47, 16);
            this.expressRB.TabIndex = 1;
            this.expressRB.Text = "快递";
            this.expressRB.UseVisualStyleBackColor = true;
            this.expressRB.CheckedChanged += new System.EventHandler(this.expressRB_CheckedChanged);
            // 
            // generalP
            // 
            this.generalP.Controls.Add(this.selectAddressB);
            this.generalP.Controls.Add(this.districtCB);
            this.generalP.Controls.Add(this.cityCB);
            this.generalP.Controls.Add(this.provinceCB);
            this.generalP.Controls.Add(this.label10);
            this.generalP.Controls.Add(this.label9);
            this.generalP.Controls.Add(this.label8);
            this.generalP.Controls.Add(this.zipCodeTB);
            this.generalP.Controls.Add(this.addressTB);
            this.generalP.Controls.Add(this.telTB);
            this.generalP.Controls.Add(this.nameTB);
            this.generalP.Controls.Add(this.label4);
            this.generalP.Controls.Add(this.label3);
            this.generalP.Controls.Add(this.label2);
            this.generalP.Controls.Add(this.label1);
            this.generalP.Controls.Add(this.pickupRB);
            this.generalP.Controls.Add(this.expressRB);
            this.generalP.Location = new System.Drawing.Point(13, 87);
            this.generalP.Name = "generalP";
            this.generalP.Size = new System.Drawing.Size(1259, 86);
            this.generalP.TabIndex = 2;
            // 
            // selectAddressB
            // 
            this.selectAddressB.Location = new System.Drawing.Point(1154, 49);
            this.selectAddressB.Name = "selectAddressB";
            this.selectAddressB.Size = new System.Drawing.Size(92, 23);
            this.selectAddressB.TabIndex = 16;
            this.selectAddressB.Text = "选择收货地址";
            this.selectAddressB.UseVisualStyleBackColor = true;
            this.selectAddressB.Click += new System.EventHandler(this.selectAddressB_Click);
            // 
            // districtCB
            // 
            this.districtCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.districtCB.FormattingEnabled = true;
            this.districtCB.Location = new System.Drawing.Point(458, 51);
            this.districtCB.Name = "districtCB";
            this.districtCB.Size = new System.Drawing.Size(130, 20);
            this.districtCB.TabIndex = 15;
            // 
            // cityCB
            // 
            this.cityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityCB.FormattingEnabled = true;
            this.cityCB.Location = new System.Drawing.Point(250, 51);
            this.cityCB.Name = "cityCB";
            this.cityCB.Size = new System.Drawing.Size(142, 20);
            this.cityCB.TabIndex = 14;
            this.cityCB.SelectedIndexChanged += new System.EventHandler(this.cityCB_SelectedIndexChanged);
            // 
            // provinceCB
            // 
            this.provinceCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinceCB.FormattingEnabled = true;
            this.provinceCB.Location = new System.Drawing.Point(65, 51);
            this.provinceCB.Name = "provinceCB";
            this.provinceCB.Size = new System.Drawing.Size(120, 20);
            this.provinceCB.TabIndex = 13;
            this.provinceCB.SelectedValueChanged += new System.EventHandler(this.provinceCB_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "城市：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(423, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "区：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "省份：";
            // 
            // zipCodeTB
            // 
            this.zipCodeTB.Location = new System.Drawing.Point(1050, 51);
            this.zipCodeTB.Name = "zipCodeTB";
            this.zipCodeTB.Size = new System.Drawing.Size(82, 21);
            this.zipCodeTB.TabIndex = 9;
            this.zipCodeTB.Text = "510000";
            // 
            // addressTB
            // 
            this.addressTB.Location = new System.Drawing.Point(677, 51);
            this.addressTB.Name = "addressTB";
            this.addressTB.Size = new System.Drawing.Size(282, 21);
            this.addressTB.TabIndex = 8;
            this.addressTB.Text = "溪南大道1011";
            // 
            // telTB
            // 
            this.telTB.Location = new System.Drawing.Point(389, 13);
            this.telTB.Name = "telTB";
            this.telTB.Size = new System.Drawing.Size(100, 21);
            this.telTB.TabIndex = 7;
            this.telTB.Text = "13926004444";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(189, 13);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 21);
            this.nameTB.TabIndex = 6;
            this.nameTB.Text = "小强";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "联系电话：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(979, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "邮政编码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "详细地址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "收件人：";
            // 
            // itemDGV
            // 
            this.itemDGV.AllowUserToAddRows = false;
            this.itemDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.image,
            this.franchiseeName,
            this.name,
            this.price,
            this.amount});
            this.itemDGV.Location = new System.Drawing.Point(13, 179);
            this.itemDGV.Name = "itemDGV";
            this.itemDGV.RowTemplate.Height = 23;
            this.itemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDGV.Size = new System.Drawing.Size(1259, 314);
            this.itemDGV.TabIndex = 3;
            // 
            // image
            // 
            this.image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.image.HeaderText = "商品图片";
            this.image.Name = "image";
            this.image.ReadOnly = true;
            // 
            // franchiseeName
            // 
            this.franchiseeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.franchiseeName.HeaderText = "商家名称";
            this.franchiseeName.Name = "franchiseeName";
            this.franchiseeName.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 200F;
            this.name.HeaderText = "商品名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.amount.HeaderText = "数量";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // footerB
            // 
            this.footerB.Controls.Add(this.totalL);
            this.footerB.Controls.Add(this.label6);
            this.footerB.Controls.Add(this.freightL);
            this.footerB.Controls.Add(this.label5);
            this.footerB.Controls.Add(this.saveB);
            this.footerB.Location = new System.Drawing.Point(584, 523);
            this.footerB.Name = "footerB";
            this.footerB.Size = new System.Drawing.Size(701, 50);
            this.footerB.TabIndex = 4;
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Location = new System.Drawing.Point(480, 21);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(41, 12);
            this.totalL.TabIndex = 6;
            this.totalL.Text = "￥0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "合计：";
            // 
            // freightL
            // 
            this.freightL.AutoSize = true;
            this.freightL.Location = new System.Drawing.Point(360, 21);
            this.freightL.Name = "freightL";
            this.freightL.Size = new System.Drawing.Size(41, 12);
            this.freightL.TabIndex = 2;
            this.freightL.Text = "￥0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "运费：";
            // 
            // saveB
            // 
            this.saveB.Location = new System.Drawing.Point(598, 4);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(100, 40);
            this.saveB.TabIndex = 0;
            this.saveB.Text = "进入支付";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(283, 499);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(273, 74);
            this.hp.TabIndex = 5;
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(13, 0);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(825, 50);
            this.titleP.TabIndex = 6;
            // 
            // OrderConfirmPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.footerB);
            this.Controls.Add(this.itemDGV);
            this.Controls.Add(this.generalP);
            this.Name = "OrderConfirmPanel";
            this.Size = new System.Drawing.Size(1297, 586);
            this.Load += new System.EventHandler(this.OrderConfirmPanel_Load);
            this.SizeChanged += new System.EventHandler(this.OrderConfirmPanel_SizeChanged);
            this.generalP.ResumeLayout(false);
            this.generalP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).EndInit();
            this.footerB.ResumeLayout(false);
            this.footerB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton pickupRB;
        private System.Windows.Forms.RadioButton expressRB;
        private System.Windows.Forms.Panel generalP;
        private System.Windows.Forms.TextBox zipCodeTB;
        private System.Windows.Forms.TextBox addressTB;
        private System.Windows.Forms.TextBox telTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView itemDGV;
        private System.Windows.Forms.Panel footerB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label freightL;
        private System.Windows.Forms.Label label5;
        private HandlePanel hp;
        private System.Windows.Forms.ComboBox districtCB;
        private System.Windows.Forms.ComboBox cityCB;
        private System.Windows.Forms.ComboBox provinceCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button selectAddressB;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewTextBoxColumn franchiseeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private TitlePanel titleP;
    }
}
