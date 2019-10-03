using Application.Main.Interfaces;
using Application.ViewModels.Islem;
using Data.Main;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    public class EntityFieldNameAppService : IslemDbAppService<EntityFieldName>, IEntityFieldNameAppService
    {
        #region Constructor
        public EntityFieldNameAppService(IIslemDbRepository<EntityFieldName> pRep)
            : base(pRep)
        {
        }
        #endregion

        public List<string> GetEntityFieldList(IslemLogSearchViewModel searchModel)
        {
            searchModel = FormatTableNameAsDbField(searchModel);
            var entityFieldList = (from p in rep.Table
                                   where p.TableName == searchModel.EntityName
                                   select new IslemLogSearchViewModel { EntityFieldName = p.ColumnName }).Distinct().ToList();
            return FormatTableName(entityFieldList);
        }

        public List<string> FormatTableName(List<IslemLogSearchViewModel> tableList)
        {
            List<string> tableNames = new List<string>();
            foreach (var t in tableList)
            {
                string temp = t.EntityFieldName.ToString().Replace("_", " ").ToLower().Replace("ı", "i");
                t.EntityFieldName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(temp).Replace(" ", "").Replace("İ", "I");
                tableNames.Add(t.EntityFieldName);
            }
            return tableNames;
        }

        public IslemLogSearchViewModel FormatTableNameAsDbField(IslemLogSearchViewModel searchModel)
        {
            char[] array = searchModel.EntityName.ToCharArray();
            string returnValue = "";
            returnValue += array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] <= 'Z' && array[i] >= 'A')
                {
                    returnValue += "_" + array[i];
                    continue;
                }
                returnValue += char.ToUpper(array[i]);
            }
            searchModel.EntityName = returnValue.Replace("İ", "I");
            return searchModel;
        }
    }
}
