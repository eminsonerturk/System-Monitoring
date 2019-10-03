using Application.Main.Interfaces;
using Data.Main;
using Domain.Main.Models;
using Rota2.AppCore;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    public class ReportDbAppService<TEntity> : AppService<TEntity>, IReportDbAppService<TEntity>
          where TEntity : REntity
    {
        public ReportDbAppService(IReportDbRepository<TEntity> pRep)
            : base(pRep)
        {
        }
        public void UseReportServer()
        {
            //configten oku degeri bas
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["ReportServerDbConnection"];
            ((IReportDbRepository<ReportServer>)rep).ChangeConnection(connectionInfo);
        }
        public void UseReportServerHD()
        {
            //configten oku degeri bas
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["ReportServerHDDbConnection"];
            ((IReportDbRepository<ReportServer>)rep).ChangeConnection(connectionInfo);
        }
        public void UseReportServerMTST()
        {
            //configten oku degeri bas
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["ReportServerMTSTDbConnection"];
            ((IReportDbRepository<ReportServer>)rep).ChangeConnection(connectionInfo);
        }
        public void UseReportServerMTGC()
        {
            //configten oku degeri bas
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["ReportServerMTGCDbConnection"];
            ((IReportDbRepository<ReportServer>)rep).ChangeConnection(connectionInfo);
        }
        public void UseReportServerOTTS()
        {
            //configten oku degeri bas
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["ReportServerOTODbConnection"];
            ((IReportDbRepository<ReportServer>)rep).ChangeConnection(connectionInfo);
        }
        public void UseReportServerBox()
        {
            //configten oku degeri bas
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["ReportServerBoxDbConnection"];
            ((IReportDbRepository<ReportServer>)rep).ChangeConnection(connectionInfo);
        }
    }
}

