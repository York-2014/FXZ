using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.api
{
    /// <summary>
    /// 接口：获取当前用户的信息
    /// </summary>
    class UserInfoHandler : Handler
    {
        public UserInfoHandler(HandlerCallback callback)
        {
            this.type = API.T_USER_INFO;
            this.callback = callback;
            this.url = API.URL_USER_INFO;

            this._callback = new _HandlerCallback(this.callback_);
        }

        public void handle()
        {
            this.get();
        }

        private void callback_(int type, int rc, string error, object content)
        {
            this.callback(type, rc, error, content);
        }
    }
}
