using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.stock.vo
{
    class ShelfVO
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string serviceDeskId;
        public string ServiceDeskId
        {
            get { return serviceDeskId; }
            set { serviceDeskId = value; }
        }

        private string serviceDeskName;
        public string ServiceDeskName
        {
            get { return serviceDeskName; }
            set { serviceDeskName = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public ShelfVO(JO jo)
        {
            this.id = jo.getString("id");
            this.serviceDeskId = jo.getString("window_id");
            this.serviceDeskName = jo.getString("window_name");
            this.name = jo.getString("shelf_name");
            this.status = jo.getInt("status");
        }
    }
}
