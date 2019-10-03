using Application.Main.Interfaces.SunucuEnvanter;
using Data.Main;
using Domain.Main.Envanter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Xml;

namespace Application.Main.SunucuEnvanter
{
    public class SunucuEnvanterServerAppService : SunucuEnvanterDbAppService<AvServer>, ISunucuEnvanterServerAppService
    {

        #region Constructor
        public SunucuEnvanterServerAppService(ISunucuEnvanterDbRepository<AvServer> rep)
            : base(rep)
        {
        }
        #endregion

        #region crud methods

        public static List<string> IISBindingInfoList = new List<string>();

        public long GetServerIDFromIP(string serverIP)
        {
            long serverID = (from server in rep.Table
                             where server.ServerIp == serverIP
                             select server.Id).FirstOrDefault();

            return serverID;
        }

        public string GetServerIPFromID(long id)
        {
            string serverIP = (from server in rep.Table
                               where server.Id == id
                               select server.ServerIp).FirstOrDefault();

            return serverIP;
        }

        public List<AvServer> tumServerlariCek()
        {
            List<AvServer> ServerList = (from server in rep.Table select server).ToList();

            return ServerList;
        }


        public List<string> GetServerIPs()
        {
            var serverIPList = (from server in rep.Table
                                select server.ServerIp).ToList();
            return serverIPList;
        }

        public List<string> GetIISBindingInfo(string machineName)
        {
            string protocol = "", binding = "";
            List<string> IISBindings = new List<string>();
            for (int i = 0; i < IISBindingInfoList.Count; i++)
            {
                if (IISBindingInfoList[i] == machineName)
                {
                    protocol = IISBindingInfoList[i + 1];
                    binding = IISBindingInfoList[i + 2];
                    IISBindings.Add(protocol + binding);
                }
            }
            return IISBindings;
        }

        public void AddServer(long lokasyonId, long serverTipiId, long operatingSystemId, string serverIp, string computerName,
            string aciklama, string Session_EMail)
        {
            AvServer newServer = new AvServer()
            {
                LokasyonId = lokasyonId,
                ServerTipiId = serverTipiId,
                OperatingSystemId = operatingSystemId,
                ServerIp = serverIp,
                ComputerName = computerName,
                Aciklama = aciklama,
                PingYapilsinMi = false
            };

            rep.Add(newServer);
            string textFormat = CreateTextFormatForServerFile(serverIp, computerName);
            SendMail(newServer.ServerIp, Session_EMail);
        }

        public AvServer GetServer(long Id)
        {
            AvServer _Server = (from server in rep.Table
                                where server.Id == Id
                                select server).FirstOrDefault();
            return _Server;
        }

        public void DeleteServer(long Id)
        {
            AvServer server = rep.Get(Id);
            rep.Remove(server);
        }

        public void UpdatePing(long Id)
        {
            AvServer server = rep.Get(Id);
            if (server.PingYapilsinMi == false)
            {
                server.PingYapilsinMi = true;
            }
            else server.PingYapilsinMi = false;
            rep.Modify(server);
        }

        public static List<string> MemoryInformation(string strNameSpace, ConnectionOptions Conn, string targetIP)
        {
            List<string> MemoryInfo = new List<string>();
            MemoryInfo.Add("----------------Memory Usage---------------");

            ManagementScope oMs;
            string IPAddress = GetLocalIPAddress();

            if (targetIP == IPAddress)
            {
                oMs = new ManagementScope(strNameSpace);
            }
            else
            {
                oMs = new ManagementScope(strNameSpace, Conn);
            }

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(oMs, wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                MemoryInfo.Add("Total Visible Memory: " + (Convert.ToDouble(result["TotalVisibleMemorySize"]) / (1024 * 1024)).ToString("#.##") + " GB");
                MemoryInfo.Add("Free Physical Memory: " + (Convert.ToDouble(result["FreePhysicalMemory"]) / (1024 * 1024)).ToString("#.##") + " GB");
            }
            MemoryInfo.Add("\n");
            return MemoryInfo;
        }

        public static List<string> DiskInformation(string strNameSpace, ConnectionOptions Conn, string targetIP)
        {
            List<string> DiskInfo = new List<string>();
            DiskInfo.Add("----------------Disk Usage-----------------");

            ManagementScope oMs;
            string IPAddress = GetLocalIPAddress();

            if (targetIP == IPAddress)
            {
                oMs = new ManagementScope(strNameSpace);
            }
            else
            {
                oMs = new ManagementScope(strNameSpace, Conn);
            }

            ObjectQuery oQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");    //DriveType 3 includes storage devices, excludes CD-ROM etc
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oReturnCollection = oSearcher.Get();

            double D_Freespace = 0;
            double D_Totalspace = 0;
            foreach (ManagementObject oReturn in oReturnCollection)
            {
                DiskInfo.Add("Name : " + oReturn["Name"].ToString());
                string strFreespace = oReturn["FreeSpace"].ToString();
                DiskInfo.Add((Convert.ToDouble(strFreespace) / (1024 * 1024 * 1024)).ToString("#.##") + " GB Free Space");
                D_Freespace = D_Freespace + System.Convert.ToDouble(strFreespace);
                string strTotalspace = oReturn["Size"].ToString();
                DiskInfo.Add((Convert.ToDouble(strTotalspace) / (1024 * 1024 * 1024)).ToString("#.##") + " GB Total Space");
                D_Totalspace = D_Totalspace + System.Convert.ToDouble(strTotalspace);
            }
            DiskInfo.Add("\n");
            DiskInfo.Add("Computer has " + (D_Freespace / (1024 * 1024 * 1024)).ToString("#.##") + " GB Free Space");
            DiskInfo.Add("Computer has " + (D_Totalspace / (1024 * 1024 * 1024)).ToString("#.##") + " GB Total Space");
            DiskInfo.Add("\n");
            return DiskInfo;
        }

        public static List<string> CPUInformation(string strNameSpace, ConnectionOptions Conn, string targetIP)
        {
            List<string> CPUInfo = new List<string>();
            CPUInfo.Add("----------------CPU Usage------------------");

            ManagementScope oMs;
            string IPAddress = GetLocalIPAddress();

            if (targetIP == IPAddress)
            {
                oMs = new ManagementScope(strNameSpace);
            }
            else
            {
                oMs = new ManagementScope(strNameSpace, Conn);
            }

            ObjectQuery oQuery = new ObjectQuery("select Description,DeviceID,LoadPercentage, Status from Win32_Processor");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);

            foreach (ManagementObject queryObj in oSearcher.Get())
            {
                CPUInfo.Add("Description: " + queryObj["Description"]);
                CPUInfo.Add("DeviceID: " + queryObj["DeviceID"]);
                CPUInfo.Add("LoadPercentage: " + queryObj["LoadPercentage"]);
                CPUInfo.Add("Status: " + queryObj["Status"]);
            }
            CPUInfo.Add("\n");
            return CPUInfo;
        }

        public List<string> GetServerInfo(long Id)
        {
            List<string> serverInfoList = new List<string>();
            try
            {
                AvServer selectedServer = rep.Get(Id);
                string machineName = selectedServer.ServerIp;
                string userName = Cryptography.DecryptedMessage("#İŞJLE|%üD").Trim();   //Getting Secure username
                string password = Cryptography.DecryptedMessage("UgŞJkzMx").Trim();     //Getting Secure password
                ConnectionOptions conn = new ConnectionOptions();
                conn.Username = userName;
                conn.Password = password;
                string strNameSpace = @"\\" + machineName + @"\root\cimv2";

                List<string> DiskInfo = DiskInformation(strNameSpace, conn, machineName);
                List<string> CPUInfo = CPUInformation(strNameSpace, conn, machineName);
                List<string> MemoryInfo = MemoryInformation(strNameSpace, conn, machineName);
                serverInfoList.AddRange(DiskInfo);
                serverInfoList.Add("\n");
                serverInfoList.AddRange(CPUInfo);
                serverInfoList.Add("\n");
                serverInfoList.AddRange(MemoryInfo);
                return serverInfoList;
            }
            catch (Exception ex)
            {
                serverInfoList.Add(ex.Message);
                return serverInfoList;
            }
        }

        public static string GetLocalIPAddress()                                        //Used to compare Local IP address with selected server's IP address
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public List<string> GetInstalledApplications(long Id)
        {
            List<string> AppList = new List<string>();
            try
            {
                AvServer selectedServer = rep.Get(Id);
                string machineName = selectedServer.ServerIp;
                string userName = Cryptography.DecryptedMessage("#İŞJLE|%üD").Trim();   //Getting Secure user name
                string password = Cryptography.DecryptedMessage("UgŞJkzMx").Trim();     //Getting Secure password

                ConnectionOptions conn = new ConnectionOptions();
                conn.Username = userName;
                conn.Password = password;
                ManagementScope scope;
                string IPAddress = GetLocalIPAddress();

                if (machineName == IPAddress)
                {
                    scope = new ManagementScope("\\\\" + machineName + "\\root\\CIMV2");
                }
                else
                {
                    scope = new ManagementScope("\\\\" + machineName + "\\root\\CIMV2", conn);
                }
                scope.Connect();


                string softwareRegLoc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
                ManagementClass registry = new ManagementClass(scope, new ManagementPath("StdRegProv"), null);
                ManagementBaseObject inParams = registry.GetMethodParameters("EnumKey");
                inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                inParams["sSubKeyName"] = softwareRegLoc;

                // Read Registry Key Names 
                ManagementBaseObject outParams = registry.InvokeMethod("EnumKey", inParams, null);
                string[] programGuids = outParams["sNames"] as string[];

                foreach (string subKeyName in programGuids)
                {
                    inParams = registry.GetMethodParameters("GetStringValue");
                    inParams["hDefKey"] = 0x80000002;                           //HKEY_LOCAL_MACHINE
                    inParams["sSubKeyName"] = softwareRegLoc + @"\" + subKeyName;
                    inParams["sValueName"] = "DisplayName";
                    outParams = registry.InvokeMethod("GetStringValue", inParams, null);

                    if (outParams.Properties["sValue"].Value != null)
                    {
                        string softwareName = outParams.Properties["sValue"].Value.ToString();
                        AppList.Add(softwareName.Trim());
                    }
                }
                return AppList;
            }
            catch (Exception ex)
            {
                AppList.Add(ex.Message);
                return AppList;
            }
        }

        public List<string> GetSiteName(long Id)
        {
            List<string> _Sites = new List<string>();
            try
            {
                AvServer selectedServer = rep.Get(Id);
                string Ip = selectedServer.ServerIp;

                string path = "\\\\" + Ip + "\\C$\\Windows\\System32\\inetsrv\\config";
                string userName = Cryptography.DecryptedMessage("#İŞJLE|%üD").Trim();   //Getting Secure user name
                string password = Cryptography.DecryptedMessage("UgŞJkzMx").Trim();     //Getting Secure password

                using (new Impersonation("ARKAS", userName, password))
                {
                    ConnectionOptions options = new ConnectionOptions();

                    options.Username = userName.Trim();
                    options.Password = password.Trim();
                    options.Authority = "ntlmdomain:ARKAS";

                    ManagementScope scope;
                    string IPAddress = GetLocalIPAddress();

                    if (Ip == IPAddress)
                    {
                        scope = new ManagementScope("\\\\" + Ip + "\\root\\cimv2");
                    }
                    else
                    {
                        scope = new ManagementScope("\\\\" + Ip + "\\root\\cimv2", options);
                    }
                    scope.Connect();

                    if (Directory.Exists(path))
                    {
                        XmlTextReader reader = new XmlTextReader(Path.Combine(path, "applicationHost.config")); //XML data on target computer 
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Path.Combine(path, "applicationHost.config"));
                        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                        {
                            if (node.Name == "system.applicationHost")
                            {
                                foreach (XmlNode childNode in node.ChildNodes)
                                {
                                    if (childNode.Name == "sites")
                                    {
                                        _Sites = setSitesAttribute(childNode);
                                    }
                                }
                            }
                        }
                    }
                }
                return _Sites;
            }
            catch (Exception ex)
            {
                _Sites.Add(ex.Message);
                return _Sites;
            }
        }

        public static string nodeToApplicationPool(XmlNode node)                    //Function that returns Application Pool names from sent Nodes
        {
            try
            {
                foreach (XmlNode grandNode in node.ChildNodes)
                {
                    if (grandNode.Attributes.Count != 0)
                    {
                        if (grandNode.Name == "application")
                        {
                            XmlNamedNodeMap attributes2 = grandNode.Attributes;
                            XmlNode applicationPool = attributes2.GetNamedItem("applicationPool");
                            if (applicationPool != null)
                            {
                                return applicationPool.Value;
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public List<string> setSitesAttribute(XmlNode node)
        {
            IISBindingInfoList = new List<string>();
            try
            {
                List<string> _Sites = new List<string>();

                foreach (XmlNode grandNode in node.ChildNodes)
                {
                    string appPoolName = nodeToApplicationPool(grandNode);
                    if (grandNode.Attributes.Count != 0)
                    {
                        XmlNamedNodeMap attributes = grandNode.Attributes;
                        XmlNode siteName = attributes.GetNamedItem("name");

                        if (siteName != null)
                        {
                            _Sites.Add(siteName.InnerText.Trim());
                        }

                        foreach (XmlNode grandGrandNode in grandNode.ChildNodes)
                        {
                            if (grandGrandNode.Name == "bindings")
                            {
                                String protocol = null;
                                String bindingInformation = null;
                                foreach (XmlNode grandGrandGrandNode in grandGrandNode.ChildNodes)
                                {
                                    if (grandGrandGrandNode.Name == "binding")
                                    {//Since there are multiple protocol and binding informaton, they are holded in a string and added to the end of previous value
                                        protocol = setProtocolAttribute(grandGrandGrandNode);
                                        bindingInformation = setBindingInformationAttribute(grandGrandGrandNode) + "\n";
                                        IISBindingInfoList.Add(siteName.InnerText.Trim());
                                        IISBindingInfoList.Add(protocol.Trim());
                                        IISBindingInfoList.Add(bindingInformation.Trim());
                                    }
                                }
                            }
                        }
                    }
                }
                return _Sites;
            }
            catch (Exception ex)
            {
                List<string> _ErrorMessage = new List<string>();
                _ErrorMessage.Add(ex.Message);
                return _ErrorMessage;
            }
        }

        public static string setProtocolAttribute(XmlNode node)
        {
            XmlNamedNodeMap attributes = node.Attributes;
            XmlNode protocol = attributes.GetNamedItem("protocol");
            if (protocol != null)
            {
                return protocol.Value.ToString();
            }
            return null;
        }

        public static string setBindingInformationAttribute(XmlNode node)
        {
            XmlNamedNodeMap attributes3 = node.Attributes;
            XmlNode bindingInformation = attributes3.GetNamedItem("bindingInformation");
            if (bindingInformation != null)
            {
                String newBindingInformation = bindingInformation.Value.ToString().Replace('*', ' ');
                newBindingInformation = newBindingInformation.Replace(':', ' ');
                return newBindingInformation;
            }
            return null;
        }
        #endregion

        public List<string> GetLinkedServerName(List<AvServerIliskiliSunucu> serverID)
        {
            List<string> ServerNames = new List<string>();
            try
            {

                for (int i = 0; i < serverID.Count; i++)
                {
                    string IPAddress = (from server in rep.Table
                                        where server.Id == serverID[i].ServerID
                                        select server.ServerIp).FirstOrDefault();
                    ServerNames.Add(IPAddress);
                }
                return ServerNames;
            }
            catch (Exception e)
            {
                ServerNames.Add(e.Message);
                return ServerNames;
            }
        }

        #region mail operations

        public void SendMail(string ServerIp, string Session_EMail)
        {
            MailMessage message = new MailMessage();
            message.To.Add("Olgac.OCEK@bimar.com.tr");
            message.To.Add("cem.ince@bimar.com.tr");
            message.To.Add("idil.akcali@bimar.com.tr");
            message.Subject = "Yeni Server Kaydı";
            message.From = new MailAddress("noreply@bimar.com.tr");
            message.Body = "Sunucu Envanter sistemine yeni bir server kaydı eklenmiştir:" + ServerIp;
            SmtpClient smtp = new SmtpClient("email.arkas.com");
            smtp.Send(message);
        }

        #endregion

        #region file operations

        private string CreateTextFormatForServerFile(string serverIp, string computerName)
        {
            string blank = "";
            for (int i = 14; i > serverIp.Length; i--)
                blank += " ";
            string fileTextFormat = serverIp + blank + "// " + computerName;
            return fileTextFormat;
        }

        private void AppendTextIntoServerFile(string fileTextFormat)
        {
            StreamWriter file = new StreamWriter("C:/Projects/BIMAR STAJ PROJELERI (BSP)/2014/Kis Donemi/Devreye Alım Uygulamalari/Sunucu Envanter/MVC.UI/Files/sunucular.txt", true);
            file.WriteLine(fileTextFormat);
            file.Close();
        }

        private void DeleteTextFromServerFile(string Ip)
        {
            string line = null;
            string lineToDelete = Ip;
            List<string> records = new List<string>();

            using (StreamReader reader = new StreamReader("C:/Projects/BIMAR STAJ PROJELERI (BSP)/2014/Kis Donemi/Devreye Alım Uygulamalari/Sunucu Envanter/Mvc.UI/Files/sunucular.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line != null && !(line.Contains(Ip)))
                    {
                        records.Add(line);
                        continue;
                    }

                }
            }
            File.WriteAllText("C:/Projects/BIMAR STAJ PROJELERI (BSP)/2014/Kis Donemi/Devreye Alım Uygulamalari/Sunucu Envanter/Mvc.UI/Files/sunucular.txt", String.Empty);
            using (StreamWriter writer = new StreamWriter("C:/Projects/BIMAR STAJ PROJELERI (BSP)/2014/Kis Donemi/Devreye Alım Uygulamalari/Sunucu Envanter/Mvc.UI/Files/sunucular.txt"))
            {
                foreach (var item in records)
                    writer.WriteLine(item);
            }

        }

        #endregion
    }
}