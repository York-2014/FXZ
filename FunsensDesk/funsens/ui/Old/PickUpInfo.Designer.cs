namespace funsens.ui
{
    partial class PickUpInfo
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
            this.components = new System.ComponentModel.Container();
            this.t = new System.Windows.Forms.Timer(this.components);
            this.hp = new HandlePanel();
            this.orderDGV2 = new PickUpInfoOrderDGV();
            this.orderDGV1 = new PickUpInfoOrderDGV();
            this.SuspendLayout();
            // 
            // t
            // 
            this.t.Enabled = true;
            this.t.Interval = 12000;
            this.t.Tick += new System.EventHandler(this.t_Tick);
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(950, 325);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(297, 115);
            this.hp.TabIndex = 2;
            // 
            // orderDGV2
            // 
            this.orderDGV2.Location = new System.Drawing.Point(679, 12);
            this.orderDGV2.Name = "orderDGV2";
            this.orderDGV2.Size = new System.Drawing.Size(657, 259);
            this.orderDGV2.TabIndex = 1;
            // 
            // orderDGV1
            // 
            this.orderDGV1.Location = new System.Drawing.Point(12, 12);
            this.orderDGV1.Name = "orderDGV1";
            this.orderDGV1.Size = new System.Drawing.Size(661, 259);
            this.orderDGV1.TabIndex = 0;
            // 
            // PickUpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 484);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.orderDGV2);
            this.Controls.Add(this.orderDGV1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PickUpInfo";
            this.Text = "PickUpInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PickUpInfo_Load);
            this.SizeChanged += new System.EventHandler(this.PickUpInfo_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private PickUpInfoOrderDGV orderDGV1;
        private PickUpInfoOrderDGV orderDGV2;
        private System.Windows.Forms.Timer t;
        private HandlePanel hp;
    }
}