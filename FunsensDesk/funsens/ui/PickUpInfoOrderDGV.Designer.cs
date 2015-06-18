namespace funsens.ui
{
    partial class PickUpInfoOrderDGV
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
            this.orderDGV = new System.Windows.Forms.DataGridView();
            this.t = new System.Windows.Forms.Timer(this.components);
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // orderDGV
            // 
            this.orderDGV.AllowUserToAddRows = false;
            this.orderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerName,
            this.serviceNo});
            this.orderDGV.Location = new System.Drawing.Point(12, 14);
            this.orderDGV.Name = "orderDGV";
            this.orderDGV.RowTemplate.Height = 23;
            this.orderDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderDGV.Size = new System.Drawing.Size(630, 232);
            this.orderDGV.TabIndex = 0;
            // 
            // t
            // 
            this.t.Enabled = true;
            this.t.Interval = 10000;
            this.t.Tick += new System.EventHandler(this.t_Tick);
            // 
            // customerName
            // 
            this.customerName.HeaderText = "客户姓名";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // serviceNo
            // 
            this.serviceNo.HeaderText = "提货台";
            this.serviceNo.Name = "serviceNo";
            this.serviceNo.ReadOnly = true;
            // 
            // PickUpInfoOrderDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.orderDGV);
            this.Name = "PickUpInfoOrderDGV";
            this.Size = new System.Drawing.Size(657, 259);
            this.Load += new System.EventHandler(this.PickUpInfoOrderDGV_Load);
            this.SizeChanged += new System.EventHandler(this.PickUpInfoOrderDGV_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView orderDGV;
        private System.Windows.Forms.Timer t;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceNo;
    }
}
