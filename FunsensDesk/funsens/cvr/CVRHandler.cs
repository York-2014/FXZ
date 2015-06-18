using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using funsens.common;

namespace funsens.cvr
{
    /// <summary>
    /// 身份证读卡器的接口类
    /// 可通过该类来读取身份证信息
    /// </summary>
    class CVRHandler
    {
        public const int RC_SUCCESS = 1;

        public const int RC_NO_CARD = 0;

        public const int RC_CONNECT_FAILED = -1;

        public const int RC_AUTHENTICATE_FAILED = -2;

        private const int READ_CYCLE = 500;

        private static CVRHandler instance;

        public delegate void CVRDelegate(int rc);

        private CVRDelegate callback;

        private int port;

        private Thread thread;

        private ThreadStart threadStart;

        private object lockObject;

        private CVRHandler()
        {
            this.lockObject = new object();

            this.threadStart = new ThreadStart(this.readCard);
            this.thread = new Thread(this.threadStart);
            this.thread.Start();
        }

        public static CVRHandler getInstance()
        {
            if (null == instance)
                instance = new CVRHandler();

            return instance;
        }

        public bool connect()
        {
            return this.initCVR() > 0;
        }

        public bool disconnect()
        {
            return CVR.CVR_CloseComm() == 1;
        }

        public bool isConnected()
        {
            return port > 0;
        }

        /// <summary>
        /// 获取身份证号码
        /// </summary>
        /// <returns></returns>
        public string getNo()
        {
            byte[] buffer = new byte[30];
            int length = 30;

            int rc = CVR.GetPeopleIDCode(ref buffer[0], ref length);
            if (rc == 1)
            {
                string no = Encoding.GetEncoding("GB2312").GetString(buffer).Replace("\0", "");
                return no;
            }

            return null;
        }

        /// <summary>
        /// 获取姓名
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            byte[] buffer = new byte[30];
            int length = 30;

            int rc = CVR.GetPeopleName(ref buffer[0], ref length);
            if (rc == 1)
            {
                string name = Encoding.GetEncoding("GB2312").GetString(buffer).Replace("\0", "");
                return name;
            }

            return null;
        }

        /// <summary>
        /// 获取住址
        /// </summary>
        /// <returns></returns>
        public string getAddress()
        {
            byte[] buffer = new byte[70];
            int length = 30;

            int rc = CVR.GetPeopleAddress(ref buffer[0], ref length);
            if (rc == 1)
            {
                string address = Encoding.GetEncoding("GB2312").GetString(buffer).Replace("\0", "");
                return address;
            }

            return null;
        }

        /// <summary>
        /// 读取卡信息
        /// </summary>
        /// <returns></returns>
        public int read()
        {
            return CVR.CVR_Read_Content(4);
        }

        /// <summary>
        /// 认证
        /// </summary>
        /// <returns></returns>
        public int authenticate()
        {
            return CVR.CVR_Authenticate();
        }

        /// <summary>
        /// 初始化，连接到读卡器
        /// </summary>
        /// <returns></returns>
        public int initCVR()
        {
            try
            {
                //判断USB接口是否连接到读卡器
                this.port = -1;
                int flag = -1;
                int tmpPort = -1;
                for (tmpPort = 1001; tmpPort <= 1016; tmpPort++)
                {
                    flag = CVR.CVR_InitComm(tmpPort);
                    if (flag == 1)
                    {
                        this.port = tmpPort;
                        break;
                    }
                }

                if (flag != 1)
                {
                    //判断COM接口是否连接到读卡器
                    for (tmpPort = 1; tmpPort <= 4; tmpPort++)
                    {
                        flag = CVR.CVR_InitComm(tmpPort);
                        if (flag == 1)
                        {
                            this.port = tmpPort;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return this.port;
        }

        public void setCallback(CVRDelegate callback)
        {
            lock(this.lockObject)
            {
                this.callback = callback;
            }
        }

        private void callbackTask(int rc)
        {
            lock(this.lockObject)
            {
                if (null != this.callback)
                    this.callback(rc);
            }
        }

        /// <summary>
        /// 定时读取身份证信息
        /// </summary>
        private void readCard()
        {
            while (true)
            {
                if (!this.connect())
                {
                    this.callbackTask(RC_CONNECT_FAILED);
                    continue;
                }

                int rc = this.authenticate();
                if (rc == 1)
                {
                    rc = this.read();
                    if (rc == 1)
                    {
                        Session session = Session.getInstance();
                        session.IcNo = this.getNo();
                        session.CustomerName = this.getName();
                        session.CustomerAddress = this.getAddress();

                        this.callbackTask(RC_SUCCESS);
                    }
                    else
                    {
                        this.callbackTask(RC_NO_CARD);
                    }
                }
                else
                {
                    this.callbackTask(RC_AUTHENTICATE_FAILED);
                }

                this.disconnect();

                try
                {
                    Thread.Sleep(READ_CYCLE);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
