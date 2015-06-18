namespace funsens.ui
{
    partial class TitlePanel
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
            this.titleL = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Panel();
            this.p.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleL
            // 
            this.titleL.AutoSize = true;
            this.titleL.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleL.Location = new System.Drawing.Point(6, 14);
            this.titleL.Name = "titleL";
            this.titleL.Size = new System.Drawing.Size(90, 21);
            this.titleL.TabIndex = 0;
            this.titleL.Text = "标题...";
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.SystemColors.Control;
            this.p.Controls.Add(this.titleL);
            this.p.Location = new System.Drawing.Point(0, 0);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(753, 49);
            this.p.TabIndex = 1;
            // 
            // TitlePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.p);
            this.Name = "TitlePanel";
            this.Size = new System.Drawing.Size(825, 50);
            this.Load += new System.EventHandler(this.TitlePanel_Load);
            this.SizeChanged += new System.EventHandler(this.TitlePanel_SizeChanged);
            this.p.ResumeLayout(false);
            this.p.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleL;
        private System.Windows.Forms.Panel p;
    }
}
