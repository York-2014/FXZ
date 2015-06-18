using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.mis
{
    /// <summary>
    /// Mis接口处理结果
    /// </summary>
    class MisResult
    {
        public const string C_SUCCESS = "00";

        //交易结果（00 表示交易成功）
        private string code;

        //结果描述（字符串，不足补空格）
        private string message;
        public string Message
        {
            get { return message; }
        }

        //交易金额（撤销、退货时为原交易金额）
        private int amount;

        //商户名称
        private string merchantName;

        //商户id
        private string merchantId;

        //终端编号
        private string terminalId;

        //交易批次号
        private string batchNo;

        //交易凭证号
        private string traceNo;

        //原交易凭证号（撤销、退货时存在）
        private string orginalTraceNo;

        //交易日期
        private DateTime transDate;

        //授权号
        private string authCode;

        //系统参考号
        private string referenceNo;

        public MisResult(byte[] responseData)
        {
            this.code = bytesToString(responseData, 2, 2);
            this.message = bytesToString(responseData, 4, 40);

            string amountString = bytesToString(responseData, 44, 12);
            this.amount = int.Parse(amountString);

            this.merchantName = bytesToString(responseData, 66, 40);
            this.merchantId = bytesToString(responseData, 106, 15);

            this.terminalId = bytesToString(responseData, 121, 8);
            this.batchNo = bytesToString(responseData, 129, 6);
            this.orginalTraceNo = bytesToString(responseData, 135, 6);

            string transDateString = bytesToString(responseData, 141, 8);
            string transTimeString = bytesToString(responseData, 149, 6);
            int year = int.Parse(transDateString.Substring(0, 4));
            int month = int.Parse(transDateString.Substring(4, 2));
            int day = int.Parse(transDateString.Substring(6, 2));
            int hour = int.Parse(transTimeString.Substring(0, 2));
            int minute = int.Parse(transTimeString.Substring(0, 2));
            int second = int.Parse(transTimeString.Substring(0, 2));
            this.transDate = new DateTime(year, month, day, hour, minute, second);

            this.authCode = bytesToString(responseData, 155, 6);
            this.referenceNo = bytesToString(responseData, 161, 12);
        }

        public bool isSuccess()
        {
            return C_SUCCESS.Equals(this.code);
        }

        private static string bytesToString(byte[] data, int position, int length)
        {
            byte[] tmp = new byte[length];
            for(int i=0;i<length;i++)
                tmp[i] = data[position + i];

            string result = Encoding.Default.GetString(tmp);

            return result;
        }
    }
}
