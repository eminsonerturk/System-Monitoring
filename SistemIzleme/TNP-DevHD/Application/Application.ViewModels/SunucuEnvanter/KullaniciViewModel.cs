using Application.ViewModels.MasterData.SelectAttributes;
using Rota2.DataCore;
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
    public class KullaniciSearchViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelKullaniciAd")]
        public string KullaniciAd { get; set; }

        [RResourceDisplayName("Envanter", "LabelKullaniciEmail")]
        public string KullaniciEMail { get; set; }

        [FieldMapAttribute(DontUseInAutomaticFilter = true)]
        public List<string> GroupSids { get; set; }

        [FieldMapAttribute(DontUseInAutomaticFilter = true)]
        public string UserEmail { get; set; }

        [RResourceDisplayName("Envanter", "LabelIsAdmin")]
        [RBooleanSelect(controlName: "IsAdmin", showSelect: true, isStaticContent: true)]
        public bool? IsAdmin { get; set; }
    }
    public class KullaniciListViewModel : KullaniciCrudViewModel
    {
    }
    public class KullaniciSelectSearchViewModel : KullaniciCrudViewModel
    {
    }
    public class KullaniciSelectListViewModel : KullaniciCrudViewModel
    {
    }
    public class KullaniciCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelKullaniciAd")]
        public string KullaniciAd { get; set; }

        [RResourceDisplayName("Envanter", "LabelKullaniciEmail")]
        public string KullaniciEMail { get; set; }

        [RResourceDisplayName("Envanter", "LabelIsAdmin")]
        [RBooleanSelect(controlName: "IsAdmin", showSelect: true, isStaticContent: true)]
        public bool? IsAdmin { get; set; }

        //[RResourceDisplayName("Envanter", "LabelKullaniciEmail")]
        //[RADObjectWithEmailValueByEmailSelect(controlName: "ADEmail", showSelect: true)]
        //public string ADEmail { get; set; }
    }
}
