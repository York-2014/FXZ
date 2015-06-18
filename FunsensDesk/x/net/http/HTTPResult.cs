using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace x.net.http
{
    class HTTPResult
    {
        public const int SC_SUCCESS = 200;

        public const int SC_FAILED = -1;

        private int statusCode;

        private string error;
        public string Error
        {
            get { return error; }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private CookieContainer cookie;
        public CookieContainer Cookie
        {
            get { return cookie; }
            set { cookie = value; }
        }

        public HTTPResult(HttpStatusCode statusCode)
        {
            this.statusCode = (int)statusCode;
        }

        public HTTPResult(string error)
        {
            this.statusCode = SC_FAILED;
            this.error = error;
        }

        public HTTPResult(HttpWebResponse response, Encoding encoding)
        {
            this.statusCode = (int)response.StatusCode;

            StreamReader stream = new StreamReader(response.GetResponseStream(), null == encoding ? Encoding.Default : encoding);
            this.content = stream.ReadToEnd();
            stream.Close();
        }

        public bool isSuccess()
        {
            return this.statusCode == (int)HttpStatusCode.OK;
        }

        public string getContent()
        {
            return this.content;
        }
    }
}
