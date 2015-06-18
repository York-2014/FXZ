using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.util;
using funsens.api;
using funsens.common;
using funsens.common.vo;
using funsens.customer.vo;
using funsens.item.vo;

namespace funsens.ui
{
    public partial class OrderConfirmPanel : UserControl
    {
        private delegate void _Delegate();

        public MainForm.MainFormCallback mainFormCallback;

        private List<DistrictVO> provinceList;

        private List<DistrictVO> cityList;

        private List<DistrictVO> districtList;

        private List<ItemVO> itemList;

        public OrderConfirmPanel()
        {
            InitializeComponent();
        }

        public void setItemList(List<ItemVO> itemList)
        {
            this.itemList = itemList;

            this.itemDGV.Rows.Clear();
            int count = this.itemList.Count;
            for(int i=0;i<count;i++)
            {
                ItemVO vo = this.itemList[i];

                DataGridViewRow row = new DataGridViewRow();
                row.Height = 100;

                DataGridViewImageCell imageCell = new DataGridViewImageCell();

                if (null != vo.Image)
                    imageCell.Value = vo.Image;

                row.Cells.Add(imageCell);

                DataGridViewTextBoxCell franchiseeNameCell = new DataGridViewTextBoxCell();
                franchiseeNameCell.Value = vo.FranchiseeName;
                row.Cells.Add(franchiseeNameCell);

                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = vo.Name;
                row.Cells.Add(nameCell);

                DataGridViewTextBoxCell priceCell = new DataGridViewTextBoxCell();
                priceCell.Value = vo.Price.ToString();
                row.Cells.Add(priceCell);

                DataGridViewTextBoxCell amountCell = new DataGridViewTextBoxCell();
                amountCell.Value = vo.Amount.ToString();
                row.Cells.Add(amountCell);

                this.itemDGV.Rows.Add(row);
            }
        }

        public void setAddress(AddressVO vo)
        {
            if (null == vo)
                return;

            this.nameTB.Text = vo.Name;
            this.telTB.Text = vo.Tel;
            this.addressTB.Text = vo.Address;

            int count = this.provinceList.Count;
            for (int i = 0; i < count; i++)
            {
                DistrictVO districtVO = this.provinceList[i];
                if (districtVO.Id.Equals(vo.ProvinceId))
                {
                    this.provinceCB.SelectedIndex = i;
                    break;
                }
            }

            count = this.cityList.Count;
            for (int i = 0; i < count; i++)
            {
                DistrictVO districtVO = this.cityList[i];
                if (districtVO.Id.Equals(vo.CityId))
                {
                    this.cityCB.SelectedIndex = i;
                    break;
                }
            }

            count = this.districtList.Count;
            for (int i = 0; i < count; i++)
            {
                DistrictVO districtVO = this.districtList[i];
                if (districtVO.Id.Equals(vo.AreaId))
                {
                    this.districtCB.SelectedIndex = i;
                    break;
                }
            }

            this.zipCodeTB.Text = vo.ZipCode;
        }

        private void save()
        {
            int isCarry = 1;
            string name = S.EMPTY;
            string tel = S.EMPTY;
            string provinceId = S.EMPTY;
            string provinceName = S.EMPTY;
            string cityId = S.EMPTY;
            string cityName = S.EMPTY;
            string areaId = S.EMPTY;
            string areaName = S.EMPTY;
            string address = S.EMPTY;
            string zipCode = S.EMPTY;

            if (this.expressRB.Checked)
            {
                isCarry = 0;

                name = this.nameTB.Text;
                if (S.blank(name))
                {
                    MessageBox.Show("请填写姓名");
                    return;
                }

                tel = this.telTB.Text;
                if (S.blank(tel))
                {
                    MessageBox.Show("请填写电话");
                    return;
                }

                if (this.provinceCB.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择省份");
                    return;
                }

                DistrictVO vo = this.provinceList[this.provinceCB.SelectedIndex];
                provinceId = vo.Id;
                provinceName = vo.Name;

                if (this.cityCB.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择城市");
                    return;
                }

                vo = this.cityList[this.cityCB.SelectedIndex];
                cityId = vo.Id;
                cityName = vo.Name;

                if (this.districtCB.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择区");
                    return;
                }

                vo = this.districtList[this.districtCB.SelectedIndex];
                areaId = vo.Id;
                areaName = vo.Name;

                address = this.addressTB.Text;
                if (S.blank(address))
                {
                    MessageBox.Show("请填写详细地址");
                    return;
                }

                zipCode = this.zipCodeTB.Text;
                if (S.blank(zipCode))
                {
                    MessageBox.Show("请填写邮政编码");
                    return;
                }
            }

            this.hp.Visible = true;

            AddOrderHandler handler = new AddOrderHandler(this.handleFinish, this.itemList, isCarry, name, tel, provinceId, provinceName, cityId, cityName, areaId, areaName, address, zipCode);
            handler.handle();
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(this.hideHP);
            this.Invoke(_delegate);

            if (type == API.T_ADD_ORDER)
            {
                if (rc == Handler.RC_SUCCESS)
                {
                    int result = int.Parse(content.ToString());
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show("您尚未登录");
                            break;
                        case 1:
                            MessageBox.Show("参数有误");
                            break;
                        case 2:
                            MessageBox.Show("下单成功，部分库存不足");
                            this.mainFormCallback(MainForm.PT_ADD_ORDER);
                            break;
                        case 3:
                            MessageBox.Show("下单成功");
                            this.mainFormCallback(MainForm.PT_ADD_ORDER);
                            break;
                        default:
                            MessageBox.Show("系统异常，请稍后再试");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("系统异常，请稍后再试");
                }
            }
        }

        private void hideHP()
        {
            this.hp.Visible = false;
        }

        private void changeReceiveType()
        {
            if(this.pickupRB.Checked)
            {
                this.provinceCB.Enabled = false;
                this.cityCB.Enabled = false;
                this.districtCB.Enabled = false;
                this.nameTB.Enabled = false;
                this.telTB.Enabled = false;
                this.addressTB.Enabled = false;
                this.zipCodeTB.Enabled = false;
                this.selectAddressB.Enabled = false;
            }
            else
            {
                this.provinceCB.Enabled = true;
                this.cityCB.Enabled = true;
                this.districtCB.Enabled = true;
                this.nameTB.Enabled = true;
                this.telTB.Enabled = true;
                this.addressTB.Enabled = true;
                this.zipCodeTB.Enabled = true;
                this.selectAddressB.Enabled = true;
            }
        }

        public void reloadProvinceCB()
        {
            List<DistrictVO> districtList = CommonData.getInstance().DistrictList;
            int count = districtList.Count;
            this.provinceList = new List<DistrictVO>();
            this.provinceCB.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                DistrictVO vo = districtList[i];
                if (DistrictVO.ROOT_ID.Equals(vo.ParentId))
                {
                    this.provinceList.Add(vo);
                    this.provinceCB.Items.Add(vo.Name);
                }
            }

            if (this.provinceList.Count > 0)
                this.provinceCB.SelectedIndex = 0;
        }

        private void reloadCityCB()
        {
            this.cityCB.Items.Clear();

            int provinceIndex = this.provinceCB.SelectedIndex;
            if (provinceIndex < 0 || provinceIndex >= this.provinceList.Count)
                return;

            string provinceId = this.provinceList[provinceIndex].Id;

            List<DistrictVO> districtList = CommonData.getInstance().DistrictList;
            int count = districtList.Count;
            this.cityList = new List<DistrictVO>();
            for (int i = 0; i < count; i++)
            {
                DistrictVO vo = districtList[i];
                if (provinceId.Equals(vo.ParentId))
                {
                    this.cityList.Add(vo);
                    this.cityCB.Items.Add(vo.Name);
                }
            }

            if (this.cityList.Count > 0)
                this.cityCB.SelectedIndex = 0;
        }

        private void reloadDistrictCB()
        {
            this.districtCB.Items.Clear();

            int cityIndex = this.cityCB.SelectedIndex;
            if (cityIndex < 0 || cityIndex >= this.cityList.Count)
                return;

            string cityId = this.cityList[cityIndex].Id;

            List<DistrictVO> districtList = CommonData.getInstance().DistrictList;
            int count = districtList.Count;
            this.districtList = new List<DistrictVO>();
            for (int i = 0; i < count; i++)
            {
                DistrictVO vo = districtList[i];
                if (cityId.Equals(vo.ParentId))
                {
                    this.districtList.Add(vo);
                    this.districtCB.Items.Add(vo.Name);
                }
            }

            if (this.districtList.Count > 0)
                this.districtCB.SelectedIndex = 0;
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 5;
            int titleH = this.titleP.ClientRectangle.Height;
            int generalPH = this.generalP.ClientRectangle.Height;
            int footerH = this.footerB.ClientRectangle.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            this.generalP.Location = new Point(spacing, titleH);

            this.itemDGV.Location = new Point(spacing, spacing + titleH + generalPH);
            this.itemDGV.Size = new Size(w - spacing * 2, h - spacing * 2 - titleH - generalPH - footerH);

            this.footerB.Location = new Point(w - spacing - this.footerB.ClientRectangle.Width, h - spacing - footerH);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        private void uiInitView()
        {
            this.titleP.setTitle("订单确认");

            this.hp.Visible = false;

            this.uiResize();
        }

        private void OrderConfirmPanel_Load(object sender, EventArgs e)
        {
            this.uiInitView();

            this.changeReceiveType();
        }

        private void OrderConfirmPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void pickupRB_CheckedChanged(object sender, EventArgs e)
        {
            this.changeReceiveType();
        }

        private void expressRB_CheckedChanged(object sender, EventArgs e)
        {
            this.changeReceiveType();
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            this.save();
        }

        private void provinceCB_SelectedValueChanged(object sender, EventArgs e)
        {
            this.reloadCityCB();
        }

        private void cityCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reloadDistrictCB();
        }

        private void selectAddressB_Click(object sender, EventArgs e)
        {
            this.mainFormCallback(MainForm.PT_SHOW_ADDRESS_SELECTOR);
        }
    }
}
