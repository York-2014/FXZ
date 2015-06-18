using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.common.vo;

namespace funsens.api
{
    /// <summary>
    /// 接口：获取所有地区信息（省、市、区）
    /// 系统启动时调用该接口加载区域信息到本地
    /// </summary>
    class GetDistrictsHandler : Handler
    {
        public GetDistrictsHandler(HandlerCallback callback)
        {
            this.type = API.T_DISTRICTS;
            this.callback = callback;
            this.url = API.URL_DISTRICTS;

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.get();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            List<DistrictVO> voList = new List<DistrictVO>();

            if (rc == RC_SUCCESS)
            {
                JO jo = new JO(content.ToString());
                JA districtJA = jo.getJA("district");
                int count = districtJA.size();
                for (int i = 0; i < count; i++)
                {
                    DistrictVO vo = new DistrictVO(districtJA.getJO(i));
                    voList.Add(vo);
                }
            }

            this.callback(type, rc, error, voList);
        }
    }
}
