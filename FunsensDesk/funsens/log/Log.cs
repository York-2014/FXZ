using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.log
{
    class Log
    {
        private const string DATE_PATTERN = "yyyyMMdd_hhmmss_fff";

        private const string DIR_NAME = "/log/";

        public void getOrders(string requestContent, object responseContent, string error)
        {
            try
            {
                string content = this.generateContent(requestContent, responseContent, error);
                string filePath = System.Environment.CurrentDirectory + DIR_NAME + "get_orders_" + DateTime.Now.ToString(DATE_PATTERN) + ".txt";

                createFile(filePath, content);
            }
            catch (Exception e)
            {
            }
        }

        public void getOrdersOfFranchisee(string requestContent, object responseContent, string error)
        {
            try
            {
                string content = this.generateContent(requestContent, responseContent, error);
                string filePath = System.Environment.CurrentDirectory + DIR_NAME + "get_orders_of_franchisee_" + DateTime.Now.ToString(DATE_PATTERN) + ".txt";

                createFile(filePath, content);
            }
            catch (Exception e)
            {
            }
        }

        public void getOrder(string requestContent, object responseContent, string error)
        {
            try
            {
                string content = this.generateContent(requestContent, responseContent, error);
                string filePath = System.Environment.CurrentDirectory + DIR_NAME + "get_order_" + DateTime.Now.ToString(DATE_PATTERN) + ".txt";

                createFile(filePath, content);
            }
            catch (Exception e)
            {
            }
        }

        public void addOrder(string requestContent, object responseContent, string error)
        {
            try
            {
                string content = this.generateContent(requestContent, responseContent, error);
                string filePath = System.Environment.CurrentDirectory + DIR_NAME + "add_order" + DateTime.Now.ToString(DATE_PATTERN) + ".txt";

                createFile(filePath, content);
            }
            catch (Exception e)
            {
            }
        }

        public void countOrder(string requestContent, object responseContent, string error)
        {
            try
            {
                string content = this.generateContent(requestContent, responseContent, error);
                string filePath = System.Environment.CurrentDirectory + DIR_NAME + "count_order_" + DateTime.Now.ToString(DATE_PATTERN) + ".txt";

                createFile(filePath, content);
            }
            catch (Exception e)
            {
            }
        }

        public void getItems(string requestContent, object responseContent, string error)
        {
            try
            {
                string content = this.generateContent(requestContent, responseContent, error);
                string filePath = System.Environment.CurrentDirectory + DIR_NAME + "get_items_" + DateTime.Now.ToString(DATE_PATTERN) + ".txt";

                createFile(filePath, content);
            }
            catch (Exception e)
            {
            }
        }

        private string generateContent(string requestContent, object responseContent, string error)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(requestContent);
            sb.Append("\r\n=========================================\r\n");
            sb.Append(null == responseContent ? "" : responseContent.ToString());
            sb.Append("\r\n=========================================\r\n");
            sb.Append(error);

            return sb.ToString();
        }

        private void createFile(string filePath, string content)
        {
            try
            {
                this.createDir();

                if (File.Exists(filePath))
                    File.Delete(filePath);

                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);

                writer.Write(content);

                writer.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

        private bool createDir()
        {
            string dirPath = System.Environment.CurrentDirectory + DIR_NAME;

            if (Directory.Exists(dirPath))
                return true;

            DirectoryInfo info = Directory.CreateDirectory(dirPath);

            return null != info;
        }
    }
}
