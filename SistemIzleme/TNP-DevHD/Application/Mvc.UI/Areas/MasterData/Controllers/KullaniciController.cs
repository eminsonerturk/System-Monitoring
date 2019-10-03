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
    public class KullaniciController : CrudController<KullaniciApp, KullaniciAppViewModel>
    {
        protected readonly IKullaniciAppAppService kullaniciAppService;

        public KullaniciController(IKullaniciAppAppService kullaniciAppSrv,
            IMapper<KullaniciApp, KullaniciAppViewModel> v)
            : base(kullaniciAppSrv, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            kullaniciAppService = kullaniciAppSrv;
        }

        public JsonResult SelectedAppReadData()
        {
            List<string> userSelectionList = new List<string>();
            //GetSelectedAppList metoduna düşmüyor
            userSelectionList = kullaniciAppService.GetSelectedAppList();
            return Json(userSelectionList, JsonRequestBehavior.AllowGet);
        }

        [NoAntiForgeryCheck]
        public void SelectedAppUpdateData(KullaniciAppViewModel selectedApps)
        {
            kullaniciAppService.UpdateSelectedAppList(selectedApps);
        }
    }
}
