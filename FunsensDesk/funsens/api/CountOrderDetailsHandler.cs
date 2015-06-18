using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.item.vo;
using funsens.log;

namespace funsens.api
{
    /// <summary>
    /// 接口：拆分订单
    /// 下单时选择好商品后，通过该接口提交到后台，由后台来拆分订单
    /// </summary>
    class CountOrderDetailsHandler : Handler
    {
        public CountOrderDetailsHandler(HandlerCallback callback, List<ItemVO> itemList)
        {
            this.type = API.T_COUNT_ORDER_DETAILS;
            this.callback = callback;
            this.url = API.URL_COUNT_ORDER_DETAILS;

            JA itemJA = new JA();
            int count = itemList.Count;
            for (int i = 0; i < count; i++)
            {
                ItemVO vo = itemList[i];

                JO itemJO = new JO();
                itemJO.put("product_id", vo.Id);
                itemJO.put("quantity", vo.Amount);
                itemJA.put(itemJO);
            }

            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("data", itemJA.toString());

            Console.WriteLine(itemJA.toString());

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            (new Log()).countOrder(this.getParameterString(), content, error);

            this.callback(type, rc, error, content);
        }
    }
}
