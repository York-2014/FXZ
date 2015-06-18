using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace funsens.ui
{
    /// <summary>
    /// “标题”面板
    /// </summary>
    public partial class TitlePanel : UserControl
    {
        public TitlePanel()
        {
            InitializeComponent();
        }

        public void setTitle(string title)
        {
            this.titleL.Text = title;
        }

        private void uiResize()
        {
            this.p.Location = new Point(0, 0);
            this.p.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - 1);
        }

        private void TitlePanel_Load(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void TitlePanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }
    }
}
