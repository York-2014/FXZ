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
using funsens.api;
using funsens.common;
using funsens.customer.vo;

namespace funsens.ui
{
    /// <summary>
    /// 选择客户收货地址
    /// </summary>
    public partial class AddressSelector : UserControl
    {
        private delegate void _Delegate();

        public MainForm.MainFormCallback mainFormCallback;

        private List<AddressVO> addressList;

        public AddressVO vo;

        public AddressSelector()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            this.showHP();

            GetAddressesHandler handler = new GetAddressesHandler(this.handleFinish);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(this.hideHP);
            this.Invoke(_delegate);

            if (rc != Handler.RC_SUCCESS)
            {
                this.Invoke(_delegate);
                MessageBox.Show("网络异常，请稍后再试。3");
                return;
            }

            if (type == API.T_ADDRESSES)
            {
                this.addressList = (List<AddressVO>)content;

                _delegate = new _Delegate(this.uiReloadAddressDGV);
                this.Invoke(_delegate);
            }
        }

        private void select()
        {
            DataGridViewSelectedRowCollection c = this.addressDGV.SelectedRows;
            if(c.Count < 1)
            {
                MessageBox.Show("请选择地址");
                return;
            }

            this.vo = this.addressList[c[0].Index];
            this.mainFormCallback(MainForm.PT_ADDESS_SELECTOR_FINISH);
        }

        private void showHP()
        {
            this.hp.Visible = true;
        }

        private void hideHP()
        {
            this.hp.Visible = false;
        }

        private void uiReloadAddressDGV()
        {
            this.addressDGV.Rows.Clear();

            int count = this.addressList.Count;
            for(int i=0;i<count;i++)
            {
                AddressVO vo = this.addressList[i];

                DataGridViewRow row = new DataGridViewRow();
                row.Height = 100;

                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = vo.Name;
                row.Cells.Add(nameCell);

                DataGridViewTextBoxCell telCell = new DataGridViewTextBoxCell();
                telCell.Value = vo.Tel;
                row.Cells.Add(telCell);

                DataGridViewTextBoxCell addressCell = new DataGridViewTextBoxCell();
                addressCell.Value = vo.ProvinceName + vo.CityName + vo.AreaName + vo.Address;
                row.Cells.Add(addressCell);

                DataGridViewTextBoxCell zipCodeCell = new DataGridViewTextBoxCell();
                zipCodeCell.Value = vo.ZipCode;
                row.Cells.Add(zipCodeCell);

                this.addressDGV.Rows.Add(row);
            }
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 5;
            int footerH = this.footerP.ClientRectangle.Height;

            this.addressDGV.Location = new Point(spacing, spacing);
            this.addressDGV.Size = new Size(w - spacing * 2, h - spacing - footerH);

            this.footerP.Location = new Point(w - spacing - this.footerP.ClientRectangle.Width, h - this.footerP.ClientRectangle.Height);
        }

        private void AddressSelector_Load(object sender, EventArgs e)
        {
            this.addressDGV.Font = new Font("SimSun", Program.DGV_FONT_SIZE);

            this.uiResize();
        }

        private void AddressSelector_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void addressDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.vo = this.addressList[e.RowIndex];
            this.mainFormCallback(MainForm.PT_ADDESS_SELECTOR_FINISH);
        }

        private void selectB_Click(object sender, EventArgs e)
        {
            this.select();
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.mainFormCallback(MainForm.PT_ADDESS_SELECTOR_FINISH);
        }
    }
}
