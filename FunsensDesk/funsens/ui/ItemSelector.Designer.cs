namespace funsens.ui
{
    partial class ItemSelector
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
            this.itemDGV = new System.Windows.Forms.DataGridView();
            this.cancelB = new System.Windows.Forms.Button();
            this.titleP = new funsens.ui.TitlePanel();
            this.条形码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.franchiseeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // itemDGV
            // 
            this.itemDGV.AllowUserToAddRows = false;
            this.itemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.条形码,
            this.franchiseeName,
            this.name,
            this.price});
            this.itemDGV.Location = new System.Drawing.Point(12, 89);
            this.itemDGV.Name = "itemDGV";
            this.itemDGV.RowTemplate.Height = 23;
            this.itemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDGV.Size = new System.Drawing.Size(799, 258);
            this.itemDGV.TabIndex = 0;
            this.itemDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDGV_CellDoubleClick);
            // 
            // cancelB
            // 
            this.cancelB.Location = new System.Drawing.Point(711, 353);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(100, 40);
            this.cancelB.TabIndex = 2;
            this.cancelB.Text = "取消";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(3, 3);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(815, 50);
            this.titleP.TabIndex = 3;
            // 
            // 条形码
            // 
            this.条形码.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.条形码.HeaderText = "条形码";
            this.条形码.Name = "条形码";
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
            this.name.HeaderText = "商品名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price.HeaderText = "价格";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // ItemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.itemDGV);
            this.Name = "ItemSelector";
            this.Size = new System.Drawing.Size(821, 405);
            this.Load += new System.EventHandler(this.ItemSelector_Load);
            this.SizeChanged += new System.EventHandler(this.ItemSelector_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView itemDGV;
        private System.Windows.Forms.Button cancelB;
        private TitlePanel titleP;
        private System.Windows.Forms.DataGridViewTextBoxColumn 条形码;
        private System.Windows.Forms.DataGridViewTextBoxColumn franchiseeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
    }
}
