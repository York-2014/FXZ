using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using x.json;
using x.net.http;
using x.util;
using funsens.api;
using funsens.item;
using funsens.item.vo;
using funsens.image;

namespace funsens.ui
{
    /// <summary>
    /// 下单第一步：选择商品
    /// 通过扫码枪扫到商品并添加到购物车
    /// </summary>
    public partial class AddOrderPanel : UserControl
    {
        private delegate void HideHPDelegate();
        private delegate void AddItemDelegate(ItemVO vo);
        private delegate void AddItemsDelegate(List<ItemVO> itemList);
        private delegate void ShowMessageDelegate(string message);

        public MainForm.MainFormCallback mainFormCallback;

        public static string shopname="";

        //private ImagePool.ImagePoolCallback _imagePoolCallback;

        //private ImagePool imagePool;

        private List<ItemVO> itemList;
        public List<ItemVO> ItemList
        {
            get { return itemList; }
        }

        private List<ItemVO> tmpItemList;
        public List<ItemVO> TmpItemList
        {
            get { return tmpItemList; }
        }

        public AddOrderPanel()
        {
            InitializeComponent();

            //this._imagePoolCallback = new ImagePool.ImagePoolCallback(this.imagePoolCallback);
            //this.imagePool = new ImagePool(this._imagePoolCallback);

            this.itemList = new List<ItemVO>();
        }

        /// <summary>
        /// 清空商品列表
        /// </summary>
        public void clearItems()
        {
            this.tmpItemList = new List<ItemVO>();
            this.itemList = new List<ItemVO>();
            this.itemDGV.Rows.Clear();
        }

        public void addItem(ItemVO vo)
        {
            int position = -1;
            int count = this.itemList.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.itemList[i].Id.Equals(vo.Id))
                {
                    this.itemList[i].Amount += 1;
                    position = i;
                    break;
                }
            }

            if (position == -1)
            {
                vo.Amount = 1;
                this.itemList.Add(vo);

                //添加行
                this.uiItemDGVAdd(vo);

                //获取商品图片
                //if (null == vo.Image)
                //    this.imagePool.append(vo.ImageUrl);
            }
            else
            {
                this.uiRefreshItemDGV();
            }

            this.uiRefreshFooter();
        }

        public void addItems(List<ItemVO> itemList)
        {
            this.hp.Visible = false;

            if (null == itemList)
            {
                MessageBox.Show("网络异常，加载商品失败");
                return;
            }

            if (itemList.Count > 1)
            {
                this.tmpItemList = itemList;
                this.mainFormCallback(MainForm.PT_ITEM_SELECTOR);
            }
            else if (itemList.Count == 1)
            {
                this.addItem(itemList[0]);
            }
            else
            {
                MessageBox.Show("查询不到相关商品");
            }

            this.uiRefreshFooter();
        }

        /// <summary>
        /// 加载商品信息
        /// </summary>
        private void loadItem()
        {
            string barcode = this.barcodeTB.Text;
            if (S.blank(barcode))
            {
                MessageBox.Show("请输入条形码");
                return;
            }

            this.barcodeTB.Text = "";

            this.loadItem(barcode);
        }

        /// <summary>
        /// 加载商品信息
        /// </summary>
        /// <param name="barcode"></param>
        private void loadItem(string barcode)
        {
            this.hp.Visible = true;

            GetItemsHandler handler = new GetItemsHandler(this.handleFinish, barcode);
            handler.handle();
        }

        /// <summary>
        /// 回调：接口处理完成
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rc"></param>
        /// <param name="error"></param>
        /// <param name="content"></param>
        private void handleFinish(int type, int rc, string error, object content)
        {
            HideHPDelegate hideHPDelegate = new HideHPDelegate(this.uiHideHP);
            this.Invoke(hideHPDelegate);

            ShowMessageDelegate showMessageDelegate = new ShowMessageDelegate(this.uiShowMessage);

            JO jo = null;

            if (null == content)
            {
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回空内容" });
                return;
            }
            else if ("0".Equals(content.ToString()))
            {
                return;
            }
            else if ((jo = new JO(content.ToString())).isNull())
            {
                this.Invoke(showMessageDelegate, new object[] { "服务器异常，返回值为:\n" + content.ToString() });
                return;
            }

            if (type == API.T_ITEM && rc == Handler.RC_SUCCESS)
            {
                int result = jo.getInt("result");

                if (result == 0)
                {
                    this.Invoke(showMessageDelegate, new object[] { "查找不到商品" });
                }
                else if (result > 0)
                {
                    JA itemJA = jo.getJA("list");
                    int count = itemJA.size();

                    if (count > 0)
                    {
                        List<ItemVO> resultList = new List<ItemVO>();

                        for (int i = 0; i < count; i++)
                        {
                            JO itemJO = itemJA.getJO(i);
                            ItemVO vo = new ItemVO(itemJO);

                            resultList.Add(vo);
                        }

                        int flag = -1;
                        List<ItemVO> tmpList = new List<ItemVO>();
                        for (int i = 0; i < count; i++)
                        {
                            ItemVO itemVO = resultList[i];

                            if (itemVO.Stock < 1)               //判断是否没有库存
                                flag = 1;
                            else if (itemVO.IsShelves != 1)     //判断是否已下架
                                flag = 2;
                            else
                                tmpList.Add(itemVO);
                        }

                        if (tmpList.Count < 1)
                        {
                            if (flag == 1)
                                this.Invoke(showMessageDelegate, new object[] { "商品库存不足" });
                            else
                                this.Invoke(showMessageDelegate, new object[] { "商品已下架" });

                            this.Invoke(hideHPDelegate);
                            return;
                        }

                        AddItemsDelegate _delegate = new AddItemsDelegate(this.addItems);
                        this.Invoke(_delegate, new object[] { tmpList });
                    }
                    else
                    {
                        this.Invoke(showMessageDelegate, new object[] { "查找不到商品" });
                        return;
                    }
                }
                else
                {
                    this.Invoke(showMessageDelegate, new object[] { "加载商品信息失败，编码为：" + result });
                }
            }
            else
            {
                this.Invoke(showMessageDelegate, new object[] { "加载商品信息失败" });
            }
        }

        //private void imagePoolCallback(string url, Image image)
        //{
        //    int count = this.itemList.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        ItemVO vo = this.itemList[i];
        //        if (url.Equals(vo.ImageUrl))
        //        {
        //            vo.Image = image;
        //            this.itemDGV.Rows[i].Cells[0].Value = image;
        //        }
        //    }
        //}

        /// <summary>
        /// 刷新商品列表
        /// </summary>
        private void uiRefreshItemDGV()
        {
            int count = this.itemList.Count;
            if (this.itemDGV.Rows.Count == count)
            {
                for (int i = 0; i < count; i++)
                {
                    ItemVO vo = this.itemList[i];

                    DataGridViewRow row = this.itemDGV.Rows[i];

                    //if (null != vo.Image)
                    //    row.Cells[0].Value = vo.Image;
                   
                       

                    row.Cells[0].Value = vo.FranchiseeName;

                    row.Cells[1].Value = vo.Name;

                    row.Cells[2].Value = vo.Price;

                    row.Cells[5].Value = vo.Amount;

                    row.Cells[7].Value = vo.Stock;

                    //row.Cells[8].Value = vo.StoreStock;
                }
            }
            else
            {
                int tmpCount = this.itemList.Count;
                List<ItemVO> tmp = new List<ItemVO>();
                for (int i = 0; i < tmpCount; i++)
                    tmp.Add(this.itemList[i]);

                this.itemDGV.Rows.Clear();

                this.itemList = new List<ItemVO>();
                for (int i = 0; i < tmpCount; i++)
                    this.itemList.Add(tmp[i]);

                for (int i = 0; i < tmpCount; i++)
                {
                    ItemVO vo = this.itemList[i];
                    this.uiItemDGVAdd(vo);
                }
            }
        }

        /// <summary>
        /// 商品列表添加行
        /// </summary>
        /// <param name="vo"></param>
        private void uiItemDGVAdd(ItemVO vo)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Height = 50;

            //DataGridViewImageCell imageCell = new DataGridViewImageCell();
            //if (null != vo.Image)
            //    imageCell.Value = vo.Image;

            //row.Cells.Add(imageCell);

            DataGridViewTextBoxCell franchiseeNameCell = new DataGridViewTextBoxCell();
            franchiseeNameCell.Value = vo.FranchiseeName;
            row.Cells.Add(franchiseeNameCell);

            //shopname = vo.FranchiseeName;

            DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
            nameCell.Value = vo.Name;
            row.Cells.Add(nameCell);

            DataGridViewTextBoxCell priceCell = new DataGridViewTextBoxCell();
            priceCell.Value = vo.Price.ToString();
            row.Cells.Add(priceCell);

            DataGridViewTextBoxCell taxCell = new DataGridViewTextBoxCell();
            taxCell.Value = vo.Tax + "%";
            row.Cells.Add(taxCell);

            DataGridViewButtonCell subtractAmountCell = new DataGridViewButtonCell();
            subtractAmountCell.Value = "减少";
            row.Cells.Add(subtractAmountCell);

            DataGridViewTextBoxCell amountCell = new DataGridViewTextBoxCell();
            amountCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            amountCell.Value = vo.Amount;
            row.Cells.Add(amountCell);

            DataGridViewButtonCell addAmountCell = new DataGridViewButtonCell();
            addAmountCell.Value = "增加";
            row.Cells.Add(addAmountCell);

            DataGridViewTextBoxCell StockCell = new DataGridViewTextBoxCell();
            StockCell.Value = vo.Stock.ToString();
            row.Cells.Add(StockCell);

            //DataGridViewTextBoxCell StoreStockCell = new DataGridViewTextBoxCell();
            //StoreStockCell.Value = vo.StoreStock.ToString();
            //row.Cells.Add(StoreStockCell);

            this.itemDGV.Rows.Add(row);

            this.itemDGV.ClearSelection();

            this.itemDGV.Rows[0].Selected = false; //不选第一行
            this.itemDGV.TabStop = false; //
            this.itemDGV.Rows[this.itemDGV.Rows.Count - 1].Selected = true;
            //选定选中行
            this.itemDGV.FirstDisplayedScrollingRowIndex = this.itemDGV.Rows.Count - 1;
            //控制滚动条自动下滑
        }

        /// <summary>
        /// 刷新底部视图
        /// </summary>
        private void uiRefreshFooter()
        {
            int itemCount = 0;
            float itemTotal = 0.0f;
            float taxTotal = 0.0f;
            float total = 0.0f;

            int count = this.itemList.Count;
            for (int i = 0; i < count; i++)
            {
                ItemVO vo = this.itemList[i];

                itemCount += vo.Amount;

                float tmpTotal = vo.Price * vo.Amount;
                itemTotal += tmpTotal;

                taxTotal += tmpTotal * (vo.Tax / 100);
            }

            total = itemTotal + taxTotal;

            this.itemCountL.Text = itemCount.ToString();
            this.itemTotalL.Text = itemTotal.ToString();
            //this.taxL.Text = taxTotal.ToString();
            this.totalL.Text = total.ToString();
        }

        private void uiHideHP()
        {
            this.hp.Visible = false;
        }

        private void uiShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// 视图大小变更
        /// </summary>
        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 5;
            int titleH = this.titleP.ClientRectangle.Height;
            int toolbarH = 40;
            int footerH = footerP.ClientRectangle.Height;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            this.barcodeTB.Location = new Point(spacing * 2, titleH + (toolbarH - this.barcodeTB.Size.Height) / 2);
            this.addItemB.Location = new Point(this.barcodeTB.Location.X + this.barcodeTB.Size.Width + spacing, titleH + (toolbarH - this.addItemB.Size.Height) / 2);

            this.itemDGV.Location = new Point(spacing, titleH + toolbarH);
            this.itemDGV.Size = new Size(w - spacing * 2, h - titleH - toolbarH - footerH - spacing);

            this.footerP.Location = new Point(w - this.footerP.ClientRectangle.Width, h - this.footerP.ClientRectangle.Height);

            this.hp.Location = new Point(0, 0);
            this.hp.Size = new Size(w, h);
        }

        /// <summary>
        /// 初始化视图
        /// </summary>
        private void uiInitView()
        {
            this.titleP.setTitle("下单");

            this.hp.Visible = false;

            this.uiResize();
        }

        private void AddOrderPanel_Load(object sender, EventArgs e)
        {
            this.itemDGV.Font = new Font("SimSun", Program.DGV_FONT_SIZE);

            this.uiInitView();
        }

        private void addItemB_Click(object sender, EventArgs e)
        {
            this.loadItem();
        }

        private void AddOrderPanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void addOrderB_Click(object sender, EventArgs e)
        {
            if (this.itemList.Count < 1)
            {
                MessageBox.Show("请选择要购买的商品");
                return;
            }
            shopname = this.itemList[0].FranchiseeName.ToString();
            this.mainFormCallback(MainForm.PT_ADD_ORDER_CONFIRM);
        }

        private void itemDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0)
                return;

            ItemVO vo = this.itemList[index];

            if (e.ColumnIndex == 4)
                vo.Amount = vo.Amount - 1;


            else if (e.ColumnIndex == 6)
                if (vo.Amount < vo.Stock) vo.Amount = vo.Amount + 1;
                else MessageBox.Show("库存不足！");

            if (vo.Amount < 1)
                this.itemList.RemoveAt(index);

            this.uiRefreshItemDGV();

            this.uiRefreshFooter();
        }

        private void barcodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadItem();
        }

        private void itemDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (null != this.itemList && this.itemList.Count > e.RowIndex)
                this.itemList.RemoveAt(e.RowIndex);
        }

        private void itemDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 != e.RowIndex && 5 == e.ColumnIndex)
            {
                ItemVO vo = this.itemList[e.RowIndex];
                string item = itemDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (bolnum(item))
                {
                    vo.Amount = Convert.ToInt32(itemDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (vo.Amount > vo.Stock)
                    {
                        MessageBox.Show("库存不足！");
                        itemDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;

                    }
                    else if (vo.Amount < 0)
                    {
                        MessageBox.Show("数量有误,不得小于0！");
                    }


                }
                else
                {
                    MessageBox.Show("输入有误，请重输数字！");

                    itemDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                }
                this.uiRefreshItemDGV();

                this.uiRefreshFooter();
            }
        }
        public bool bolnum(string temp)
        {
            int num = 0;
            return int.TryParse(temp, out num);

            //for (int i = 0; i < temp.Length; i++)
            //{
            //    byte tempbyte = Convert.ToByte(temp[i]);
            //    if ((tempbyte < 48) || (tempbyte > 57))
            //        return false;
            //}
            //return true;

        }
    }
}
