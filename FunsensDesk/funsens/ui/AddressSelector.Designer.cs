namespace funsens.ui
{
    partial class AddressSelector
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
            this.addressDGV = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.邮编 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.footerP = new System.Windows.Forms.Panel();
            this.cancelB = new System.Windows.Forms.Button();
            this.selectB = new System.Windows.Forms.Button();
            this.hp = new funsens.ui.HandlePanel();
            ((System.ComponentModel.ISupportInitialize)(this.addressDGV)).BeginInit();
            this.footerP.SuspendLayout();
            this.SuspendLayout();
            // 
            // addressDGV
            // 
            this.addressDGV.AllowUserToAddRows = false;
            this.addressDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.addressDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addressDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.tel,
            this.address,
            this.邮编});
            this.addressDGV.Location = new System.Drawing.Point(3, 68);
            this.addressDGV.Name = "addressDGV";
            this.addressDGV.RowTemplate.Height = 23;
            this.addressDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.addressDGV.Size = new System.Drawing.Size(702, 150);
            this.addressDGV.TabIndex = 0;
            this.addressDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addressDGV_CellDoubleClick);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // tel
            // 
            this.tel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tel.HeaderText = "电话";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            // 
            // address
            // 
            this.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.address.FillWeight = 500F;
            this.address.HeaderText = "地址";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // 邮编
            // 
            this.邮编.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.邮编.HeaderText = "邮编";
            this.邮编.Name = "邮编";
            this.邮编.Width = 80;
            // 
            // footerP
            // 
            this.footerP.Controls.Add(this.cancelB);
            this.footerP.Controls.Add(this.selectB);
            this.footerP.Location = new System.Drawing.Point(255, 12);
            this.footerP.Name = "footerP";
            this.footerP.Size = new System.Drawing.Size(450, 50);
            this.footerP.TabIndex = 1;
            // 
            // cancelB
            // 
            this.cancelB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelB.Location = new System.Drawing.Point(337, 4);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(100, 40);
            this.cancelB.TabIndex = 1;
            this.cancelB.Text = "取消";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // selectB
            // 
            this.selectB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectB.Location = new System.Drawing.Point(193, 4);
            this.selectB.Name = "selectB";
            this.selectB.Size = new System.Drawing.Size(100, 40);
            this.selectB.TabIndex = 0;
            this.selectB.Text = "选择";
            this.selectB.UseVisualStyleBackColor = true;
            this.selectB.Click += new System.EventHandler(this.selectB_Click);
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.Color.Bisque;
            this.hp.Location = new System.Drawing.Point(34, 12);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(196, 44);
            this.hp.TabIndex = 12;
            // 
            // AddressSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hp);
            this.Controls.Add(this.footerP);
            this.Controls.Add(this.addressDGV);
            this.Name = "AddressSelector";
            this.Size = new System.Drawing.Size(729, 234);
            this.Load += new System.EventHandler(this.AddressSelector_Load);
            this.SizeChanged += new System.EventHandler(this.AddressSelector_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.addressDGV)).EndInit();
            this.footerP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView addressDGV;
        private System.Windows.Forms.Panel footerP;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button selectB;
        private global::funsens.ui.HandlePanel hp;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn 邮编;
    }
}
