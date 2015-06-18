namespace funsens.ui
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuP = new funsens.ui.MainMenu();
            this.userInfoP = new System.Windows.Forms.Panel();
            this.idCardReaderStatusL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.signOutB = new System.Windows.Forms.Button();
            this.telL = new System.Windows.Forms.Label();
            this.usernameL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idNoL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hp = new funsens.ui.HandlePanel();
            this.itemS = new funsens.ui.ItemSelector();
            this.pickUpOrderListP = new funsens.ui.MyOrderListPanel();
            this.pickUpOrderDetailsP = new funsens.ui.MyOrderDetailsPanel();
            this.addOrderP = new funsens.ui.AddOrderPanel();
            this.signInP = new funsens.ui.SignInPanel();
            this.signUpP = new funsens.ui.SignUpPanel();
            this.franchiseeSignInP = new funsens.ui.FranchiseeSignInPanel();
            this.addOrderConfirmP = new funsens.ui.AddOrderConfirmPanel();
            this.addressSelectorP = new funsens.ui.AddressSelector();
            this.addOrderPayP = new funsens.ui.AddOrderPayPanel();
            this.posP = new funsens.ui.PosPanel();
            this.userInfoP.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuP
            // 
            this.menuP.BackColor = System.Drawing.SystemColors.Control;
            this.menuP.Location = new System.Drawing.Point(0, 0);
            this.menuP.Name = "menuP";
            this.menuP.Size = new System.Drawing.Size(256, 641);
            this.menuP.TabIndex = 0;
            // 
            // userInfoP
            // 
            this.userInfoP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.userInfoP.Controls.Add(this.idCardReaderStatusL);
            this.userInfoP.Controls.Add(this.label3);
            this.userInfoP.Controls.Add(this.signOutB);
            this.userInfoP.Controls.Add(this.telL);
            this.userInfoP.Controls.Add(this.usernameL);
            this.userInfoP.Controls.Add(this.label4);
            this.userInfoP.Controls.Add(this.idNoL);
            this.userInfoP.Controls.Add(this.label2);
            this.userInfoP.Controls.Add(this.label1);
            this.userInfoP.Location = new System.Drawing.Point(207, 1);
            this.userInfoP.Name = "userInfoP";
            this.userInfoP.Size = new System.Drawing.Size(1122, 50);
            this.userInfoP.TabIndex = 5;
            // 
            // idCardReaderStatusL
            // 
            this.idCardReaderStatusL.AutoSize = true;
            this.idCardReaderStatusL.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idCardReaderStatusL.Location = new System.Drawing.Point(97, 19);
            this.idCardReaderStatusL.Name = "idCardReaderStatusL";
            this.idCardReaderStatusL.Size = new System.Drawing.Size(35, 13);
            this.idCardReaderStatusL.TabIndex = 8;
            this.idCardReaderStatusL.Text = "未知";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "读卡器状态：";
            // 
            // signOutB
            // 
            this.signOutB.Location = new System.Drawing.Point(1006, 8);
            this.signOutB.Name = "signOutB";
            this.signOutB.Size = new System.Drawing.Size(108, 33);
            this.signOutB.TabIndex = 6;
            this.signOutB.Text = "退出当前用户";
            this.signOutB.UseVisualStyleBackColor = true;
            this.signOutB.Click += new System.EventHandler(this.signOutB_Click);
            // 
            // telL
            // 
            this.telL.AutoSize = true;
            this.telL.Location = new System.Drawing.Point(803, 19);
            this.telL.Name = "telL";
            this.telL.Size = new System.Drawing.Size(11, 12);
            this.telL.TabIndex = 5;
            this.telL.Text = "-";
            // 
            // usernameL
            // 
            this.usernameL.AutoSize = true;
            this.usernameL.Location = new System.Drawing.Point(271, 19);
            this.usernameL.Name = "usernameL";
            this.usernameL.Size = new System.Drawing.Size(11, 12);
            this.usernameL.TabIndex = 4;
            this.usernameL.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "身份证号码：";
            // 
            // idNoL
            // 
            this.idNoL.AutoSize = true;
            this.idNoL.Location = new System.Drawing.Point(511, 19);
            this.idNoL.Name = "idNoL";
            this.idNoL.Size = new System.Drawing.Size(11, 12);
            this.idNoL.TabIndex = 2;
            this.idNoL.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(739, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "手机号码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // hp
            // 
            this.hp.BackColor = System.Drawing.SystemColors.Control;
            this.hp.Location = new System.Drawing.Point(1255, 131);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(200, 100);
            this.hp.TabIndex = 6;
            // 
            // itemS
            // 
            this.itemS.Location = new System.Drawing.Point(220, 630);
            this.itemS.Name = "itemS";
            this.itemS.Size = new System.Drawing.Size(791, 420);
            this.itemS.TabIndex = 7;
            // 
            // pickUpOrderListP
            // 
            this.pickUpOrderListP.BackColor = System.Drawing.SystemColors.Control;
            this.pickUpOrderListP.Location = new System.Drawing.Point(708, 433);
            this.pickUpOrderListP.Name = "pickUpOrderListP";
            this.pickUpOrderListP.Size = new System.Drawing.Size(591, 240);
            this.pickUpOrderListP.TabIndex = 4;
            // 
            // pickUpOrderDetailsP
            // 
            this.pickUpOrderDetailsP.BackColor = System.Drawing.SystemColors.Control;
            this.pickUpOrderDetailsP.Location = new System.Drawing.Point(708, 433);
            this.pickUpOrderDetailsP.Name = "pickUpOrderDetailsP";
            this.pickUpOrderDetailsP.Size = new System.Drawing.Size(591, 240);
            this.pickUpOrderDetailsP.TabIndex = 4;
            // 
            // addOrderP
            // 
            this.addOrderP.BackColor = System.Drawing.SystemColors.Control;
            this.addOrderP.Location = new System.Drawing.Point(230, 440);
            this.addOrderP.Name = "addOrderP";
            this.addOrderP.Size = new System.Drawing.Size(445, 233);
            this.addOrderP.TabIndex = 3;
            // 
            // signInP
            // 
            this.signInP.BackColor = System.Drawing.SystemColors.Control;
            this.signInP.Location = new System.Drawing.Point(736, 107);
            this.signInP.Name = "signInP";
            this.signInP.Size = new System.Drawing.Size(513, 320);
            this.signInP.TabIndex = 2;
            // 
            // signUpP
            // 
            this.signUpP.BackColor = System.Drawing.SystemColors.Control;
            this.signUpP.Location = new System.Drawing.Point(230, 107);
            this.signUpP.Name = "signUpP";
            this.signUpP.Size = new System.Drawing.Size(452, 320);
            this.signUpP.TabIndex = 1;
            // 
            // franchiseeSignInP
            // 
            this.franchiseeSignInP.BackColor = System.Drawing.SystemColors.Control;
            this.franchiseeSignInP.Location = new System.Drawing.Point(736, 107);
            this.franchiseeSignInP.Name = "franchiseeSignInP";
            this.franchiseeSignInP.Size = new System.Drawing.Size(513, 320);
            this.franchiseeSignInP.TabIndex = 2;
            // 
            // addOrderConfirmP
            // 
            this.addOrderConfirmP.Location = new System.Drawing.Point(1030, 701);
            this.addOrderConfirmP.Name = "addOrderConfirmP";
            this.addOrderConfirmP.Size = new System.Drawing.Size(357, 270);
            this.addOrderConfirmP.TabIndex = 8;
            // 
            // addressSelectorP
            // 
            this.addressSelectorP.Location = new System.Drawing.Point(220, 630);
            this.addressSelectorP.Name = "addressSelectorP";
            this.addressSelectorP.Size = new System.Drawing.Size(791, 420);
            this.addressSelectorP.TabIndex = 7;
            // 
            // addOrderPayP
            // 
            this.addOrderPayP.Location = new System.Drawing.Point(12, 875);
            this.addOrderPayP.Name = "addOrderPayP";
            this.addOrderPayP.Size = new System.Drawing.Size(255, 175);
            this.addOrderPayP.TabIndex = 9;
            // 
            // posP
            // 
            this.posP.BackColor = System.Drawing.SystemColors.Control;
            this.posP.Location = new System.Drawing.Point(708, 433);
            this.posP.Name = "posP";
            this.posP.Size = new System.Drawing.Size(591, 240);
            this.posP.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 1054);
            this.Controls.Add(this.addOrderPayP);
            this.Controls.Add(this.addOrderConfirmP);
            this.Controls.Add(this.itemS);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.userInfoP);
            this.Controls.Add(this.pickUpOrderListP);
            this.Controls.Add(this.pickUpOrderDetailsP);
            this.Controls.Add(this.addOrderP);
            this.Controls.Add(this.signInP);
            this.Controls.Add(this.signUpP);
            this.Controls.Add(this.franchiseeSignInP);
            this.Controls.Add(this.menuP);
            this.Controls.Add(this.addressSelectorP);
            this.Controls.Add(this.posP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "风信子 - 服务台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.userInfoP.ResumeLayout(false);
            this.userInfoP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenu menuP;
        private SignUpPanel signUpP;
        private SignInPanel signInP;
        private FranchiseeSignInPanel franchiseeSignInP;
        private AddOrderPanel addOrderP;
        private MyOrderListPanel pickUpOrderListP;
        private MyOrderDetailsPanel pickUpOrderDetailsP;
        private PosPanel posP;
        private System.Windows.Forms.Panel userInfoP;
        private System.Windows.Forms.Label telL;
        private System.Windows.Forms.Label usernameL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label idNoL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button signOutB;
        private HandlePanel hp;
        private ItemSelector itemS;
        private AddOrderConfirmPanel addOrderConfirmP;
        private AddressSelector addressSelectorP;
        private System.Windows.Forms.Label idCardReaderStatusL;
        private System.Windows.Forms.Label label3;
        private AddOrderPayPanel addOrderPayP;
    }
}