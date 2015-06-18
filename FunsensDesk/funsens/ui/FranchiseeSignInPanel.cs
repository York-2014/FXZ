using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using x.util;
using funsens.api;
using funsens.common;
using funsens.customer;
using funsens.customer.vo;
using funsens.franchisee.vo;
using funsens.util;

namespace funsens.ui
{
    /// <summary>
    /// 商家登录界面
    /// </summary>
    public partial class FranchiseeSignInPanel : UserControl
    {
        private delegate void _Delegate();

        public MainForm.MainFormCallback mainFormCallback;

        private List<RegsiterUserInfo> lstRegUserInfo = new List<RegsiterUserInfo>();

        public FranchiseeSignInPanel()
        {
            InitializeComponent();

            this.uiInitView();
        }

        private void signIn()
        {
            string username = this.usernameTB.Text;
            if (S.blank(username))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usernameTB.Focus();
                return;
            }

            string password = this.passwordTB.Text;
            if (S.blank(password))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.passwordTB.Focus();
                return;
            }

            //登录验证略。。。。
            //this.DialogResult = DialogResult.OK;
            // this.Close();

            _Delegate _delegate = new _Delegate(this.showHP);
            this.Invoke(_delegate);

            SignInHandler handler = new SignInHandler(this.handleFinish, null, null, username, password);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(this.hideHP);

            JO jo = null;

            if (rc != Handler.RC_SUCCESS)
            {
                this.Invoke(_delegate);
                MessageBox.Show("网络异常，请稍后再试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (null == content || (jo = new JO(content.ToString())).isNull())
            {
                MessageBox.Show("服务器异常，返回值为\n:" + content.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(_delegate);
                return;
            }

            if (type == API.T_SIGN_IN)
            {
                int code = jo.getInt("status");
                if (code == 1)
                {
                    MessageBox.Show("用户已被锁定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (code == 2)
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (code == 3)
                {
                    MessageBox.Show("身份证和姓名不匹配！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (code == 4)
                {
                    MessageBox.Show("用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (code == 5)
                {
                    MessageBox.Show("系统异常，请稍后再试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int userType = jo.getInt("user_type");
                    if (userType != 2)
                    {
                        MessageBox.Show("您不是商家，不能进行该操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    FranchiseeVO vo = new FranchiseeVO();
                    vo.Id = jo.getString("userid");
                    Session.getInstance().FranchiseeVO = vo;

                    UserInfoHandler handler = new UserInfoHandler(this.handleFinish);
                    handler.handle();
                }

                this.Invoke(_delegate);
            }
            else if (type == API.T_USER_INFO)
            {
                string name = jo.getString("name");
                string tel = jo.getString("mobile");

                Session session = Session.getInstance();
                session.FranchiseeVO.Name = name;
                session.FranchiseeVO.Username = tel;

                //判断记住密码复选框
                if (this.checkBox_SavePassword.Checked)
                {
                    //保存记住密码复选框为勾选状态
                    RegisterUtil.SetRegistryData(session.FranchiseeVO.Username, "CheckedPassword", "true");
                    //保存密码
                    RegisterUtil.SetRegistryData(session.FranchiseeVO.Username, "Password", Base64Util.EncodeBase64((Base64Util.EncodeBase64(passwordTB.Text))));
                }
                else
                {
                    //保存记住密码复选框为未勾选状态
                    RegisterUtil.SetRegistryData(session.FranchiseeVO.Username, "CheckedPassword", "false");
                    //清空密码
                    RegisterUtil.SetRegistryData(session.FranchiseeVO.Username, "Password", string.Empty);
                }

                //判断记住用户名复选框
                if (this.checkBox_SaveUserName.Checked)
                {
                    //保存记住用户名复选框为勾选状态
                    RegisterUtil.SetRegistryData(session.FranchiseeVO.Username, "CheckedUserName", "true");
                }
                else
                {
                    this.checkBox_SavePassword.Checked = false;
                    if (RegisterUtil.IsRegUserNameExist(string.Empty, session.FranchiseeVO.Username))
                    {
                        RegisterUtil.DeleteRegist(string.Empty, session.FranchiseeVO.Username);
                    }
                }

                _delegate = new _Delegate(this.back);
                this.Invoke(_delegate);
            }
        }

        private void showHP()
        {
            this.hp.Visible = true;
        }

        private void hideHP()
        {
            this.hp.Visible = false;
        }

        private void back()
        {
            this.mainFormCallback(MainForm.PT_FRANCHISEE_SIGNED);
        }

        private void uiResize()
        {
            int w = this.Width;
            int h = this.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, this.titleP.ClientRectangle.Height);

            this.gb1.Location = new Point((w - this.gb1.Width) / 2, (h - this.gb1.Height) / 2);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        private void uiInitView()
        {
            this.titleP.setTitle("商家登录");

            this.label_Version.Text = string.Format("v{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

            this.hp.Visible = false;
        }

        private void FranchiseeSignIn_Load(object sender, EventArgs e)
        {
            this.uiResize();

            //加载保存在本地注册表中的用户信息
            try
            {
                lstRegUserInfo = RegisterUtil.GetAllRegUserInfo();
                foreach (RegsiterUserInfo item in lstRegUserInfo)
                {
                    usernameTB.Items.Add(item.UserName);
                }
            }
            catch
            {
                //异常则忽略
            }

            if (usernameTB.Items.Count > 0)
            {
                //加载最后一个
                usernameTB.SelectedIndex = usernameTB.Items.Count - 1;
            }
        }

        private void FranchiseeSignIn_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void signInB_Click(object sender, EventArgs e)
        {
            this.signIn();
        }

        private void passwordTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.signIn();
            }
        }

        private void usernameTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            usernameTB.Text = lstRegUserInfo[usernameTB.SelectedIndex].UserName;
            passwordTB.Text = Base64Util.DecodeBase64(Base64Util.DecodeBase64(lstRegUserInfo[usernameTB.SelectedIndex].PassWord));
            checkBox_SaveUserName.Checked = lstRegUserInfo[usernameTB.SelectedIndex].CheckedUserName;
            checkBox_SavePassword.Checked = lstRegUserInfo[usernameTB.SelectedIndex].CheckedPassword;
        }

        private void checkBox_SavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SavePassword.Checked)
            {
                checkBox_SaveUserName.Checked = true;
            }
        }

        private void checkBox_SaveUserName_CheckedChanged(object sender, EventArgs e)
        {
            if (false == checkBox_SaveUserName.Checked)
            {
                checkBox_SavePassword.Checked = false;
            }
        }

        private void usernameTB_TextChanged(object sender, EventArgs e)
        {
            int index = usernameTB.Items.IndexOf(usernameTB.Text);
            if (index < 0)
            {
                passwordTB.Clear();
                checkBox_SaveUserName.Checked = false;
                checkBox_SavePassword.Checked = false;
            }
            else
            {
                usernameTB.Text = lstRegUserInfo[index].UserName;
                passwordTB.Text = Base64Util.DecodeBase64(Base64Util.DecodeBase64(lstRegUserInfo[index].PassWord));
                checkBox_SaveUserName.Checked = lstRegUserInfo[index].CheckedUserName;
                checkBox_SavePassword.Checked = lstRegUserInfo[index].CheckedPassword;
            }
        }
    }
}
