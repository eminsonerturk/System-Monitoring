using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Rota2.DataCore;
using Rota2.DomainCore;

namespace Data.Main
{
    public class ElmahDbRepository<TEntity>:Repository<TEntity>, IElmahDbRepository<TEntity>
          where TEntity : REntity
    {
        public ElmahDbRepository([Dependency("ElmahDbContext")] IQueryableUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }
    }
}
