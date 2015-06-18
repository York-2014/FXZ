using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using x.util;
using funsens.log;
using funsens.order.vo;

namespace funsens.api
{
    /// <summary>
    /// 接口：查询订单
    /// </summary>
    class GetOrdersHandler : Handler
    {
        public GetOrdersHandler(HandlerCallback callback, int isCarry, int status, List<string> orderIdList, int pageSize, int pageNo)
        {
            this.type = API.T_ORDERS;
            this.callback = callback;
            this.url = API.URL_ORDERS;

            this.parameterMap = new Dictionary<string, string>();

            if(isCarry > -1)
            this.parameterMap.Add("is_carry", isCarry + "");

            if (status != OrderVO.STATUS_NONE)
                this.parameterMap.Add("order_status", status.ToString());

            if (null != orderIdList)
            {
                int count = orderIdList.Count;
                if (count > 0)
                {
                    StringBuilder ids = new StringBuilder();
                    for (int i = 0; i < count; i++)
                    {
                        if (i != 0)
                            ids.Append(",");

                        ids.Append(orderIdList[i]);
                    }

                    this.parameterMap.Add("order_ids", ids.ToString());
                }
            }

            this.parameterMap.Add("number", pageSize.ToString());
            this.parameterMap.Add("page", pageNo.ToString());

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            (new Log()).getOrders(this.getParameterString(), content, error);

            this.callback(type, rc, error, content);
        }
    }
}
