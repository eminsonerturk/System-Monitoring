using Application.ViewModels.MasterData.SelectAttributes;
using Rota2.MvcUtils;
using Rota2.MvcUtils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.ViewModels.Envanter
{
    public class YoneticiSearchViewModel : YoneticiCrudViewModel
    {
    }

    public class YoneticiListViewModel : YoneticiCrudViewModel
    {
    }

    public class YoneticiSelectSearchViewModel : YoneticiCrudViewModel
    {

    }

    public class YoneticiSelectListViewModel : YoneticiCrudViewModel
    {
    }

    public class YoneticiCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelYoneticiAdi")]
        public string Ad { get; set; }

        [RResourceDisplayName("Envanter", "LabelYoneticiEmail")]
        public string EMail { get; set; }

        [RResourceDisplayName("Envanter", "LabelYoneticiEMail")]
        [RADObjectWithEmailValueByEmailSelect(controlName: "ADEmail", showSelect: true)]
        public string ADEmail { get; set; }

    }
}
