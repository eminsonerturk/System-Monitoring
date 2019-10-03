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
    public class ServerTipiController : Crud7Controller<AvServerTipi, ServerTipiCrudViewModel, ServerTipiSearchViewModel, ServerTipiListViewModel, ServerTipiSelectSearchViewModel, ServerTipiSelectListViewModel>
    {
        IServerTipiAppService _service;
        public ServerTipiController(IServerTipiAppService srv,
            IMapper<AvServerTipi, ServerTipiCrudViewModel> crudMapper, IMapper<AvServerTipi, ServerTipiListViewModel> listMapper, IMapper<AvServerTipi, ServerTipiSelectListViewModel> selectListMapper)
            : base(srv, crudMapper, listMapper, selectListMapper)
        {
            _service = srv;
            CrudOnIndex = true;
            AutoFilter = true;
        }

        public ActionResult GetServerTypeForDropdown()
        {
            IEnumerable<ServerTipiListViewModel> serverTypeServiceParameters = _service.GetServerTypeServiceParameters();
            var items = new List<SelectListItem>();
            foreach (var item in serverTypeServiceParameters)
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ad });

            return Json(items, JsonRequestBehavior.AllowGet); 
        }
    }
}