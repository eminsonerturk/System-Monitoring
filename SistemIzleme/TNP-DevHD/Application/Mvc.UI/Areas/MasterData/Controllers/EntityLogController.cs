using Application.ViewModels.Elmah;
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
    public class EntityLogController : CrudController<EntityLog, EntityLogViewModel>
    {
        protected readonly IEntityLogAppService entityLogService;

        public EntityLogController(IEntityLogAppService entityLogSrv,
            IMapper<EntityLog, EntityLogViewModel> v)
            : base(entityLogSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            entityLogService = entityLogSrv;
        }
    }
}
