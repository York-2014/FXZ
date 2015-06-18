using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using funsens.api;
using funsens.common;
using funsens.common.vo;
using funsens.customer;
using funsens.customer.vo;
using funsens.cvr;
using funsens.item.vo;

namespace funsens.ui
{
    /// <summary>
    /// 主界面
    /// 所有其它界面和面板都嵌套于该界面中
    /// </summary>
    public partial class MainForm : Form
    {
        private delegate void _Delegate();

        private delegate void CVRCallback(int rc);

        public delegate void MainFormCallback(int type);

        public const int PT_SIGN_UP = 1;

        public const int PT_SIGN_IN = 2;

        public const int PT_FRANCHISEE_SIGNED = 21;

        public const int PT_PICK_UP_ORDER_LIST = 3;

        public const int PT_PICK_UP_ORDER_DETAILS = 4;

        public const int PT_ADD_ORDER = 5;

        public const int PT_ADD_ORDER_CONFIRM = 6;

        public const int PT_ADD_ORDER_PAY = 61;

        public const int PT_ITEM_SELECTOR = 7;
        public const int PT_ITEM_SELECTOR_RESULT = 8;

        public const int PT_SHOW_ADDRESS_SELECTOR = 91;
        public const int PT_ADDESS_SELECTOR_FINISH = 92;

        public const int PT_POS = 101;

        private CVRHandler.CVRDelegate cvrDelegate;

        private MainMenu.MainMenuDelegate menuCallback;

        public MainForm()
        {
            InitializeComponent();
        }

        private void hideHP()
        {
            this.hp.Visible = false;
        }

        /// <summary>
        /// 读卡器回调
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="no"></param>
        /// <param name="name"></param>
        private void cvrCallback(int rc)
        {
            CVRCallback callback = new CVRCallback(this._cvrCallback);
            this.Invoke(callback, new object[] { rc });
        }

        private void _cvrCallback(int rc)
        {
            if (rc == CVRHandler.RC_SUCCESS)
            {
                Session session = Session.getInstance();

                if (this.signInP.Visible)
                    this.signInP.setUserInfo(session.IcNo, session.CustomerName);
                else if (this.signUpP.Visible)
                    this.signUpP.setUserInfo(session.IcNo, session.CustomerName, session.CustomerAddress);
            }

            if (rc == CVRHandler.RC_CONNECT_FAILED)
            {
                this.idCardReaderStatusL.ForeColor = Color.Red;
                this.idCardReaderStatusL.Text = "连接失败";
            }
            else
            {
                this.idCardReaderStatusL.ForeColor = Color.Green;
                this.idCardReaderStatusL.Text = "正常";
            }
        }

        private void panelCallback(int type)
        {
            _Delegate _delegate = null;

            switch (type)
            {
                case PT_SIGN_UP:
                    this.signUpBClick();
                    break;
                case PT_SIGN_IN:
                    this.signInBClick();
                    break;
                case PT_PICK_UP_ORDER_LIST:
                    this.pickUpBClick();
                    break;
                case PT_PICK_UP_ORDER_DETAILS:
                    this.pickUpOrderDetails();
                    break;
                case PT_ADD_ORDER:
                    _delegate = new _Delegate(this.addOrderBClick);
                    this.Invoke(_delegate);
                    break;
                case PT_ADD_ORDER_CONFIRM:
                    addOrderConfirm();
                    break;
                case PT_ADD_ORDER_PAY:
                    _delegate = new _Delegate(this.addOrderPay);
                    this.Invoke(_delegate);
                    break;
                case PT_ITEM_SELECTOR:
                    this.addOrderP.Visible = false;
                    this.itemS.Visible = true;
                    this.itemS.setItems(this.addOrderP.TmpItemList);
                    break;
                case PT_ITEM_SELECTOR_RESULT:
                    this.selectItem();
                    break;
                case PT_SHOW_ADDRESS_SELECTOR:
                    this.addOrderConfirmP.Visible = false;
                    this.addressSelectorP.Visible = true;
                    this.addressSelectorP.loadData();
                    break;
                case PT_ADDESS_SELECTOR_FINISH:
                    this.addressSelectorP.Visible = false;
                    this.addOrderConfirmP.Visible = true;
                    this.addOrderConfirmP.setAddress(this.addressSelectorP.vo);
                    break;
                case PT_FRANCHISEE_SIGNED:  //商家登录成功
                    this.cbFranchiseeSigned();
                    break;
                case PT_POS:
                    this.posBClick();
                    break;
            }

            _delegate = new _Delegate(this.uiRefreshUserInfoP);
            this.Invoke(_delegate);
        }

        private void pickUpBClick()
        {
            if (!Session.getInstance().isCustomerSign())
            {
                MessageBox.Show("请先登录");
                this.signInBClick();
                return;
            }

            this.pickUpOrderListP.Visible = true;
            this.pickUpOrderDetailsP.Visible = false;
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = false;
            this.posP.Visible = false;
            this.signUpP.Visible = false;
            this.signInP.Visible = false;
            this.franchiseeSignInP.Visible = false;
            this.itemS.Visible = false;

            this.pickUpOrderListP.loadData();
        }

        private void pickUpOrderDetails()
        {
            this.pickUpOrderListP.Visible = false;

            this.pickUpOrderDetailsP.setVo(this.pickUpOrderListP.Vo);
            this.pickUpOrderDetailsP.Visible = true;
        }

        private void addOrderBClick()
        {
            if (!Session.getInstance().isCustomerSign())
            {
                MessageBox.Show("请先登录");
                this.signInBClick();
                return;
            }

            this.menuP.setItemClick(1);

            this.pickUpOrderListP.Visible = false;
            this.pickUpOrderDetailsP.Visible = false;
            this.addOrderP.Visible = true;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = false;
            this.posP.Visible = false;
            this.signUpP.Visible = false;
            this.signInP.Visible = false;
            this.franchiseeSignInP.Visible = false;
            this.itemS.Visible = false;

            this.addOrderP.clearItems();
        }

        private void selectItem()
        {
            this.itemS.Visible = false;

            ItemVO vo = this.itemS.getVo();
            if (null != vo)
                this.addOrderP.addItem(vo);

            this.addOrderP.Visible = true;
        }

        private void addOrderConfirm()
        {
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = true;
            this.addOrderPayP.Visible = false;

            this.addOrderConfirmP.setItemList(this.addOrderP.ItemList);
        }

        private void addOrderPay()
        {
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = true;

            this.addOrderPayP.setOrderIdList(Session.getInstance().OrderIdList);
        }

        /// <summary>
        /// POS菜单项点击
        /// </summary>
        private void posBClick()
        {
            this.menuP.setItemClick(2);

            this.pickUpOrderListP.Visible = false;
            this.pickUpOrderDetailsP.Visible = false;
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = false;
            this.posP.Visible = true;
            this.signUpP.Visible = false;
            this.signInP.Visible = false;
            this.franchiseeSignInP.Visible = false;
            this.itemS.Visible = false;
        }

        /// <summary>
        /// 注册菜单项点击
        /// </summary>
        private void signUpBClick()
        {
            //this.menuP.setItemClick(3);

            this.pickUpOrderListP.Visible = false;
            this.pickUpOrderDetailsP.Visible = false;
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = false;
            this.posP.Visible = false;
            this.signUpP.Visible = true;
            this.signInP.Visible = false;
            this.franchiseeSignInP.Visible = false;
            this.itemS.Visible = false;
        }

        /// <summary>
        /// 登录菜单项点击
        /// </summary>
        private void signInBClick()
        {
            this.menuP.setItemClick(4);

            this.pickUpOrderListP.Visible = false;
            this.pickUpOrderDetailsP.Visible = false;
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = false;
            this.posP.Visible = false;
            this.signUpP.Visible = false;
            this.signInP.Visible = true;
            this.franchiseeSignInP.Visible = false;
            this.itemS.Visible = false;
        }

        /// <summary>
        /// 回调：商家登录成功
        /// </summary>
        private void cbFranchiseeSigned()
        {
            //设置菜单项的可视属性
            List<bool> menuItemStatusList = new List<bool>();
            menuItemStatusList.Add(true);
            menuItemStatusList.Add(true);
            menuItemStatusList.Add(true);
            menuItemStatusList.Add(true);
            menuItemStatusList.Add(true);
            this.menuP.setItemStatusList(menuItemStatusList);

            //设置面板的可视属性
            this.hp.Visible = false;
            this.pickUpOrderListP.Visible = false;
            this.pickUpOrderDetailsP.Visible = false;
            this.addOrderP.Visible = false;
            this.addOrderConfirmP.Visible = false;
            this.addOrderPayP.Visible = false;
            this.signUpP.Visible = false;
            this.signInP.Visible = false;
            this.franchiseeSignInP.Visible = false;
            this.itemS.Visible = false;

            //设置主窗口的标题
            this.Text = string.Format("风信子 v{0} - {1}"
                , System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                , Session.getInstance().FranchiseeVO.Name);// "风信子 v6.12- " + Session.getInstance().FranchiseeVO.Name;
        }

        /// <summary>
        /// 回调：左边菜单项点击
        /// </summary>
        /// <param name="position"></param>
        private void menuItemClick(int position)
        {
            switch (position)
            {
                case 0:
                    this.pickUpBClick();
                    break;
                case 1:
                    this.addOrderBClick();
                    break;
                case 2:
                    this.posBClick();
                    break;
                case 3:
                    this.signUpBClick();
                    break;
                case 4:
                    this.signInBClick();
                    break;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        private void signOut()
        {
            this.hp.Visible = true;

            SignOutHandler handler = new SignOutHandler(this.handleFinish);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(hideHP);
            this.Invoke(_delegate);

            if (type == API.T_DISTRICTS)
            {
                if (rc != Handler.RC_SUCCESS)
                {
                    MessageBox.Show("网络异常，请重启软件");
                    Environment.Exit(0);
                }

                List<DistrictVO> districtList = (List<DistrictVO>)content;

                CommonData.getInstance().DistrictList = districtList;

                //判断是否为商家端
                if (Program.APP_TYPE == 2)
                {
                    _delegate = new _Delegate(this.uiShowFranchiseeSignInP);
                    this.Invoke(_delegate);
                }
                else
                {
                    _delegate = new _Delegate(this.signInBClick);
                    this.Invoke(_delegate);
                }
            }
            else if (type == API.T_SIGN_OUT)
            {
                if (rc != Handler.RC_SUCCESS)
                {
                    MessageBox.Show("网络异常，请查看网络连接");
                    return;
                }

                Session.getInstance().customerSignOut();
                MessageBox.Show("退出成功");

                //this.addOrderPayP.stopRefresh();

                _Delegate signInBClickDelegate = new _Delegate(this.signInBClick);
                this.Invoke(signInBClickDelegate);

                _delegate = new _Delegate(this.uiRefreshUserInfoP);
                this.Invoke(_delegate);
            }
        }

        private void uiShowFranchiseeSignInP()
        {
            this.franchiseeSignInP.Visible = true;
        }

        private void uiRefreshUserInfoP()
        {
            Session session = Session.getInstance();

            if (session.isCustomerSign())
            {
                string icNo = session.IcNo;
                if (null == icNo)
                {
                    icNo = "";
                }
                else
                {
                    int l = icNo.Length;
                    if (l == 18)
                        icNo = icNo.Substring(0, 4) + "**********" + icNo.Substring(14, 4);
                    else if (l == 15)
                        icNo = icNo.Substring(0, 4) + "*******" + icNo.Substring(11, 4);
                    else
                        icNo = "";
                }

                this.idNoL.Text = icNo;
                this.usernameL.Text = session.CustomerName;
                this.telL.Text = session.CustomerTel;

                this.signOutB.Visible = true;
            }
            else
            {
                this.idNoL.Text = "-";
                this.usernameL.Text = "-";
                this.telL.Text = "-";

                this.signOutB.Visible = false;
            }
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;

            int menuSpacing = 1;
            int menuW = MainMenu.MENU_WIDTH - menuSpacing * 2;
            int menuH = (h - menuSpacing * 4) / 3;

            int userPH = this.userInfoP.Height;
            int panelW = w - MainMenu.MENU_WIDTH;
            int panelH = h - userPH;

            //Menu
            this.menuP.Location = new Point(0, 0);
            this.menuP.Size = new Size(MainMenu.MENU_WIDTH, h);

            //User Panel
            this.userInfoP.Location = new Point(MainMenu.MENU_WIDTH, 0);
            this.userInfoP.Size = new Size(panelW, userPH);

            int signOutBY = (userPH - this.signOutB.Height) / 2;
            int x = panelW - this.signOutB.Height - this.signOutB.Width;
            this.signOutB.Location = new Point(x, signOutBY);

            //Panel
            this.signUpP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.signUpP.Size = new Size(panelW, panelH);

            this.signInP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.signInP.Size = new Size(panelW, panelH);

            this.franchiseeSignInP.Location = new Point(0, 0);
            this.franchiseeSignInP.Size = new Size(w, h);

            this.pickUpOrderListP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.pickUpOrderListP.Size = new Size(panelW, panelH);

            this.pickUpOrderDetailsP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.pickUpOrderDetailsP.Size = new Size(panelW, panelH);

            this.addOrderP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.addOrderP.Size = new Size(panelW, panelH);

            this.addOrderConfirmP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.addOrderConfirmP.Size = new Size(panelW, panelH);

            this.addOrderPayP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.addOrderPayP.Size = new Size(panelW, panelH);

            this.posP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.posP.Size = new Size(panelW, panelH);

            //Handle Panel
            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);

            //Item Selector
            this.itemS.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.itemS.Size = new Size(panelW, panelH);

            //Address Selector
            this.addressSelectorP.Location = new Point(MainMenu.MENU_WIDTH, userPH);
            this.addressSelectorP.Size = new Size(panelW, panelH);
        }

        private void uiInit()
        {
            //初始化左边菜单
            this.menuP.addItem("我的订单", Properties.Resources.goods);
            this.menuP.addItem("下单", Properties.Resources.order);
            this.menuP.addItem("POS", null);
            this.menuP.addItem("注册", Properties.Resources.user);
            this.menuP.addItem("登录", Properties.Resources.user);

            this.hp.setText("正在初始化......");
            this.hp.Visible = false;

            this.itemS.Visible = false;

            this.signUpP.Visible = false;
            this.signUpP.mainFormCallback = this.panelCallback;

            this.signInP.Visible = false;
            this.signInP.mainFormCallback = this.panelCallback;

            this.franchiseeSignInP.Visible = false;
            this.franchiseeSignInP.BringToFront();
            this.franchiseeSignInP.mainFormCallback = this.panelCallback;

            this.pickUpOrderListP.Visible = false;
            this.pickUpOrderListP.mainFormCallback = this.panelCallback;

            this.pickUpOrderDetailsP.Visible = false;
            this.pickUpOrderDetailsP.mainFormCallback = this.panelCallback;

            this.addOrderP.Visible = false;
            this.addOrderP.mainFormCallback = this.panelCallback;

            this.addOrderConfirmP.Visible = false;
            this.addOrderConfirmP.mainFormCallback = this.panelCallback;

            this.addOrderPayP.Visible = false;
            this.addOrderPayP.mainFormCallback = this.panelCallback;

            this.itemS.Visible = false;
            this.itemS.mainFormCallback = this.panelCallback;

            this.addressSelectorP.Visible = false;
            this.addressSelectorP.mainFormCallback = this.panelCallback;

            this.hp.BringToFront();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.uiInit();
            this.uiResize();
            this.uiRefreshUserInfoP();

            //菜单回调
            this.menuCallback = new MainMenu.MainMenuDelegate(this.menuItemClick);
            this.menuP.setCallback(this.menuCallback);

            //注册读卡回调
            this.cvrDelegate = new CVRHandler.CVRDelegate(this.cvrCallback);
            CVRHandler.getInstance().setCallback(this.cvrDelegate);

            //显示提示面板
            this.hp.Visible = true;

            //加载区域信息
            GetDistrictsHandler handler = new GetDistrictsHandler(this.handleFinish);
            handler.handle();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.init();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void signOutB_Click(object sender, EventArgs e)
        {
            this.signOut();
        }
    }
}
