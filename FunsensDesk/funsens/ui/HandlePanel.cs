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
    /// “处理中”提示面板
    /// 与后台接口进行交互过程中，显示该面板以提示用户
    /// </summary>
    public partial class HandlePanel : UserControl
    {
        public HandlePanel()
        {
            InitializeComponent();
        }

        public void setText(string text)
        {
            this.l.Text = text;
        }

        private void uiResize()
        {
            int w = this.Width;
            int h = this.Height;

            this.l.Location = new Point((w - this.l.Width) / 2, (h - this.l.Height) / 2);
        }

        private void HandlePanel_Load(object sender, EventArgs e)
        {
            this.uiResize();
        }

        private void HandlePanel_SizeChanged(object sender, EventArgs e)
        {
            this.uiResize();
        }
    }
}
