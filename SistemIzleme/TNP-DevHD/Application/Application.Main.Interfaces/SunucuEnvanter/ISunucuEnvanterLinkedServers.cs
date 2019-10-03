using Domain.Main.Envanter;
using System.Collections.Generic;

namespace Application.Main.Interfaces.SunucuEnvanter
{
    public interface ISunucuEnvanterLinkedServers : ISunucuEnvanterDbAppService<AvServerIliskiliSunucu>
    {
        List<AvServerIliskiliSunucu> GetIliskiliServerID(long serverID);

        List<List<long>> nodeVeIliskileriAl(long serverID, List<long> ChildList, List<long> ParentList, List<long> DolasilmisOlanlar, Stack<long> digerServerIpleri, List<List<long>> ChildveParentveDolasilmisOlanlar);

        AvServerIliskiliSunucu getServer(long serverID);

        void DeleteServerConnection(long ID);
        void IliskiEkle(long _serverID, long _parentID);

        void IliskiSil(long _serverID, long _parentID);

        List<AvServerIliskiliSunucu> tumIliskileriAl();

        bool IliskiDbdeVarMi(long serverID, long parentID);
    }
}
