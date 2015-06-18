using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.api
{
    /// <summary>
    /// 接口：用户登录
    /// </summary>
    class SignInHandler : Handler
    {
        public SignInHandler(HandlerCallback callback, string idNo, string name, string tel, string password)
        {
            this.type = API.T_SIGN_IN;
            this.callback = callback;
            this.url = API.URL_SIGN_IN;
            this.parameterMap = new Dictionary<string, string>();

            if(null == idNo)
            {
                this.parameterMap.Add("mobile", tel);
                this.parameterMap.Add("password", password);
            }
            else
            {
                this.parameterMap.Add("id_card", idNo);
                this.parameterMap.Add("name", name);
            }

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
