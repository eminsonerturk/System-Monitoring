using Domain.Main;
using Domain.Main.Envanter;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces.SunucuEnvanter
{
    public interface ISunucuEnvanterServerAppService : ISunucuEnvanterDbAppService<AvServer>
    {
        void AddServer(long lokasyonId, long serverTipiId, long operatingSystemId, string serverIp, string computerName,
           string aciklama, string Session_EMail);
        AvServer GetServer(long Id);
        List<string> GetServerIPs();
        void DeleteServer(long Id);
        void UpdatePing(long Id);
        List<string> GetSiteName(long Id);
        List<string> GetInstalledApplications(long Id);
        List<string> GetServerInfo(long Id);
        List<string> GetIISBindingInfo(string machineName);
        List<string> GetLinkedServerName(List<AvServerIliskiliSunucu> serverID);
        long GetServerIDFromIP(string serverIP);
        string GetServerIPFromID(long id);
        List<AvServer> tumServerlariCek();
    }
}