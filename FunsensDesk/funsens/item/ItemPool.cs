using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using x.json;
using funsens.api;
using funsens.item.vo;

namespace funsens.item
{
    public class ItemPool
    {
        public delegate void ItemPoolCallback(List<ItemVO> itemList);

        private static ItemPool instance;

        private ItemPoolCallback callback;

        private bool isRunning;

        private ThreadStart threadStart;

        private Thread thread;

        private bool isDownloading;

        private Dictionary<string, string> barcodeMap;

        private List<string> barcodeList;

        private Dictionary<string, ItemVO> itemMap;

        private ItemPool(ItemPoolCallback callback)
        {
            this.callback = callback;

            this.barcodeMap = new Dictionary<string, string>();
            this.barcodeList = new List<string>();
            this.itemMap = new Dictionary<string, ItemVO>();

            this.isRunning = true;
            this.isDownloading = false;

            this.threadStart = new ThreadStart(this.downloadTask);
            this.thread = new Thread(this.threadStart);
            this.thread.Start();
        }

        public void append(string barcode)
        {
            //判断是否已经存在商品信息
            List<ItemVO> itemList = new List<ItemVO>();
            foreach(KeyValuePair<string,ItemVO> o in this.itemMap)
            {
                if (barcode.Equals(o.Value.Barcode))
                    itemList.Add(o.Value);
            }

            if(itemList.Count > 0)
            {
                this.callback(itemList);
                return;
            }

            //判断相同条形码是否已经正在同步
            if (!this.barcodeMap.ContainsKey(barcode))
            {
                this.barcodeMap.Add(barcode, barcode);
                this.barcodeList.Add(barcode);
            }
        }

        private void handleFinish(int type, int rc, string error, object content)
        {
            if (type == API.T_ITEM)
            {
                string barcode = this.barcodeList[0];
                this.barcodeList.RemoveAt(0);
                this.barcodeMap.Remove(barcode);

                if (rc == Handler.RC_SUCCESS)
                {
                    List<ItemVO> itemList = (List<ItemVO>)content;
                    int count = itemList.Count;
                    for (int i = 0; i < count; i++)
                    {
                        ItemVO vo = itemList[i];
                        this.itemMap.Add(vo.Id, vo);
                    }

                    this.callback(itemList);
                }
                else
                {
                    this.callback(null);
                }

                this.isDownloading = false;
            }
        }

        public static ItemPool getInstance(ItemPoolCallback callback)
        {
            if (null == instance)
                instance = new ItemPool(callback);

            return instance;
        }

        private void downloadTask()
        {
            while(this.isRunning)
            {
                if(!this.isDownloading && this.barcodeList.Count > 0)
                {
                    this.isDownloading = true;

                    string itemId = this.barcodeList[0];

                    GetItemsHandler handler = new GetItemsHandler(this.handleFinish, itemId);
                    handler.handle();
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
