using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.ViewModels.Envanter
{
    public class OperatingSystemSearchViewModel : OperatingSystemCrudViewModel
    {
    }

    public class OperatingSystemListViewModel : OperatingSystemCrudViewModel
    {
    }

    public class OperatingSystemSelectSearchViewModel : OperatingSystemCrudViewModel
    {
    }
    public class OperatingSystemSelectListViewModel : OperatingSystemCrudViewModel
    {
    }

    public class OperatingSystemCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelOperatingSystemAd")]
        public string Ad { get; set; }

    }
}
