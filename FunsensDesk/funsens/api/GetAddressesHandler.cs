using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.common;
using funsens.customer.vo;

namespace funsens.api
{
    /// <summary>
    /// 接口：获取收货地址列表
    /// 下单时可调用该接口来获取到当前用户的所有收货地址信息
    /// </summary>
    public class GetAddressesHandler : Handler
    {
        public GetAddressesHandler(HandlerCallback callback)
        {
            this.type = API.T_ADDRESSES;
            this.callback = callback;
            this.url = API.URL_GET_ADDRESSES;

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.get();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            List<AddressVO> voList = new List<AddressVO>();

            if (rc == RC_SUCCESS)
            {
                CommonData cd = CommonData.getInstance();

                JO jo = new JO(content.ToString());
                JA addressJA = jo.getJA("list");
                int count = addressJA.size();

                for (int i = 0; i < count; i++)
                {
                    JO addressJO = addressJA.getJO(i);

                    AddressVO vo = new AddressVO(addressJO);
                    vo.ProvinceName = cd.getDistrictNameById(vo.ProvinceId);
                    vo.CityName = cd.getDistrictNameById(vo.CityId);
                    vo.AreaName = cd.getDistrictNameById(vo.AreaId);

                    voList.Add(vo);
                }
            }

            this.callback(type, rc, error, voList);
        }
    }
}
