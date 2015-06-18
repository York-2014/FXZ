using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using x.net.http;

namespace funsens.image
{
    public class ImagePool
    {
        public delegate void ImagePoolCallback(string url, Image image);

        private ImagePoolCallback callback;

        private bool isRunning;

        private ThreadStart threadStart;

        private Thread thread;

        private Dictionary<string, string> imageIdMap;

        private List<string> imageIdList;

        private Dictionary<string, Image> imageMap;

        public ImagePool(ImagePoolCallback callback)
        {
            this.callback = callback;

            this.imageIdMap = new Dictionary<string, string>();
            this.imageIdList = new List<string>();
            this.imageMap = new Dictionary<string, Image>();

            this.isRunning = true;

            this.threadStart = new ThreadStart(this.downloadTask);
            this.thread = new Thread(this.threadStart);
            this.thread.Start();
        }

        public void append(string url)
        {
            if (null == url || "".Equals(url))
                return;

            if(this.imageMap.ContainsKey(url))
            {
                Image image = this.imageMap[url];
                this.callback(url, image);

                return;
            }

            if (!this.imageIdMap.ContainsKey(url))
            {
                this.imageIdMap.Add(url, url);
                this.imageIdList.Add(url);
            }
        }

        private void downloadTask()
        {
            while(this.isRunning)
            {
                if(this.imageIdList.Count > 0)
                {
                    string url = this.imageIdList[0];

                    string tmp = Environment.GetEnvironmentVariable("TEMP") + "/" + (new Random()).NextDouble();
                    string tmpPath = tmp + ".jpg";
                    string destPath = tmp + "_.jpg";

                    HTTP http = new HTTP();
                    HTTPResult result = http.download(url, tmpPath);
                    if (result.isSuccess())
                    {
                        Image srcImage = Image.FromFile(tmpPath);

                        int srcWidth = srcImage.Width;
                        int srcHeight = srcImage.Height;

                        int maxWH = 90;
                        int destWidth = 0;
                        int destHeight = 0;
                        if (srcWidth > srcHeight)
                        {
                            destWidth = maxWH;
                            destHeight = (int)(srcHeight * ((double)destWidth / (double)srcWidth));
                        }
                        else
                        {
                            destHeight = maxWH;
                            destWidth = (int)(srcWidth * ((double)destHeight / (double)srcHeight));
                        }

                        Image destImage = new Bitmap(destWidth, destHeight);
                        Graphics g = Graphics.FromImage(destImage);
                        g.DrawImage(srcImage, 0, 0, destWidth, destHeight);
                        destImage.Save(destPath);

                        this.imageMap.Add(url, destImage);

                        this.callback(url, destImage);
                    }

                    this.imageIdMap.Remove(url);
                    this.imageIdList.RemoveAt(0);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch(Exception e)
                {

                }
            }
        }
    }
}
