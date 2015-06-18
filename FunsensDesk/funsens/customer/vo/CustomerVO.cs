using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funsens.customer.vo
{
    class CustomerVO
    {
        private string idNo;

        public string IdNo
        {
            get { return idNo; }
            set { idNo = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
    }
}
