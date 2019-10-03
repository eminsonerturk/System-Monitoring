using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Rota2.DataCore;
using Rota2.DomainCore;
using Data.Main.Models;

namespace Data.Main
{
    public class IslemDbRepository<TEntity> : Repository<TEntity>, IIslemDbRepository<TEntity>
          where TEntity : REntity
    {
        public IslemDbRepository([Dependency("IslemDbContext")] IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        public void ChangeConnection(string connString)
        {
            ((IslemDbContext)UnitOfWork).ChangeConnection(connString);
        }
    }
}
