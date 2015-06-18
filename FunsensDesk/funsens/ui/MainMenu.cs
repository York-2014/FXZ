using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace funsens.ui
{
    /// <summary>
    /// 主界面左边菜单面板
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public delegate void MainMenuDelegate(int position);

        public const int MENU_WIDTH = 200;

        private MainMenuDelegate callback;

        private List<MenuItem> menuList;

        private List<bool> menuStatusList;

        public MainMenu()
        {
            InitializeComponent();

            this.init();
        }

        public void setItemClick(int position)
        {
            this.uiRefresh(position);
        }

        public void addItem(string title, Bitmap bitmap)
        {
            int position = this.menuList.Count;

            MenuItem item = new MenuItem();
            item.BackColor = System.Drawing.SystemColors.Highlight;
            item.Name = "item_" + position;
            item.setTitle(title);
            item.setImage(bitmap);
            item.Tag = position;
            item.Click += new System.EventHandler(this.menu_Click);
            item.pb.Click += new System.EventHandler(this.menu_Click);
            item.pb.Tag = position;
            item.l.Click += new System.EventHandler(this.menu_Click);
            item.l.Tag = position;
            this.Controls.Add(item);

            this.menuList.Add(item);
            this.menuStatusList.Add(true);

            this.uiResize();
        }

        /// <summary>
        /// 设置各个菜单项的可视属性
        /// 并重置可视的菜单项坐标和大小
        /// </summary>
        /// <param name="menuStatusList"></param>
        public void setItemStatusList(List<bool> menuStatusList)
        {
            this.menuStatusList = menuStatusList;
            int count = this.menuStatusList.Count;
            for (int i = 0; i < count; i++)
                this.menuList[i].Visible = this.menuStatusList[i];

            this.uiResize();
        }

        public void setCallback(MainMenuDelegate callback)
        {
            this.callback = callback;
        }

        private void uiRefresh(int position)
        {
            int count = this.menuList.Count;
            for (int i = 0; i < count; i++)
            {
                MenuItem item = this.menuList[i];
                if (position == i)
                    item.BackColor = Color.MediumBlue;
                else
                    item.BackColor = SystemColors.Highlight;
            }
        }

        private void uiResize()
        {
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int spacing = 2;

            int visibledCount = 0;
            int count = this.menuStatusList.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.menuStatusList[i])
                    visibledCount++;
            }

            if (visibledCount < 1)
                return;

            int itemH = (h - spacing * (visibledCount + 1)) / visibledCount;
            Size itemSize = new Size(w - spacing * 2, itemH);
            int tmp = 0;
            for (int i = 0; i < count; i++)
            {
                if (this.menuStatusList[i])
                {
                    MenuItem item = this.menuList[i];
                    item.Location = new Point(spacing, spacing * (tmp + 1) + itemH * tmp);
                    item.Size = itemSize;

                    tmp++;
                }
            }
        }

        private void uiInitView()
        {
        }

        private void menu_Click(object sender, EventArgs e)
        {
            int position = int.Parse(((Control)sender).Tag.ToString());
            
            this.uiRefresh(position);

            this.callback(position);
        }

        private void init()
        {
            this.menuList = new List<MenuItem>();
            this.menuStatusList = new List<bool>();

            this.uiInitView();
            this.uiResize();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.init();
        }

        private void MainMenu_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }
    }
}
