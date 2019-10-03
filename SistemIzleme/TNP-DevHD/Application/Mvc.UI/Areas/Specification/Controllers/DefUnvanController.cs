using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.ViewModels.MasterData;
using Data.Main.Models;
using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using Rota2.MvcUtils.Mappers;
using Domain.Main.Models;
using Application.Main.Interfaces;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class DefUnvanController : CrudController<DefUnvan,DefUnvanViewModel>
    {
        protected readonly IDefUnvanAppService defUnvanService;

        public DefUnvanController(IDefUnvanAppService defUnvanSrv,
            IMapper<DefUnvan,DefUnvanViewModel> v)
            : base(defUnvanSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            defUnvanService = defUnvanSrv;
        }
    }
}

