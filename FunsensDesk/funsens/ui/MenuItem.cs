using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace funsens.ui
{
    /// <summary>
    /// 主界面左边菜单的菜单项
    /// </summary>
    public partial class MenuItem : UserControl
    {
        public MenuItem()
        {
            InitializeComponent();
        }

        public void setTitle(string title)
        {
            this.l.Text = title;
        }

        public void setImage(Bitmap image)
        {
            this.pb.BackgroundImage = image;
        }

        private void uiResize()
        {
            int w = this.Width;
            int h = this.Height;
            int h2 = h / 2;

            int pbWH = w / 5;

            this.pb.Location = new Point((w - pbWH) / 2, h2 - pbWH);
            this.pb.Size = new Size(pbWH, pbWH);

            this.l.Location = new Point((w - this.l.Width) / 2, h2 + this.l.Size.Height);
        }

        private void MenuItem_Load(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void MenuItem_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void MenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.MediumBlue;
        }

        private void MenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            //this.BackColor = SystemColors.Highlight;
        }
    }
}
