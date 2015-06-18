namespace funsens.ui
{
    partial class AddOrderPayPanel
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
            this.orderDGV = new System.Windows.Forms.DataGridView();
            this.footerP = new System.Windows.Forms.Panel();
            this.unPayTaxL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hp = new funsens.ui.HandlePanel();
            this.titleP = new funsens.ui.TitlePanel();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay = new System.Windows.Forms.DataGridViewButtonColumn();
            this.receipt = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).BeginInit();
            this.footerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderDGV
            // 
            this.orderDGV.AllowUserToAddRows = false;
            this.orderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.customerName,
            this.payment,
            this.status,
            this.pay,
            this.receipt});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderDGV.Location = new System.Drawing.Point(14, 104);
            this.orderDGV.Name = "orderDGV";
            this.orderDGV.RowTemplate.Height = 23;
            this.orderDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderDGV.Size = new System.Drawing.Size(834, 313);
            this.orderDGV.TabIndex = 0;
            this.orderDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderDGV_CellContentClick);
            this.orderDGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.orderDGV_RowPrePaint);
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.unPayTaxL);
            this.footerP.Controls.Add(this.label1);
            this.footerP.Location = new System.Drawing.Point(627, 434);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(221, 50);
            this.footerP.TabIndex = 3;
            // 
            // unPayTaxL
            // 
            this.unPayTaxL.AutoSize = true;
            this.unPayTaxL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unPayTaxL.Location = new System.Drawing.Point(139, 20);
            this.unPayTaxL.Name = "unPayTaxL";
            this.unPayTaxL.Size = new System.Drawing.Size(61, 16);
            this.unPayTaxL.TabIndex = 1;
            this.unPayTaxL.Text = "￥0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "今日未交税费：";
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(14, 423);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(374, 95);
            this.hp.TabIndex = 2;
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(23, 30);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(825, 50);
            this.titleP.TabIndex = 1;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.id.HeaderText = "订单号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 200;
            // 
            // customerName
            // 
            this.customerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerName.HeaderText = "付款人";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // payment
            // 
            this.payment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.payment.HeaderText = "应付金额";
            this.payment.Name = "payment";
            this.payment.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // pay
            // 
            this.pay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pay.HeaderText = "支付";
            this.pay.Name = "pay";
            this.pay.Width = 60;
            // 
            // receipt
            // 
            this.receipt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.receipt.HeaderText = "小票";
            this.receipt.Name = "receipt";
            this.receipt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.receipt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.receipt.Width = 70;
            // 
            // AddOrderPayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.footerP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.orderDGV);
            this.Name = "AddOrderPayPanel";
            this.Size = new System.Drawing.Size(971, 525);
            this.Load += new System.EventHandler(this.AddOrderPayPanel_Load);
            this.SizeChanged += new System.EventHandler(this.AddOrderPayPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).EndInit();
            this.footerP.ResumeLayout(false);
            this.footerP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView orderDGV;
        private global::funsens.ui.TitlePanel titleP;
        private global::funsens.ui.HandlePanel hp;
        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.Label unPayTaxL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn pay;
        private System.Windows.Forms.DataGridViewButtonColumn receipt;
    }
}
