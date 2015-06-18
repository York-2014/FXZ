using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using x.util;
using funsens.item.vo;
using funsens.log;

namespace funsens.api
{
    /// <summary>
    /// 接口：下单
    /// </summary>
    class AddOrderHandler : Handler
    {
        //public AddOrderHandler(HandlerCallback callback, List<ItemVO> itemList, int isCarry, string name, string tel, string provinceId, string provinceName, string cityId, string cityName, string areaId, string areaName, string address, string zipCode)
        public AddOrderHandler(HandlerCallback callback, JA ja)
        {
            this.type = API.T_ADD_ORDER;
            this.callback = callback;
            this._callback = new _HandlerCallback(this.callback_);
            this.url = API.URL_ADD_ORDER;

            /*JO jo = new JO();

            Dictionary<string, JA> orderMap = new Dictionary<string, JA>();
            int count = itemList.Count;
            for (int i = 0; i < count; i++)
            {
                ItemVO vo = itemList[i];

                JA itemJA = null;
                if (orderMap.ContainsKey(vo.FranchiseeId))
                    itemJA = orderMap[vo.FranchiseeId];
                else
                    itemJA = new JA();

                JO itemJO = new JO();
                itemJO.put("product_id", vo.Id);
                itemJO.put("quantity", vo.Amount.ToString());

                itemJA.put(itemJO);
                orderMap.Add(vo.FranchiseeId, itemJA);
            }

            JA orderJA = new JA();

            foreach (KeyValuePair<string, JA> o in orderMap)
            {
                string franchiseeId = o.Key;
                JA itemJA = o.Value;

                JO orderJO = new JO();
                orderJO.put("seller_id", franchiseeId);
                orderJO.put("product_list", itemJA);

                orderJA.put(orderJO);
            }

            jo.put("order", orderJA);

            JO addressJO = new JO();
            addressJO.put("connect_name", name);
            addressJO.put("province_id", provinceId);
            addressJO.put("city_id", cityId);
            addressJO.put("area_id", areaId);
            addressJO.put("area", "");//provinceName + cityName + areaName);
            addressJO.put("address", address);
            addressJO.put("post_code", zipCode);
            addressJO.put("telephone", S.EMPTY);
            addressJO.put("mobilephone", tel);
            addressJO.put("is_default", 1);
            jo.put("address", addressJO);*/

            //jo.put("is_carry", isCarry);

            //string data = jo.toString();

            this.parameterMap = new Dictionary<string, string>();
            //this.parameterMap.Add("data", data);

            /*string type = null;
            if (expressType == 0)
                type = "mail";
            else if (expressType == 1)
                type = "ems";
            else
                type = "express";

            this.parameterMap.Add("logistics_type", type);
            this.parameterMap.Add("is_carry", isCarry + S.EMPTY);*/

            this.parameterMap.Add("data", ja.toString());
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            (new Log()).addOrder(this.getParameterString(), content, error);

            this.callback(type, rc, error, content);
        }
    }
}
