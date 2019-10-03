using Application.ViewModels.Ssrs;
using Data.Main.Models;
using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using Rota2.MvcUtils.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Main.Interfaces;
using Domain.Main.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Text;
using System.IO;
using Domain.Main.DTO;
using Rota2.MvcUtils.Attributes;
using System.Web.Configuration;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class ReportServerController : Crud5Controller<ReportServer,ReportServerViewModel, ReportServerSearchViewModel, ReportServerViewModel>
    {
        protected readonly IReportServerAppService reportServerService;
        protected readonly IMapper<ReportServerDto, ReportServerViewModel> dtoMapper;

        public ReportServerController(IReportServerAppService reportServerSrv,
            IMapper<ReportServer, ReportServerViewModel> v, IMapper<ReportServerDto, ReportServerViewModel> _dtoMapper)
            : base(reportServerSrv, v,null)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            reportServerService = reportServerSrv;
            dtoMapper = _dtoMapper;
        }

        protected override JsonResult GetGridData(DataSourceRequest request, ReportServerSearchViewModel searchModel)
        {
            if (searchModel.IsAutoRefresh)
            {
                searchModel.StartDate = new DateTime();
                searchModel.EndDate = new DateTime();
            }

            switch (searchModel.EnabledServer)
            {
                case 0: reportServerService.UseReportServer();
                    break;
                case 1: reportServerService.UseReportServerHD();
                    break;
                case 2: reportServerService.UseReportServerMTST();
                    break;
                case 3: reportServerService.UseReportServerMTGC();
                    break;
                case 4: reportServerService.UseReportServerOTTS();
                    break;
                case 5: reportServerService.UseReportServerBox();
                    break;
            }

            if (searchModel.ReportName != null)
                searchModel.ReportName = searchModel.ReportName.Replace("i", "I");

            IEnumerable<ReportServerDto> list = reportServerService.WhereDto<ReportServerSearchViewModel, ReportServerDto>(searchModel);
            var res = dtoMapper.MapToModel(list);
            return Json(res.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [NoAntiForgeryCheck]
        public JsonResult CustomReadDataForServerSelect(ReportServerSearchViewModel searchModel)
        {
            string[] ReportServerIP = (WebConfigurationManager.AppSettings["ReportServerDbConnection"].ToString()).Split('=', ';');
            string[] ReportServerHDIP = (WebConfigurationManager.AppSettings["ReportServerHDDbConnection"].ToString()).Split('=', ';');
            string[] ReportServerMTSTIP = (WebConfigurationManager.AppSettings["ReportServerMTSTDbConnection"].ToString()).Split('=', ';');
            string[] ReportServerMTGCIP = (WebConfigurationManager.AppSettings["ReportServerMTGCDbConnection"].ToString()).Split('=', ';');
            string[] ReportServerOTTSIP = (WebConfigurationManager.AppSettings["ReportServerOTODbConnection"].ToString()).Split('=', ';');
            string[] ReportServerBoxIP = (WebConfigurationManager.AppSettings["ReportServerBoxDbConnection"].ToString()).Split('=', ';');

            var res1 = new List<SelectListItem>() {
            new SelectListItem() {
                    Text = ReportServerIP[1] + " ( Canlı )",
                    Value = "0"
                },
                new SelectListItem() {
                    Text = ReportServerHDIP[1] + " ( HD - Dev )",
                    Value = "1"
                },
                new SelectListItem() {
                    Text = ReportServerMTSTIP[1] + " ( MTST - Test )",
                    Value = "2"
                },
                new SelectListItem() {
                    Text = ReportServerMTGCIP[1] + " ( MTGC - Güncel Test )",
                    Value = "3"
                },
                new SelectListItem() {
                    Text = ReportServerOTTSIP[1] + " ( OTTS - Oto Test )",
                    Value = "4"
                },
                new SelectListItem() {
                    Text = ReportServerBoxIP[1] + " ( Box )",
                    Value = "5"
                }
            };
            return Json(res1, JsonRequestBehavior.AllowGet);
        }
    }
}
