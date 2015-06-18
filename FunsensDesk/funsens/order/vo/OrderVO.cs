using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.common;
using funsens.item.vo;

namespace funsens.order.vo
{
    public class OrderVO
    {
        /// <summary>
        /// 
        /// </summary>
        public const int STATUS_NONE = -9;

        /// <summary>
        /// 已删除
        /// </summary>
        public const int STATUS_DELETED = -1;

        /// <summary>
        /// 等待付款
        /// </summary>
        public const int STATUS_UN_PAY = 1;

        /// <summary>
        /// 已付款
        /// </summary>
        public const int STATUS_PAYED = 2;

        /// <summary>
        /// 已发货
        /// </summary>
        public const int STATUS_DELIVED = 3;

        /// <summary>
        /// 交易成功
        /// </summary>
        public const int STATUS_FINISH = 4;

        /// <summary>
        /// 已取消
        /// </summary>
        public const int STATUS_CANCELED = 0;

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
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

        private string customerId;
        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        private string customerTel;
        public string CustomerTel
        {
            get { return customerTel; }
            set { customerTel = value; }
        }

        private string customerAddress;
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }

        private string customerAccountName;
        public string CustomerAccountName
        {
            get { return customerAccountName; }
            set { customerAccountName = value; }
        }

        private string buyerComment;
        public string BuyerComment
        {
            get { return buyerComment; }
            set { buyerComment = value; }
        }

        private string sellerComment;
        public string SellerComment
        {
            get { return sellerComment; }
            set { sellerComment = value; }
        }

        private string expressType;
        public string ExpressType
        {
            get { return expressType; }
            set { expressType = value; }
        }

        private string expressName;
        public string ExpressName
        {
            get { return expressName; }
            set { expressName = value; }
        }

        private string invoiceNo;
        public string InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private int itemCount;
        public int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; }
        }

        private float itemTotal;
        public float ItemTotal
        {
            get { return itemTotal; }
            set { itemTotal = value; }
        }

        private float taxTotal;
        public float TaxTotal
        {
            get { return taxTotal; }
            set { taxTotal = value; }
        }

        //历史已交税费
        private float paiedTax;
        public float PaiedTax
        {
            get { return paiedTax; }
            set { paiedTax = value; }
        }

        //历史未交税费
        private float unPayTax;
        public float UnPayTax
        {
            get { return unPayTax; }
            set { unPayTax = value; }
        }

        //所有订单（拆分后的子订单）总税费
        private float ordersTax;
        public float OrdersTax
        {
            get { return ordersTax; }
            set { ordersTax = value; }
        }

        private float total;
        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        private float payment;
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private float mailFreight;    //平邮费用
        public float MailFreight
        {
            get { return mailFreight; }
            set { mailFreight = value; }
        }

        private float emsFreight;    //EMS费用
        public float EmsFreight
        {
            get { return emsFreight; }
            set { emsFreight = value; }
        }

        private float expressFreight;    //快递费用
        public float ExpressFreight
        {
            get { return expressFreight; }
            set { expressFreight = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int reimburseStatus;
        public int ReimburseStatus
        {
            get { return reimburseStatus; }
            set { reimburseStatus = value; }
        }

        private DateTime created;
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        private string serviceDeskId;
        public string ServiceDeskId
        {
            get { return serviceDeskId; }
            set { serviceDeskId = value; }
        }

        private string serviceDeskName;
        public string ServiceDeskName
        {
            get { return serviceDeskName; }
            set { serviceDeskName = value; }
        }

        private bool isAllReady;
        public bool IsAllReady
        {
            get { return isAllReady; }
            set { isAllReady = value; }
        }

        private List<ItemVO> itemList;
        public List<ItemVO> ItemList
        {
            get { return itemList; }
        }

        private List<OrderDetailsVO> detailsList;
        public List<OrderDetailsVO> DetailsList
        {
            get { return detailsList; }
            set { detailsList = value; }
        }

        public OrderVO()
        {

        }

        public OrderVO(JO jo)
        {
            this.id = jo.getString("orderId");
            this.franchiseeId = jo.getString("shopId");
            this.franchiseeName = jo.getString("shopName");
            this.customerName = jo.getString("connectName");
            this.customerTel = jo.getString("consignee_mobile");
            this.customerAddress = jo.getString("consignee_address");
            this.buyerComment = jo.getString("buyerComment");
            this.sellerComment = jo.getString("sellerComment");
            this.expressType = jo.getString("postType");
            this.expressFreight = jo.getFloat("postPrice");
            this.taxTotal = jo.getFloat("tax_price");
            this.total = jo.getFloat("priceTotal");
            this.payment = jo.getFloat("priceTotal");
            this.status = jo.getInt("orderStatus");
            this.reimburseStatus = jo.getInt("reimburseStatus");
            this.created = jo.getDateTime("createTime");

            JA itemJA = jo.getJA("productList");
            int count = itemJA.size();
            this.itemList = new List<ItemVO>();
            this.detailsList = new List<OrderDetailsVO>();
            for (int i = 0; i < count; i++)
            {
                JO itemJO = itemJA.getJO(i);
                ItemVO itemVO = new ItemVO();
                itemVO.loadOrderDetails(this.franchiseeId, this.franchiseeName, itemJO);
                this.itemList.Add(itemVO);

                OrderDetailsVO detailsVO = new OrderDetailsVO();
                detailsVO.ItemId = itemJO.getString("productId");
                detailsVO.ItemName = itemJO.getString("productName");
                detailsVO.Barcode = itemJO.getString("barcode");
                float itemPrice = itemJO.getFloat("price");
                int itemAmount = itemJO.getInt("productVolume");
                detailsVO.ItemPrice = itemPrice;
                detailsVO.Amount = itemAmount;
                detailsVO.Total = itemPrice * itemAmount;
                this.detailsList.Add(detailsVO);
            }
        }

        public void loadPackagedJO(JO jo)
        {
            int allReady = jo.getInt("all_ready");
            this.isAllReady = (allReady == 1);

            this.customerId = jo.getString("buyer_id");
            this.customerName = jo.getString("consignee");
            this.created = jo.getDateTime("deliver_time");
            this.serviceDeskId = jo.getString("window_id");
            this.serviceDeskName = CommonData.getInstance().getServiceDeskName(this.serviceDeskId);
        }

        public void loadFullJO(JO jo)
        {
            this.id = jo.getString("orderId");
            this.status = jo.getInt("orderStatus");
            this.remark = jo.getString("additionWord");
            this.reimburseStatus = jo.getInt("reimburseStatus");
            this.buyerComment = jo.getString("buyerComment");
            this.sellerComment = jo.getString("sellerComment");
            this.payment = jo.getFloat("paidMoney");
            this.expressType = jo.getString("postType");
            this.expressName = jo.getString("logisticsName");
            this.expressFreight = jo.getFloat("postPrice");
            this.invoiceNo = jo.getString("invoiceNo");
            this.total = jo.getFloat("priceTotal");
            this.customerName = jo.getString("connectName");
            this.customerAddress = jo.getString("address");
            this.customerTel = jo.getString("mobilephone");
            this.created = jo.getDateTime("createTime");
            this.franchiseeId = jo.getString("shopId");
            this.franchiseeName = jo.getString("shopName");
            this.customerAccountName = jo.getString("username");
            this.itemCount = jo.getInt("productTotal");

            JA detailsJA = jo.getJA("list");
            int count = detailsJA.size();
            this.detailsList = new List<OrderDetailsVO>();
            for (int i = 0; i < count; i++)
            {
                JO detailsJO = detailsJA.getJO(i);
                OrderDetailsVO detailsVO = new OrderDetailsVO(detailsJO);
                this.detailsList.Add(detailsVO);
            }
        }

        public void loadOrder(JO jo)
        {
            this.id = jo.getString("id");
            this.franchiseeId = jo.getString("seller_id");
            this.franchiseeName = jo.getString("company");
            this.itemTotal = jo.getFloat("sumprice");   //商品总金额（未包含税和运费）
            this.taxTotal = jo.getFloat("sumtax");  //税费
               
            this.mailFreight = jo.getFloat("mail");
            this.emsFreight = jo.getFloat("ems");
            this.expressFreight = jo.getFloat("express");

            JA itemJA = jo.getJA("prolist");
            int count = itemJA.size();
            this.detailsList = new List<OrderDetailsVO>();
            for (int i = 0; i < count; i++)
            {
                JO itemJO = itemJA.getJO(i);

                OrderDetailsVO detailsVO = new OrderDetailsVO();
                detailsVO.loadConfirm(itemJO);
                this.detailsList.Add(detailsVO);
            }
        }
    }
}
