namespace funsens.ui
{
    partial class SignInPanel
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
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordL = new System.Windows.Forms.Label();
            this.telL = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.telTB = new System.Windows.Forms.TextBox();
            this.signUpB = new System.Windows.Forms.Button();
            this.signInB = new System.Windows.Forms.Button();
            this.titleP = new funsens.ui.TitlePanel();
            this.hp = new funsens.ui.HandlePanel();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.passwordL);
            this.gb1.Controls.Add(this.telL);
            this.gb1.Controls.Add(this.passwordTB);
            this.gb1.Controls.Add(this.telTB);
            this.gb1.Controls.Add(this.signUpB);
            this.gb1.Controls.Add(this.signInB);
            this.gb1.Location = new System.Drawing.Point(123, 127);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(509, 240);
            this.gb1.TabIndex = 10;
            this.gb1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "请刷身份证或填写手机号码进行登录";
            // 
            // passwordL
            // 
            this.passwordL.AutoSize = true;
            this.passwordL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordL.Location = new System.Drawing.Point(97, 90);
            this.passwordL.Name = "passwordL";
            this.passwordL.Size = new System.Drawing.Size(56, 16);
            this.passwordL.TabIndex = 10;
            this.passwordL.Text = "密码：";
            // 
            // telL
            // 
            this.telL.AutoSize = true;
            this.telL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.telL.Location = new System.Drawing.Point(65, 47);
            this.telL.Name = "telL";
            this.telL.Size = new System.Drawing.Size(88, 16);
            this.telL.TabIndex = 11;
            this.telL.Text = "手机号码：";
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("宋体", 12F);
            this.passwordTB.Location = new System.Drawing.Point(159, 86);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(295, 26);
            this.passwordTB.TabIndex = 2;
            // 
            // telTB
            // 
            this.telTB.Font = new System.Drawing.Font("宋体", 12F);
            this.telTB.Location = new System.Drawing.Point(159, 43);
            this.telTB.MaxLength = 11;
            this.telTB.Name = "telTB";
            this.telTB.Size = new System.Drawing.Size(295, 26);
            this.telTB.TabIndex = 1;
            // 
            // signUpB
            // 
            this.signUpB.Location = new System.Drawing.Point(384, 132);
            this.signUpB.Name = "signUpB";
            this.signUpB.Size = new System.Drawing.Size(70, 45);
            this.signUpB.TabIndex = 4;
            this.signUpB.Text = "注册";
            this.signUpB.UseVisualStyleBackColor = true;
            this.signUpB.Click += new System.EventHandler(this.signUpB_Click);
            // 
            // signInB
            // 
            this.signInB.Font = new System.Drawing.Font("宋体", 12F);
            this.signInB.Location = new System.Drawing.Point(159, 132);
            this.signInB.Name = "signInB";
            this.signInB.Size = new System.Drawing.Size(218, 45);
            this.signInB.TabIndex = 3;
            this.signInB.Text = "登录";
            this.signInB.UseVisualStyleBackColor = true;
            this.signInB.Click += new System.EventHandler(this.signInB_Click);
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(3, 3);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(708, 50);
            this.titleP.TabIndex = 12;
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(446, 406);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(196, 94);
            this.hp.TabIndex = 11;
            // 
            // SignInPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.gb1);
            this.Name = "SignInPanel";
            this.Size = new System.Drawing.Size(714, 545);
            this.Load += new System.EventHandler(this.SignInPanel_Load);
            this.SizeChanged += new System.EventHandler(this.SignInPanel_SizeChanged);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button signInB;
        private System.Windows.Forms.Button signUpB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label passwordL;
        private System.Windows.Forms.Label telL;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox telTB;
        private HandlePanel hp;
        private TitlePanel titleP;
    }
}
