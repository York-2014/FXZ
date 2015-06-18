namespace funsens.ui
{
    partial class MenuItem
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
            this.l = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l.ForeColor = System.Drawing.Color.White;
            this.l.Location = new System.Drawing.Point(160, 164);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(76, 21);
            this.l.TabIndex = 0;
            this.l.Text = "label1";
            // 
            // pb
            // 
            this.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb.Location = new System.Drawing.Point(162, 90);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 50);
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.pb);
            this.Controls.Add(this.l);
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(393, 239);
            this.Load += new System.EventHandler(this.MenuItem_Load);
            this.SizeChanged += new System.EventHandler(this.MenuItem_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuItem_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label l;
        public System.Windows.Forms.PictureBox pb;
    }
}
