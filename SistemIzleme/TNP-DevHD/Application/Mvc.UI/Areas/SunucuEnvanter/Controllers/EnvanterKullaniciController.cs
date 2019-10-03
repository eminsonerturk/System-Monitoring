using Application.Main.Interfaces;
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

namespace Mvc.UI.Areas.Envanter.Controllers
{
    public class EnvanterKullaniciController : Crud7Controller<AvKullanici, KullaniciCrudViewModel, KullaniciSearchViewModel, KullaniciListViewModel, KullaniciSelectSearchViewModel, KullaniciSelectListViewModel>
    {

        public EnvanterKullaniciController(IKullaniciAppService service ,Application.Main.Interfaces.SunucuEnvanter.ISunucuEnvanterKullaniciAppService srv,
            IMapper<AvKullanici, KullaniciCrudViewModel> crudMapper, IMapper<AvKullanici, KullaniciListViewModel> listMapper, IMapper<AvKullanici, KullaniciSelectListViewModel> selectListMapper)
            : base(srv, crudMapper, listMapper, selectListMapper)
        {
            CrudOnIndex = true;
            AutoFilter = true;
        }

        protected override void PrepareViewModelBeforeSave(KullaniciCrudViewModel model)
        {
            model.CreatedByUserId = 10027;
            model.ModifiedByUserId = 10027;
            model.CreatedDate = System.DateTime.Now;
            model.ModifiedDate = System.DateTime.Now;
            model.IsActive = true;
        }

    }
}