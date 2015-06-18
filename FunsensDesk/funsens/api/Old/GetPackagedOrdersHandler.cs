using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.order.vo;

namespace funsens.api
{
    class GetPackagedOrdersHandler : Handler
    {
        public GetPackagedOrdersHandler(HandlerCallback callback)
        {
            this.type = API.T_PACKAGED_ORDERS;
            this.callback = callback;
            this.url = API.URL_PACKAGED_ORDERS;

            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("page", "1");
            this.parameterMap.Add("number", "99999999");

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.get();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            List<OrderVO> voList = new List<OrderVO>();

            if (rc == RC_SUCCESS)
            {
                JO jo = new JO(content.ToString());

                /*int count = jo.getInt("count");
                int pageIndex = jo.getInt("pageIndex");
                int pageTotal = jo.getInt("pageTotal");*/

                JA ja = jo.getJA("list");
                int count = ja.size();
                for (int i = 0; i < count; i++)
                {
                    JO orderJO = ja.getJO(i);

                    OrderVO vo = new OrderVO();
                    vo.loadPackagedJO(orderJO);
                    voList.Add(vo);
                }
            }

            this.callback(type, rc, error, voList);
        }
    }
}
