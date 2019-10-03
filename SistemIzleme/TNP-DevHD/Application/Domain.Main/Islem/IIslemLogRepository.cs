using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Main;
using Domain.Main.Models;
using Rota2.DomainCore;

namespace Domain.Main.Islem
{
    public interface IIslemLogRepository : IIslemDbRepository<IslemLog>
    {
        IEnumerable<IslemLog> GetDataWithSql(string whereClause, List<SqlParameter> parameters);
    }
}
