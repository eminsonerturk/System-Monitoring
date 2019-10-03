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
    public class PartiController : CrudController<Parti,PartiViewModel>
    {
        protected readonly IPartiAppService partiService;

        public PartiController(IPartiAppService partiSrv,
            IMapper<Parti,PartiViewModel> v)
            : base(partiSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            partiService = partiSrv;
        }
    }
}

