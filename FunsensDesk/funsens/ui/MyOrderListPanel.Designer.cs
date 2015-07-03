namespace funsens.ui
{
    partial class MyOrderListPanel
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
            this.itemDGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.顾客 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay = new System.Windows.Forms.DataGridViewButtonColumn();
            this.operation = new System.Windows.Forms.DataGridViewButtonColumn();
            this.print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.prePageB = new System.Windows.Forms.Button();
            this.nextPageB = new System.Windows.Forms.Button();
            this.pageNoL = new System.Windows.Forms.Label();
            this.titleP = new funsens.ui.TitlePanel();
            this.hp = new funsens.ui.HandlePanel();
            this.footerP = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).BeginInit();
            this.footerP.SuspendLayout();
            this.SuspendLayout();
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
            this.id,
            this.顾客,
            this.total,
            this.created,
            this.status,
            this.pay,
            this.operation,
            this.print});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemDGV.Location = new System.Drawing.Point(3, 64);
            this.itemDGV.Name = "itemDGV";
            this.itemDGV.ReadOnly = true;
            this.itemDGV.RowTemplate.Height = 23;
            this.itemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDGV.Size = new System.Drawing.Size(672, 264);
            this.itemDGV.TabIndex = 0;
            this.itemDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDGV_CellContentClick);
            this.itemDGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.itemDGV_RowPrePaint);
            this.itemDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemDGV_KeyDown);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "订单号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // 顾客
            // 
            this.顾客.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.顾客.HeaderText = "顾客";
            this.顾客.Name = "顾客";
            this.顾客.ReadOnly = true;
            this.顾客.Width = 80;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.FillWeight = 50F;
            this.total.HeaderText = "订单金额";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // created
            // 
            this.created.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.created.HeaderText = "下单日期";
            this.created.Name = "created";
            this.created.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.FillWeight = 50F;
            this.status.HeaderText = "订单状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // pay
            // 
            this.pay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pay.HeaderText = "支付";
            this.pay.Name = "pay";
            this.pay.ReadOnly = true;
            this.pay.Width = 50;
            // 
            // operation
            // 
            this.operation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.operation.FillWeight = 126.9036F;
            this.operation.HeaderText = "详情";
            this.operation.Name = "operation";
            this.operation.ReadOnly = true;
            this.operation.Width = 50;
            // 
            // print
            // 
            this.print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.print.HeaderText = "打印";
            this.print.Name = "print";
            this.print.ReadOnly = true;
            this.print.Width = 50;
            // 
            // prePageB
            // 
            this.prePageB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prePageB.Location = new System.Drawing.Point(29, 13);
            this.prePageB.Name = "prePageB";
            this.prePageB.Size = new System.Drawing.Size(85, 28);
            this.prePageB.TabIndex = 3;
            this.prePageB.Text = "上一页";
            this.prePageB.UseVisualStyleBackColor = true;
            this.prePageB.Click += new System.EventHandler(this.prePageB_Click);
            // 
            // nextPageB
            // 
            this.nextPageB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextPageB.Location = new System.Drawing.Point(188, 12);
            this.nextPageB.Name = "nextPageB";
            this.nextPageB.Size = new System.Drawing.Size(97, 29);
            this.nextPageB.TabIndex = 4;
            this.nextPageB.Text = "下一页";
            this.nextPageB.UseVisualStyleBackColor = true;
            this.nextPageB.Click += new System.EventHandler(this.nextPageB_Click);
            // 
            // pageNoL
            // 
            this.pageNoL.AutoSize = true;
            this.pageNoL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageNoL.Location = new System.Drawing.Point(145, 19);
            this.pageNoL.Name = "pageNoL";
            this.pageNoL.Size = new System.Drawing.Size(17, 16);
            this.pageNoL.TabIndex = 5;
            this.pageNoL.Text = "0";
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(3, 0);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(669, 58);
            this.titleP.TabIndex = 2;
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(476, 426);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(186, 56);
            this.hp.TabIndex = 1;
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.pageNoL);
            this.footerP.Controls.Add(this.prePageB);
            this.footerP.Controls.Add(this.nextPageB);
            this.footerP.Location = new System.Drawing.Point(337, 3);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(308, 50);
            this.footerP.TabIndex = 6;
            // 
            // MyOrderListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.footerP);
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.itemDGV);
            this.Name = "MyOrderListPanel";
            this.Size = new System.Drawing.Size(690, 499);
            this.Load += new System.EventHandler(this.PickUpOrderListPanel_Load);
            this.SizeChanged += new System.EventHandler(this.PickUpOrderListPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.itemDGV)).EndInit();
            this.footerP.ResumeLayout(false);
            this.footerP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView itemDGV;
        private HandlePanel hp;
        private TitlePanel titleP;
        private System.Windows.Forms.Button prePageB;
        private System.Windows.Forms.Button nextPageB;
        private System.Windows.Forms.Label pageNoL;
        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 顾客;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn pay;
        private System.Windows.Forms.DataGridViewButtonColumn operation;
        private System.Windows.Forms.DataGridViewButtonColumn print;
    }
}
