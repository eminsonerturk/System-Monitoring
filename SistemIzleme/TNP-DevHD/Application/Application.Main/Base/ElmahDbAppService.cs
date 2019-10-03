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
    public class ElmahDbAppService<TEntity>:AppService<TEntity>, IElmahDbAppService<TEntity>
          where TEntity : REntity
    {
        public ElmahDbAppService(IElmahDbRepository<TEntity> pRep)
            : base(pRep)
        {
        }
    }
}

