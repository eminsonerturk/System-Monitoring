using Application.ViewModels.Islem;
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
using Application.ViewModels;
using System.Text;
using System.IO;
using AutoMapper;
using Data.Main;
using System.Web.Configuration;
using Rota2.MvcUtils.Attributes;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class IslemLogController : Crud5Controller<IslemLog, IslemLogViewModel, IslemLogSearchViewModel, IslemLogViewModel>
    {
        protected readonly IIslemLogAppService islemLogService;

        public IslemLogController(IIslemLogAppService islemLogSrv,
            IMapper<IslemLog, IslemLogViewModel> v)
            : base(islemLogSrv, v, null)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            islemLogService = islemLogSrv;
        }

        protected override JsonResult GetGridData(DataSourceRequest request, IslemLogSearchViewModel searchModel)
        {
            int choosenServer = -1;
            if (HttpRuntime.Cache["ChoosenServer"] != null)
                choosenServer = (int)HttpRuntime.Cache["ChoosenServer"];

            if (HttpRuntime.Cache["ChoosenServer"] == null | choosenServer != searchModel.EnabledServer)
            {
                HttpRuntime.Cache["ChoosenServer"] = searchModel.EnabledServer;
                HttpRuntime.Cache.Remove("Kullanici");
            }

            switch (searchModel.EnabledServer)
            {
                case 0: islemLogService.UseYnaLogServer();
                        islemLogService.GetCache();
                    break;
                case 1: islemLogService.UseYnaLogTestServer();
                        islemLogService.GetCache();
                    break;
                case 2:
                    islemLogService.UseYnaLogTest2Server();
                    islemLogService.GetCache();
                    break;
                case 3:
                    islemLogService.UseYnaLogTest3Server();
                    islemLogService.GetCache();
                    break;
            }

            IEnumerable<IslemLogViewModel> islemLogList = islemLogService.CustomFilter(searchModel);
            return Json(islemLogList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [NoAntiForgeryCheck]
        public JsonResult CustomReadDataForServerSelect(IslemLogSearchViewModel searchModel)
        {
            string[] YnaLog = (WebConfigurationManager.AppSettings["YnaLogDbConnectionString"].ToString()).Split('=', ';');
            string[] YnaTestLog = (WebConfigurationManager.AppSettings["YnaLogTestDbConnectionString"].ToString()).Split('=', ';');
            string[] YnaTest2Log = (WebConfigurationManager.AppSettings["YnaLogTest2DbConnectionString"].ToString()).Split('=', ';');
            string[] YnaTest3Log = (WebConfigurationManager.AppSettings["YnaLogTest3DbConnectionString"].ToString()).Split('=', ';');

            var res1 = new List<SelectListItem>() 
            {
                new SelectListItem() {
                    Text = YnaLog[1] + " ( Canlı )",
                    Value = "0"
                },
                new SelectListItem() {
                    Text = YnaTestLog[1] + " ( Test )",
                    Value = "1"
                },
                new SelectListItem() {
                    Text = YnaTest2Log[1] + " ( Test2 )",
                    Value = "2"
                },
                new SelectListItem() {
                    Text = YnaTest3Log[1] + " ( Test3 )",
                    Value = "3"
                }
            };

            return Json(res1, JsonRequestBehavior.AllowGet);
        }
    }
}

