namespace funsens.ui
{
    partial class OrderConfirmItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.generalP = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.expressTypeCB = new System.Windows.Forms.ComboBox();
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
            this.pickupRB = new System.Windows.Forms.RadioButton();
            this.expressRB = new System.Windows.Forms.RadioButton();
            this.itemDGV = new System.Windows.Forms.DataGridView();
            this.franchiseeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.减少 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.footerP = new System.Windows.Forms.Panel();
            this.taxTotalL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.itemTotalL = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.freightL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.generalP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).BeginInit();
            this.footerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalP
            // 
            this.generalP.Controls.Add(this.button1);
            this.generalP.Controls.Add(this.label11);
            this.generalP.Controls.Add(this.expressTypeCB);
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
            this.generalP.Location = new System.Drawing.Point(0, 0);
            this.generalP.Name = "generalP";
            this.generalP.Size = new System.Drawing.Size(1093, 114);
            this.generalP.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(758, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 26);
            this.button1.TabIndex = 20;
            this.button1.Text = "新增地址";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(201, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "快递方式：";
            // 
            // expressTypeCB
            // 
            this.expressTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expressTypeCB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expressTypeCB.FormattingEnabled = true;
            this.expressTypeCB.Items.AddRange(new object[] {
            "EMS",
            "平邮",
            "快递"});
            this.expressTypeCB.Location = new System.Drawing.Point(295, 14);
            this.expressTypeCB.Name = "expressTypeCB";
            this.expressTypeCB.Size = new System.Drawing.Size(104, 24);
            this.expressTypeCB.TabIndex = 17;
            this.expressTypeCB.SelectedIndexChanged += new System.EventHandler(this.expressTypeCB_SelectedIndexChanged);
            // 
            // selectAddressB
            // 
            this.selectAddressB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectAddressB.Location = new System.Drawing.Point(619, 83);
            this.selectAddressB.Name = "selectAddressB";
            this.selectAddressB.Size = new System.Drawing.Size(123, 26);
            this.selectAddressB.TabIndex = 16;
            this.selectAddressB.Text = "选择收货地址";
            this.selectAddressB.UseVisualStyleBackColor = true;
            this.selectAddressB.Click += new System.EventHandler(this.selectAddressB_Click);
            // 
            // districtCB
            // 
            this.districtCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.districtCB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.districtCB.FormattingEnabled = true;
            this.districtCB.Location = new System.Drawing.Point(505, 45);
            this.districtCB.Name = "districtCB";
            this.districtCB.Size = new System.Drawing.Size(116, 24);
            this.districtCB.TabIndex = 15;
            this.districtCB.SelectedIndexChanged += new System.EventHandler(this.districtCB_SelectedIndexChanged);
            // 
            // cityCB
            // 
            this.cityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityCB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cityCB.FormattingEnabled = true;
            this.cityCB.Location = new System.Drawing.Point(296, 48);
            this.cityCB.Name = "cityCB";
            this.cityCB.Size = new System.Drawing.Size(131, 24);
            this.cityCB.TabIndex = 14;
            this.cityCB.SelectedIndexChanged += new System.EventHandler(this.cityCB_SelectedIndexChanged);
            // 
            // provinceCB
            // 
            this.provinceCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinceCB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.provinceCB.FormattingEnabled = true;
            this.provinceCB.Location = new System.Drawing.Point(81, 45);
            this.provinceCB.Name = "provinceCB";
            this.provinceCB.Size = new System.Drawing.Size(120, 24);
            this.provinceCB.TabIndex = 13;
            this.provinceCB.SelectedIndexChanged += new System.EventHandler(this.provinceCB_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(224, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "城市：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(459, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "区：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(19, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "省份：";
            // 
            // zipCodeTB
            // 
            this.zipCodeTB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zipCodeTB.Location = new System.Drawing.Point(737, 48);
            this.zipCodeTB.Name = "zipCodeTB";
            this.zipCodeTB.Size = new System.Drawing.Size(131, 26);
            this.zipCodeTB.TabIndex = 9;
            // 
            // addressTB
            // 
            this.addressTB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addressTB.Location = new System.Drawing.Point(119, 83);
            this.addressTB.Name = "addressTB";
            this.addressTB.Size = new System.Drawing.Size(486, 26);
            this.addressTB.TabIndex = 8;
            // 
            // telTB
            // 
            this.telTB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.telTB.Location = new System.Drawing.Point(736, 17);
            this.telTB.Name = "telTB";
            this.telTB.Size = new System.Drawing.Size(131, 26);
            this.telTB.TabIndex = 7;
            // 
            // nameTB
            // 
            this.nameTB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameTB.Location = new System.Drawing.Point(504, 12);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 26);
            this.nameTB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(653, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "联系电话：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(654, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "邮政编码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "详细地址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(438, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "收件人：";
            // 
            // pickupRB
            // 
            this.pickupRB.AutoSize = true;
            this.pickupRB.Checked = true;
            this.pickupRB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pickupRB.Location = new System.Drawing.Point(22, 13);
            this.pickupRB.Name = "pickupRB";
            this.pickupRB.Size = new System.Drawing.Size(58, 20);
            this.pickupRB.TabIndex = 0;
            this.pickupRB.TabStop = true;
            this.pickupRB.Text = "自提";
            this.pickupRB.UseVisualStyleBackColor = true;
            this.pickupRB.CheckedChanged += new System.EventHandler(this.pickupRB_CheckedChanged);
            // 
            // expressRB
            // 
            this.expressRB.AutoSize = true;
            this.expressRB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expressRB.Location = new System.Drawing.Point(114, 13);
            this.expressRB.Name = "expressRB";
            this.expressRB.Size = new System.Drawing.Size(58, 20);
            this.expressRB.TabIndex = 1;
            this.expressRB.Text = "快递";
            this.expressRB.UseVisualStyleBackColor = true;
            this.expressRB.CheckedChanged += new System.EventHandler(this.expressRB_CheckedChanged);
            // 
            // itemDGV
            // 
            this.itemDGV.AllowUserToAddRows = false;
            this.itemDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.franchiseeName,
            this.name,
            this.price,
            this.数量,
            this.减少});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemDGV.Location = new System.Drawing.Point(0, 120);
            this.itemDGV.Name = "itemDGV";
            this.itemDGV.ReadOnly = true;
            this.itemDGV.RowTemplate.Height = 23;
            this.itemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDGV.Size = new System.Drawing.Size(1093, 61);
            this.itemDGV.TabIndex = 4;
            this.itemDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDGV_CellContentClick);
            this.itemDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemDGV_KeyDown);
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
            // 数量
            // 
            this.数量.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            // 
            // 减少
            // 
            this.减少.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.减少.HeaderText = "减少";
            this.减少.Name = "减少";
            this.减少.ReadOnly = true;
            this.减少.Width = 60;
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.taxTotalL);
            this.footerP.Controls.Add(this.label7);
            this.footerP.Controls.Add(this.itemTotalL);
            this.footerP.Controls.Add(this.label12);
            this.footerP.Controls.Add(this.freightL);
            this.footerP.Controls.Add(this.label5);
            this.footerP.Controls.Add(this.totalL);
            this.footerP.Controls.Add(this.label6);
            this.footerP.Location = new System.Drawing.Point(283, 187);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(810, 45);
            this.footerP.TabIndex = 5;
            // 
            // taxTotalL
            // 
            this.taxTotalL.AutoSize = true;
            this.taxTotalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taxTotalL.Location = new System.Drawing.Point(428, 17);
            this.taxTotalL.Name = "taxTotalL";
            this.taxTotalL.Size = new System.Drawing.Size(68, 19);
            this.taxTotalL.TabIndex = 13;
            this.taxTotalL.Text = "￥0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(373, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "税费：";
            // 
            // itemTotalL
            // 
            this.itemTotalL.AutoSize = true;
            this.itemTotalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemTotalL.Location = new System.Drawing.Point(96, 17);
            this.itemTotalL.Name = "itemTotalL";
            this.itemTotalL.Size = new System.Drawing.Size(68, 19);
            this.itemTotalL.TabIndex = 11;
            this.itemTotalL.Text = "￥0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(229, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 19);
            this.label12.TabIndex = 10;
            this.label12.Text = "运费：";
            // 
            // freightL
            // 
            this.freightL.AutoSize = true;
            this.freightL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.freightL.Location = new System.Drawing.Point(289, 17);
            this.freightL.Name = "freightL";
            this.freightL.Size = new System.Drawing.Size(68, 19);
            this.freightL.TabIndex = 9;
            this.freightL.Text = "￥0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "商品总价：";
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalL.Location = new System.Drawing.Point(614, 17);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(73, 19);
            this.totalL.TabIndex = 6;
            this.totalL.Text = "￥0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(550, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "合计：";
            // 
            // OrderConfirmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.footerP);
            this.Controls.Add(this.itemDGV);
            this.Controls.Add(this.generalP);
            this.Name = "OrderConfirmItem";
            this.Size = new System.Drawing.Size(1173, 263);
            this.Load += new System.EventHandler(this.OrderConfirmItem_Load);
            this.generalP.ResumeLayout(false);
            this.generalP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).EndInit();
            this.footerP.ResumeLayout(false);
            this.footerP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel generalP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox expressTypeCB;
        private System.Windows.Forms.Button selectAddressB;
        private System.Windows.Forms.ComboBox districtCB;
        private System.Windows.Forms.ComboBox cityCB;
        private System.Windows.Forms.ComboBox provinceCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox zipCodeTB;
        private System.Windows.Forms.TextBox addressTB;
        private System.Windows.Forms.TextBox telTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton pickupRB;
        private System.Windows.Forms.RadioButton expressRB;
        private System.Windows.Forms.DataGridView itemDGV;
        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.Label itemTotalL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label freightL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label taxTotalL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn franchiseeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 减少;
    }
}
