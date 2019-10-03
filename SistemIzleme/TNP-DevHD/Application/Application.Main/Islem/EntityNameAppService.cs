using Application.Main.Interfaces;
using Data.Main;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Main
{
    public class EntityNameAppService : IslemDbAppService<EntityName>, IEntityNameAppService
    {
        #region Constructor
        public EntityNameAppService(IIslemDbRepository<EntityName> pRep)
            : base(pRep)
        {
        }
        #endregion

        public List<EntityName> GetCache()
        {
            List<EntityName> tableList = HttpRuntime.Cache["EntityName"] as List<EntityName>;

            if (HttpRuntime.Cache["EntityName"] == null)
            {
                tableList = (from e in rep.Table
                             select e).ToList();
                HttpRuntime.Cache["EntityName"] = FormatTableName(tableList);
            }
            return tableList;
        }

        public List<string> GetEntityNameList()
        {
            List<EntityName> tableList = GetCache();
            var query = (from p in tableList
                         select p.TableName).ToList();
            return query;
        }

        public List<EntityName> FormatTableName(List<EntityName> tableList)
        {
            foreach (var t in tableList)
            {
                string temp = t.TableName.ToString().Replace("_", " ").ToLower().Replace("ı", "i");
                t.TableName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(temp).Replace(" ", "").Replace("İ", "I");
            }
            return tableList;
        }
    }
}
