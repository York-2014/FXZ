using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeLib;

namespace funsens.util
{
    class BarcodeUtil
    {
        /// <summary>
        /// 获取条形码图片
        /// </summary>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="no">条形码</param>
        /// <returns></returns>
        public Image getBarcodeImage(int width, int height, string no)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.CENTER,
                Width = width,
                Height = height,
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };

            Image image = barcode.Encode(TYPE.CODE128B, no);

            return image;
        }
    }
}
