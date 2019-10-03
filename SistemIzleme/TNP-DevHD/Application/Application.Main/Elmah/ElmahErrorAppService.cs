using Application.Main.Interfaces;
using Application.ViewModels.Elmah;
using Data.Main;
using Domain.Main.DTO;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Main
{
    public class ElmahErrorAppService : ElmahDbAppService<ElmahError>, IElmahErrorAppService
    {
        #region Constructor
        public ElmahErrorAppService(IElmahDbRepository<ElmahError> pRep)
            : base(pRep)
        {
        }
        #endregion

        public List<ElmahErrorDto> GetCache() 
        {
            List<ElmahErrorDto> elmah = HttpRuntime.Cache["Elmah"] as List<ElmahErrorDto>;

            if (HttpRuntime.Cache["Elmah"] == null)
            {
                var time = DateTime.Today.AddDays(-7);
                elmah = (from e in rep.Table
                         where e.Kayityaratmatarihi > time 
                         select new ElmahErrorDto
                             {
                                 Errorid = e.Errorid,
                                 Application = e.Application,
                                 Host = e.Host,
                                 Type = e.Type,
                                 Source = e.Source,
                                 Message = e.Message,
                                 User = e.User,
                                 Sequence = e.Sequence,
                                 Kayityaratmatarihi = e.Kayityaratmatarihi
                             }).ToList();
                HttpRuntime.Cache["Elmah"] = elmah;
            }
            return elmah;
        }

        public IQueryable<ElmahErrorDto> UpdateCache()
        {
            List<ElmahErrorDto> currentData = GetCache();

            var maxDate = (from c in currentData
                           select c.Kayityaratmatarihi).Max();

            var newData = (from e in rep.Table
                           where e.Kayityaratmatarihi > maxDate
                           select new ElmahErrorDto
                          {
                              Errorid = e.Errorid,
                              Application = e.Application,
                              Host = e.Host,
                              Type = e.Type,
                              Source = e.Source,
                              Message = e.Message,
                              User = e.User,
                              Sequence = e.Sequence,
                              Kayityaratmatarihi = e.Kayityaratmatarihi
                          }).ToList();

            List<ElmahErrorDto> allData = currentData.Union(newData).ToList();
            HttpRuntime.Cache["Elmah"] = allData;

            return allData.AsQueryable();
        }

        public override IEnumerable<TEntityDto> WhereDto<TSearchModel, TEntityDto>(TSearchModel searchModel, int pageIndex = 0, int pageSize = 0)
        {
            IEnumerable<ElmahErrorDto> elmahDataDto;
            ElmahErrorSearchViewModel elmahSearchModel = (ElmahErrorSearchViewModel)(object)searchModel;

            if (elmahSearchModel.StartDate >= DateTime.Today.AddDays(-7))
            {
                Expression<Func<ElmahErrorDto, bool>> predicate = f => true;
                predicate = CreateCustomDtoPredicate(searchModel);

                var elmahData = UpdateCache().Where(predicate);
                elmahDataDto = (from e in elmahData
                                orderby e.Kayityaratmatarihi descending
                                select e).Take(1000);
            }
            else
            {
                IQueryable<ElmahError> elmahData = rep.Table;

                elmahData = CustomFilter(elmahData, elmahSearchModel);
                elmahDataDto = (from e in elmahData
                                orderby e.Kayityaratmatarihi descending
                                select new ElmahErrorDto
                                {
                                    Errorid = e.Errorid,
                                    Application = e.Application,
                                    Host = e.Host,
                                    Type = e.Type,
                                    Source = e.Source,
                                    Message = e.Message,
                                    User = e.User,
                                    Sequence = e.Sequence,
                                    Kayityaratmatarihi = e.Kayityaratmatarihi
                                }).Take(1000);

            }
            return (IEnumerable<TEntityDto>)elmahDataDto.AsEnumerable();
        }

        public Expression<Func<ElmahErrorDto, bool>> CreateCustomDtoPredicate(object searchModel)
        {
            Expression<Func<ElmahErrorDto, bool>> predicate = f => true;
            ElmahErrorSearchViewModel model = (ElmahErrorSearchViewModel)(object)searchModel;
            predicate = e => (model.Host == null ? true : e.Host == model.Host) &&
                            (model.Type == null ? true : e.Type.StartsWith(model.Type)) &&
                            (string.IsNullOrWhiteSpace(model.ErrorIdString) ? true : e.Errorid.ToString().ToUpper().StartsWith(model.ErrorIdString.ToUpper().Trim())) &&
                            (model.User == null ? true : e.User.Contains(model.User)) &&
                            (model.Message == null ? true : e.Message.Contains(model.Message)) &&
                            (model.Source == null ? true : e.Source.StartsWith(model.Source)) &&
                            ((model.Application == null || model.Application.Count == 0) ? true : model.Application.Contains(e.Application)) &&
                            (model.Sequence == 0 ? true : e.Sequence == model.Sequence) &&
                            (model.IsAutoRefresh ? true : e.Kayityaratmatarihi >= model.StartDate) &&
                            (model.IsAutoRefresh ? true : e.Kayityaratmatarihi <= model.EndDate) &&
                            (string.IsNullOrWhiteSpace(model.MessageNotLike) ? true : !e.Message.Contains(model.MessageNotLike))
                            ;
            return predicate;
        }

        public IQueryable<ElmahError> CustomFilter(IQueryable<ElmahError> elmahData, ElmahErrorSearchViewModel elmahSearchModel)
        {
            if (elmahSearchModel.Host != null)
            {
                elmahData = (from e in elmahData
                             where e.Host == elmahSearchModel.Host
                             select e);
            }
            if (elmahSearchModel.Type != null)
            {
                elmahData = (from e in elmahData
                             where e.Type.StartsWith(elmahSearchModel.Type)
                             select e);
            }
            if (elmahSearchModel.Message != null)
            {
                elmahData = (from e in elmahData
                             where e.Message.Contains(elmahSearchModel.Message)
                             select e);
            }
            if (!string.IsNullOrWhiteSpace(elmahSearchModel.ErrorIdString))
            {
                elmahData = (from e in elmahData
                             where e.Errorid.ToString().ToUpper().StartsWith(elmahSearchModel.ErrorIdString.ToUpper().Trim())
                             select e);
            }
            if (!string.IsNullOrWhiteSpace(elmahSearchModel.MessageNotLike))
            {
                elmahData = (from e in elmahData
                             where !e.Message.Contains(elmahSearchModel.Message.Trim())
                             select e);
            }
            if (elmahSearchModel.User != null)
            {
                elmahData = (from e in elmahData
                             where e.User.Contains(elmahSearchModel.User)
                             select e);
            }
            if (elmahSearchModel.Source != null)
            {
                elmahData = (from e in elmahData
                             where e.Source.StartsWith(elmahSearchModel.Source)
                             select e);
            }
            if (elmahSearchModel.Application != null && elmahSearchModel.Application.Count != 0)
            {
                elmahData = (from e in elmahData
                             where elmahSearchModel.Application.Contains(e.Application)
                             select e);
            }
            if (elmahSearchModel.Sequence != 0)
            {
                elmahData = (from e in elmahData
                             where e.Sequence == elmahSearchModel.Sequence
                             select e);
            }
            if (elmahSearchModel.IsAutoRefresh == false)
            {
                elmahData = (from e in elmahData
                             where
                                e.Kayityaratmatarihi >= elmahSearchModel.StartDate &&
                                e.Kayityaratmatarihi <= elmahSearchModel.EndDate
                             select e);
            }
            return elmahData;
        }

        public List<string> GetApplicationList()
        {
            var query = (from e in rep.Table
                         select e.Application).Distinct().ToList();

            query.Add("YNA_TUM");
            query.Sort();

            return query;
        }

        public string GetAllXml(string errorId)
        {
            System.Guid g = new Guid(errorId);
            var query = (from p in rep.Table
                         where p.Errorid == g
                         select p.Allxml).Single();
            query.ToString();
            return query;
        }

    }
}
