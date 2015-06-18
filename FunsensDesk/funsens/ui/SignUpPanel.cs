using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using x.util;
using funsens.api;
using funsens.common;
using funsens.customer;
using funsens.customer.vo;

namespace funsens.ui
{
    /// <summary>
    /// 客户注册界面
    /// </summary>
    public partial class SignUpPanel : UserControl
    {
        private delegate void _Delegate();

        private delegate void ShowMessageDelegate(string message);

        public MainForm.MainFormCallback mainFormCallback;

        private string address;

        public SignUpPanel()
        {
            InitializeComponent();

            this.uiInitView();
        }

        public void setUserInfo(string no, string name, string address)
        {
            this.idNoTB.Text = no;

            this.nameTB.Text = name;

            this.address = address;

            string password = no.Substring(no.Length - 6, 6);
            this.passwordTB.Text = password;
        }

        private void signUp()
        {
            string idNo = this.idNoTB.Text;
            string name = this.nameTB.Text;
            if (S.blank(idNo) || S.blank(name))
            {
                MessageBox.Show("请刷身份证");
                return;
            }

            string tel = this.telTB.Text;
            if (S.blank(tel))
            {
                MessageBox.Show("请输入手机号码");
                return;
            }

            long tmpTel = S.toLong(tel);
            if (tmpTel < 13000000000 || tmpTel > 18999999999)
            {
                MessageBox.Show("请输入有效的手机号码");
                return;
            }

            string password = this.passwordTB.Text;
            if (S.blank(password) || password.Length < 6)
            {
                MessageBox.Show("请至少输入6位密码");
                return;
            }

            this.showHP();

            SignUpHandler handler = new SignUpHandler(this.handleFinish, idNo, name, this.address, tel, password);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(hideHP);
            ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.showMessage);

            JO jo = null;

            if (rc != Handler.RC_SUCCESS)
            {
                this.Invoke(_delegate);
                this.Invoke(showMessageDelegate, new object[] { "网络异常，请稍后再试" });
                return;
            }
            else if (null == content || (jo = new JO(content.ToString())).isNull())
            {
                this.Invoke(_delegate);
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回内容为：\n" + content.ToString() });
                return;
            }

            if (type == API.T_SIGN_UP)
            {
                int code = jo.getInt("status");
                if (code == 3)
                {
                    this.Invoke(_delegate);
                    this.Invoke(showMessageDelegate, new object[] { "手机号码已经被注册" });
                }
                else if (code == 4)
                {
                    this.Invoke(_delegate);
                    this.Invoke(showMessageDelegate, new object[] { "身份证号码已经被注册" });
                }
                else if (code == 6)
                {
                    UserInfoHandler handler = new UserInfoHandler(this.handleFinish);
                    handler.handle();
                }
                else
                {
                    this.Invoke(_delegate);
                    this.Invoke(showMessageDelegate, new object[] { "注册失败" });
                }
            }
            else if (type == API.T_USER_INFO)
            {
                this.Invoke(_delegate);
                this.Invoke(showMessageDelegate, new object[] { "注册成功" });

                string icNo = jo.getString("id_card");
                string name = jo.getString("name");
                string tel = jo.getString("mobile");

                JO addressJO = jo.getJO("address");

                if (S.blank(tel) || null == addressJO)
                {
                    this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回内容为：\n" + content.ToString() });

                    Environment.Exit(0);
                }

                string address = addressJO.getString("address");

                Session session = Session.getInstance();
                session.IcNo = icNo;
                session.CustomerName = name;
                session.CustomerTel = tel;
                session.CustomerAddress = address;

                _delegate = new _Delegate(this.callback);
                this.Invoke(_delegate);
            }
        }

        private void callback()
        {
            this.mainFormCallback(MainForm.PT_ADD_ORDER);
        }

        private void showHP()
        {
            this.hp.Visible = true;
        }

        private void hideHP()
        {
            this.hp.Visible = false;
        }

        private void showMessage(string message)
        {
            MessageBox.Show(message);
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
            this.titleP.setTitle("客户注册");

            this.hp.Visible = false;
        }

        private void SignUpPanel_Load(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void signUpB_Click(object sender, EventArgs e)
        {
            this.signUp();
        }

        private void signInB_Click(object sender, EventArgs e)
        {
            this.mainFormCallback(MainForm.PT_SIGN_IN);
        }

        private void SignUpPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }
    }
}
