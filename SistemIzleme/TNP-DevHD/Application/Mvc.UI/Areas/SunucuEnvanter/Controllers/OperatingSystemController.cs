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
    public class OperatingSystemController : Crud7Controller<AvOperatingSystem, OperatingSystemCrudViewModel, OperatingSystemSearchViewModel, OperatingSystemListViewModel, OperatingSystemSelectSearchViewModel, OperatingSystemSelectListViewModel>
    {
        IOperatingSystemAppService _service;
        public OperatingSystemController(IOperatingSystemAppService srv,
            IMapper<AvOperatingSystem, OperatingSystemCrudViewModel> crudMapper, IMapper<AvOperatingSystem, OperatingSystemListViewModel> listMapper, IMapper<AvOperatingSystem, OperatingSystemSelectListViewModel> selectListMapper)
            : base(srv, crudMapper, listMapper, selectListMapper)
        {
            _service = srv;
            CrudOnIndex = true;
            AutoFilter = true;
        }

        protected override System.Collections.Generic.IEnumerable<Application.ViewModels.Envanter.OperatingSystemSelectListViewModel> DoReadDataMapForSelectListMapper(System.Collections.Generic.IEnumerable<AvOperatingSystem> list)
        {
            List<OperatingSystemSelectListViewModel> viewModelList = new List<OperatingSystemSelectListViewModel>();
            foreach (var item in list)
            {
                OperatingSystemSelectListViewModel viewModel = new OperatingSystemSelectListViewModel();
                viewModel.Id = item.Id;
                viewModel.Ad = item.Ad;
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }
        public ActionResult GetOperatingSystemForDropdown()
        {
            IEnumerable<OperatingSystemListViewModel> operatinSystemServiceParameters = _service.GetOperatingSystemServiceParameters();
            var items = new List<SelectListItem>();
            foreach (var item in operatinSystemServiceParameters)
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ad });

            return Json(items, JsonRequestBehavior.AllowGet); 
        }

    }
}