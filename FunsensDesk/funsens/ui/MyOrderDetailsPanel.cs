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
using funsens.image;
using funsens.item.vo;
using funsens.order.vo;

namespace funsens.ui
{
    /// <summary>
    /// 订单明细界面，在“我的订单”界面打开
    /// </summary>
    public partial class MyOrderDetailsPanel : UserControl
    {
        private delegate void _Delegate();
        private delegate void _Delegate1(int rc);

        public MainForm.MainFormCallback mainFormCallback;

        //private ImagePool.ImagePoolCallback _imagePoolCallback;

        //private ImagePool imagePool;

        private OrderVO vo;

        private string barcode;

        public MyOrderDetailsPanel()
        {
            InitializeComponent();

            this.hp.Visible = false;

            //this._imagePoolCallback = new ImagePool.ImagePoolCallback(this.imagePoolCallback);
            //this.imagePool = new ImagePool(this._imagePoolCallback);

            this.barcode = S.EMPTY;
        }

        public void setVo(OrderVO vo)
        {
            this.vo = vo;

            this.reloadItemDGV();

            this.uiRefreshFooter();
        }

        private void save()
        {
            bool isFinish = true;
            List<ItemVO> itemList = this.vo.ItemList;
            int count = itemList.Count;
            for(int i=0;i<count;i++)
            {
                ItemVO itemVO = itemList[i];
                if(!itemVO.IsSelected)
                {
                    isFinish = false;
                    break;
                }
            }

            if(!isFinish)
            {
                MessageBox.Show("您还有尚未提取的商品");
                return;
            }

            this.hp.Visible = true;
            ModifyOrderStatusHandler handler = new ModifyOrderStatusHandler(this.handleFinish, this.vo.Id, OrderVO.STATUS_FINISH);
            handler.handle();
        }

        private void reloadItemDGV()
        {
            this.itemDGV.Rows.Clear();

            if (null == this.vo)
                return;

            List<ItemVO> itemList = this.vo.ItemList;
            int count = itemList.Count;
            for(int i=0;i<count;i++)
            {
                ItemVO itemVO = itemList[i];

                //新增行
                DataGridViewRow row = new DataGridViewRow();
                row.ReadOnly = true;
                row.Height = 100;

                DataGridViewTextBoxCell barcodeCell = new DataGridViewTextBoxCell();
                barcodeCell.Value = itemVO.Barcode;
                row.Cells.Add(barcodeCell);

                //DataGridViewImageCell imageCell = new DataGridViewImageCell();
                //if (null != itemVO.Image)
                //    imageCell.Value = itemVO.Image;

                //row.Cells.Add(imageCell);

                DataGridViewTextBoxCell franchiseeNameCell = new DataGridViewTextBoxCell();
                franchiseeNameCell.Value = itemVO.FranchiseeName;
                row.Cells.Add(franchiseeNameCell);

                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = itemVO.Name;
                row.Cells.Add(nameCell);

                DataGridViewTextBoxCell priceCell = new DataGridViewTextBoxCell();
                priceCell.Value = itemVO.Price;
                row.Cells.Add(priceCell);

                DataGridViewTextBoxCell taxCell = new DataGridViewTextBoxCell();
                taxCell.Value = itemVO.Tax * itemVO.Price / 100;
                row.Cells.Add(taxCell);

                DataGridViewTextBoxCell amountCell = new DataGridViewTextBoxCell();
                amountCell.Value = itemVO.Amount;
                row.Cells.Add(amountCell);

                DataGridViewTextBoxCell totalCell = new DataGridViewTextBoxCell();
                totalCell.Value = (itemVO.Price * itemVO.Amount);
                row.Cells.Add(totalCell);

                this.itemDGV.Rows.Add(row);

                ////加载图片
                //if (null == itemVO.Image && !S.blank(itemVO.ImageUrl))
                //    this.imagePool.append(itemVO.ImageUrl);
            }
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            _Delegate _delegate = new _Delegate(hideHP);

            if (rc != Handler.RC_SUCCESS)
            {
                this.Invoke(_delegate);
                MessageBox.Show("网络异常，请稍后再试。6");
                return;
            }

            if (type == API.T_MODIFY_ORDER_STATUS)
            {
                int result = (new JO(content.ToString())).getInt("result");

                _Delegate1 _d1 = new _Delegate1(this.modifyResult);
                this.Invoke(_d1, new object[] { result });
            }
        }

        //private void imagePoolCallback(string url, Image image)
        //{
        //    List<ItemVO> itemList = this.vo.ItemList;
        //    int count = itemList.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        ItemVO vo = itemList[i];
        //        if (url.Equals(vo.ImageUrl))
        //        {
        //            vo.Image = image;
        //            this.itemDGV.Rows[i].Cells[1].Value = image;
        //        }
        //    }
        //}

        private void modifyResult(int rc)
        {
            switch(rc)
            {
                case -3:
                    MessageBox.Show("您尚未登录");
                    break;
                case -2:
                    MessageBox.Show("订单状态错误");
                    break;
                case -1:
                    MessageBox.Show("参数有误");
                    break;
                case 0:
                    MessageBox.Show("操作失败");
                    break;
                case 1:
                    MessageBox.Show("提货成功");

                    this.mainFormCallback(MainForm.PT_PICK_UP_ORDER_LIST);

                    break;
            }
        }

        private void hideHP()
        {
            this.hp.Visible = false;
        }

        private void scannerListen(Keys key)
        {
            if (key == Keys.Enter)
            {
                List<ItemVO> itemList = this.vo.ItemList;
                int count = itemList.Count;
                bool isFinish = false;  //如果存在相同条形码的商品，每次扫描只处理第一个未扫描的商品
                for (int i = 0; i < count; i++)
                {
                    ItemVO vo = itemList[i];
                    if (!vo.IsSelected && barcode.Equals(vo.Barcode) && !isFinish)
                    {
                        vo.IsSelected = true;
                        this.itemDGV.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        isFinish = true;
                    }
                    else
                    {
                        this.itemDGV.Rows[i].DefaultCellStyle.BackColor = SystemColors.Control;
                    }
                }

                this.barcode = S.EMPTY;
            }
            else
            {
                string s = (new ASCIIEncoding()).GetString(new byte[] { (byte)key });
                this.barcode += s;
            }
        }

        private void uiRefreshFooter()
        {
            List<ItemVO> itemList = this.vo.ItemList;
            int count = itemList.Count;
            int amount = 0;
            double total = 0.00;
            double totalt = 0.00;
            double taxx = 0.00;
            for (int i = 0; i < count; i++)
            {
                ItemVO itemVO = itemList[i];
                amount += itemVO.Amount;
                total += (itemVO.Price * itemVO.Amount);
                taxx += itemVO.Price * itemVO.Amount * itemVO.Tax / 100;
                totalt += (itemVO.Price * itemVO.Amount) * (1 + itemVO.Tax / 100);
            }
            if (taxx <= 50)
            {
                totalt = totalt - taxx;
                this.label5.Font = new Font("SimSun", 14, FontStyle.Strikeout);
            }
            else this.label5.Font = new Font("SimSun", 14);
            this.itemCountL.Text = amount.ToString();
            this.totalL.Text = "￥" + total.ToString();
            this.label4.Text = "￥" + totalt.ToString();
            this.label5.Text = "+ ￥" + taxx.ToString();
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 5;
            int titleH = this.titleP.ClientRectangle.Height;
            int footerW = this.footerP.ClientRectangle.Width;
            int footerH = this.footerP.ClientRectangle.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            this.itemDGV.Location = new Point(spacing, spacing + titleH);
            this.itemDGV.Size = new Size(w - spacing * 2, h - spacing * 2 - titleH - footerH);

            this.footerP.Location = new Point(w - spacing - footerW, h - spacing - footerH);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        private void uiInitView()
        {
            this.titleP.setTitle("订单明细");

            this.hp.Visible = false;

            this.uiResize();
        }

        private void PickUpOrderDetailsPanel_Load(object sender, EventArgs e)
        {
            this.itemDGV.Font = new Font("SimSun", Program.DGV_FONT_SIZE);

            this.uiInitView();
        }

        private void PickUpOrderDetailsPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void itemDGV_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            //this.scannerListen(e.KeyCode);
        }

        private void PickUpOrderDetailsPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.itemDGV.Focus();
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            //this.save();
            this.mainFormCallback(MainForm.PT_PICK_UP_ORDER_LIST);
        }
    }
}
