using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Main.Models;
using Microsoft.Practices.Unity;
using Rota2.DataCore;
using Rota2.DomainCore;

namespace Data.Main
{    
    public class ReportDbRepository<TEntity> : Repository<TEntity>, IReportDbRepository<TEntity>
          where TEntity : REntity
    {
        public ReportDbRepository([Dependency("ReportDbContext")] IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        public void ChangeConnection(string connString)
        {
            ((ReportDbContext)UnitOfWork).ChangeConnection(connString);
        }
    }
}
