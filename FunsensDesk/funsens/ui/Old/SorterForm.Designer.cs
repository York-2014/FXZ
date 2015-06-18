namespace funsens.ui
{
    partial class SorterForm
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
            this.selectDeskP = new System.Windows.Forms.Panel();
            this.selectDeskGB = new System.Windows.Forms.GroupBox();
            this.serviceDeskCB = new System.Windows.Forms.ComboBox();
            this.selectB = new System.Windows.Forms.Button();
            this.orderDGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIdTB = new System.Windows.Forms.TextBox();
            this.generalGB = new System.Windows.Forms.GroupBox();
            this.packageB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hp = new HandlePanel();
            this.selectDeskP.SuspendLayout();
            this.selectDeskGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).BeginInit();
            this.generalGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectDeskP
            // 
            this.selectDeskP.Controls.Add(this.selectDeskGB);
            this.selectDeskP.Location = new System.Drawing.Point(12, 291);
            this.selectDeskP.Name = "selectDeskP";
            this.selectDeskP.Size = new System.Drawing.Size(414, 127);
            this.selectDeskP.TabIndex = 0;
            // 
            // selectDeskGB
            // 
            this.selectDeskGB.Controls.Add(this.serviceDeskCB);
            this.selectDeskGB.Controls.Add(this.selectB);
            this.selectDeskGB.Location = new System.Drawing.Point(25, 31);
            this.selectDeskGB.Name = "selectDeskGB";
            this.selectDeskGB.Size = new System.Drawing.Size(316, 72);
            this.selectDeskGB.TabIndex = 2;
            this.selectDeskGB.TabStop = false;
            // 
            // serviceDeskCB
            // 
            this.serviceDeskCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceDeskCB.FormattingEnabled = true;
            this.serviceDeskCB.Location = new System.Drawing.Point(20, 29);
            this.serviceDeskCB.Name = "serviceDeskCB";
            this.serviceDeskCB.Size = new System.Drawing.Size(156, 20);
            this.serviceDeskCB.TabIndex = 0;
            // 
            // selectB
            // 
            this.selectB.Location = new System.Drawing.Point(191, 29);
            this.selectB.Name = "selectB";
            this.selectB.Size = new System.Drawing.Size(107, 23);
            this.selectB.TabIndex = 1;
            this.selectB.Text = "选择服务窗口";
            this.selectB.UseVisualStyleBackColor = true;
            this.selectB.Click += new System.EventHandler(this.selectB_Click);
            // 
            // orderDGV
            // 
            this.orderDGV.AllowUserToAddRows = false;
            this.orderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.customerName,
            this.total,
            this.created});
            this.orderDGV.Location = new System.Drawing.Point(12, 135);
            this.orderDGV.Name = "orderDGV";
            this.orderDGV.RowTemplate.Height = 23;
            this.orderDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderDGV.Size = new System.Drawing.Size(742, 150);
            this.orderDGV.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "订单号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // customerName
            // 
            this.customerName.HeaderText = "客户姓名";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "订单金额";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // created
            // 
            this.created.HeaderText = "下单时间";
            this.created.Name = "created";
            this.created.ReadOnly = true;
            // 
            // orderIdTB
            // 
            this.orderIdTB.Location = new System.Drawing.Point(76, 22);
            this.orderIdTB.Name = "orderIdTB";
            this.orderIdTB.Size = new System.Drawing.Size(176, 21);
            this.orderIdTB.TabIndex = 3;
            this.orderIdTB.Text = "201504011312402";
            this.orderIdTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orderIdTB_KeyPress);
            // 
            // generalGB
            // 
            this.generalGB.Controls.Add(this.packageB);
            this.generalGB.Controls.Add(this.label1);
            this.generalGB.Controls.Add(this.orderIdTB);
            this.generalGB.Location = new System.Drawing.Point(12, 22);
            this.generalGB.Name = "generalGB";
            this.generalGB.Size = new System.Drawing.Size(707, 57);
            this.generalGB.TabIndex = 4;
            this.generalGB.TabStop = false;
            // 
            // packageB
            // 
            this.packageB.Location = new System.Drawing.Point(269, 20);
            this.packageB.Name = "packageB";
            this.packageB.Size = new System.Drawing.Size(75, 23);
            this.packageB.TabIndex = 5;
            this.packageB.Text = "打包完成";
            this.packageB.UseVisualStyleBackColor = true;
            this.packageB.Click += new System.EventHandler(this.packageB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "订单号：";
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(497, 313);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(200, 81);
            this.hp.TabIndex = 5;
            // 
            // SorterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 430);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.generalGB);
            this.Controls.Add(this.orderDGV);
            this.Controls.Add(this.selectDeskP);
            this.Name = "SorterForm";
            this.Text = "服务窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ServiceDesk_Load);
            this.SizeChanged += new System.EventHandler(this.ServiceDesk_SizeChanged);
            this.selectDeskP.ResumeLayout(false);
            this.selectDeskGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).EndInit();
            this.generalGB.ResumeLayout(false);
            this.generalGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel selectDeskP;
        private System.Windows.Forms.Button selectB;
        private System.Windows.Forms.ComboBox serviceDeskCB;
        private System.Windows.Forms.GroupBox selectDeskGB;
        private System.Windows.Forms.DataGridView orderDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.TextBox orderIdTB;
        private System.Windows.Forms.GroupBox generalGB;
        private System.Windows.Forms.Button packageB;
        private System.Windows.Forms.Label label1;
        private HandlePanel hp;
    }
}