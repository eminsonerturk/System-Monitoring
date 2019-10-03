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
using Rota2.MvcUtils.Attributes;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class EntityNameController : CrudController<EntityName, IslemLogSearchViewModel>
    {
        protected readonly IEntityNameAppService entityNameService;
        protected readonly IIslemLogAppService islemLogService;

        public EntityNameController(IEntityNameAppService entityNameSrv, IIslemLogAppService islemLogSrv,
            IMapper<EntityName, IslemLogSearchViewModel> v)
            : base(entityNameSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            entityNameService = entityNameSrv;
            islemLogService = islemLogSrv;
        }

        public JsonResult EntityReadData([DataSourceRequest]DataSourceRequest request)
        {
            islemLogService.UseYnaLogServer();
            List<string> entityList = entityNameService.GetEntityNameList();
            return Json(entityList, JsonRequestBehavior.AllowGet);
        }
    }
}
