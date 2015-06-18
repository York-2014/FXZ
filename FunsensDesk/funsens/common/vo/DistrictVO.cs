using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.common.vo
{
    public class DistrictVO
    {
        public const string ROOT_ID = "0";

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string parentId;
        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DistrictVO(JO jo)
        {
            this.id = jo.getString("id");
            this.parentId = jo.getString("pid");
            this.name = jo.getString("name");
        }
    }
}
