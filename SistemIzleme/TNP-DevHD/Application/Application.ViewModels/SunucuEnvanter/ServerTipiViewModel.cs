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
    public class ServerTipiSearchViewModel : ServerTipiCrudViewModel
    {
    }

    public class ServerTipiListViewModel : ServerTipiCrudViewModel
    {
    }

    public class ServerTipiSelectSearchViewModel : ServerTipiCrudViewModel
    {
    }
    public class ServerTipiSelectListViewModel : ServerTipiCrudViewModel
    {
    }

    public class ServerTipiCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelServerTipiAd")]
        public string Ad { get; set; }

    }
}
