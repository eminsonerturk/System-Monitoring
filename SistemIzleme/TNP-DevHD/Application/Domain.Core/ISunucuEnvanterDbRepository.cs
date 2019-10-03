using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.DomainCore;

namespace Data.Main
{
    public interface ISunucuEnvanterDbRepository<TEntity> : IRepository<TEntity>
        where TEntity : REntity
    {
    }
}
