using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using x.net.http;
using funsens.common;
using funsens.customer;

namespace funsens.api
{
    /// <summary>
    /// 接口基类
    /// 所有与后台交互的接口都继承自该类
    /// </summary>
    public class Handler
    {
        public const int RC_SUCCESS = 1;

        public const int RC_FAILED = -1;

        public delegate void _HandlerCallback(int type, int rc, string error, string content);

        public delegate void HandlerCallback(int type, int rc, string error, object content);

        private Thread thread;

        private ThreadStart threadStart;

        protected int type;

        protected HandlerCallback callback;

        protected _HandlerCallback _callback;

        protected string url;

        protected Dictionary<string, string> parameterMap;

        public Handler()
        {

        }

        public Handler(HandlerCallback callback)
        {
            this.callback = callback;
        }

        protected void get()
        {
            this.threadStart = new ThreadStart(this.handleGet);

            this.thread = new Thread(this.threadStart);
            this.thread.Start();
        }

        protected void post()
        {
            this.threadStart = new ThreadStart(this.handlePost);

            this.thread = new Thread(this.threadStart);
            this.thread.Start();
        }

        private void handleGet()
        {
            HTTP http = new HTTP();
            
            HTTPResult result = http.get(this.url, Session.getInstance().Cookie);

            this._callback(this.type, result.isSuccess() ? RC_SUCCESS : RC_FAILED, null, result.getContent());
        }

        private void handlePost()
        {
            HTTP http = new HTTP();
            HTTPResult result = http.post(this.url, this.parameterMap, Session.getInstance().Cookie);

            if (null != result.Cookie)
                Session.getInstance().Cookie = result.Cookie;

            this._callback(this.type, result.isSuccess() ? RC_SUCCESS : RC_FAILED, null, result.getContent());
        }

        public string getParameterString()
        {
            StringBuilder sb = new StringBuilder();

            if(null != this.parameterMap)
            {
                foreach (KeyValuePair<string, string> item in this.parameterMap)
                    sb.Append(item.Key + " = " + item.Value + "\r\n");
            }

            return sb.ToString();
        }
    }
}
