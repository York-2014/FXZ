using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using funsens.customer.vo;
using funsens.franchisee.vo;

namespace funsens.common
{
    /// <summary>
    /// Session信息
    /// 记录当前登录的商家和客户信息
    /// </summary>
    class Session
    {
        private static Session instance;

        private string icNo;
        public string IcNo
        {
            get { return icNo; }
            set { icNo = value; }
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

        private CookieContainer cookie;
        public CookieContainer Cookie
        {
            get { return cookie; }
            set { cookie = value; }
        }

        private FranchiseeVO franchiseeVO;
        public FranchiseeVO FranchiseeVO
        {
            get { return franchiseeVO; }
            set { franchiseeVO = value; }
        }

        private List<string> orderIdList;
        public List<string> OrderIdList
        {
            get { return orderIdList; }
            set { orderIdList = value; }
        }

        private Session()
        {

        }

        public static Session getInstance()
        {
            if (null == instance)
                instance = new Session();

            return instance;
        }

        public void customerSignOut()
        {
            this.icNo = null;
            this.customerName = null;
            this.customerTel = null;
            this.customerAddress = null;
        }

        public bool isCustomerSign()
        {
            return null != this.icNo;
        }

        public string getFranchiseeId()
        {
            return null == this.franchiseeVO ? null : this.franchiseeVO.Id;
        }
    }
}
