using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.json;

namespace funsens.customer.vo
{
    public class AddressVO
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

        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string provinceId;
        public string ProvinceId
        {
            get { return provinceId; }
            set { provinceId = value; }
        }

        private string provinceName;
        public string ProvinceName
        {
            get { return provinceName; }
            set { provinceName = value; }
        }

        private string cityId;
        public string CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        private string cityName;
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        private string areaId;
        public string AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        private string areaName;
        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string zipCode;
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public AddressVO(JO jo)
        {
            this.id = jo.getString("addressId");
            this.name = jo.getString("connectName");
            this.tel = jo.getString("mobilephone");
            this.provinceId = jo.getString("provinceid");
            this.cityId = jo.getString("cityid");
            this.areaId = jo.getString("areaid");
            this.address = jo.getString("address");
            this.zipCode = jo.getString("postCode");
        }
    }
}
