using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.api
{
    /// <summary>
    /// 绑定货架和订单
    /// </summary>
    class BindShelfOrderHandler : Handler
    {
        public BindShelfOrderHandler(HandlerCallback callback, string orderId, string shelfId)
        {
            this.type = API.T_IN_STOCK;
            this.callback = callback;
            this.url = API.URL_SHELF;

            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("action", "in");
            this.parameterMap.Add("order_id", orderId);
            this.parameterMap.Add("shelf_id", shelfId);

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            JO jo = new JO(content.ToString());
            this.callback(type, rc, error, jo);
        }
    }
}
