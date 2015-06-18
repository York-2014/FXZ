namespace funsens.ui
{
    partial class FranchiseeSignInPanel
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
            this.checkBox_SaveUserName = new System.Windows.Forms.CheckBox();
            this.checkBox_SavePassword = new System.Windows.Forms.CheckBox();
            this.usernameTB = new System.Windows.Forms.ComboBox();
            this.passwordL = new System.Windows.Forms.Label();
            this.usernameL = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.signInB = new System.Windows.Forms.Button();
            this.titleP = new funsens.ui.TitlePanel();
            this.hp = new funsens.ui.HandlePanel();
            this.label_Version = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label_Version);
            this.gb1.Controls.Add(this.checkBox_SaveUserName);
            this.gb1.Controls.Add(this.checkBox_SavePassword);
            this.gb1.Controls.Add(this.usernameTB);
            this.gb1.Controls.Add(this.passwordL);
            this.gb1.Controls.Add(this.usernameL);
            this.gb1.Controls.Add(this.passwordTB);
            this.gb1.Controls.Add(this.signInB);
            this.gb1.Location = new System.Drawing.Point(136, 150);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(550, 230);
            this.gb1.TabIndex = 12;
            this.gb1.TabStop = false;
            // 
            // checkBox_SaveUserName
            // 
            this.checkBox_SaveUserName.AutoSize = true;
            this.checkBox_SaveUserName.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_SaveUserName.Location = new System.Drawing.Point(132, 145);
            this.checkBox_SaveUserName.Name = "checkBox_SaveUserName";
            this.checkBox_SaveUserName.Size = new System.Drawing.Size(84, 16);
            this.checkBox_SaveUserName.TabIndex = 4;
            this.checkBox_SaveUserName.Text = "记住用户名";
            this.checkBox_SaveUserName.UseVisualStyleBackColor = true;
            this.checkBox_SaveUserName.CheckedChanged += new System.EventHandler(this.checkBox_SaveUserName_CheckedChanged);
            // 
            // checkBox_SavePassword
            // 
            this.checkBox_SavePassword.AutoSize = true;
            this.checkBox_SavePassword.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_SavePassword.Location = new System.Drawing.Point(250, 145);
            this.checkBox_SavePassword.Name = "checkBox_SavePassword";
            this.checkBox_SavePassword.Size = new System.Drawing.Size(72, 16);
            this.checkBox_SavePassword.TabIndex = 5;
            this.checkBox_SavePassword.Text = "记住密码";
            this.checkBox_SavePassword.UseVisualStyleBackColor = true;
            this.checkBox_SavePassword.CheckedChanged += new System.EventHandler(this.checkBox_SavePassword_CheckedChanged);
            // 
            // usernameTB
            // 
            this.usernameTB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameTB.FormattingEnabled = true;
            this.usernameTB.Location = new System.Drawing.Point(132, 72);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(235, 24);
            this.usernameTB.TabIndex = 1;
            this.usernameTB.SelectedIndexChanged += new System.EventHandler(this.usernameTB_SelectedIndexChanged);
            this.usernameTB.TextChanged += new System.EventHandler(this.usernameTB_TextChanged);
            // 
            // passwordL
            // 
            this.passwordL.AutoSize = true;
            this.passwordL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordL.Location = new System.Drawing.Point(54, 116);
            this.passwordL.Name = "passwordL";
            this.passwordL.Size = new System.Drawing.Size(72, 16);
            this.passwordL.TabIndex = 10;
            this.passwordL.Text = "密  码：";
            // 
            // usernameL
            // 
            this.usernameL.AutoSize = true;
            this.usernameL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameL.Location = new System.Drawing.Point(54, 76);
            this.usernameL.Name = "usernameL";
            this.usernameL.Size = new System.Drawing.Size(72, 16);
            this.usernameL.TabIndex = 11;
            this.usernameL.Text = "用户名：";
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("宋体", 12F);
            this.passwordTB.Location = new System.Drawing.Point(132, 111);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(235, 26);
            this.passwordTB.TabIndex = 2;
            this.passwordTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passwordTB_KeyUp);
            // 
            // signInB
            // 
            this.signInB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.signInB.Location = new System.Drawing.Point(373, 72);
            this.signInB.Name = "signInB";
            this.signInB.Size = new System.Drawing.Size(123, 65);
            this.signInB.TabIndex = 3;
            this.signInB.Text = "登录(&Login)";
            this.signInB.UseVisualStyleBackColor = true;
            this.signInB.Click += new System.EventHandler(this.signInB_Click);
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(3, 3);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(816, 50);
            this.titleP.TabIndex = 14;
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(575, 408);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(196, 94);
            this.hp.TabIndex = 13;
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Font = new System.Drawing.Font("宋体", 12F);
            this.label_Version.ForeColor = System.Drawing.Color.Black;
            this.label_Version.Location = new System.Drawing.Point(463, 203);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(72, 16);
            this.label_Version.TabIndex = 12;
            this.label_Version.Text = "v1.0.0.0";
            // 
            // FranchiseeSignInPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.gb1);
            this.Name = "FranchiseeSignInPanel";
            this.Size = new System.Drawing.Size(822, 530);
            this.Load += new System.EventHandler(this.FranchiseeSignIn_Load);
            this.SizeChanged += new System.EventHandler(this.FranchiseeSignIn_SizeChanged);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private global::funsens.ui.HandlePanel hp;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label passwordL;
        private System.Windows.Forms.Label usernameL;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button signInB;
        private TitlePanel titleP;
        private System.Windows.Forms.ComboBox usernameTB;
        private System.Windows.Forms.CheckBox checkBox_SavePassword;
        private System.Windows.Forms.CheckBox checkBox_SaveUserName;
        private System.Windows.Forms.Label label_Version;
    }
}
