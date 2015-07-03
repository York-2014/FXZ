using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.item.vo
{
    public class ItemVO
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        private string franchiseeId;
        public string FranchiseeId
        {
            get { return franchiseeId; }
            set { franchiseeId = value; }
        }

        private string franchiseeName;
        public string FranchiseeName
        {
            get { return franchiseeName; }
            set { franchiseeName = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private double tax;
        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private int storeStock;
        public int StoreStock
        {
            get { return storeStock; }
            set { storeStock = value; }
        }

        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private double taxRate;
        public double TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        private int isShelves;
        public int IsShelves
        {
            get { return isShelves; }
            set { isShelves = value; }
        }

        public ItemVO()
        {

        }

        public ItemVO(JO jo)
        {
            this.id = jo.getString("id");
            this.barcode = jo.getString("barcode");
            this.franchiseeId = jo.getString("seller_id");
            this.franchiseeName = jo.getString("company");
            this.name = jo.getString("name");
            this.price = jo.getdouble("price");
            this.tax = jo.getdouble("tax_rate");
            this.stock = jo.getInt("stock");
            this.storeStock = jo.getInt("store_stock");
            this.imageUrl = jo.getString("pic") + "_220X220.jpg";
            this.taxRate = jo.getdouble("tax_rate");
            this.isShelves = jo.getInt("is_shelves");
        }

        public void loadOrderDetails(string franchiseeId, string franchiseeName, JO jo)
        {
            this.franchiseeId = franchiseeId;
            this.franchiseeName = franchiseeName;

            this.id = jo.getString("productId");
            this.barcode = jo.getString("barcode");
            this.name = jo.getString("productName");
            this.imageUrl = jo.getString("picUrl") + "_220X220.jpg";
            this.price = jo.getdouble("price");
            this.tax = jo.getdouble("tax_rate");
            this.amount = jo.getInt("productVolume");
        }
    }
}
