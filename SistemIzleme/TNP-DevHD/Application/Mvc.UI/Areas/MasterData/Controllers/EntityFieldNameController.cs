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
using System.Globalization;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class EntityFieldNameController : CrudController<EntityFieldName, IslemLogSearchViewModel>
    {
        protected readonly IEntityFieldNameAppService entityFieldNameService;
        protected readonly IIslemLogAppService islemLogService;

        public EntityFieldNameController(IEntityFieldNameAppService entityFieldNameSrv, IIslemLogAppService islemLogSrv,
            IMapper<EntityFieldName, IslemLogSearchViewModel> v)
            : base(entityFieldNameSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            entityFieldNameService = entityFieldNameSrv;
            islemLogService = islemLogSrv;
        }

        public JsonResult EntityFieldReadData([DataSourceRequest]DataSourceRequest request, IslemLogSearchViewModel searchModel)
        {
            islemLogService.UseYnaLogServer();
            if (searchModel.EntityName == null)
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);
            List<string> entityList = entityFieldNameService.GetEntityFieldList(searchModel);
            return Json(entityList, JsonRequestBehavior.AllowGet);
        }
    }
}
