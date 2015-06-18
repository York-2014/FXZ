using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using funsens.ui;
using instock;

namespace funsens
{
    static class Program
    {
        //平台类型
        //1：服务台；    2：商家端；  3：拣货端；  4：提货信息台
        public const int APP_TYPE = 2;

        public const int DGV_FONT_SIZE = 12;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new OrderReceiptForm());
            Application.Run(new MainForm());
        }
    }
}
