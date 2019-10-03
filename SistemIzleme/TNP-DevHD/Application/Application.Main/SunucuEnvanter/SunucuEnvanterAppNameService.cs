using Application.Main.Interfaces.SunucuEnvanter;
using Domain.Main.Envanter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Application.Main.SunucuEnvanter
{
    public class SunucuEnvanterAppNameService : SunucuEnvanterDbAppService<AvServerUygulamalar>, ISunucuEnvanterAppService
    {
        public SunucuEnvanterAppNameService(Data.Main.ISunucuEnvanterDbRepository<AvServerUygulamalar> pRep) : base(pRep)
        {
        }

        #region Crud methods

        public List<string> GetAppName(long Id)
        {
            List<string> AppNameList = new List<string>();
            AppNameList = (from server in rep.Table
                           where server.ServerID == Id
                           select server.ApplicationName).ToList();
            return AppNameList;
        }

        public void DeleteServerApp(long Id)
        {
            List<AvServerUygulamalar> ServerList;
            ServerList = rep.GetFiltered(t => t.ServerID == Id).ToList();
            for (int i = 0; i < ServerList.Count; i++)
            {
                rep.Remove(ServerList[i]);
            }
        }

        public void AddServerApp(long Id, List<string> appNames)
        {
            for (int i = 0; i < appNames.Count; i++)
            {
                if (!appNames[i].Contains("Access is denied") && !appNames[i].Contains("RPC server"))
                {
                    AvServerUygulamalar newServerApp = new AvServerUygulamalar()
                    {
                        ServerID = Id,
                        ApplicationName = appNames[i]
                    };
                    rep.Add(newServerApp);
                }
            }
        }
        #endregion Crud methods
    }
}