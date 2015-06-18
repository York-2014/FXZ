namespace instock
{
    partial class InStockForm
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
            this.generalGB = new System.Windows.Forms.GroupBox();
            this.customerNameL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inStockB = new System.Windows.Forms.Button();
            this.shelfIdTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.orderIdTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shelfGB = new System.Windows.Forms.GroupBox();
            this.shelfDGV = new System.Windows.Forms.DataGridView();
            this.shelfName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderGB = new System.Windows.Forms.GroupBox();
            this.orderDGV = new System.Windows.Forms.DataGridView();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generalGB.SuspendLayout();
            this.shelfGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shelfDGV)).BeginInit();
            this.orderGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // generalGB
            // 
            this.generalGB.Controls.Add(this.customerNameL);
            this.generalGB.Controls.Add(this.label3);
            this.generalGB.Controls.Add(this.inStockB);
            this.generalGB.Controls.Add(this.shelfIdTB);
            this.generalGB.Controls.Add(this.label2);
            this.generalGB.Controls.Add(this.orderIdTB);
            this.generalGB.Controls.Add(this.label1);
            this.generalGB.Location = new System.Drawing.Point(12, 2);
            this.generalGB.Name = "generalGB";
            this.generalGB.Size = new System.Drawing.Size(882, 62);
            this.generalGB.TabIndex = 0;
            this.generalGB.TabStop = false;
            // 
            // customerNameL
            // 
            this.customerNameL.AutoSize = true;
            this.customerNameL.Location = new System.Drawing.Point(309, 28);
            this.customerNameL.Name = "customerNameL";
            this.customerNameL.Size = new System.Drawing.Size(11, 12);
            this.customerNameL.TabIndex = 7;
            this.customerNameL.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "客户姓名：";
            // 
            // inStockB
            // 
            this.inStockB.Location = new System.Drawing.Point(660, 18);
            this.inStockB.Name = "inStockB";
            this.inStockB.Size = new System.Drawing.Size(75, 33);
            this.inStockB.TabIndex = 5;
            this.inStockB.Text = "入库";
            this.inStockB.UseVisualStyleBackColor = true;
            this.inStockB.Click += new System.EventHandler(this.inStockB_Click);
            // 
            // shelfIdTB
            // 
            this.shelfIdTB.Location = new System.Drawing.Point(505, 25);
            this.shelfIdTB.Name = "shelfIdTB";
            this.shelfIdTB.ReadOnly = true;
            this.shelfIdTB.Size = new System.Drawing.Size(129, 21);
            this.shelfIdTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货架：";
            // 
            // orderIdTB
            // 
            this.orderIdTB.Location = new System.Drawing.Point(73, 25);
            this.orderIdTB.Name = "orderIdTB";
            this.orderIdTB.Size = new System.Drawing.Size(135, 21);
            this.orderIdTB.TabIndex = 1;
            this.orderIdTB.Text = "201504011312402";
            this.orderIdTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderIdTB_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号：";
            // 
            // shelfGB
            // 
            this.shelfGB.Controls.Add(this.shelfDGV);
            this.shelfGB.Location = new System.Drawing.Point(12, 82);
            this.shelfGB.Name = "shelfGB";
            this.shelfGB.Size = new System.Drawing.Size(312, 539);
            this.shelfGB.TabIndex = 1;
            this.shelfGB.TabStop = false;
            this.shelfGB.Text = "货架列表";
            // 
            // shelfDGV
            // 
            this.shelfDGV.AllowUserToAddRows = false;
            this.shelfDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shelfDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shelfDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shelfName,
            this.status,
            this.handle});
            this.shelfDGV.Location = new System.Drawing.Point(20, 32);
            this.shelfDGV.Name = "shelfDGV";
            this.shelfDGV.RowTemplate.Height = 23;
            this.shelfDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shelfDGV.Size = new System.Drawing.Size(276, 487);
            this.shelfDGV.TabIndex = 0;
            this.shelfDGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.shelfDGV_CellMouseClick);
            // 
            // shelfName
            // 
            this.shelfName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shelfName.HeaderText = "货架名称";
            this.shelfName.Name = "shelfName";
            this.shelfName.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.HeaderText = "货架状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // handle
            // 
            this.handle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.handle.HeaderText = "操作";
            this.handle.Name = "handle";
            this.handle.Width = 50;
            // 
            // orderGB
            // 
            this.orderGB.Controls.Add(this.orderDGV);
            this.orderGB.Location = new System.Drawing.Point(350, 82);
            this.orderGB.Name = "orderGB";
            this.orderGB.Size = new System.Drawing.Size(544, 539);
            this.orderGB.TabIndex = 2;
            this.orderGB.TabStop = false;
            this.orderGB.Text = "订单列表";
            // 
            // orderDGV
            // 
            this.orderDGV.AllowUserToAddRows = false;
            this.orderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderId,
            this.customerName,
            this.dataGridViewTextBoxColumn1});
            this.orderDGV.Location = new System.Drawing.Point(18, 32);
            this.orderDGV.Name = "orderDGV";
            this.orderDGV.RowTemplate.Height = 23;
            this.orderDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderDGV.Size = new System.Drawing.Size(506, 487);
            this.orderDGV.TabIndex = 1;
            // 
            // orderId
            // 
            this.orderId.HeaderText = "订单号";
            this.orderId.Name = "orderId";
            this.orderId.ReadOnly = true;
            // 
            // customerName
            // 
            this.customerName.HeaderText = "收货人";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "货架名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // InStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 633);
            this.Controls.Add(this.orderGB);
            this.Controls.Add(this.shelfGB);
            this.Controls.Add(this.generalGB);
            this.Name = "InStockForm";
            this.Text = "风信子 - 入库平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InStockForm_Load);
            this.SizeChanged += new System.EventHandler(this.InStockForm_SizeChanged);
            this.generalGB.ResumeLayout(false);
            this.generalGB.PerformLayout();
            this.shelfGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shelfDGV)).EndInit();
            this.orderGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalGB;
        private System.Windows.Forms.Button inStockB;
        private System.Windows.Forms.TextBox shelfIdTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox orderIdTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox shelfGB;
        private System.Windows.Forms.GroupBox orderGB;
        private System.Windows.Forms.DataGridView shelfDGV;
        private System.Windows.Forms.DataGridView orderDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label customerNameL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn shelfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn handle;
    }
}