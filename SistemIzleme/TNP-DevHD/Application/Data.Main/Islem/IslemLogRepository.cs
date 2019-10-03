using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Main.Islem;
using Domain.Main.Models;
using Microsoft.Practices.Unity;
using Rota2.DataCore;

namespace Data.Main.Islem
{
    public class IslemLogRepository : IslemDbRepository<IslemLog>, IIslemLogRepository
    {
        public IslemLogRepository([Dependency("IslemDbContext")] IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<IslemLog> GetDataWithSql(string whereClause, List<SqlParameter> parameters)
        {
            string sql = "select KULLANICI_ID as KullaniciId, ISLEM_ADI as IslemAdi,"
                + "REQUEST_MESSAGE_DATE as RequestMessageDate,RESPONSE_STATUS_ID as ResponseStatusId,"
			+ " ENTITY_NAME as EntityName, ENTITY_ID_VALUE as EntityIdValue, ADDED_NEW as AddedNew,"
            + " ENTITY_FIELD_NAME as EntityFieldName, OLD_VALUE as OldValue, NEW_VALUE as NewValue from YNA_LOG_SORGU_VW where" + whereClause;

            IEnumerable<IslemLog> islemData = ((IQueryableUnitOfWork)UnitOfWork).ExecuteQuery<IslemLog>(sql, parameters.ToArray()).ToList();
            return islemData;
        }
    }
}
