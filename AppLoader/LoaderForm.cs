using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AppLoader
{
    public partial class LoaderForm : Form
    {
        private WebClient myWebClient = new WebClient();

        private string CurrentUpdatePath = string.Empty;

        private bool isLocked = false;//逐个下载锁定标识

        #region 界面刷新
        private delegate void UpdateStatusDelegate(string strDescribe);
        private delegate void UpdateProgressDelegate(int progress);
        private void RefreshProcess(int progress)
        {
            if (progressBar1.Visible == false)
            {
                progressBar1.Visible = true;
            }
            progressBar1.Value = progress;
        }

        private void RefreshDescribe(string strDescribe)
        {
            if (strDescribe.Contains("Exception") == true)
            {
                this.TopMost = false;
                if (strDescribe.Contains("WebException"))
                {
                    label_status.Text = "无法获取服务器数据！";
                    progressBar1.Visible = false;
                    MessageBox.Show(strDescribe.Split(':')[1], "网络异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (strDescribe.Contains("StartException"))
                {
                    label_status.Text = "启动失败！";
                    progressBar1.Visible = false;
                    MessageBox.Show(strDescribe.Split(':')[1], "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (strDescribe.Contains("UpdateException"))
                {
                    label_status.Text = "升级失败，请重试或联系管理员！";
                    progressBar1.Visible = false;
                    MessageBox.Show(strDescribe.Split(':')[1], "升级失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (myWebClient != null)
                {
                    myWebClient.CancelAsync();
                }
                Application.Exit();
            }
            label_status.Text = strDescribe;
        }

        private void UpdateStatus(string strDescribe)
        {
            Invoke(new UpdateStatusDelegate(RefreshDescribe), new object[] { strDescribe });
        }

        private void UpdateStatusAndProgress(string strDescribe, int progress)
        {
            Invoke(new UpdateStatusDelegate(RefreshDescribe), new object[] { strDescribe });
            Invoke(new UpdateProgressDelegate(RefreshProcess), new object[] { progress });
        }
        #endregion

        public LoaderForm()
        {
            InitializeComponent();
        }

        private void LoaderForm_Load(object sender, EventArgs e)
        {
            string settingsPath = Path.Combine(System.Environment.CurrentDirectory, "Settings.xml");
            if (File.Exists(settingsPath) == false)
            {
                MessageBox.Show("配置文件丢失造成程序无法启动，请联系管理员！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                CurrentUpdatePath = GetUpdatePath(settingsPath);
                Thread guideThread = new Thread(new ThreadStart(Init));
                guideThread.IsBackground = true;
                guideThread.Start();
            }
        }

        private void Init()
        {
            if (AppRunAlready("funsens") == true)
            {
                UpdateStatus("StartException:" + "主程序已经启动，请将其手动关闭后重试！");
                //UpdateStatus("IOException:" + "主程序正在使用，请将其手动关闭后重试！");
                return;
            }

            //设置保存下载数据的临时文件夹
            string tempDirectoryName = Path.Combine(System.Environment.CurrentDirectory, "TEMP");
            string oldVersionDirectory = Path.Combine(System.Environment.CurrentDirectory, "OLDVERSION");
            //当前版本程序所在目录
            string currentVersionDirectory = System.Environment.CurrentDirectory + @"\Main";

            //获取当前主程序版本号
            string targetPath = currentVersionDirectory + @"\funsens.exe";
            string targetDirectory = Path.GetDirectoryName(targetPath);
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(targetPath);
            string currentVersion = fileVersion.FileVersion;
            Version vCurrent = new Version(currentVersion);

            UpdateStatus("稍等，正在检查版本更新...");
            Thread.Sleep(500);
            XmlDocument xmlDoc = new XmlDocument();
            string remoteVersion = null;

            try
            {
                //获取远程xml清单
                string xmlContent = myWebClient.DownloadString(CurrentUpdatePath);//"http://www.wan0791.com/client_update/pc/check_update.xml");
                xmlDoc.LoadXml(xmlContent);
                //获取远程版本号
                remoteVersion = xmlDoc.DocumentElement["version"].InnerText;
            }
            catch (Exception ex)
            {
                WriteTextLog(ex.Message + "\r\nDetails:" + ex.StackTrace);
                if (ex is WebException)
                {
                    UpdateStatus("WebException:" + "网络连接异常，请检查网络连接并重试！");
                }
                return;
            }
            //远程版本号
            Version vRemote = new Version(remoteVersion);
            //Version vRemote = new Version("1.0.0.1"); //new Version(remoteVersion);
            try
            {
                //当远程版本号大于当前版本,将文件下载到temp目录,全部下载完成后覆盖到CardManager文件夹,成功后启动主程序
                if (vRemote > vCurrent)
                {
                    UpdateStatus("检查到有更新的版本，正在获取...");
                    Thread.Sleep(500);

                    #region 下载升级包
                    //从XML获取MD5校验码
                    string md5Code = xmlDoc.DocumentElement["md5"].InnerText;
                    //获取Zip文件下载路径
                    string zipURL = xmlDoc.DocumentElement["zipfile"].InnerText;
                    //设置Temp文件夹在当前文件夹下
                    string tmpFileSavePath = Path.Combine(System.Environment.CurrentDirectory, tempDirectoryName);
                    //如果Temp文件夹存在则删除
                    if (true == Directory.Exists(tmpFileSavePath))
                    {
                        //删除Temp文件夹
                        Directory.Delete(tempDirectoryName, true);
                    }
                    //重新创建Temp文件夹
                    Directory.CreateDirectory(tmpFileSavePath);
                    //zip压缩文件保存路径 Temp文件夹下
                    string zipFileSavePath = Path.Combine(tmpFileSavePath, Path.GetFileName(zipURL));
                    myWebClient.DownloadProgressChanged += myWebClient_DownloadProgressChanged;
                    myWebClient.DownloadFileCompleted += myWebClient_DownloadFileCompleted;
                    isLocked = true;
                    //下载zip压缩文件到Temp文件夹下
                    myWebClient.DownloadFileAsync(new Uri(zipURL), zipFileSavePath);
                    bool checkNetWorkFlag = false;
                    while (true)
                    {
                        if (false == isLocked)
                        {
                            break;
                        }
                        else
                        {//检查网络连接
                            if (checkNetWorkFlag == false)
                            {
                                checkNetWorkFlag = true;
                                WebClient checkNetWork = new WebClient();
                                try
                                {
                                    string xmlContent = checkNetWork.DownloadString(CurrentUpdatePath);// "http://www.wan0791.com/client_update/pc/check_update.xml");
                                }
                                catch (Exception ex)
                                {
                                    WriteTextLog(ex.Message + "\r\nDetails:" + ex.StackTrace);
                                    if (ex is WebException)
                                    {
                                        UpdateStatus("WebException:" + "无法连接到服务器，请检查网络连接并重试！");
                                    }
                                }
                                finally
                                {
                                    checkNetWork.CancelAsync();
                                    checkNetWork.Dispose();
                                    checkNetWorkFlag = false;
                                }
                            }
                        }
                    }
                    UpdateStatus("正在替换新版本文件...");
                    Thread.Sleep(500);
                    //进行MD5校验
                    if (getMD5Hash(zipFileSavePath) == md5Code)
                    {
                        #region 解压
                        //异常信息
                        string strExceptionMessgae = string.Empty;
                        //指定解压后的文件存放目录
                        string unZipDirectory = Path.Combine(tempDirectoryName, System.IO.Path.GetFileNameWithoutExtension(zipFileSavePath));

                        //解压zip压缩文件
                        bool result = UnZipFile(zipFileSavePath, unZipDirectory, ref strExceptionMessgae);
                        #endregion
                        if (true == result)
                        {
                            #region 开始替换文件
                            #region STEP 1 - 清空旧版本文件夹数据
                            //如果旧版本文件夹不存在
                            if (false == Directory.Exists(oldVersionDirectory))
                            {
                                //创建旧版本文件夹
                                Directory.CreateDirectory(oldVersionDirectory);
                            }
                            #endregion

                            #region STEP 2 - 将当前版本文件备份到旧版本文件夹
                            //获取当前版本目录信息
                            DirectoryInfo currentVersionFolderInfo = new DirectoryInfo(currentVersionDirectory);
                            //获取目录下的所有文件信息
                            FileInfo[] currentVersionFiles = currentVersionFolderInfo.GetFiles();
                            foreach (FileInfo curFile in currentVersionFiles)
                            {
                                //设置要保存到旧版本文件夹的对应文件路径
                                string targetOldVersionFilePath = Path.Combine(oldVersionDirectory, curFile.ToString());
                                //将当前目录下的文件复制到旧版本文件夹
                                File.Copy(Path.Combine(curFile.DirectoryName, curFile.Name), targetOldVersionFilePath, true);
                            }
                            #endregion

                            #region STEP 3 - 将新版本文件复制到当前版本文件夹
                            //获取目录信息
                            DirectoryInfo afterUnZipDirInfo = new DirectoryInfo(unZipDirectory);
                            //获取目录下的所有文件信息
                            FileInfo[] afterUnZipFiles = afterUnZipDirInfo.GetFiles();
                            //遍历目录内所有文件
                            foreach (FileInfo file in afterUnZipFiles)
                            {
                                //Error_location = string.Format("替换当前版本文件. 新文件={0}, 旧文件={1}", file, currentVersionDirectory);
                                //获取新版本文件路径
                                string newVersionFile = Path.Combine(file.DirectoryName, file.Name);
                                string targetFile = Path.Combine(currentVersionDirectory, Path.GetFileName(newVersionFile));
                                //用新版本文件覆盖原有文件
                                File.Copy(newVersionFile, targetFile, true);
                            }
                            #endregion

                            #region STEP 4 - 删除TEMP文件夹
                            //删除Temp文件夹包括其所有文件
                            Directory.Delete(tempDirectoryName, true);
                            #endregion
                            #endregion
                        }
                        else
                        {
                            throw new IOException("解压升级包失败，请重试！");
                        }
                    }
                    else
                    {
                        throw new IOException("升级包文件损坏，请重试！");
                    }
                    #endregion
                    vCurrent = vRemote;
                    WriteTextLog("成功升级到版本：" + vCurrent.ToString());
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                WriteTextLog(ex.Message + "\r\nDetails:" + ex.StackTrace);
                UpdateStatus("UpdateException:" + ex.Message);
                return;
            }

            //启动主程序,结束自身
            UpdateStatus("正在启动...");
            Thread.Sleep(500);
            try
            {
                Process.Start(targetPath);
                WriteTextLog("启动主程序成功，当前版本：" + vCurrent.ToString());
            }
            catch (Exception ex)
            {
                WriteTextLog("******主程序启动失败******\r\n" + ex.Message + "\r\nDetails:" + ex.StackTrace);
                UpdateStatus("StartException:" + "主程序启动失败，请重试！");
            }
            Application.Exit();
        }

        private string GetUpdatePath(string settingsPath)
        {
            string strUpdatePath = string.Empty;
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(File.ReadAllText(settingsPath));
                string strPort = xdoc.DocumentElement["Port"].InnerText;
                string strUrl = xdoc.DocumentElement["Url"].InnerText;
                string strPath = xdoc.DocumentElement["Path"].InnerText;
                if (string.IsNullOrEmpty(strPort) == false)// && string.IsNullOrEmpty(strUrl) == false && string.IsNullOrEmpty(strPath) == false)
                {
                    strUpdatePath = strUrl + ":" + strPort + "/" + strPath + "/" + "check_update.xml";
                }
                else
                {
                    strUpdatePath = strUrl + "/" + strPath + "/" + "check_update.xml";
                }
            }
            catch (Exception ex)
            {
                strUpdatePath = ex.Message;
            }
            return strUpdatePath;
        }

        ///<summary>     
        /// 验证目标是否已经运行
        /// </summary>  
        public static bool AppRunAlready(string appName)
        {
            Process[] app = Process.GetProcessesByName(appName);
            return app.Length > 0;
        }

        private void myWebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //更新进度
            string strProgress = (Convert.ToDouble(e.BytesReceived) / Convert.ToDouble(e.TotalBytesToReceive)).ToString("0.0%");
            strProgress = String.Format("正在下载升级包{0}...", strProgress);
            UpdateStatusAndProgress(strProgress, e.ProgressPercentage);
        }

        private void myWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                WriteTextLog(e.Error.Message + "\r\nDetails:" + e.Error.StackTrace);
                UpdateStatus("WebException:" + "网络连接异常，请检查网络连接并重试！");
                myWebClient.CancelAsync();
                return;
            }
            UpdateStatus("下载完成，准备安装...");
            Thread.Sleep(500);
            isLocked = false;
        }

        #region  Write Text Log
        /// <summary>
        /// Write text to log file.
        /// </summary>
        /// <param name="strLog"></param>
        public static void WriteTextLog(string strLog)
        {
            string savePath = string.Format("{0}\\Log\\CheckUpdate_{1}.txt", Environment.CurrentDirectory, System.DateTime.Now.ToString("yyyy-MM-dd"));
            string saveFolder = Path.GetDirectoryName(savePath);
            if (!System.IO.Directory.Exists(saveFolder))
            {
                System.IO.Directory.CreateDirectory(saveFolder);
                DirectorySecurity secu = new DirectorySecurity(Path.GetDirectoryName(savePath), AccessControlSections.Access);
                FileSystemAccessRule fsar = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
                secu.SetAccessRule(fsar);
                System.IO.Directory.SetAccessControl(saveFolder, secu);
            }
            using (StreamWriter sw = new StreamWriter(savePath, true))
            {
                sw.WriteLine(string.Format("【{0}】\r\n  {1}\r\n", DateTime.Now.ToString("HH:mm:ss"), strLog));
            }
        }
        #endregion

        #region MD5
        /// <summary>
        /// 计算文件的MD5码
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string getMD5Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            try
            {
                using (FileStream oFileStream = new FileStream(pathName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream);//计算指定Stream 对象的哈希值
                    oFileStream.Close();
                    //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                    strHashData = System.BitConverter.ToString(arrbytHashValue);
                    //替换-
                    strHashData = strHashData.Replace("-", "");
                    strResult = strHashData;
                }
            }
            catch// (Exception ex)
            {
                strResult = null;
            }
            return strResult;
        }
        #endregion

        #region 解压文件到指定目录
        /// <summary>
        /// 解压文件到指定目录
        /// </summary>
        /// <param name="zipFilePath">Zip压缩文件所在路径</param>
        /// <param name="unZipDirectory">解压后的文件存放目录</param>
        /// <param name="strExceptionMessage">失败异常信息</param>
        public static bool UnZipFile(string zipFilePath, string unZipDirectory, ref string strExceptionMessage)
        {
            bool result = false;
            try
            {
                using (var zip1 = Ionic.Zip.ZipFile.Read(zipFilePath))
                {
                    foreach (var entry in zip1)
                    {
                        entry.Extract(unZipDirectory, ExtractExistingFileAction.OverwriteSilently);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                strExceptionMessage = ex.ToString();
            }
            return result;
        }
        #endregion
    }
}
