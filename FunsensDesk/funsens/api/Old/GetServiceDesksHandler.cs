using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.log;
using funsens.servicedesk.vo;

namespace funsens.api
{
    /// <summary>
    /// 获取服务窗口列表
    /// </summary>
    class GetServiceDesksHandler : Handler
    {
        public GetServiceDesksHandler(HandlerCallback callback)
        {
            this.type = API.T_SERVICE_DESKS;
            this.callback = callback;
            this.url = API.URL_GET_SERVICE_DESKS;

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.get();
        }

        private void callback_(int type, int rc, string error, string content)
        {
            JA ja = new JA(content);
            int count = ja.size();
            List<ServiceDeskVO> voList = new List<ServiceDeskVO>();
            for (int i = 0; i < count; i++)
            {
                JO jo = ja.getJO(i);
                ServiceDeskVO vo = new ServiceDeskVO(jo);
                voList.Add(vo);
            }

            this.callback(type, rc, error, voList);
        }
    }
}
