using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace funsens.mis
{
    /// <summary>  
    /// USB主控制器信息  
    /// </summary>  
    public struct HostControllerInfo
    {
        public String PNPDeviceID;      // 设备ID  
        public String Name;             // 设备名称  
    }

    class MisUSB
    {
        public MisUSB()
        {
        }

        public List<HostControllerInfo> getAllHostControllers()
        {
            List<HostControllerInfo> HostControllers = new List<HostControllerInfo>();

            // 获取USB控制器及其相关联的设备实体  
            ManagementObjectCollection MOC = new ManagementObjectSearcher("SELECT * FROM Win32_USBController").Get();
            if (MOC != null)
            {
                foreach (ManagementObject MO in MOC)
                {
                    HostControllerInfo Element;
                    Element.PNPDeviceID = MO["PNPDeviceID"] as String;  // 设备ID  
                    Element.Name = MO["Name"] as String;    // 设备描述  

                    HostControllers.Add(Element);

                    Console.WriteLine(HostControllers.Count + "=====" + Element.PNPDeviceID + "   " + Element.Name);
                }
            }

            return HostControllers;
        }
    }
}
