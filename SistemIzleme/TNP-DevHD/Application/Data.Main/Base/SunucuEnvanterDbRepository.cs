using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Rota2.DataCore;
using Rota2.DomainCore;
using Domain.Main.Models;
using System.Data.Entity;
using Data.Main.Models;
using Rota2.CrossCutting.Logging;

namespace Data.Main
{
    public class SunucuEnvanterDbRepository<TEntity> : Repository<TEntity>, ISunucuEnvanterDbRepository<TEntity>
          where TEntity : REntity
    {
        public SunucuEnvanterDbRepository([Dependency("SunucuEnvanterDbContext")] IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
