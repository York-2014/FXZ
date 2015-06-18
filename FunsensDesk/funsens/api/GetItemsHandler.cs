using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;
using x.util;
using funsens.common;
using funsens.customer;
using funsens.item.vo;
using funsens.log;

namespace funsens.api
{
    /// <summary>
    /// 接口：查询商品
    /// 应用于下单时通过扫商品条形码获取商品信息
    /// </summary>
    class GetItemsHandler : Handler
    {
        public GetItemsHandler(HandlerCallback callback, string barcode)
        {
            this.type = API.T_ITEM;
            this.callback = callback;
            this.url = API.URL_ITEM + barcode;

            string franchiseeId = Session.getInstance().getFranchiseeId();
            if (!S.blank(franchiseeId))
                this.url += "&userid=" + franchiseeId;

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.get();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            (new Log()).getItems(this.url, content, error);

            this.callback(type, rc, error, content);
        }
    }
}
