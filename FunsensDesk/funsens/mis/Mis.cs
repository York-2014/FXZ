using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using x.util;

namespace funsens.mis
{
    class Mis
    {
        //交易类型：签到
        private const string TT_LOG_IN = "00";

        //交易类型：签退
        private const string TT_LOG_OUT = "01";

        //交易类型：结算
        private const string TT_SETTLE = "02";

        //交易类型：查询余额
        private const string TT_QUERY_BALANCES = "03";

        //交易类型：消费
        private const string TT_SPEND = "22";

        //交易类型：撤消（消费）
        private const string TT_CANCEL_SPEND = "23";

        //交易类型：重打印上一笔
        private const string TT_PRINT_PRE = "40";

        //交易类型：重打结算单
        private const string TT_PRINT_SETTLE = "41";

        //交易类型：查询最后一笔交易
        private const string TT_QUERY_LAST_ORDER = "43";

        //交易类型：查询指定交易
        private const string TT_QUERY_ORDER = "44";

        //交易类型：订单支付
        private const string TT_ORDER_PAY = "71";

        private SerialPort comPort;

        public Mis(SerialPort comPort)
        {
            this.comPort = comPort;
        }


        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool logIn(string userId)
        {
            bool result = this.handle(TT_LOG_IN, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, userId, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 签退
        /// </summary>
        /// <returns></returns>
        public bool logOut()
        {
            bool result = this.handle(TT_LOG_OUT, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <returns></returns>
        public bool settle()
        {
            bool result = this.handle(TT_SETTLE, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <returns></returns>
        public bool queryBalances()
        {
            bool result = this.handle(TT_QUERY_BALANCES, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool spend(float payment, string userId)
        {
            bool result = this.handle(TT_SPEND, payment, DateTime.Now, true, S.EMPTY, S.EMPTY, userId, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 撤消（消费）
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool cancelSpend(string traceNo)
        {
            bool result = this.handle(TT_CANCEL_SPEND, 0.0f, DateTime.Now, true, traceNo, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 重打印上一单
        /// </summary>
        /// <returns></returns>
        public bool printPre()
        {
            bool result = this.handle(TT_PRINT_PRE, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 重打结算单
        /// </summary>
        /// <returns></returns>
        public bool printSettle()
        {
            bool result = this.handle(TT_PRINT_SETTLE, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 查询最后一笔交易
        /// </summary>
        /// <returns></returns>
        public bool queryLastOrder()
        {
            bool result = this.handle(TT_QUERY_LAST_ORDER, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public bool queryOrder(string orderId)
        {
            bool result = this.handle(TT_QUERY_ORDER, 0.0f, DateTime.Now, false, S.EMPTY, S.EMPTY, S.EMPTY, orderId, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 订单支付
        /// 调用串口连接的POS机进行支付
        /// </summary>
        /// <param name="payment">支付金额，单位：元</param>
        /// <param name="orderDate">下单日期</param>
        /// <param name="userId">收款台操作员号</param>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public bool orderPay(float payment, DateTime orderDate, string userId, string orderId)
        {
            bool result = this.handle(TT_ORDER_PAY, payment, orderDate, false, S.EMPTY, S.EMPTY, userId, orderId, S.EMPTY);

            return result;
        }

        /// <summary>
        /// 调用API
        /// </summary>
        /// <param name="transType">业务类型</param>
        /// <param name="payment">支付金额，单位：元</param>
        /// <param name="orderDate">交易日期</param>
        /// <param name="traceNo">原小票凭证号</param>
        /// <param name="referenceNo">原系统参考号</param>
        /// <param name="userId">收银台操作员号</param>
        /// <param name="orderId">订单号</param>
        /// <param name="otherInfo">其它信息</param>
        /// <returns></returns>
        public bool handle(string transType, float payment, DateTime orderDate, bool isNullOrderDate, string traceNo, string referenceNo, string userId, string orderId, string otherInfo)
        {
            //打开串口
            if (!this.openCom())
                return false;

            //生成指令
            byte[] startData = strToToHexByte("5F52");//指令头
            byte[] transTypeData = Encoding.Default.GetBytes(transType);//交易类型
            byte[] paymentData = formatPayment(payment);//交易金额
            byte[] orderDateData = formatOrderDate(orderDate, isNullOrderDate);//交易日期
            byte[] traceNoData = formatTraceNo(traceNo);//小票凭证号
            byte[] referenceNoData = formatReferenceNo(referenceNo);//系统参考号
            byte[] userIdData = formatUserId(userId);//收款台操作员号
            byte[] orderIdData = formatOrderId(orderId);//订单号
            byte[] otherData = generateOtherInfo();//其它交易信息    
            byte[] endData = new byte[1] { 0x1C };//指令尾

            List<byte[]> dataList = new List<byte[]>();
            dataList.Add(startData);
            dataList.Add(transTypeData);
            dataList.Add(paymentData);
            dataList.Add(orderDateData);
            dataList.Add(traceNoData);
            dataList.Add(referenceNoData);
            dataList.Add(userIdData);
            dataList.Add(orderIdData);
            dataList.Add(otherData);
            dataList.Add(endData);

            byte[] data = mergeData(dataList);

            int count = data.Length;
            for (int i = 0; i < count; i++)
                Console.Write(" " + byteToHexStr(data[i]));

            //发送指令
            this.comPort.Write(data, 0, data.Length);

            //关闭串口
            this.closeCom();

            return true;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public bool openCom()
        {
            if (null != this.comPort && this.comPort.IsOpen)
                return true;

            try
            {
                //获取所有串口名称
                string[] portNameArray = SerialPort.GetPortNames();
                Array.Sort(portNameArray);
                int count = portNameArray.Length;
                string portName = null;
                for (int i = 0; i < count; i++)
                {
                    if(!"COM1".Equals(portNameArray[i]))
                        portName = portNameArray[i];

                    Console.WriteLine(">>>" + portNameArray[i]);
                }

                Console.WriteLine("[SelectedPort]" + portName);

                //打开串口
                this.comPort.BaudRate = 9600;
                this.comPort.PortName = portName;
                this.comPort.DataBits = 8;
                this.comPort.StopBits = StopBits.One;
                this.comPort.Parity = Parity.None;
                this.comPort.Open();

                bool isOpen = this.comPort.IsOpen;

                return isOpen;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return false;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        private bool closeCom()
        {
            if (null == this.comPort || !this.comPort.IsOpen)
                return true;

            try
            {
                this.comPort.Close();

                bool isOpen = this.comPort.IsOpen;

                return !isOpen;
            }
            catch(Exception e)
            {

            }

            return false;
        }

        /// <summary>
        /// 合并字节数组
        /// </summary>
        /// <param name="dataList">要合并的字节数组列表</param>
        /// <returns>返回合并后的字节数组</returns>
        private static byte[] mergeData(List<byte[]> dataList)
        {
            int count = dataList.Count;
            int byteCount = 0;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(">>>" + dataList[i].Length);
                byteCount += dataList[i].Length;
            }

            int position = 0;
            byte[] result = new byte[byteCount];
            for (int i = 0; i < count; i++)
            {
                byte[] data = dataList[i];
                int dataCount = data.Length;
                for (int j = 0; j < dataCount; j++)
                {
                    result[position + j] = data[j];
                }

                position += dataCount;
            }

            return result;
        }

        /// <summary>
        /// 生成“其它交易信息”
        /// </summary>
        /// <returns>返回“其它交易信息”，100个空格</returns>
        private static byte[] generateOtherInfo()
        {
            int count = 100;
            byte[] result = new byte[100];
            for (int i = 0; i < count; i++)
                result[i] = (byte)' ';

            return result;
        }

        /// <summary>
        /// 将“订单号”转换为指令内容
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>返回转换后的指令内容</returns>
        private static byte[] formatOrderId(string orderId)
        {
            //补位
            string str = (null == orderId ? S.EMPTY : orderId);
            int count = 32 - orderId.Length;
            for (int i = 0; i < count; i++)
                str += " ";

            //转换
            byte[] result = Encoding.Default.GetBytes(str);

            return result;
        }

        /// <summary>
        /// 将“收款台操作员id”转换为指令内容
        /// </summary>
        /// <param name="userId">收款台操作员id</param>
        /// <returns>返回转换后的指令内容</returns>
        private static byte[] formatUserId(string userId)
        {
            //补位
            string str = (null == userId ? S.EMPTY : userId);
            int count = 8 - userId.Length;
            for (int i = 0; i < count; i++)
                str += " ";

            //转换
            byte[] result = Encoding.Default.GetBytes(str);

            return result;
        }

        /// <summary>
        /// 将“原系统参考号”转换为指令内容
        /// </summary>
        /// <param name="referenceNo">原系统参考号</param>
        /// <returns>返回转换后的指令内容</returns>
        private static byte[] formatReferenceNo(string referenceNo)
        {
            //补位
            string str = "";
            string tmp = (null == referenceNo ? S.EMPTY : referenceNo);
            int count = 12 - tmp.Length;
            for (int i = 0; i < count; i++)
                str += "0";

            str += tmp;

            //转换
            byte[] result = Encoding.Default.GetBytes(str);

            return result;
        }

        /// <summary>
        /// 将“原小票凭证号”转换为指令内容
        /// </summary>
        /// <param name="traceNo">原小票凭证号</param>
        /// <returns>返回转换后的指令内容</returns>
        private static byte[] formatTraceNo(string traceNo)
        {
            //补位
            string str = "";
            string tmp = (null == traceNo ? S.EMPTY : traceNo);
            int count = 6 - tmp.Length;
            for (int i = 0; i < count; i++)
                str += "0";

            str += tmp;

            //转换
            byte[] result = Encoding.Default.GetBytes(str);

            return result;
        }

        /// <summary>
        /// 将“原交易时间”转换为指令内容
        /// </summary>
        /// <param name="orderDate">原交易时间</param>
        /// <returns>返回转换后的指令内容</returns>
        private static byte[] formatOrderDate(DateTime orderDate, bool isNull)
        {
            byte[] result = null;

            if(isNull)
            {
                result = new byte[4];
                result[0] = (byte)'0';
                result[1] = (byte)'0';
                result[2] = (byte)'0';
                result[3] = (byte)'0';

                return result;
            }

            string dateString = orderDate.ToString("MMdd");

            result = Encoding.Default.GetBytes(dateString);

            return result;
        }

        /// <summary>
        /// 将“交易金额”转换为指令内容
        /// </summary>
        /// <param name="payment">交易金额，单位元</param>
        /// <returns>返回转换后的指令内容</returns>
        private static byte[] formatPayment(float payment)
        {
            //单位转换为分
            int _payment = (int)(payment * 100);

            //补位，不足12位时前面补0
            byte[] paymentData = Encoding.Default.GetBytes(_payment + "");

            byte[] result = new byte[12];
            int count = paymentData.Length;
            for (int i = 0; i < count; i++)
                result[12 - count + i] = paymentData[i];

            count = 12 - count;
            for (int i = 0; i < count; i++)
                result[i] = (byte)'0';

            return result;
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");

            if ((hexString.Length % 2) != 0)
                hexString += " ";

            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return returnBytes;
        }

        public static string byteToHexStr(byte bytes)
        {
            string returnStr = "";
            returnStr += bytes.ToString("X2");

            return returnStr;
        }
    }
}
