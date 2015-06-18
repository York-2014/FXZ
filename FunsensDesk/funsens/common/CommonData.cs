using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x.util;
using funsens.common.vo;
using funsens.servicedesk.vo;

namespace funsens.common
{
    public class CommonData
    {
        private static CommonData instance;

        private List<DistrictVO> districtList;
        public List<DistrictVO> DistrictList
        {
            get { return districtList; }
            set { districtList = value; }
        }

        private Dictionary<string, ServiceDeskVO> serviceDeskMap;
        public Dictionary<string, ServiceDeskVO> ServiceDeskMap
        {
            get { return serviceDeskMap; }
        }

        private CommonData()
        {
            this.districtList = new List<DistrictVO>();
        }

        public static CommonData getInstance()
        {
            if (null == instance)
                instance = new CommonData();

            return instance;
        }

        public string getDistrictNameById(string id)
        {
            int count = this.districtList.Count;
            for (int i = 0; i < count; i++)
            {
                DistrictVO vo = this.districtList[i];
                if (vo.Id.Equals(id))
                    return vo.Name;
            }

            return S.EMPTY;
        }

        public void setServiceDeskList(List<ServiceDeskVO> serviceDeskList)
        {
            int count = serviceDeskList.Count;
            this.serviceDeskMap = new Dictionary<string, ServiceDeskVO>();
            for (int i = 0; i < count; i++)
            {
                ServiceDeskVO vo = serviceDeskList[i];
                this.serviceDeskMap.Add(vo.Id, vo);
            }
        }

        public string getServiceDeskName(string id)
        {
            if (null != this.serviceDeskMap && this.serviceDeskMap.ContainsKey(id))
                return this.serviceDeskMap[id].Name;

            return S.EMPTY;
        }
    }
}
