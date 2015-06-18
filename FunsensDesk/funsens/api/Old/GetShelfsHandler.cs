using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using funsens.stock.vo;

namespace funsens.api
{
    /// <summary>
    /// 获取货架列表
    /// </summary>
    class GetShelfsHandler : Handler
    {
        public GetShelfsHandler(HandlerCallback callback, string type)
        {
            this.type = API.T_SHELFS;
            this.callback = callback;
            this.url = API.URL_SHELF;

            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("action", "list");
            this.parameterMap.Add("type", type);

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            List<ShelfVO> voList = new List<ShelfVO>();

            if (rc == RC_SUCCESS)
            {
                JA ja = new JA(content.ToString());
                int count = ja.size();
                for (int i = 0; i < count; i++)
                {
                    ShelfVO vo = new ShelfVO(ja.getJO(i));
                    voList.Add(vo);
                }
            }

            this.callback(type, rc, error, voList);
        }
    }
}
