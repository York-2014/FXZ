using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using x.net.http;

namespace funsens.api
{
    /// <summary>
    /// 接口：注册用户
    /// </summary>
    class SignUpHandler : Handler
    {
        public SignUpHandler(HandlerCallback callback, string idNo, string name, string address, string tel, string password)
        {
            this.type = API.T_SIGN_UP;
            this.callback = callback;
            this.url = API.URL_SIGN_UP;
            this.parameterMap = new Dictionary<string, string>();
            this.parameterMap.Add("mobile", tel);
            this.parameterMap.Add("password", password);
            this.parameterMap.Add("id_card", idNo);
            this.parameterMap.Add("name", name);
            this.parameterMap.Add("address", address);

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.post();
        }

        private void callback_(int type, int rc, string error, string content)
        {
            this.callback(type, rc, error, content);
        }
    }
}
