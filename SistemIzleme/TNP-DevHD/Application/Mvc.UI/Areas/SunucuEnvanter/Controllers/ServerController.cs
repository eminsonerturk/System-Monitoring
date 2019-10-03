using Application.Main.Interfaces.SunucuEnvanter;
using Application.ViewModels.Envanter;
using Domain.Main.Envanter;
using Kendo.Mvc.Extensions;
//using Kendo.Mvc;
using Kendo.Mvc.UI;
using Mvc.UI.Areas.SunucuEnvanter.Modals;
using Newtonsoft.Json;
//using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using Rota2.MvcUtils.Mappers;
using Rota2.Objects.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web.Mvc;
using TreeGenerator;

namespace Mvc.UI.Areas.Envanter.Controllers
{
    public struct ServerAppNames                                            //Holds server Information
    {
        public long serverID;
        public List<string> appNames;
    }

    public class ServerController : Crud7Controller<AvServer, ServerCrudViewModel, ServerSearchViewModel, ServerListViewModel, ServerSelectSearchViewModel, ServerSelectListViewModel>
    {
        ServerAppNames[] allServers;
        HashSet<long> ServerList = new HashSet<long>();
        List<long> ServerDenemeList = new List<long>();
        HashSet<AvServerIliskiliSunucu> IliskiliSunucuList = new HashSet<AvServerIliskiliSunucu>();
        int silmeSayaciChild = 0, silmeSayaciParent = 0;
        

        #region constructor

        Application.Main.Interfaces.SunucuEnvanter.ISunucuEnvanterServerAppService _service;
        IServerTipiAppService _serverTipiAppService;
        ILokasyonAppService _lokasyonAppService;
        IOperatingSystemAppService _operatingSystemAppService;
        IYoneticiServerAppService _yoneticiServerService;
        ISunucuEnvanterLinkedServers _linkedService;
        ISunucuEnvanterAppService _appService;

        public ServerController(Application.Main.Interfaces.SunucuEnvanter.ISunucuEnvanterServerAppService srv,
            IMapper<AvServer, ServerCrudViewModel> crudMapper, IMapper<AvServer, ServerListViewModel> listMapper, IMapper<AvServer, ServerSelectListViewModel> selectListMapper,
            IServerTipiAppService service1, ILokasyonAppService service2, IOperatingSystemAppService service3, IYoneticiServerAppService service4, ISunucuEnvanterLinkedServers service5,
            ISunucuEnvanterAppService service6)
            : base(srv, crudMapper, listMapper, selectListMapper)
        {
            _service = srv;
            _serverTipiAppService = service1;
            _lokasyonAppService = service2;
            _operatingSystemAppService = service3;
            _yoneticiServerService = service4;
            _linkedService = service5;
            _appService = service6;
            CrudOnIndex = true;
            AutoFilter = true;
        }

        #endregion

        public ActionResult tumIliskileriAl()
        {
            List<AvServerIliskiliSunucu> serverIliskileri = _linkedService.tumIliskileriAl();
            List<AvServer> serverList = _service.tumServerlariCek();

            List<ServerIliski> parentVeChildIcinTabloDegerleri = new List<ServerIliski>();

            AvServer sonDeger = serverList.Last();

            foreach (var iliski in serverIliskileri)
            {
                int i = 0;
                ServerIliski eklenecekIliski = new ServerIliski();
                foreach (var server in serverList)
                {
                    if(iliski.ParentID == server.Id)
                    {
                        eklenecekIliski.parentIp = server.ServerIp;
                        eklenecekIliski.parentName = server.ComputerName;
                        i++;
                    }
                    else if(iliski.ServerID == server.Id)
                    {
                        eklenecekIliski.childIp = server.ServerIp;
                        eklenecekIliski.childName = server.ComputerName;
                        i++;
                    }else if (i == 2)
                    {
                        parentVeChildIcinTabloDegerleri.Add(eklenecekIliski);
                        break;
                    }else if (server.Equals(sonDeger))
                    {
                        parentVeChildIcinTabloDegerleri.Add(eklenecekIliski);
                    }
                }
            }

            return Json(new { parentVeChildIcinTabloDegerleri }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult iliskiliServerlariListele(long Id)
        {

            List<Server> serverIpleriveIsimleri = new List<Server>();
            List<List<long>> childVeParentlar = new List<List<long>>();

            //Child list bu listenin 0. elemanı, parent list bu listenin 1. elemanı ve totalde dolaşılan tüm nodelar ise bu listenin 3. elemanında tutulmaktadır.
            List<List<string>> childVeParentVeNodelar = new List<List<string>>();

            //İlk gelen liste child serverlar, ikinci gelen liste parent serverları, üçüncü gelen liste ise dolaşılan tüm server id lerini tutmaktadır..

            childVeParentlar = _linkedService.nodeVeIliskileriAl(Id, new List<long>(), new List<long>(), new List<long>(), new Stack<long>(), new List<List<long>>());
            List<AvServer> serverList = _service.tumServerlariCek();
            
            //Child idleri bulunan serverların server ipleri çekilmekte..
            if (childVeParentlar[0].Any())
            {
                List<string> childServerIpleri = new List<string>();

                foreach (long childId in childVeParentlar[0])
                {
                    var childServer = serverList.FirstOrDefault(x => x.Id == childId);

                    if (childServer != null)
                    {
                        childServerIpleri.Add(serverList.Find(x => x.Id == childId).ServerIp);
                    }
                    else
                    {
                        childServerIpleri.Add(null);
                    }

                }

                childVeParentVeNodelar.Add(childServerIpleri);

            }
            else
            {
                childVeParentVeNodelar.Add(null);
            }

            //ParentId leri bulunan serverların server ipleri çekilmekte.. Ayrıca child ve parent listelerde null olan değerlerin silinmesi işlemi karşılıklı olarak gerçekleşmektedir..
            if (childVeParentlar[1].Any())
            {
                List<string> parentServerIpleri = new List<string>();

                foreach (long parentId in childVeParentlar[1])
                {
                    var parentServer = serverList.FirstOrDefault(x => x.Id == parentId);

                    if (parentServer != null)
                    {
                        parentServerIpleri.Add(serverList.Find(x => x.Id == parentId).ServerIp);
                    }
                    else
                    {
                        parentServerIpleri.Add(null);
                    }


                }


                //Child ve parentlarda null olan değerlerin index no'ları alınıyor ve her iki listede de karşılıklı index noları null olanlar siliniyor..
                var childServerlardaNullOlanlar = childVeParentVeNodelar[0].Select((item, i) => new { index = i, item = item }).Where(p => p.item == null).Select(item => item.index);


                //Burada sayaç tutulmasının sebebi 2 ayrı listeden aynı şekilde elemanların silinmesini sağlamak içindir. Child listte bir eleman silinirde o
                //değer parent listte, parent listte bir eleman silinirse o değer aynı zamanda da child listten silinmek zorundadır.
                silmeSayaciChild = 0;

                foreach (var item in childServerlardaNullOlanlar)
                {
                    parentServerIpleri.RemoveAt(item - silmeSayaciChild);
                    silmeSayaciChild++;
                }

                var parentServerlardaNullOlanlar = parentServerIpleri.Select((item, i) => new { index = i, item = item }).Where(p => p.item == null).Select(item => item.index);

                silmeSayaciParent = 0;
                foreach (var item in parentServerlardaNullOlanlar)
                {
                    childVeParentVeNodelar[0].RemoveAt(item - silmeSayaciParent);
                    silmeSayaciParent++;
                }


                childVeParentVeNodelar.Add(parentServerIpleri);


                childVeParentVeNodelar[0].RemoveAll(item => item == null);
                childVeParentVeNodelar[1].RemoveAll(item => item == null);
            }
            else
            {
                childVeParentVeNodelar.Add(null);
            }

            //Nodelardan duble olanları siliniyor ve serverIpleri çekilerek yeni listede düzenleniyor..
            if (childVeParentlar[2].Any())
            {
                List<string> NodeIpleri = new List<string>();
                List<string> NodeIsimleri = new List<string>();
                List<string> NodeAciklamalari = new List<string>();
                childVeParentlar[2] = childVeParentlar[2].Distinct().ToList();

                foreach (long nodeId in childVeParentlar[2])
                {
                    var nodeServer = serverList.FirstOrDefault(x => x.Id == nodeId);

                    if (nodeServer != null)
                    {
                        NodeIpleri.Add(serverList.Find(x => x.Id == nodeId).ServerIp);
                        NodeIsimleri.Add(serverList.Find(x => x.Id == nodeId).ComputerName);
                        NodeAciklamalari.Add(serverList.Find(x => x.Id == nodeId).Aciklama);
                    }
                }

                NodeIpleri.RemoveAll(item => item == null);
                NodeIsimleri.RemoveAll(item => item == null);
                childVeParentVeNodelar.Add(NodeIpleri);
                childVeParentVeNodelar.Add(NodeIsimleri);
                childVeParentVeNodelar.Add(NodeAciklamalari);

            }


            childVeParentlar.Clear();
            System.GC.Collect();


            //Düzenlenmiş ve temizlenmiş node iplerine ping atılması işlemi yapılmaktadır ve çıkan sonuçlar listede depolanmaktadır..
            List<string> pingSonuclari = new List<string>();
            

            for (int i = 0; i < childVeParentVeNodelar[2].Count; i++)
            {
                string sonuc = Ping(childVeParentVeNodelar[2].ElementAt(i));

                if (sonuc.Contains("Success"))
                {
                    pingSonuclari.Add("true");
                }
                else
                {
                    pingSonuclari.Add("false");
                }
            }

            //Grid yapısında bilgisayar özellik ve değerlerini listelemek için özel bir class oluşturuldu. Server class'ı 
            //Bir bilgisayarın bilgisayar adı ve server ip'si bilgilerini tutmaktadır. 
            for (int i = 0; i < childVeParentVeNodelar[2].Count; i++)
            {
                Server eklenecekServer = new Server();
                eklenecekServer.ComputerName = childVeParentVeNodelar[3].ElementAt(i);
                eklenecekServer.serverIp = childVeParentVeNodelar[2].ElementAt(i);
                serverIpleriveIsimleri.Add(eklenecekServer);
            }
            

            return Json(new { serverIpleriveIsimleri, pingSonuclari, childList = childVeParentVeNodelar[0], parentList = childVeParentVeNodelar[1], nodeList = childVeParentVeNodelar[2],nodeisimList=childVeParentVeNodelar[3],nodeAciklamaList=childVeParentVeNodelar[4] }, JsonRequestBehavior.AllowGet);


        }


        public void GetIliskiliServerID(long Id)
        {
            List<AvServerIliskiliSunucu> tempServerList = new List<AvServerIliskiliSunucu>();



            tempServerList.Add(null);
            IliskiliSunucuList.Add(_linkedService.getServer(Id));
            while (tempServerList.Count != 0)
            {
                tempServerList = new List<AvServerIliskiliSunucu>();

                tempServerList.AddRange(_linkedService.GetIliskiliServerID(Id));

                IliskiliSunucuList.AddRange(tempServerList);
                ServerList.Add(Id);
                ServerDenemeList.Add(Id);
                for (int i = 0; i < tempServerList.Count; i++)
                {
                    GetIliskiliServerID(tempServerList[i].ServerID);
                }
                tempServerList = new List<AvServerIliskiliSunucu>();
            }
        }
        
        public void refreshServerInfo()
        {
            List<string> serverIPList = new List<string>();
            serverIPList = _service.GetServerIPs();
            allServers = new ServerAppNames[serverIPList.Count];

            for (int i = 0; i < serverIPList.Count; i++)
            {
                string pingResult = Ping(serverIPList[i]);
                List<string> AppName = new List<string>();
                if (pingResult == "Success")
                {
                    long serverID = _service.GetServerIDFromIP(serverIPList[i]);
                    AppName = _service.GetSiteName(serverID);
                    allServers[i].appNames = AppName;
                    allServers[i].serverID = serverID;
                    _appService.DeleteServerApp(serverID);
                }
                else
                {
                    long serverID = _service.GetServerIDFromIP(serverIPList[i]);
                    AppName = _appService.GetAppName(serverID);
                    allServers[i].appNames = AppName;
                    allServers[i].serverID = serverID;
                    _appService.DeleteServerApp(serverID);
                }
            }

            for (int i = 0; i < allServers.Count(); i++)
            {
                _appService.AddServerApp(allServers[i].serverID, allServers[i].appNames);
            }
        }

        public static string Ping(string targetIP)                                      //Used to check if Server is down
        {
            try
            {
                Ping p1 = new Ping();
                PingReply PR = p1.Send(targetIP);
                if (PR.Status.ToString().Equals("Success"))
                {
                    return ("Success");
                }
                else
                {
                    return ("Not Succeeded");
                }
            }
            catch (Exception ex)
            {
                return ("Ping Process Failed" + ex.Message);
            }
        }

        public ActionResult getAppName(string ServerIP)
        {
            long serverID = _service.GetServerIDFromIP(ServerIP);

            List<string> AppName = new List<string>();
            AppName = _appService.GetAppName(serverID);
            return Json(new { AppName = AppName }, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult getIISSiteNames(long Id)
        {
            List<string> SitesList = new List<string>();
            SitesList = _service.GetSiteName(Id);
            SitesList.Sort();
            return Json(new { SitesList = SitesList }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getIISSiteNamesFromIP(string ServerIp)
        {
            long serverID = _service.GetServerIDFromIP(ServerIp);
            List<string> SitesList = new List<string>();
            SitesList = _service.GetSiteName(serverID);
            SitesList.Sort();
            return Json(new { SitesList = SitesList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getIISBindings(string machineName)
        {
            List<string> IISBindings;
            IISBindings = _service.GetIISBindingInfo(machineName);
            IISBindings.Sort();
            return Json(new { IISBindings = IISBindings }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getInstalledApplications(long Id)
        {
            List<string> AppList = new List<string>();
            AppList = _service.GetInstalledApplications(Id);
            AppList.Sort();
            return Json(new { AppList = AppList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getServerInfo(long Id)
        {
            List<string> ServerInfoList = new List<string>();
            List<string> ServerCPUInfoList = new List<string>();
            List<string> ServerDiskInfoList = new List<string>();
            List<string> ServerMemoryInfoList = new List<string>();
            ServerInfoList = _service.GetServerInfo(Id);
            for (int i = 0; i < ServerInfoList.Count; i++)
            {
                if (ServerInfoList[i] == "----------------Disk Usage-----------------")
                {
                    i++;
                    while (ServerInfoList[i] != "----------------CPU Usage------------------")
                    {
                        ServerDiskInfoList.Add(ServerInfoList[i]);
                        i++;
                    }
                    i--;
                }
                else if (ServerInfoList[i] == "----------------CPU Usage------------------")
                {
                    i++;
                    while (ServerInfoList[i] != "----------------Memory Usage---------------")
                    {
                        ServerCPUInfoList.Add(ServerInfoList[i]);
                        i++;
                    }
                    i--;
                }
                else if (ServerInfoList[i] == "----------------Memory Usage---------------")
                {
                    i++;
                    while (i != ServerInfoList.Count)
                    {
                        ServerMemoryInfoList.Add(ServerInfoList[i]);
                        i++;
                    }
                    i--;
                }
            }
            if (ServerDiskInfoList.Count == 0)
            {
                ServerDiskInfoList = ServerInfoList;
            }
            return Json(new { ServerDiskInfoList = ServerDiskInfoList, ServerCPUInfoList = ServerCPUInfoList, ServerMemoryInfoList = ServerMemoryInfoList }, JsonRequestBehavior.AllowGet);

        }

        #region manuel map mathods
        protected override AvServer DoEntityMapBeforeCreate(Application.ViewModels.Envanter.ServerCrudViewModel saveModel)
        {
            AvServer Server = new AvServer();

            Server.ServerIp = saveModel.ServerIp;
            Server.ComputerName = saveModel.ComputerName;
            Server.Aciklama = saveModel.Aciklama;
            Server.LokasyonId = saveModel.LokasyonId;
            Server.ServerTipiId = saveModel.ServerTipiId;
            Server.OperatingSystemId = saveModel.OperatingSystemId;
            Server.PingYapilsinMi = saveModel.PingYapilsinMi;

            return Server;
        }

        protected override System.Collections.Generic.IEnumerable<Application.ViewModels.Envanter.ServerListViewModel>

        DoReadDataMapForListMapper(System.Collections.Generic.IEnumerable<AvServer> list)
        {
            List<ServerListViewModel> viewModelList = new List<ServerListViewModel>();
            int x = list.Count();
            foreach (var item in list)
            {
                ServerListViewModel viewModel = new ServerListViewModel();

                viewModel.Id = item.Id;
                viewModel.ServerIp = item.ServerIp;
                viewModel.Aciklama = item.Aciklama;
                viewModel.ComputerName = item.ComputerName;


                viewModel.LokasyonAd = item.Lokasyon.Ad;
                viewModel.ServerTipiAd = item.ServerTipi.Ad;
                viewModel.OperatingSystemAd = item.OperatingSystem.Ad;
                viewModel.PingYapilsinMi = item.PingYapilsinMi;
                viewModelList.Add(viewModel);

            }

            return viewModelList;
        }

        protected override JsonResult GetGridData(ServerSearchViewModel searchModel)
        {
            return base.GetGridData(searchModel);
        }
        #endregion

        #region crud methods

        public ActionResult AddServer(string lokasyon, string serverTipi, string operatingSystem, string serverIp,
                    string computerName, string aciklama)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageCreateServer);

            List<string> IPList = _service.GetServerIPs();
            foreach (var item in IPList)
            {
                if (item == serverIp)
                    return null;
            }


            var lokasyonId = _lokasyonAppService.GetLocationId(lokasyon);
            var serverTipiId = _serverTipiAppService.GetServerTypeId(serverTipi);
            var operatingSystemId = _operatingSystemAppService.GetOperatingSystemId(operatingSystem);

            string Session_EMail = Session["EMail"].ToString();

            try
            {
                _service.AddServer(lokasyonId, serverTipiId, operatingSystemId,
                serverIp, computerName, aciklama, Session_EMail);
            }
            catch (Exception e)
            {
                e.ToString();
            }


            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }

        //Mesaj gönderimini iptal etmek için
        public ActionResult UpdatePing(long Id)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.UpdatePing);
            _service.UpdatePing(Id);


            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }

        public ActionResult IliskiSil(string serverIp, string parentIp)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };

            long serverID = _service.GetServerIDFromIP(serverIp);
            long parentID = _service.GetServerIDFromIP(parentIp);



            if ((serverID != 0) && (parentID != 0) && (serverID != parentID))
            {
                if (_linkedService.IliskiDbdeVarMi(serverID, parentID))
                {
                    sJRS.SuccessMessages = new List<string>();
                    sJRS.SuccessMessages.Add("Silme işlemi başarılı bir şekilde yapılmıştır..");
                    _linkedService.IliskiSil(serverID, parentID);
                }
                else
                {
                    sJRS.WarningMessages = new List<string>();
                    sJRS.WarningMessages.Add("Bu ilişki veritabanında bulunmamaktadır..");
                    sJRS.Statu = "fail";
                }
            }
            else if (serverID == 0 || parentID == 0)
            {
                sJRS.WarningMessages = new List<string>();
                sJRS.WarningMessages.Add("Değerler veritabanında bulunamadı. Lütfen değerlerinizi tekrar kontrol ediniz.");
                sJRS.Statu = "fail";
            }
            else if (serverID == parentID)
            {
                sJRS.WarningMessages = new List<string>();
                sJRS.WarningMessages.Add("Aynı değerler arasında ilişki bulunamaz..");
                sJRS.Statu = "fail";
            }
            else
            {
                sJRS.WarningMessages = new List<string>();
                sJRS.WarningMessages.Add("Silme işlemi gerçekleştirilemedi.. Lütfen değerlerini kontrol ederek tekrar deneyiniz..");
                sJRS.Statu = "fail";

            }

            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }


        public ActionResult IliskiEkle(string serverIp,string parentIp)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            
            long serverID=_service.GetServerIDFromIP(serverIp);
            long parentID = _service.GetServerIDFromIP(parentIp);



            if((serverID != 0) && (parentID != 0) && (serverID != parentID))
            {
                if( _linkedService.IliskiDbdeVarMi(serverID, parentID))
                {
                    sJRS.WarningMessages = new List<string>();
                    sJRS.WarningMessages.Add("İlişki zaten veritabanında kayıtlıdır.");
                    sJRS.Statu = "fail";
                }
                else
                {
                    sJRS.SuccessMessages = new List<string>();
                    sJRS.SuccessMessages.Add(Application.Resources.Control.AddRelationServer);
                    _linkedService.IliskiEkle(serverID, parentID);
                }
            }else if (serverID==0 || parentID==0)
            {
                sJRS.WarningMessages = new List<string>();
                sJRS.WarningMessages.Add("Değerler veritabanında bulunamadı. Lütfen değerlerinizi tekrar kontrol ediniz.");
                sJRS.Statu = "fail";
            }
            else if(serverID == parentID)
            {
                sJRS.WarningMessages = new List<string>();
                sJRS.WarningMessages.Add("Aynı değerler arasında ilişki bulunamaz..");
                sJRS.Statu = "fail";
            }
            else
            {
                sJRS.WarningMessages = new List<string>();
                sJRS.WarningMessages.Add("Belirtilen ilişkiler eklenemedi. Lütfen değerlerinizi tekrar kontrol ediniz.");
                sJRS.Statu = "fail";

            }
            
            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }

        //Tüm serverların çekilme işlemi yapılacak..
        public JsonResult serverlariListele()
        {
             
            List<AvServer> ipS = _service.tumServerlariCek();

            List<Server> serverlar = new List<Server>();

            foreach (var item in ipS)
            {
                Server server = new Server();

                server.ComputerName = item.ComputerName;
                server.serverIp = item.ServerIp;

                serverlar.Add(server);
            }
            
            return this.Json(new { serverlar }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteServer(long Id)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageDeleteServer);

            _yoneticiServerService.DeleteServerConnection(Id);          //delete servers connection with Yonetici table
            _linkedService.DeleteServerConnection(Id);                  //delete servers connection with SERVER_ILISKILI_SUNUCU table
            _appService.DeleteServerApp(Id);                            //delete servers connection with SERVER_UYGULAMALAR table
            _service.DeleteServer(Id);                                  //delete server from database

            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }

        protected override Domain.Main.Envanter.AvServer DoEntityMapBeforeUpdate(Application.ViewModels.Envanter.ServerCrudViewModel saveModel)
        {
            AvServer server = new AvServer();
            server.Id = (long)saveModel.Id;
            server.Aciklama = saveModel.Aciklama;
            server.ComputerName = saveModel.ComputerName;
            server.LokasyonId = saveModel.LokasyonId;
            server.OperatingSystemId = saveModel.OperatingSystemId;
            server.PingYapilsinMi = saveModel.PingYapilsinMi;
            server.ServerIp = saveModel.ServerIp;
            server.ServerTipiId = saveModel.ServerTipiId;
            return server;
        }

        protected override void PrepareViewModelBeforeSearch(DataSourceRequest request, ServerSearchViewModel model)
        {
            model.Aciklama = String.IsNullOrEmpty(model.Aciklama) ? model.Aciklama : model.Aciklama.Replace("ı", "i");
        }

        #endregion

        #region decimal parser

        public static string ConvertToDecimalPointFormatFromCommaFormat(string DecimalValue)
        {
            string CorrectFormattedValue = "";

            for (int i = 0; i < DecimalValue.Count(); i++)
            {
                if (DecimalValue[i] == ',')
                    CorrectFormattedValue += '.';
                else
                    CorrectFormattedValue += DecimalValue[i];
            }

            return CorrectFormattedValue;
        }

        #endregion

    }
}