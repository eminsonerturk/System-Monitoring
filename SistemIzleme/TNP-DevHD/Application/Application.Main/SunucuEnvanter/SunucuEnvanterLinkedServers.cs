using Application.Main.Interfaces.SunucuEnvanter;
using Domain.Main.Envanter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Main.SunucuEnvanter
{
    public class SunucuEnvanterLinkedServers : SunucuEnvanterDbAppService<AvServerIliskiliSunucu>, ISunucuEnvanterLinkedServers
    {
        bool eklemeBayragi, returnBayragi = true;
        public SunucuEnvanterLinkedServers(Data.Main.ISunucuEnvanterDbRepository<AvServerIliskiliSunucu> pRep) : base(pRep)
        {
        }

        #region SunucuIliskileri

        public AvServerIliskiliSunucu getServer(long serverID)
        {
            try
            {
                AvServerIliskiliSunucu server = rep.GetFiltered(t => t.ServerID == serverID).FirstOrDefault();
                return server;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<long> SunucununTumIliskileri(long serverID)
        {
            List<AvServerIliskiliSunucu> serverList = rep.GetFiltered(t => t.ParentID == serverID || t.ServerID == serverID).ToList();
            List<long> serverIDList = new List<long>();
            foreach (var item in serverList)
            {
                serverIDList.Add(item.ServerID);
            }
            return serverIDList;


        }


        public void IliskiSil(long _serverID, long _parentID)
        {
            List<AvServerIliskiliSunucu> ServerList;
            ServerList = rep.GetFiltered(t => t.ServerID == _serverID).ToList();
            for (int i = 0; i < ServerList.Count; i++)
            {
                if(ServerList[i].ParentID == _parentID)
                    rep.Remove(ServerList[i]);
            }
            
        }

        




        public void IliskiEkle(long _serverID, long _parentID)
        {

            AvServerIliskiliSunucu newServerConnection = new AvServerIliskiliSunucu()
            {
                ServerID = _serverID,
                ParentID = _parentID

            };

            rep.Add(newServerConnection);

        }


        public List<List<long>> nodeVeIliskileriAl(long serverID, List<long> ChildList, List<long> ParentList, List<long> DolasilmisOlanlar, Stack<long> digerServerIpleri, List<List<long>> ChildveParentveDolasilmisOlanlar)
        {

            List<AvServerIliskiliSunucu> anaServeraBagliServerlar = rep.GetFiltered(t => t.ParentID == serverID || t.ServerID == serverID).ToList();

            DolasilmisOlanlar.Add(serverID);


            for (int i = 0; i < anaServeraBagliServerlar.Count; i++)
            {
                eklemeBayragi = true;
                if (anaServeraBagliServerlar[i].ServerID == serverID)
                {

                    foreach (long IP in DolasilmisOlanlar)
                    {
                        if (IP == anaServeraBagliServerlar[i].ParentID)
                        {
                            eklemeBayragi = false;
                            break;
                        }
                    }

                    if (eklemeBayragi)
                        digerServerIpleri.Push(anaServeraBagliServerlar[i].ParentID);

                }
                else if (anaServeraBagliServerlar[i].ParentID == serverID)
                {
                    foreach (long IP in DolasilmisOlanlar)
                    {
                        if (IP == anaServeraBagliServerlar[i].ServerID)
                        {
                            eklemeBayragi = false;
                            break;
                        }
                    }

                    if (eklemeBayragi)
                        digerServerIpleri.Push(anaServeraBagliServerlar[i].ServerID);
                }

                if (eklemeBayragi)
                {
                    ChildList.Add(anaServeraBagliServerlar[i].ServerID);
                    ParentList.Add(anaServeraBagliServerlar[i].ParentID);
                }
            }

            if (digerServerIpleri.Count != 0)
            {
                nodeVeIliskileriAl(digerServerIpleri.Pop(), ChildList, ParentList, DolasilmisOlanlar, digerServerIpleri, ChildveParentveDolasilmisOlanlar);
            }
            else
            {
                if (returnBayragi)
                {
                    returnBayragi = false;
                    ChildveParentveDolasilmisOlanlar.Add(ChildList);
                    ChildveParentveDolasilmisOlanlar.Add(ParentList);
                    ChildveParentveDolasilmisOlanlar.Add(DolasilmisOlanlar);
                }
                else
                {
                    return ChildveParentveDolasilmisOlanlar;
                }

            }

            if (returnBayragi)
            {
                returnBayragi = false;
                ChildveParentveDolasilmisOlanlar.Add(ChildList);
                ChildveParentveDolasilmisOlanlar.Add(ParentList);
                ChildveParentveDolasilmisOlanlar.Add(DolasilmisOlanlar);
                return ChildveParentveDolasilmisOlanlar;
            }
            else
            {
                return ChildveParentveDolasilmisOlanlar;
            }


        }


        public List<long> GetChilds(long serverID)
        {

            HashSet<long> TotalChilds = new HashSet<long>();
            List<AvServerIliskiliSunucu> Parents = rep.GetFiltered(t => t.ServerID == serverID).ToList();

            for (int i = 0; i < Parents.Count; i++)
            {
                long parentIndex = Parents[i].ParentID;
                List<long> Childs = (from server in rep.Table
                                     where server.ParentID == parentIndex && server.ServerID != 0
                                     select server.ServerID).ToList();

                for (int j = 0; j < Childs.Count; j++)
                {
                    TotalChilds.Add(Childs[j]);
                }
            }
            return TotalChilds.ToList();

        }

        public List<AvServerIliskiliSunucu> tumIliskileriAl()
        {
            List<AvServerIliskiliSunucu> ServerIDList = (from server in rep.Table
                                                         select server).ToList();

            if (ServerIDList.Count > 0)
            {
                return ServerIDList;
            }
            else
            {
                return null;
            }

        }

        public List<AvServerIliskiliSunucu> GetIliskiliServerID(long serverID)
        {
            List<AvServerIliskiliSunucu> ServerIDList = (from server in rep.Table
                                                         where server.ParentID == serverID
                                                         select server).ToList();


            return ServerIDList;
        }

        public bool IliskiDbdeVarMi(long serverID, long parentID)
        {
            List<AvServerIliskiliSunucu> ServerIDList = (from server in rep.Table
                                                         where (server.ParentID == parentID) && (server.ServerID == serverID)
                                                         select server).ToList();

            return ServerIDList.Count > 0;
        }

        public void DeleteServerConnection(long ID)
        {
            List<AvServerIliskiliSunucu> ServerList;
            ServerList = rep.GetFiltered(t => t.ServerID == ID).ToList();
            for (int i = 0; i < ServerList.Count; i++)
            {
                rep.Remove(ServerList[i]);
            }
        }

        
        #endregion
    }
}