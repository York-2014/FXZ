using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Web;

namespace x.net.http
{
    class HTTP
    {
        private const string DEFAULT_CONTENT_TYPE = "application/x-www-form-urlencoded";

        private const int CONNECT_TIMEOUT = 300;

        private const string PARAMETER_PATTERN_A = "{0}={1}";
        private const string PARAMETER_PATTERN_B = "&{0}={1}";

        private const int READ_BUFFER_SIZE = 1024;

        public HTTPResult get(string url)
        {
            return this.get(url, null, null);
        }

        public HTTPResult get(string url, CookieContainer cookie)
        {
            return this.get(url, cookie, null);
        }

        public HTTPResult get(string url, CookieContainer cookie, Encoding encoding)
        {
            HttpWebResponse response = null;
            HTTPResult result = null;

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = WebRequestMethods.Http.Get;
                //request.Timeout = CONNECT_TIMEOUT;
                request.CookieContainer = cookie;

                response = request.GetResponse() as HttpWebResponse;
                result = new HTTPResult(response, encoding);
            }
            catch (Exception e)
            {
                result = new HTTPResult(e.ToString());
            }
            finally
            {
                if (null != response)
                {
                    try
                    {
                        response.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            return result;
        }

        public HTTPResult post(string url, IDictionary<string, string> parameterMap)
        {
            return this.post(url, parameterMap, null, Encoding.UTF8);
        }

        public HTTPResult post(string url, IDictionary<string, string> parameterMap, CookieContainer cookie)
        {
            return this.post(url, parameterMap, cookie, Encoding.UTF8);
        }

        public HTTPResult post(string url, IDictionary<string, string> parameterMap, CookieContainer cookie, Encoding encoding)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            HTTPResult result = null;

            try
            {
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = WebRequest.Create(url) as HttpWebRequest;
                }

                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = DEFAULT_CONTENT_TYPE;

                if (null == cookie)
                    cookie = new CookieContainer();

                request.CookieContainer = cookie;

                if (null != parameterMap && parameterMap.Count > 0)
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in parameterMap.Keys)
                    {
                        string value = HttpUtility.UrlEncode(parameterMap[key], encoding);

                        if (i > 0)
                            buffer.AppendFormat(PARAMETER_PATTERN_B, key, value);
                        else
                            buffer.AppendFormat(PARAMETER_PATTERN_A, key, value);

                        i++;
                    }

                    byte[] data = Encoding.Default.GetBytes(buffer.ToString());
                    request.ContentLength = data.Length;
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                        stream.Close();
                    }
                }

                response = request.GetResponse() as HttpWebResponse;

                result = new HTTPResult(response, encoding);

                string cookieHeader = request.CookieContainer.GetCookieHeader(new Uri(url));
                cookie.SetCookies(new Uri(url), cookieHeader);
                result.Cookie = cookie;
            }
            catch (Exception e)
            {
                result = new HTTPResult(e.ToString());
            }
            finally
            {
                if (null != response)
                {
                    try
                    {
                        response.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            return result;
        }

        public HTTPResult download(string url, string filePath)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            HTTPResult result = null;

            try
            {
                request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.AllowAutoRedirect = true;

                response = request.GetResponse() as HttpWebResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream stream = response.GetResponseStream();
                    byte[] buffer = new byte[READ_BUFFER_SIZE];
                    int l = -1;
                    FileStream fileStream = File.Create(filePath);
                    while ((l = stream.Read(buffer, 0, READ_BUFFER_SIZE)) > 0)
                        fileStream.Write(buffer, 0, l);

                    fileStream.Flush();
                    fileStream.Close();

                    stream.Close();
                    response.Close();

                    result = new HTTPResult(HttpStatusCode.OK);
                }
                else
                {
                    result = new HTTPResult(response.StatusCode);
                }
            }
            catch (Exception e)
            {
                result = new HTTPResult(e.ToString());
            }
            finally
            {
                if (null != response)
                {
                    try
                    {
                        response.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            return result;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
