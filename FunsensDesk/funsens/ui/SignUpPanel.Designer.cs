namespace funsens.ui
{
    partial class SignUpPanel
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
            this.signInB = new System.Windows.Forms.Button();
            this.signUpB = new System.Windows.Forms.Button();
            this.idNoTB = new System.Windows.Forms.TextBox();
            this.passwordL = new System.Windows.Forms.Label();
            this.telL = new System.Windows.Forms.Label();
            this.nameL = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.telTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.idNoL = new System.Windows.Forms.Label();
            this.hp = new System.Windows.Forms.Panel();
            this.hpL = new System.Windows.Forms.Label();
            this.titleP = new funsens.ui.TitlePanel();
            this.gb1.SuspendLayout();
            this.hp.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.signInB);
            this.gb1.Controls.Add(this.signUpB);
            this.gb1.Controls.Add(this.idNoTB);
            this.gb1.Controls.Add(this.passwordL);
            this.gb1.Controls.Add(this.telL);
            this.gb1.Controls.Add(this.nameL);
            this.gb1.Controls.Add(this.passwordTB);
            this.gb1.Controls.Add(this.telTB);
            this.gb1.Controls.Add(this.nameTB);
            this.gb1.Controls.Add(this.idNoL);
            this.gb1.Location = new System.Drawing.Point(91, 157);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(509, 323);
            this.gb1.TabIndex = 9;
            this.gb1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "请刷身份证进行注册";
            // 
            // signInB
            // 
            this.signInB.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.signInB.Location = new System.Drawing.Point(384, 235);
            this.signInB.Name = "signInB";
            this.signInB.Size = new System.Drawing.Size(70, 45);
            this.signInB.TabIndex = 4;
            this.signInB.Text = "登录";
            this.signInB.UseVisualStyleBackColor = true;
            this.signInB.Click += new System.EventHandler(this.signInB_Click);
            // 
            // signUpB
            // 
            this.signUpB.Font = new System.Drawing.Font("SimSun", 12F);
            this.signUpB.Location = new System.Drawing.Point(159, 235);
            this.signUpB.Name = "signUpB";
            this.signUpB.Size = new System.Drawing.Size(218, 45);
            this.signUpB.TabIndex = 3;
            this.signUpB.Text = "注册";
            this.signUpB.UseVisualStyleBackColor = true;
            this.signUpB.Click += new System.EventHandler(this.signUpB_Click);
            // 
            // idNoTB
            // 
            this.idNoTB.Font = new System.Drawing.Font("SimSun", 12F);
            this.idNoTB.Location = new System.Drawing.Point(159, 48);
            this.idNoTB.Name = "idNoTB";
            this.idNoTB.ReadOnly = true;
            this.idNoTB.Size = new System.Drawing.Size(295, 26);
            this.idNoTB.TabIndex = 1;
            // 
            // passwordL
            // 
            this.passwordL.AutoSize = true;
            this.passwordL.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordL.Location = new System.Drawing.Point(97, 189);
            this.passwordL.Name = "passwordL";
            this.passwordL.Size = new System.Drawing.Size(56, 16);
            this.passwordL.TabIndex = 2;
            this.passwordL.Text = "密码：";
            this.passwordL.Visible = false;
            // 
            // telL
            // 
            this.telL.AutoSize = true;
            this.telL.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.telL.Location = new System.Drawing.Point(65, 146);
            this.telL.Name = "telL";
            this.telL.Size = new System.Drawing.Size(88, 16);
            this.telL.TabIndex = 3;
            this.telL.Text = "手机号码：";
            // 
            // nameL
            // 
            this.nameL.AutoSize = true;
            this.nameL.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameL.Location = new System.Drawing.Point(97, 98);
            this.nameL.Name = "nameL";
            this.nameL.Size = new System.Drawing.Size(56, 16);
            this.nameL.TabIndex = 4;
            this.nameL.Text = "姓名：";
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("SimSun", 12F);
            this.passwordTB.Location = new System.Drawing.Point(159, 185);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(295, 26);
            this.passwordTB.TabIndex = 2;
            this.passwordTB.Visible = false;
            // 
            // telTB
            // 
            this.telTB.Font = new System.Drawing.Font("SimSun", 12F);
            this.telTB.Location = new System.Drawing.Point(159, 142);
            this.telTB.MaxLength = 11;
            this.telTB.Name = "telTB";
            this.telTB.Size = new System.Drawing.Size(295, 26);
            this.telTB.TabIndex = 1;
            // 
            // nameTB
            // 
            this.nameTB.Font = new System.Drawing.Font("SimSun", 12F);
            this.nameTB.Location = new System.Drawing.Point(159, 94);
            this.nameTB.Name = "nameTB";
            this.nameTB.ReadOnly = true;
            this.nameTB.Size = new System.Drawing.Size(295, 26);
            this.nameTB.TabIndex = 7;
            // 
            // idNoL
            // 
            this.idNoL.AutoSize = true;
            this.idNoL.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idNoL.Location = new System.Drawing.Point(49, 52);
            this.idNoL.Name = "idNoL";
            this.idNoL.Size = new System.Drawing.Size(104, 16);
            this.idNoL.TabIndex = 0;
            this.idNoL.Text = "身份证号码：";
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Controls.Add(this.hpL);
            this.hp.Location = new System.Drawing.Point(522, 486);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(200, 100);
            this.hp.TabIndex = 10;
            // 
            // hpL
            // 
            this.hpL.AutoSize = true;
            this.hpL.Location = new System.Drawing.Point(37, 43);
            this.hpL.Name = "hpL";
            this.hpL.Size = new System.Drawing.Size(137, 12);
            this.hpL.TabIndex = 0;
            this.hpL.Text = "正在处理，请稍候......";
            // 
            // titleP
            // 
            this.titleP.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleP.Location = new System.Drawing.Point(5, 3);
            this.titleP.Name = "titleP";
            this.titleP.Size = new System.Drawing.Size(807, 50);
            this.titleP.TabIndex = 11;
            // 
            // SignUpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.titleP);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.gb1);
            this.Name = "SignUpPanel";
            this.Size = new System.Drawing.Size(830, 601);
            this.Load += new System.EventHandler(this.SignUpPanel_Load);
            this.SizeChanged += new System.EventHandler(this.SignUpPanel_SizeChanged);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.hp.ResumeLayout(false);
            this.hp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button signInB;
        private System.Windows.Forms.Button signUpB;
        private System.Windows.Forms.TextBox idNoTB;
        private System.Windows.Forms.Label passwordL;
        private System.Windows.Forms.Label telL;
        private System.Windows.Forms.Label nameL;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox telTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label idNoL;
        private System.Windows.Forms.Panel hp;
        private System.Windows.Forms.Label hpL;
        private System.Windows.Forms.Label label1;
        private TitlePanel titleP;
    }
}
