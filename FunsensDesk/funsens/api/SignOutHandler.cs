using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.api
{
    /// <summary>
    /// 接口：退出登录
    /// </summary>
    public class SignOutHandler : Handler
    {
        public SignOutHandler(HandlerCallback callback)
        {
            this.type = API.T_SIGN_OUT;
            this.callback = callback;
            this.url = API.URL_SIGN_OUT;

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
