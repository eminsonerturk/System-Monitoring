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
    public class IslemDbAppService<TEntity> : AppService<TEntity>, IIslemDbAppService<TEntity>
          where TEntity : REntity
    {
        public IslemDbAppService(IIslemDbRepository<TEntity> pRep)
            : base(pRep)
        {
        }

        public void UseYnaLogServer()
        {
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["YnaLogDbConnectionString"];
            ((IIslemDbRepository<IslemLog>)rep).ChangeConnection(connectionInfo);
        }

        public void UseYnaLogTestServer()
        {
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["YnaLogTestDbConnectionString"];
            ((IIslemDbRepository<IslemLog>)rep).ChangeConnection(connectionInfo);
        }

        public void UseYnaLogTest2Server()
        {
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["YnaLogTest2DbConnectionString"];
            ((IIslemDbRepository<IslemLog>)rep).ChangeConnection(connectionInfo);
        }

        public void UseYnaLogTest3Server()
        {
            string connectionInfo = System.Configuration.ConfigurationManager.AppSettings["YnaLogTest3DbConnectionString"];
            ((IIslemDbRepository<IslemLog>)rep).ChangeConnection(connectionInfo);
        }
    }
}

