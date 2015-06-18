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
using x.net.http;
using funsens.image;
using funsens.item.vo;

namespace funsens.ui
{
    public partial class ItemSelector : UserControl
    {
        public MainForm.MainFormCallback mainFormCallback;

        //private ImagePool.ImagePoolCallback _imagePoolCallback;

        //private ImagePool imagePool;

        private List<ItemVO> itemList;

        private ItemVO vo;

        public ItemSelector()
        {
            InitializeComponent();

            this.itemList = new List<ItemVO>();

            //this._imagePoolCallback = new ImagePool.ImagePoolCallback(this.imagePoolCallback);
            //this.imagePool = new ImagePool(this._imagePoolCallback);
        }

        public void setItems(List<ItemVO> itemList)
        {
            this.itemDGV.Rows.Clear();

            this.itemList.Clear();

            int count = itemList.Count;
            
            for (int i = 0; i < count; i++)
                this.addItem(itemList[i]);

            this.itemDGV.Focus();
        }

        public ItemVO getVo()
        {
            return this.vo;
        }

        private void addItem(ItemVO vo)
        {
            this.itemList.Add(vo);

            DataGridViewRow row = new DataGridViewRow();
            row.Height = 100;

            //DataGridViewImageCell imageCell = new DataGridViewImageCell();
            //row.Cells.Add(imageCell);

            DataGridViewTextBoxCell franchiseeNameCell = new DataGridViewTextBoxCell();
            franchiseeNameCell.Value = vo.FranchiseeName;
            row.Cells.Add(franchiseeNameCell);

            DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
            nameCell.Value = vo.Name;
            row.Cells.Add(nameCell);

            DataGridViewTextBoxCell priceCell = new DataGridViewTextBoxCell();
            priceCell.Value = vo.Price.ToString();
            row.Cells.Add(priceCell);

            this.itemDGV.Rows.Add(row);

            //if (null == vo.Image)
            //    this.imagePool.append(vo.ImageUrl);
            //else
            //    imageCell.Value = vo.Image;
        }

        //private void imagePoolCallback(string url, Image image)
        //{
        //    int count = this.itemList.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        ItemVO vo = this.itemList[i];
        //        if (url.Equals(vo.ImageUrl))
        //        {
        //            if (i < this.itemDGV.Rows.Count)
        //            {
        //                vo.Image = image;
        //                this.itemDGV.Rows[i].Cells[0].Value = image;
        //            }
        //        }
        //    }
        //}

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int titleH = this.titleP.ClientRectangle.Height;
            int spacing = 5;
            int toolbarH = 60;

            this.titleP.Location = new Point(0, 0);
            this.titleP.Size = new Size(w, titleH);

            this.itemDGV.Location = new Point(spacing, titleH);
            this.itemDGV.Size = new Size(w - spacing * 5, h - spacing * 2 - titleH - toolbarH);

            this.cancelB.Location = new Point(w - spacing * 5 - this.cancelB.Size.Width, h - spacing - this.cancelB.Size.Height);
        }

        /// <summary>
        /// 初始化视图
        /// </summary>
        private void uiInitView()
        {
            this.titleP.setTitle("选择商品");

            this.uiResize();
        }

        private void ItemSelector_Load(object sender, EventArgs e)
        {
            this.uiInitView();
        }

        private void ItemSelector_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void itemDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.vo = this.itemList[e.RowIndex];
            this.mainFormCallback(MainForm.PT_ITEM_SELECTOR_RESULT);
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.vo = null;
            this.mainFormCallback(MainForm.PT_ITEM_SELECTOR_RESULT);
        }
    }
}
