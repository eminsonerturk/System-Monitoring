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
using System.Text;
using System.IO;
using Rota2.MvcUtils.Attributes;
using Newtonsoft.Json;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class ExceptionRequestController : CrudController<ExceptionRequest, ExceptionRequestViewModel>
    {
        protected readonly IExceptionRequestAppService exceptionRequestService;

        public ExceptionRequestController(IExceptionRequestAppService exceptionRequestSrv,
            IMapper<ExceptionRequest, ExceptionRequestViewModel> v)
            : base(exceptionRequestSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            exceptionRequestService = exceptionRequestSrv;
        }
    }
}
