using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.api
{
    public class ModifyOrderStatusHandler : Handler
    {
        public ModifyOrderStatusHandler(HandlerCallback callback, string id, int status)
        {
            this.type = API.T_MODIFY_ORDER_STATUS;
            this.callback = callback;
            this.url = API.URL_MODIFY_ORDER_STATUS;
            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("order_id", id);
            this.parameterMap.Add("order_status", status.ToString());

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            this.callback(type, rc, error, content);
        }
    }
}
