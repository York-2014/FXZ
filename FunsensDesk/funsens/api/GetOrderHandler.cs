using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.log;
using funsens.order.vo;

namespace funsens.api
{
    /// <summary>
    /// 接口：获取订单详情
    /// </summary>
    class GetOrderHandler : Handler
    {
        public GetOrderHandler(HandlerCallback callback, string orderId)
        {
            this.type = API.T_ORDER;
            this.callback = callback;
            this.url = API.URL_ORDER;

            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("order_id", orderId);

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            (new Log()).getOrder(this.getParameterString(), content, error);

            OrderVO vo = null;

            if (rc == RC_SUCCESS)
                vo = new OrderVO(new JO(content.ToString()));

            this.callback(type, rc, error, vo);
        }
    }
}
