namespace funsens.ui
{
    partial class AddOrderPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barcodeTB = new System.Windows.Forms.TextBox();
            this.addItemB = new System.Windows.Forms.Button();
            this.itemDGV = new System.Windows.Forms.DataGridView();
            this.addOrderB = new System.Windows.Forms.Button();
            this.footerP = new System.Windows.Forms.Panel();
            this.totalL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.itemTotalL = new System.Windows.Forms.Label();
            this.itemCountL = new System.Windows.Forms.Label();
            this.hp = new funsens.ui.HandlePanel();
            this.titleP = new funsens.ui.TitlePanel();
            this.franchiseeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtractAmount = new System.Windows.Forms.DataGridViewButtonColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addAmount = new System.Windows.Forms.DataGridViewButtonColumn();
            this.剩余库存 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).BeginInit();
            this.footerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // barcodeTB
            // 
            this.barcodeTB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barcodeTB.Location = new System.Drawing.Point(8, 67);
            this.barcodeTB.Name = "barcodeTB";
            this.barcodeTB.Size = new System.Drawing.Size(283, 29);
            this.barcodeTB.TabIndex = 0;
            this.barcodeTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barcodeTB_KeyDown);
            // 
            // addItemB
            // 
            this.addItemB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addItemB.Location = new System.Drawing.Point(314, 67);
            this.addItemB.Name = "addItemB";
            this.addItemB.Size = new System.Drawing.Size(119, 29);
            this.addItemB.TabIndex = 1;
            this.addItemB.Text = "添加商品";
            this.addItemB.UseVisualStyleBackColor = true;
            this.addItemB.Click += new System.EventHandler(this.addItemB_Click);
            // 
            // itemDGV
            // 
            this.itemDGV.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.itemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.franchiseeName,
            this.name,
            this.price,
            this.tax,
            this.subtractAmount,
            this.amount,
            this.addAmount,
            this.剩余库存});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDGV.DefaultCellStyle = dataGridViewCellStyle4;
            this.itemDGV.Location = new System.Drawing.Point(8, 102);
            this.itemDGV.Name = "itemDGV";
            this.itemDGV.RowTemplate.Height = 23;
            this.itemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDGV.Size = new System.Drawing.Size(756, 207);
            this.itemDGV.TabIndex = 2;
            this.itemDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDGV_CellContentClick);
            this.itemDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDGV_CellValueChanged);
            this.itemDGV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.itemDGV_RowsRemoved);
            // 
            // addOrderB
            // 
            this.addOrderB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addOrderB.Location = new System.Drawing.Point(543, 13);
            this.addOrderB.Name = "addOrderB";
            this.addOrderB.Size = new System.Drawing.Size(100, 40);
            this.addOrderB.TabIndex = 3;
            this.addOrderB.Text = "结算";
            this.addOrderB.UseVisualStyleBackColor = true;
            this.addOrderB.Click += new System.EventHandler(this.addOrderB_Click);
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.totalL);
            this.footerP.Controls.Add(this.label1);
            this.footerP.Controls.Add(this.label5);
            this.footerP.Controls.Add(this.label4);
            this.footerP.Controls.Add(this.itemTotalL);
            this.footerP.Controls.Add(this.itemCountL);
            this.footerP.Controls.Add(this.addOrderB);
            this.footerP.Location = new System.Drawing.Point(8, 315);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(716, 63);
            this.footerP.TabIndex = 4;
            // 
            // totalL
            // 
            this.totalL.AutoSize = true;
            this.totalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalL.Location = new System.Drawing.Point(466, 21);
            this.totalL.Name = "totalL";
            this.totalL.Size = new System.Drawing.Size(62, 19);
            this.totalL.TabIndex = 11;
            this.totalL.Text = "￥0.0";
            this.totalL.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(416, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "合计：";
            this.label1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(34, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "商品数量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(219, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "商品总价：";
            // 
            // itemTotalL
            // 
            this.itemTotalL.AutoSize = true;
            this.itemTotalL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemTotalL.Location = new System.Drawing.Point(334, 21);
            this.itemTotalL.Name = "itemTotalL";
            this.itemTotalL.Size = new System.Drawing.Size(62, 19);
            this.itemTotalL.TabIndex = 6;
            this.itemTotalL.Text = "￥0.0";
            // 
            // itemCountL
            // 
            this.itemCountL.AutoSize = true;
            this.itemCountL.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemCountL.Location = new System.Drawing.Point(149, 21);
            this.itemCountL.Name = "itemCountL";
            this.itemCountL.Size = new System.Drawing.Size(20, 19);
            this.itemCountL.TabIndex = 4;
            this.itemCountL.Text = "0";
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(515, 384);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(209, 80);
            this.hp.TabIndex = 6;
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(3, 0);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(761, 50);
            this.titleP.TabIndex = 5;
            // 
            // franchiseeName
            // 
            this.franchiseeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.franchiseeName.HeaderText = "商家名称";
            this.franchiseeName.Name = "franchiseeName";
            this.franchiseeName.ReadOnly = true;
            this.franchiseeName.Width = 180;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "商品名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.price.Width = 80;
            // 
            // tax
            // 
            this.tax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tax.HeaderText = "税率";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            this.tax.Width = 80;
            // 
            // subtractAmount
            // 
            this.subtractAmount.HeaderText = "";
            this.subtractAmount.Name = "subtractAmount";
            this.subtractAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subtractAmount.Width = 80;
            // 
            // amount
            // 
            this.amount.HeaderText = "数量";
            this.amount.Name = "amount";
            this.amount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.amount.Width = 80;
            // 
            // addAmount
            // 
            this.addAmount.HeaderText = "";
            this.addAmount.Name = "addAmount";
            this.addAmount.ReadOnly = true;
            this.addAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.addAmount.Width = 80;
            // 
            // 剩余库存
            // 
            this.剩余库存.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.剩余库存.HeaderText = "剩余库存";
            this.剩余库存.Name = "剩余库存";
            // 
            // AddOrderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.hp);
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.footerP);
            this.Controls.Add(this.itemDGV);
            this.Controls.Add(this.addItemB);
            this.Controls.Add(this.barcodeTB);
            this.Name = "AddOrderPanel";
            this.Size = new System.Drawing.Size(794, 477);
            this.Load += new System.EventHandler(this.AddOrderPanel_Load);
            this.SizeChanged += new System.EventHandler(this.AddOrderPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).EndInit();
            this.footerP.ResumeLayout(false);
            this.footerP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox barcodeTB;
        private System.Windows.Forms.Button addItemB;
        private System.Windows.Forms.DataGridView itemDGV;
        private System.Windows.Forms.Button addOrderB;
        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.Label totalL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label itemTotalL;
        private System.Windows.Forms.Label itemCountL;
        private TitlePanel titleP;
        private HandlePanel hp;
        private System.Windows.Forms.DataGridViewTextBoxColumn franchiseeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewButtonColumn subtractAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewButtonColumn addAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn 剩余库存;
    }
}
