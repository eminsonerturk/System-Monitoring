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
    public class LokasyonSearchViewModel : LokasyonCrudViewModel
    {
    }

    public class LokasyonListViewModel : LokasyonCrudViewModel
    {
    }

    public class LokasyonSelectSearchViewModel : LokasyonCrudViewModel
    {
    }
    public class LokasyonSelectListViewModel : LokasyonCrudViewModel
    {
    }

    public class LokasyonCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelLokasyonAd")]
        public string Ad { get; set; }

    }
}
