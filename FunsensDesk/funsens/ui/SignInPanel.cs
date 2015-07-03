using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using x.util;
using funsens.api;
using funsens.common;
using funsens.customer;
using funsens.customer.vo;
using funsens.mis;

namespace funsens.ui
{
    /// <summary>
    /// 客户登录界面
    /// </summary>
    public partial class SignInPanel : UserControl
    {
        private delegate void _Delegate();

        private delegate void ShowMessageDelegate(string message);

        public MainForm.MainFormCallback mainFormCallback;

        public SignInPanel()
        {
            InitializeComponent();

            this.uiInitView();
        }

        public void setUserInfo(string idNo, string name)
        {
            this.signIn(idNo, name);
        }

        private void signIn(string idNo, string name)
        {
            string tel = null;
            string password = null;

            if (null == idNo)
            {
                tel = this.telTB.Text;
                if (S.blank(tel))
                {
                    MessageBox.Show("请输入有效的手机号码");
                    this.telTB.Focus();
                    return;
                }

                long tmpTel = S.toLong(tel);
                if (tmpTel < 13000000000 || tmpTel > 18999999999)
                {
                    MessageBox.Show("请输入有效的手机号码");
                    this.telTB.Focus();
                    return;
                }

                password = this.passwordTB.Text;
                if (null == password || "".Equals(password) || password.Length < 6)
                {
                    MessageBox.Show("请至少输入6位密码");
                    this.passwordTB.Focus();
                    return;
                }
            }

            _Delegate _delegate = new _Delegate(this.showHP);
            this.Invoke(_delegate);

            SignInHandler handler = new SignInHandler(this.handleFinish, idNo, name, tel, password);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(this.hideHP);

            JO jo = null;

            if (rc != Handler.RC_SUCCESS)
            {
                this.Invoke(_delegate);
                MessageBox.Show("网络异常，请稍后再试");
                return;
            }
            else if (null == content || (jo = new JO(content.ToString())).isNull())
            {
                MessageBox.Show("服务器异常，返回值为\n:" + content.ToString());
                this.Invoke(_delegate);
                return;
            }

            if (type == API.T_SIGN_IN)
            {
                int code = jo.getInt("status");
                if (code == 1)
                {
                    MessageBox.Show("用户已被锁定");
                }
                else if (code == 2)
                {
                    MessageBox.Show("手机号码与密码不匹配");
                }
                else if (code == 3)
                {
                    MessageBox.Show("身份证和姓名不匹配");
                }
                else if (code == 4)
                {
                    MessageBox.Show("用户不存在");
                }
                else if (code == 5)
                {
                    MessageBox.Show("系统异常，请稍后再试");
                }
                else
                {
                    UserInfoHandler handler = new UserInfoHandler(this.handleFinish);
                    handler.handle();
                }

                this.Invoke(_delegate);
            }
            else if (type == API.T_USER_INFO)
            {
                string icNo = jo.getString("id_card");
                string name = jo.getString("name");
                string tel = jo.getString("mobile");

                JO addressJO = jo.getJO("address");
                //string userId = addressJO.getString("userid");

                if (S.blank(tel) || null == addressJO)
                {
                    ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.showMessage);
                    this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回内容为：\n" + content.ToString() });

                    Environment.Exit(0);
                }

                string address = addressJO.getString("address");
                string area=addressJO.getString("area");
                string province = "";
                string cityname = "";
                string areaname = "";
                if(null != area && area.Length>0)
                {
                   string[] sArray = addressJO.getString("area").Split(' ');
                if (sArray.Length > 2)
                {
                    province = sArray[0];
                    cityname = sArray[1];
                    areaname = sArray[2];
                }
                }
               
                
               
                
                string zipcode = addressJO.getString("zip");

                Session session = Session.getInstance();
                session.IcNo = icNo;
                session.CustomerName = name ;
                session.CustomerTel = tel;
                session.CustomerAddress = address;
                session.Province = province;
                session.Cityname = cityname;
                session.Areaname = areaname;
                session.Zipcode = zipcode;

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

        private void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void back()
        {
            this.mainFormCallback(MainForm.PT_ADD_ORDER);
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
            this.titleP.setTitle("客户登录");

            this.hp.Visible = false;
        }

        private void SignInPanel_Load(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void signInB_Click(object sender, EventArgs e)
        {
            this.signIn(null, null);
        }

        private void signUpB_Click(object sender, EventArgs e)
        {
            this.mainFormCallback(MainForm.PT_SIGN_UP);
        }

        private void SignInPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }
    }
}
