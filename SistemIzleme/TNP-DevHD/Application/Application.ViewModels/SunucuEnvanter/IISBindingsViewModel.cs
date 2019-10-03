using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Envanter
{
    public class IISBindingsViewModel : IISCrudViewModel
    {
    }

    public class IISCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "SiteAdi")]
        public string SiteName { get; set; }

    }
}
