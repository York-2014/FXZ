using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.util
{
    class RegsiterUserInfo
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        private bool checkedUserName;
        public bool CheckedUserName
        {
            get { return checkedUserName; }
            set { checkedUserName = value; }
        }

        private bool checkedPassword;
        public bool CheckedPassword
        {
            get { return checkedPassword; }
            set { checkedPassword = value; }
        }

    }

    class RegisterUtil
    {
        private static readonly string subkey = "software\\funsens";

        public static List<RegsiterUserInfo> GetAllRegUserInfo()
        {
            List<RegsiterUserInfo> lstRegUserInfo = new List<RegsiterUserInfo>();
            RegistryKey root = Registry.LocalMachine;
            RegistryKey myKey = root.OpenSubKey(subkey, true);
            string[] subkeyNames = myKey.GetSubKeyNames();
            RegsiterUserInfo userInfo;
            foreach (string aimKey in subkeyNames)
            {
                userInfo = new RegsiterUserInfo();
                myKey = root.OpenSubKey(subkey + "\\" + aimKey, true);
                userInfo.CheckedPassword = Convert.ToBoolean(myKey.GetValue("CheckedPassword").ToString());
                userInfo.CheckedUserName = Convert.ToBoolean(myKey.GetValue("CheckedUserName").ToString());
                userInfo.UserName = aimKey;
                userInfo.PassWord = myKey.GetValue("Password").ToString();
                lstRegUserInfo.Add(userInfo);
            }
            return lstRegUserInfo;
        }

        /// <summary>
        /// 读取指定名称的注册表的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetRegistryData(string key, string name)
        {
            RegistryKey root = Registry.LocalMachine;
            string registData = "";
            RegistryKey myKey = root.OpenSubKey(subkey + "\\" + key, true);
            if (myKey != null)
            {
                registData = myKey.GetValue(name).ToString();
            }
            myKey.Close();
            root.Close();
            return registData;
        }

        /// <summary>
        /// 向注册表中写数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tovalue"></param> 
        public static void SetRegistryData(string key, string name, string value)
        {
            RegistryKey root = Registry.LocalMachine;
            RegistryKey aimdir = root.CreateSubKey(subkey + "\\" + key);
            aimdir.SetValue(name, value);
            root.Close();
            aimdir.Close();
        }

        /// <summary>
        /// 删除注册表中指定的注册表项
        /// </summary>
        /// <param name="name"></param>
        public static void DeleteRegist(string key, string name)
        {
            string[] subkeyNames;
            RegistryKey root = Registry.LocalMachine;
            RegistryKey myKey = root.OpenSubKey(subkey + "\\" + key, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string aimKey in subkeyNames)
            {
                if (aimKey == name)
                {
                    myKey.DeleteSubKeyTree(name);
                }
            }
            myKey.Close();
            root.Close();
        }

        /// <summary>
        /// 判断指定注册表项是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRegUserNameExist(string key, string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey root = Registry.LocalMachine;
            RegistryKey myKey = root.OpenSubKey(subkey + "\\" + key, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == name)
                {
                    _exit = true;
                    return _exit;
                }
            }
            myKey.Close();
            root.Close();
            return _exit;
        }
    }
}