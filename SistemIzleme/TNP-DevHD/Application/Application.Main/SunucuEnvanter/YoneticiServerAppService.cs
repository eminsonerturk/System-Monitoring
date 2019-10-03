
using Application.Main.Interfaces.SunucuEnvanter;
using Application.ViewModels.Envanter;
using Data.Main;
using Domain.Main.Envanter;
using System.Collections.Generic;
using System.Linq;


namespace Application.Main.SunucuEnvanter
{
    public class YoneticiServerAppService : SunucuEnvanterDbAppService<AvYoneticiServer>, IYoneticiServerAppService
    {

        #region Constructor

        public YoneticiServerAppService(ISunucuEnvanterDbRepository<AvYoneticiServer> rep)
            : base(rep)
        {}

        #endregion

        #region crud methods

        public void DeleteServerConnection(long Id)
        {
            List<AvYoneticiServer> ServerList;
            ServerList = rep.GetFiltered(t => t.ServerId == Id).ToList();
            for (int i = 0; i < ServerList.Count; i++)
            {
                rep.Remove(ServerList[i]);
            }
        }

        public IEnumerable<YoneticiListViewModel> GetYoneticiServiceParameters(long Id)
        {
            var YoneticiList = (from yServer in rep.Table
                                where yServer.ServerId == Id
                                select new YoneticiListViewModel
                                {
                                    Id = yServer.YoneticiId,
                                    Ad = yServer.Yonetici.Ad,
                                    EMail = yServer.Yonetici.EMail
                                });
            return YoneticiList;
        }

        public bool AddManagerToSpecificServer(AvServer server, AvYonetici yonetici)
        {
            bool eklendi = false;
            var sorgu = (from ys in rep.Table
                         where (ys.YoneticiId == yonetici.Id && ys.ServerId == server.Id)
                         select ys).Count();

            if (sorgu == 0)
            {
                eklendi = true;
                AvYoneticiServer yeniYoneticiServer = new AvYoneticiServer()
                {
                    Server = server,
                    Yonetici = yonetici,
                    ServerId = server.Id,
                    YoneticiId = yonetici.Id
                };
                rep.Add(yeniYoneticiServer);
                return eklendi;
            }
            return eklendi;
        }
        public List<string> GetYoneticiListForSpecificServer(long Id)
        {
            var YoneticiList = (from yoneticiServer in rep.Table
                                where yoneticiServer.ServerId == Id
                                select yoneticiServer.Yonetici.Ad).ToList();
            return YoneticiList;
        }
        public void RemoveYoneticiFromSpecificServer(long Id) 
        {
            List<AvYoneticiServer> YoneticiList = (from yoneticiServer in rep.Table
                                         where yoneticiServer.ServerId == Id
                                         select yoneticiServer).ToList();
            for (int i = 0; i < YoneticiList.Count(); i++)
                rep.Remove(YoneticiList[i]);
        }
        public void RemoveYoneticiFromSpecificServerByYoneticiId(long Id)
        {
            List<AvYoneticiServer> YoneticiList = (from yoneticiServer in rep.Table
                                                   where yoneticiServer.YoneticiId == Id
                                                   select yoneticiServer).ToList();
            for (int i = 0; i < YoneticiList.Count(); i++)
                rep.Remove(YoneticiList[i]);
        }
        public void RemoveYoneticiFromSpecificServer(long Id, string Ad)
        {
            AvYoneticiServer Yonetici = (from yoneticiServer in rep.Table
                                         where (yoneticiServer.ServerId == Id && yoneticiServer.Yonetici.Ad.Equals(Ad))
                                         select yoneticiServer).FirstOrDefault();
            rep.Remove(Yonetici);
        }

        #endregion

    }
}
