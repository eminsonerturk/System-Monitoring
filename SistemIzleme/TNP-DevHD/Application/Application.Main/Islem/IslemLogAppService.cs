using Application.Main.Interfaces;
using Application.ViewModels.Islem;
using Data.Main;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Domain.Main.Islem;
using Rota2.DataCore;
using System.Data.SqlClient;
using System.Data.Common;

namespace Application.Main
{
    public class IslemLogAppService : IslemDbAppService<IslemLog>, IIslemLogAppService
    {
        private IIslemDbRepository<Kullanici> kRep;

        #region Constructor
        public IslemLogAppService(IIslemLogRepository pRep, IIslemDbRepository<Kullanici> kRep)
            : base(pRep)
        {
            this.kRep = kRep;
        }
        #endregion

        public List<Kullanici> GetCache()
        {
            List<Kullanici> kullanici = new List<Kullanici>();
            kullanici = HttpRuntime.Cache["Kullanici"] as List<Kullanici>;

            if (HttpRuntime.Cache["Kullanici"] == null)
            {
                kullanici = (from e in kRep.Table
                             select e).ToList();

                HttpRuntime.Cache["Kullanici"] = kullanici;
                return kullanici;
            }
            else
            {
                List<Kullanici> currentData = kullanici;

                var maxId = (from n in currentData
                             select n.Id).Max();

                var newData = (from e in kRep.Table
                               where e.Id > maxId
                               select e).ToList();

                List<Kullanici> allData = currentData.Union(newData).ToList();
                HttpRuntime.Cache["Kullanici"] = allData;

                return allData;
            }
        }

        public IEnumerable<IslemLogViewModel> CustomFilter(IslemLogSearchViewModel searchModel)
        {
            Expression<Func<IslemLog, bool>> predicate = f => true;
            predicate = CreateCustomPredicate(searchModel);

            ////Veritabanında Kullanici tablosu olmadığından cache yapıp aldığımız kısım
            List<Kullanici> kullanici = new List<Kullanici>();
            kullanici = HttpRuntime.Cache["Kullanici"] as List<Kullanici>;

            List<SqlParameter> parameters=new List<SqlParameter>();
            string whereClause = CreateWhereClause(searchModel, parameters);

            IEnumerable<IslemLog> islemData = ((IIslemLogRepository)rep).GetDataWithSql(whereClause, parameters);

            var joinedSequence = (from k in kullanici
                                  join i in islemData on k.Id equals i.KullaniciId
                                  select new IslemLogViewModel
                                  {
                                      KullaniciId = i.KullaniciId,
                                      KullaniciAdi = k.KullaniciAdi,
                                      AddedNew = i.AddedNew,
                                      EntityFieldName = i.EntityFieldName,
                                      EntityIdValue = i.EntityIdValue,
                                      EntityName = i.EntityName,
                                      ResponseStatusId = i.ResponseStatusId,
                                      NewValue = i.NewValue,
                                      OldValue = i.OldValue,
									  RequestMessageDate = i.RequestMessageDate,
                                      IslemAdi = i.IslemAdi
                                  });

            return joinedSequence.AsEnumerable();
        }

        private string CreateWhereClause(IslemLogSearchViewModel model, List<SqlParameter> parameters)
        {
            StringBuilder whereClause = new StringBuilder();
            if (model.EntityIdValue == 0)
            {
                rep.SetTimeOut(300);
                whereClause.Append(" ");
                whereClause.Append("ENTITY_NAME= @entityname");
                parameters.Add(new SqlParameter("entityname",model.EntityName));
                if (!string.IsNullOrEmpty(model.EntityFieldName))
                {
                    whereClause.Append(" ");
                    whereClause.Append("and");
                    whereClause.Append(" ");
                    whereClause.Append("ENTITY_FIELD_NAME= @entityfieldname");
                    parameters.Add(new SqlParameter("entityfieldname", model.EntityFieldName));
                }

                if (!string.IsNullOrEmpty(model.NewValue) && !string.IsNullOrEmpty(model.OldValue))
                {
                    whereClause.Append(" ");
                    whereClause.Append("and");
                    whereClause.Append(" ");
                    whereClause.Append("(NEW_VALUE= @newvalue or OLD_VALUE= @oldvalue)");
                    parameters.Add(new SqlParameter("newvalue", model.NewValue));
                    parameters.Add(new SqlParameter("oldvalue", model.OldValue));
                }
                else
                    if (!string.IsNullOrEmpty(model.NewValue))
                    {
                        whereClause.Append(" ");
                        whereClause.Append("and");
                        whereClause.Append(" ");
                        whereClause.Append("NEW_VALUE= @newvalue");
                        parameters.Add(new SqlParameter("newvalue", model.NewValue));
                    }
                    else
                        if (!string.IsNullOrEmpty(model.OldValue))
                        {
                            whereClause.Append(" ");
                            whereClause.Append("and");
                            whereClause.Append(" ");
                            whereClause.Append("OLD_VALUE= @oldvalue");
                            parameters.Add(new SqlParameter("oldvalue", model.OldValue));
                        }
            }
            else
            {
                if (string.IsNullOrEmpty(model.OldValue) && string.IsNullOrEmpty(model.NewValue))
                {
                    whereClause.Append(" ");
                    whereClause.Append("ENTITY_NAME= @entityname");
                    whereClause.Append(" ");
                    whereClause.Append("and");
                    whereClause.Append(" ");
                    whereClause.Append("ENTITY_ID_VALUE=@entityidvalue");

                    parameters.Add(new SqlParameter("entityname", model.EntityName));
                    parameters.Add(new SqlParameter("entityidvalue", model.EntityIdValue));
                    if (!string.IsNullOrEmpty(model.EntityFieldName))
                    {
                        whereClause.Append(" ");
                        whereClause.Append("and");
                        whereClause.Append(" ");
                        whereClause.Append("ENTITY_FIELD_NAME= @entityfieldname");
                        parameters.Add(new SqlParameter("entityfieldname", model.EntityFieldName));
                    }
                }
                else
                {
                    whereClause.Append(" ");
                    whereClause.Append("ENTITY_NAME= @entityname");
                    parameters.Add(new SqlParameter("entityname", model.EntityName));
                    if (!string.IsNullOrEmpty(model.EntityFieldName))
                    {
                        whereClause.Append(" ");
                        whereClause.Append("and");
                        whereClause.Append(" ");
                        whereClause.Append("ENTITY_FIELD_NAME= @entityfieldname and ENTITY_ID_VALUE=@entityidvalue");
                        parameters.Add(new SqlParameter("entityfieldname", model.EntityFieldName));
                        parameters.Add(new SqlParameter("entityidvalue", model.EntityIdValue));
                    }

                    if (!string.IsNullOrEmpty(model.NewValue) && !string.IsNullOrEmpty(model.OldValue))
                    {
                        whereClause.Append(" ");
                        whereClause.Append("and");
                        whereClause.Append(" ");
                        whereClause.Append("(NEW_VALUE= @newvalue or OLD_VALUE= @oldvalue)");
                        parameters.Add(new SqlParameter("newvalue", model.NewValue));
                        parameters.Add(new SqlParameter("oldvalue", model.OldValue));
                    }
                    else
                        if (!string.IsNullOrEmpty(model.NewValue))
                        {
                            whereClause.Append(" ");
                            whereClause.Append("and");
                            whereClause.Append(" ");
                            whereClause.Append("NEW_VALUE= @newvalue");
                            parameters.Add(new SqlParameter("newvalue", model.NewValue));
                        }
                        else
                            if (!string.IsNullOrEmpty(model.OldValue))
                            {
                                whereClause.Append(" ");
                                whereClause.Append("and");
                                whereClause.Append(" ");
                                whereClause.Append("OLD_VALUE= @oldvalue");
                                parameters.Add(new SqlParameter("oldvalue", model.OldValue));
                            }
                }
            }

            if (model.AddedNew != null)
            {
                whereClause.Append(" ");
                whereClause.Append("and");
                whereClause.Append(" ");
                whereClause.Append("ADDED_NEW= @addednew");
                parameters.Add(new SqlParameter("addednew", model.AddedNew));
            }

            return whereClause.ToString();
        }
    }
}
