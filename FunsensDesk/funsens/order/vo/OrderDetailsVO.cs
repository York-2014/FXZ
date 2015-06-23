using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.order.vo
{
    public class OrderDetailsVO
    {
        private string itemId;
        public string ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string itemImageUrl;
        public string ItemImageUrl
        {
            get { return itemImageUrl; }
            set { itemImageUrl = value; }
        }

        private float itemPrice;
        public float ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private float tax;
        public float Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private float total;
        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        private Image itemImage;
        public Image ItemImage
        {
            get { return itemImage; }
            set { itemImage = value; }
        }
        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }


       

        public OrderDetailsVO()
        {

        }
       

        public OrderDetailsVO(JO jo)
        {
            this.itemId = jo.getString("productId");
            this.itemName = jo.getString("productName");
            this.itemImageUrl = jo.getString("picUrl");
            this.itemPrice = jo.getFloat("price");
            this.amount = jo.getInt("productVolume");
            this.total = jo.getFloat("productPrice");
            this.barcode = jo.getString("barcode");
        }

        public void loadConfirm(JO jo)
        {
            this.itemId = jo.getString("pid");
            this.itemName = jo.getString("pname");
            this.itemImageUrl = jo.getString("pic");
            this.itemPrice = jo.getFloat("price");
            this.amount = jo.getInt("quantity");
            this.barcode = jo.getString("barcode");
        }
    }
}
