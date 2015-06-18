using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.servicedesk.vo
{
    public class ServiceDeskVO
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
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

        public ServiceDeskVO(JO jo)
        {
            this.id = jo.getString("id");
            this.name = jo.getString("window_name");
            this.status = jo.getInt("status");
        }
    }
}
