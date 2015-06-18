namespace funsens.ui
{
    partial class MyOrderDetailsPanel
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
            this.footerP = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.itemCountL = new System.Windows.Forms.Label();
            this.totalL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveB = new System.Windows.Forms.Button();
            this.itemDGV = new System.Windows.Forms.DataGridView();
            this._barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.franchiseeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hp = new funsens.ui.HandlePanel();
            this.titleP = new funsens.ui.TitlePanel();
            this.footerP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.label4);
            this.footerP.Controls.Add(this.label3);
            this.footerP.Controls.Add(this.label5);
            this.footerP.Controls.Add(this.itemCountL);
            this.footerP.Controls.Add(this.totalL);
            this.footerP.Controls.Add(this.label2);
            this.footerP.Controls.Add(this.label1);
            this.footerP.Controls.Add(this.saveB);
            this.footerP.Location = new System.Drawing.Point(3, 346);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(721, 62);
            this.footerP.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(479, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "￥0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(414, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "总计：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(320, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "+";
            // 
            // itemCountL
            // 
            this.itemCountL.AutoSize = true;
            this.itemCountL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemCountL.Location = new System.Drawing.Point(118, 25);
            this.itemCountL.Name = "itemCountL";
            this.itemCountL.Size = new System.Drawing.Size(20, 19);
            this.itemCountL.TabIndex = 4;
            this.itemCountL.Text = "0";
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalL.Location = new System.Drawing.Point(241, 25);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(73, 19);
            this.totalL.TabIndex = 3;
            this.totalL.Text = "￥0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(181, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "合计：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品数量：";
            // 
            // saveB
            // 
            this.saveB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveB.Location = new System.Drawing.Point(596, 15);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(100, 40);
            this.saveB.TabIndex = 0;
            this.saveB.Text = "返回";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
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
            this._barcode,
            this.franchiseeName,
            this.name,
            this.price,
            this.tax,
            this.amount,
            this.total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemDGV.Location = new System.Drawing.Point(3, 123);
            this.itemDGV.Name = "itemDGV";
            this.itemDGV.ReadOnly = true;
            this.itemDGV.RowTemplate.Height = 23;
            this.itemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDGV.Size = new System.Drawing.Size(721, 217);
            this.itemDGV.TabIndex = 1;
            this.itemDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemDGV_KeyDown);
            // 
            // _barcode
            // 
            this._barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._barcode.HeaderText = "条形码";
            this._barcode.Name = "_barcode";
            this._barcode.ReadOnly = true;
            this._barcode.Width = 130;
            // 
            // franchiseeName
            // 
            this.franchiseeName.HeaderText = "商家名称";
            this.franchiseeName.Name = "franchiseeName";
            this.franchiseeName.ReadOnly = true;
            // 
            // name
            // 
            this.name.FillWeight = 200F;
            this.name.HeaderText = "商品名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.price.FillWeight = 36.08247F;
            this.price.HeaderText = "商品单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // tax
            // 
            this.tax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tax.FillWeight = 36.08247F;
            this.tax.HeaderText = "进口税";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.amount.FillWeight = 36.08247F;
            this.amount.HeaderText = "数量";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.total.FillWeight = 36.08247F;
            this.total.HeaderText = "小计（未税）";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 120;
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(17, 414);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(174, 77);
            this.hp.TabIndex = 2;
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(17, 17);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(692, 50);
            this.titleP.TabIndex = 3;
            // 
            // MyOrderDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.itemDGV);
            this.Controls.Add(this.footerP);
            this.Name = "MyOrderDetailsPanel";
            this.Size = new System.Drawing.Size(732, 504);
            this.Load += new System.EventHandler(this.PickUpOrderDetailsPanel_Load);
            this.SizeChanged += new System.EventHandler(this.PickUpOrderDetailsPanel_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.PickUpOrderDetailsPanel_VisibleChanged);
            this.footerP.ResumeLayout(false);
            this.footerP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.Label itemCountL;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.DataGridView itemDGV;
        private HandlePanel hp;
        private TitlePanel titleP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn _barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn franchiseeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}
