using System;
using System.Management;
using System.Net;

namespace Pb.Library
{
    public class IPHelper
    {
        /// <summary>
        /// 切换IP
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="subnetMask">子网掩码</param>
        /// <param name="defaultIPGateway">默认网关</param>
        /// <param name="dnsServerSearchOrder">首选DNS</param>
        /// <param name="dnsServerSpare">备选DNS</param>
        /// <returns></returns>
        public static bool SetIP(string ipAddress, string subnetMask, string defaultIPGateway, string dnsServerSearchOrder, string dnsServerSpare)
        {
            try
            {
                ManagementBaseObject Inpra = null;
                ManagementBaseObject OutPra = null;
                ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection Moc = MC.GetInstances();

                foreach (ManagementObject mo in Moc)
                {
                    if (!(bool)mo["IPEnabled"])
                        continue;

                    Inpra = mo.GetMethodParameters("EnableStatic");
                    Inpra["IPAddress"] = new string[] { string.IsNullOrEmpty(ipAddress) ? null : ipAddress };

                    Inpra["SubnetMask"] = new string[] { string.IsNullOrEmpty(subnetMask) ? null : subnetMask };
                    OutPra = mo.InvokeMethod("EnableStatic", Inpra, null);

                    Inpra = mo.GetMethodParameters("SetGateways");
                    Inpra["DefaultIPGateway"] = new string[] { string.IsNullOrEmpty(defaultIPGateway) ? null : defaultIPGateway };
                    OutPra = mo.InvokeMethod("SetGateways", Inpra, null);

                    Inpra = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    Inpra["DNSServerSearchOrder"] = new string[] { 
                            string.IsNullOrEmpty(dnsServerSearchOrder)?null:dnsServerSearchOrder,
                            string.IsNullOrEmpty(dnsServerSpare)?null:dnsServerSpare
                        };
                    OutPra = mo.InvokeMethod("SetDNSServerSearchOrder", Inpra, null);
                    break;
                }

                IPHostEntry oIPHost = Dns.GetHostEntry(Environment.MachineName);
                if (oIPHost.AddressList.Length > 0)
                    return true;
            }
            catch
            {
                throw;
            }
            return false;
        }

        /// <summary>
        /// 自动获取IP和DNS
        /// </summary>
        /// <returns></returns>
        public static bool SetAutoIP()
        {
            try
            {
                string carName = string.Empty;
                ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_NetWorkAdapterConfiguration");
                foreach (ManagementObject sear in search.Get())
                {
                    if (sear["IPAddress"] != null)
                    {
                        carName = sear["Description"].ToString().Trim();
                        break;
                    }
                }

                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        if (mo["Description"].ToString() == carName)
                        {
                            //重置DNS为空   
                            mo.InvokeMethod("SetDNSServerSearchOrder", null);
                            //开启DHCP   
                            mo.InvokeMethod("EnableDHCP", null);
                            break;
                        }
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
