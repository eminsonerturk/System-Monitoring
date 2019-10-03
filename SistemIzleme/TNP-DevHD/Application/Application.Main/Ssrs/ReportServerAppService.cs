using Application.Main.Interfaces;
using Application.ViewModels.Ssrs;
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
    public class ReportServerAppService : ReportDbAppService<ReportServer>, IReportServerAppService
    {
        #region Constructor
        public ReportServerAppService(IReportDbRepository<ReportServer> pRep)
            : base(pRep)
        {
        }
        #endregion

        public List<ReportServer> GetCache(ReportServerSearchViewModel model)
        {
            List<ReportServer> ssrs = new List<ReportServer>();
            if (model.EnabledServer == 0)
            {
                ssrs = HttpRuntime.Cache["ReportServer"] as List<ReportServer>;

                if (HttpRuntime.Cache["ReportServer"] == null)
                {
                    var time = DateTime.Today.AddDays(-1);
                    ssrs = (from e in rep.Table
                            where e.TimeStart > time
                            select e).ToList();
                    HttpRuntime.Cache["ReportServer"] = ssrs;
                }
            }
            else if (model.EnabledServer == 1)
            {
                ssrs = HttpRuntime.Cache["ReportServerHD"] as List<ReportServer>;

                if (HttpRuntime.Cache["ReportServerHD"] == null)
                {
                    var time = DateTime.Today.AddDays(-1);
                    ssrs = (from e in rep.Table
                            where e.TimeStart > time
                            select e).ToList();
                    HttpRuntime.Cache["ReportServerHD"] = ssrs;
                }
            }
            else if (model.EnabledServer == 2)
            {
                ssrs = HttpRuntime.Cache["ReportServerMTST"] as List<ReportServer>;

                if (HttpRuntime.Cache["ReportServerMTST"] == null)
                {
                    var time = DateTime.Today.AddDays(-1);
                    ssrs = (from e in rep.Table
                            where e.TimeStart > time
                            select e).ToList();
                    HttpRuntime.Cache["ReportServerMTST"] = ssrs;
                }
            }
            else if (model.EnabledServer == 3)
            {
                ssrs = HttpRuntime.Cache["ReportServerMTGC"] as List<ReportServer>;

                if (HttpRuntime.Cache["ReportServerMTGC"] == null)
                {
                    var time = DateTime.Today.AddDays(-1);
                    ssrs = (from e in rep.Table
                            where e.TimeStart > time
                            select e).ToList();
                    HttpRuntime.Cache["ReportServerMTGC"] = ssrs;
                }
            }
            else if (model.EnabledServer == 4)
            {
                ssrs = HttpRuntime.Cache["ReportServerOTTS"] as List<ReportServer>;

                if (HttpRuntime.Cache["ReportServerOTTS"] == null)
                {
                    var time = DateTime.Today.AddDays(-1);
                    ssrs = (from e in rep.Table
                            where e.TimeStart > time
                            select e).ToList();
                    HttpRuntime.Cache["ReportServerOTTS"] = ssrs;
                }
            }
            else if (model.EnabledServer == 5)
            {
                ssrs = HttpRuntime.Cache["ReportServerBOX"] as List<ReportServer>;

                if (HttpRuntime.Cache["ReportServerBOX"] == null)
                {
                    var time = DateTime.Today.AddDays(-1);
                    ssrs = (from e in rep.Table
                            where e.TimeStart > time
                            select e).ToList();
                    HttpRuntime.Cache["ReportServerBOX"] = ssrs;
                }
            }

            if (ssrs != null && ssrs.Count != 0)
                ssrs = ssrs.Where(a => a != null).ToList();

            return ssrs;
        }

        public IQueryable<ReportServer> UpdateCache(ReportServerSearchViewModel model)
        {
            List<ReportServer> currentData = GetCache(model);

            var maxDate = (from n in currentData
                           select n.TimeStart).Max();

            var newData = (from e in rep.Table
                           where e.TimeStart > maxDate
                           select e).ToList();

            List<ReportServer> allData = currentData.Union(newData).ToList();

            if (model.EnabledServer == 0)
                HttpRuntime.Cache["ReportServer"] = allData;
            else if (model.EnabledServer == 1)
                HttpRuntime.Cache["ReportServerHD"] = allData;
            else if (model.EnabledServer == 2)
                HttpRuntime.Cache["ReportServerMTST"] = allData;
            else if (model.EnabledServer == 3)
                HttpRuntime.Cache["ReportServerMTGC"] = allData;
            else if (model.EnabledServer == 4)
                HttpRuntime.Cache["ReportServerOTTS"] = allData;
            else if (model.EnabledServer == 5)
                HttpRuntime.Cache["ReportServerBOX"] = allData;

            return allData.AsQueryable();
        }

        public override IEnumerable<TEntityDto> WhereDto<TSearchModel, TEntityDto>(TSearchModel searchModel, int pageIndex = 0, int pageSize = 0)
        {
            ReportServerSearchViewModel model = (ReportServerSearchViewModel)(object)searchModel;
            IQueryable<ReportServer> reportServerData;
            IQueryable<ReportServerDto> reportServerDataDto;

            Expression<Func<ReportServer, bool>> predicate = f => true;
            predicate = CreateDynamicPredicate<TSearchModel>(searchModel);

            if (model.StartDate >= DateTime.Today.AddDays(-1))
            {
                reportServerData = UpdateCache(model).Where(predicate);
                reportServerDataDto = (from e in reportServerData
                                           orderby e.TimeStart descending
                                           select new ReportServerDto
                                           {
                                               ItemPath = e.ItemPath,
                                               UserName = e.UserName,
                                               Format = e.Format,
                                               Parameters = e.Parameters,
                                               TimeStart = e.TimeStart,
                                               TimeEnd = e.TimeEnd,
                                               LogEntryId = e.LogEntryId,
                                           }).Take(1000);

                return (IEnumerable<TEntityDto>)reportServerDataDto.AsEnumerable();
            }
            else
            {
                reportServerDataDto = (from e in rep.Table.Where(predicate)
                                       orderby e.TimeStart descending
                                       select new ReportServerDto
                                           {
                                               ItemPath = e.ItemPath,
                                               UserName = e.UserName,
                                               Format = e.Format,
                                               Parameters = e.Parameters,
                                               TimeStart = e.TimeStart,
                                               TimeEnd = e.TimeEnd,
                                               LogEntryId = e.LogEntryId,
                                           }).Take(1000);

                return (IEnumerable<TEntityDto>)reportServerDataDto.AsEnumerable();
            }
        }
    }
}
