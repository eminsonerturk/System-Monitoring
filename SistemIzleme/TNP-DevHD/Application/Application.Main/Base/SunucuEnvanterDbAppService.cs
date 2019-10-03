using Application.Main.Interfaces;
using Data.Main;
using Rota2.AppCore;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    public class SunucuEnvanterDbAppService<TEntity> : AppService<TEntity>, ISunucuEnvanterDbAppService<TEntity>
          where TEntity : REntity
    {
        public SunucuEnvanterDbAppService(ISunucuEnvanterDbRepository<TEntity> pRep)
            : base(pRep)
        {
        }
    }
}

