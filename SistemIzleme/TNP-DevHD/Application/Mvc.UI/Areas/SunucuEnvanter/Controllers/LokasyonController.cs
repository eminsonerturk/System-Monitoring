using Application.Main.Interfaces;
using Application.Main.Interfaces.SunucuEnvanter;
using Application.ViewModels.Envanter;
using Domain.Main;
using Domain.Main.Envanter;
using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using Rota2.MvcUtils.Mappers;
using Rota2.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.UI.Areas.Envanter.Controllers
{
    public class LokasyonController : Crud7Controller<AvLokasyon, LokasyonCrudViewModel, LokasyonSearchViewModel, LokasyonListViewModel, LokasyonSelectSearchViewModel, LokasyonSelectListViewModel>
    {
        ILokasyonAppService _service;
        public LokasyonController(ILokasyonAppService srv,
            IMapper<AvLokasyon, LokasyonCrudViewModel> crudMapper, IMapper<AvLokasyon, LokasyonListViewModel> listMapper,
            IMapper<AvLokasyon, LokasyonSelectListViewModel> selectListMapper)
            : base(srv, crudMapper, listMapper, selectListMapper)
        {
            _service = srv;
            CrudOnIndex = true;
            AutoFilter = true;
        }

        public ActionResult GetLocationForDropdown() 
        {
            IEnumerable<LokasyonListViewModel> locationServiceParameters = _service.GetLocationServiceParameters();
            var items = new List<SelectListItem>();
            foreach (var item in locationServiceParameters)
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ad });

            return Json(items, JsonRequestBehavior.AllowGet); 
        }
    }
}