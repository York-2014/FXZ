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
using funsens.common;
using funsens.common.vo;
using funsens.customer.vo;
using funsens.image;
using funsens.order.vo;

namespace funsens.ui
{
    /// <summary>
    /// 下订单第二步中，每个订单的信息
    /// </summary>
    public partial class OrderConfirmItem : UserControl
    {
        private const int ROW_HEIGHT = 80;

        private AddOrderConfirmPanel addOrderConfirmPanel;

        public MainForm.MainFormCallback mainFormCallback;

        //private ImagePool.ImagePoolCallback _imagePoolCallback;

        //private ImagePool imagePool;

        private List<DistrictVO> provinceList;

        private List<DistrictVO> cityList;

        private List<DistrictVO> districtList;

        private OrderVO vo;

        private float itemTotal;
        public float ItemTotal
        {
            get { return itemTotal; }
        }

        private float freightTotal;
        public float FreightTotal
        {
            get { return freightTotal; }
        }

        //本次（包括拆分后的所有订单）所要交的税费，该值大于0表示本单需要交税
        private float ordersTaxTotal;

        public OrderConfirmItem(AddOrderConfirmPanel addOrderConfirmPanel)
        {
            InitializeComponent();

            this.addOrderConfirmPanel = addOrderConfirmPanel;

            //this._imagePoolCallback = new ImagePool.ImagePoolCallback(this.imagePoolCallback);
            //this.imagePool = new ImagePool(this._imagePoolCallback);
        }

        public void setOrder(float ordersTaxTotal, OrderVO vo)
        {
            this.ordersTaxTotal = ordersTaxTotal;
            this.vo = vo;

            this.uiReloadOrderDGV();
            this.uiResize();
        }

        /// <summary>
        /// 
        /// </summary>
        public JO getInfo()
        {
            int isCarry = 1;
            string name = S.EMPTY;
            string tel = S.EMPTY;
            string provinceId = S.EMPTY;
            string provinceName = S.EMPTY;
            string cityId = S.EMPTY;
            string cityName = S.EMPTY;
            string districtId = S.EMPTY;
            string districtName = S.EMPTY;
            string address = S.EMPTY;
            string zipCode = S.EMPTY;

            if (this.expressRB.Checked)
            {
                isCarry = 0;

                name = this.nameTB.Text;
                if (S.blank(name))
                {
                    MessageBox.Show("请填写姓名");
                    return null;
                }

                tel = this.telTB.Text;
                if (S.blank(tel))
                {
                    MessageBox.Show("请填写电话");
                    return null;
                }

                if (this.provinceCB.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择省份");
                    return null;
                }

                DistrictVO vo = this.provinceList[this.provinceCB.SelectedIndex];
                provinceId = vo.Id;
                provinceName = vo.Name;

                if (this.cityCB.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择城市");
                    return null;
                }

                vo = this.cityList[this.cityCB.SelectedIndex];
                cityId = vo.Id;
                cityName = vo.Name;

                if (this.districtCB.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择区");
                    //return null;
                }
                else
                {
                    vo = this.districtList[this.districtCB.SelectedIndex];
                    districtId = vo.Id;
                    districtName = vo.Name;
                }

                address = this.addressTB.Text;
                if (S.blank(address))
                {
                    MessageBox.Show("请填写详细地址");
                    return null;
                }

                zipCode = this.zipCodeTB.Text;
                if (S.blank(zipCode))
                {
                    MessageBox.Show("请填写邮政编码");
                    return null;
                }
            }
            else
            {
                Session session = Session.getInstance();

                name = session.CustomerName;
                tel = session.CustomerTel;
                address = session.CustomerAddress;
            }

            JO jo = new JO();
            jo.put("isCarry", isCarry);

            string logisticsType = "";
            switch (this.expressTypeCB.SelectedIndex)
            {
                case 0:
                    logisticsType = "ems";
                    break;
                case 1:
                    logisticsType = "mail";
                    break;
                case 2:
                    logisticsType = "express";
                    break;
            }

            jo.put("logistics_type", logisticsType);

            jo.put("name", name);
            jo.put("tel", tel);
            jo.put("provinceId", provinceId);
            jo.put("cityId", cityId);
            jo.put("districtId", districtId);
            jo.put("address", address);
            jo.put("zipCode", zipCode);

            List<OrderDetailsVO> detailsList = this.vo.DetailsList;
            int count = detailsList.Count;
            JA detailsJA = new JA();
            for (int i = 0; i < count; i++)
            {
                OrderDetailsVO detailsVO = detailsList[i];
                JO detailsJO = new JO();
                detailsJO.put("id", detailsVO.ItemId);
                detailsJO.put("amount", detailsVO.Amount);

                detailsJA.put(detailsJO);
            }

            jo.put("detailsList", detailsJA);

            return jo;
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

        private void changeReceiveType()
        {
            if (this.pickupRB.Checked)
            {
                this.expressTypeCB.Enabled = false;
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
                this.expressTypeCB.Enabled = true;
                this.provinceCB.Enabled = true;
                this.cityCB.Enabled = true;
                this.districtCB.Enabled = true;
                this.nameTB.Enabled = true;
                this.telTB.Enabled = true;
                this.addressTB.Enabled = true;
                this.zipCodeTB.Enabled = true;
                this.selectAddressB.Enabled = true;
            }

            this.uiRefreshTotal();
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

            //if (this.provinceList.Count > 0)
                //this.provinceCB.SelectedIndex = 0;
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

        //private void imagePoolCallback(string url, Image image)
        //{
        //    if (null != this.vo)
        //    {
        //        List<OrderDetailsVO> detailsList = this.vo.DetailsList;
        //        int detailsCount = detailsList.Count;
        //        for (int i = 0; i < detailsCount; i++)
        //        {
        //            OrderDetailsVO detailsVO = detailsList[i];
        //            if (url.Equals(detailsVO.ItemImageUrl))
        //            {
        //                detailsVO.ItemImage = image;
        //                this.itemDGV.Rows[i].Cells[0].Value = image;
        //            }
        //        }
        //    }
        //}

        public void uiResetWidth(int width)
        {
            int h = this.ClientRectangle.Height;

            this.Size = new Size(width, h);

            this.itemDGV.Size = new Size(width, this.itemDGV.ClientRectangle.Height);

            this.footerP.Location = new Point(width - this.footerP.ClientRectangle.Width, this.footerP.Location.Y);
        }

        /// <summary>
        /// 刷新总额（商品总额、运费、税费、总额）
        /// </summary>
        private void uiRefreshTotal()
        {
            this.itemTotal = 0.0f;
            this.freightTotal = 0.0f;
            float taxTotal = this.vo.TaxTotal;
            float total = 0.0f;

            if (null != this.vo)
            {
                this.itemTotal = this.vo.ItemTotal;

                if (this.expressRB.Checked)
                {
                    int expressType = this.expressTypeCB.SelectedIndex;
                    switch (expressType)
                    {
                        case 0:
                            this.freightTotal = this.vo.EmsFreight;
                            break;
                        case 1:
                            this.freightTotal = this.vo.MailFreight;
                            break;
                        case 2:
                            this.freightTotal = this.vo.ExpressFreight;
                            break;
                    }
                }
            }

            if (this.ordersTaxTotal > 0)
            {
                total = this.itemTotal + this.freightTotal + taxTotal;
                this.taxTotalL.Font = new Font("SimSun", 14);
            }
            else
            {
                total = this.itemTotal + this.freightTotal;
                this.taxTotalL.Font = new Font("SimSun", 14, FontStyle.Strikeout);
            }

            this.itemTotalL.Text = "￥" + itemTotal;
            this.freightL.Text = "￥" + freightTotal;
            this.taxTotalL.Text = "￥" + taxTotal;
            if (taxTotal > 0)
            {
                pickupRB.Enabled = false;
                expressRB.Checked = true;
                pickupRB.Checked = false;
            }
            this.totalL.Text = "￥" + total;

            this.addOrderConfirmPanel.refreshTotal();
        }

        /// <summary>
        /// 刷新订单列表
        /// </summary>
        private void uiReloadOrderDGV()
        {
            this.itemDGV.Rows.Clear();

            if (null != this.vo)
            {
                List<OrderDetailsVO> detailsList = this.vo.DetailsList;
                int detailsCount = detailsList.Count;
                for (int j = 0; j < detailsCount; j++)
                {
                    OrderDetailsVO detailsVO = detailsList[j];

                    DataGridViewRow row = new DataGridViewRow();
                    row.ReadOnly = true;
                    row.Height = ROW_HEIGHT;

                    //DataGridViewImageCell imageCell = new DataGridViewImageCell();

                    //if (null != detailsVO.ItemImage)
                    //    imageCell.Value = detailsVO.ItemImage;

                    //row.Cells.Add(imageCell);

                    DataGridViewTextBoxCell franchiseeNameCell = new DataGridViewTextBoxCell();
                    franchiseeNameCell.Value = this.vo.FranchiseeName;
                    row.Cells.Add(franchiseeNameCell);

                    DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                    nameCell.Value = detailsVO.ItemName;
                    row.Cells.Add(nameCell);

                    DataGridViewTextBoxCell priceCell = new DataGridViewTextBoxCell();
                    priceCell.Value = detailsVO.ItemPrice.ToString();
                    row.Cells.Add(priceCell);

                    DataGridViewButtonCell subtractAmountCell = new DataGridViewButtonCell();
                    subtractAmountCell.Value = "减少";
                    row.Cells.Add(subtractAmountCell);

                    DataGridViewTextBoxCell amountCell = new DataGridViewTextBoxCell();
                    amountCell.Value = detailsVO.Amount.ToString();
                    row.Cells.Add(amountCell);

                    //DataGridViewButtonCell addAmountCell = new DataGridViewButtonCell();
                    //addAmountCell.Value = "增加";
                    //row.Cells.Add(addAmountCell);

                    this.itemDGV.Rows.Add(row);

                    //this.imagePool.append(detailsVO.ItemImageUrl);
                }
            }

            this.uiRefreshTotal();
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width - 20;
            int generalH = this.generalP.ClientRectangle.Height;

            this.generalP.Location = new Point(0, 0);
            this.generalP.Size = new Size(w, generalH);

            int detailsDGVH = this.itemDGV.ColumnHeadersHeight + 20 + ROW_HEIGHT * this.itemDGV.Rows.Count;
            this.itemDGV.Location = new Point(0, generalH);
            this.itemDGV.Size = new Size(w, detailsDGVH);

            this.footerP.Location = new Point(w - this.footerP.ClientRectangle.Width, generalH + detailsDGVH);

            int h = generalH + detailsDGVH + this.footerP.ClientRectangle.Height;
            this.Size = new Size(w, h);
        }

        private void OrderConfirmItem_Load(object sender, EventArgs e)
        {
            this.itemDGV.Font = new Font("SimSun", Program.DGV_FONT_SIZE);

            this.reloadProvinceCB();

            this.expressTypeCB.SelectedIndex = 0;
            this.changeReceiveType();

            Session session = Session.getInstance();
            this.nameTB.Text = session.CustomerName;
            this.telTB.Text = session.CustomerTel;
            this.addressTB.Text = session.CustomerAddress;
            

            
        }

        private void pickupRB_CheckedChanged(object sender, EventArgs e)
        {
            this.changeReceiveType();
        }

        private void expressRB_CheckedChanged(object sender, EventArgs e)
        {
            this.changeReceiveType();
        }

        private void provinceCB_SelectedIndexChanged(object sender, EventArgs e)
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

        private void expressTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.uiRefreshTotal();
        }

        private void itemDGV_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void itemDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            OrderDetailsVO detailsVO = this.vo.DetailsList[e.RowIndex];

            if (e.ColumnIndex == 3)
                addOrderConfirmPanel.resetAmount(detailsVO.ItemId, -1);
            
           
            //else if (e.ColumnIndex == 5)
            //    addOrderConfirmPanel.resetAmount(detailsVO.ItemId, +1);
        }

        private void districtCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string address = this.provinceList[this.provinceCB.SelectedIndex].Name + this.cityList[this.cityCB.SelectedIndex].Name + this.districtList[this.districtCB.SelectedIndex].Name;
            this.addressTB.Text = address;
            this.addressTB.Select(this.addressTB.TextLength, 0);
            this.addressTB.ScrollToCaret();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
