﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace funsens.cvr
{
    /// <summary>
    /// 身份证读卡机的接口定义
    /// </summary>
    class CVR
    {
        [DllImport("termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_InitComm(int Port);//声明外部的标准动态库, 跟Win32API是一样的
        [DllImport("termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Authenticate();
        [DllImport("termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Read_Content(int Active);
        [DllImport("termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_CloseComm();
        [DllImport("termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetPeopleName(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "CVR_GetSAMID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int CVR_GetSAMID(ref byte strTmp);
        [DllImport("termb.dll", EntryPoint = "GetManuID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetManuID(ref byte strTmp);
    }
}
