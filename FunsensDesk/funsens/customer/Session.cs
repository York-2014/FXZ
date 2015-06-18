using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using funsens.customer.vo;
using funsens.franchisee.vo;

namespace funsens.customer
{
    class Session
    {
        private static Session instance;

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

        private CustomerVO customerVO;
        public CustomerVO CustomerVO
        {
            get { return customerVO; }
            set { customerVO = value; }
        }

        private Session()
        {

        }

        public void signOut()
        {
            this.customerVO = null;
        }

        public bool isSign()
        {
            return null != this.customerVO;
        }

        public string getFranchiseeId()
        {
            return null == this.franchiseeVO ? null : this.franchiseeVO.Id;
        }

        public static Session getInstance()
        {
            if (null == instance)
                instance = new Session();

            return instance;
        }
    }
}
