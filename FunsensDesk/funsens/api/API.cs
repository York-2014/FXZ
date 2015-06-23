using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.api
{
    /// <summary>
    /// 接口的公共数据
    /// </summary>
    class API
    {

        private static readonly string SERVER = "http://www.funsens.com/api/";
       // private static readonly string SERVER = "http://www.funsens.test/api/";
        //private static readonly string SERVER = "http://120.25.216.73/api/";

        public const int T_DISTRICTS = 1001;

        public const int T_SIGN_UP = 2001;
        public const int T_SIGN_IN = 2002;
        public const int T_SIGN_OUT = 2003;
        public const int T_USER_INFO = 2004;

        public const int T_ITEM = 3001;

        public const int T_ADD_ORDER = 4001;
        public const int T_ORDERS = 4002;
        public const int T_ORDERS_OF_FRANCHISEE = 400231;
        public const int T_PACKAGED_ORDERS = 4003;
        public const int T_ORDER = 4004;
        public const int T_MODIFY_ORDER_STATUS = 4005;
        public const int T_COUNT_ORDER_DETAILS = 4006;

        public const int T_ADDRESSES = 5001;

        public const int T_SERVICE_DESKS = 6001;

        public const int T_SHELFS = 7001;
        public const int T_IN_STOCK = 7002;
        public const int T_RESET_SHELF = 7003;

        public static readonly string URL_DISTRICTS = SERVER + "district.php";

        public static readonly string URL_SIGN_UP = SERVER + "register.php";
        public static readonly string URL_SIGN_IN = SERVER + "login.php";
        public static readonly string URL_SIGN_OUT = SERVER + "loginout.php";
        public static readonly string URL_USER_INFO = SERVER + "userinfo.php";

        public static readonly string URL_ITEM = SERVER + "product.php?barcode=";

        public static readonly string URL_ADD_ORDER = SERVER + "order_add.php?data=";
        public static readonly string URL_ORDERS = SERVER + "order_list.php";
        public static readonly string URL_ORDERS_OF_FRANCHISEE = SERVER + "orders_of_franchisee.php";
        public static readonly string URL_PACKAGED_ORDERS = SERVER + "order_calling.php";
        public static readonly string URL_ORDER = SERVER + "order_detail.php";
        public static readonly string URL_MODIFY_ORDER_STATUS = SERVER + "order_status.php";
        public static readonly string URL_COUNT_ORDER_DETAILS = SERVER + "order_confirm.php";

        public static readonly string URL_GET_ADDRESSES = SERVER + "address_list.php";

        public static readonly string URL_GET_SERVICE_DESKS = SERVER + "window.php";

        public static readonly string URL_SHELF = SERVER + "shelf.php";
    }
}
