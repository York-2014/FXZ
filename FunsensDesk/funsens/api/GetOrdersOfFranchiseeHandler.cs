using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using funsens.log;

namespace funsens.api
{
    /// <summary>
    /// 接口：获取指定商家的订单列表
    /// 应用于“我的订单”
    /// </summary>
    class GetOrdersOfFranchiseeHandler : Handler
    {
        public GetOrdersOfFranchiseeHandler(HandlerCallback callback, string franchiseeId, int pageSize, int pageNo)
        {
            this.type = API.T_ORDERS_OF_FRANCHISEE;
            this.callback = callback;
            this.url = API.URL_ORDERS_OF_FRANCHISEE;

            this.parameterMap = new Dictionary<string, string>();

            this.parameterMap.Add("franchiseeId", franchiseeId);
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
            (new Log()).getOrdersOfFranchisee(this.getParameterString(), content, error);

            this.callback(type, rc, error, content);
        }
    }
}
