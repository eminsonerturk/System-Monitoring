using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.DataCore;
using System.ComponentModel.DataAnnotations;
using Application.ViewModels.Islem.DropDownAttributes;
using Rota2.MvcUtils.Attributes;

namespace Application.ViewModels.Islem
{
    public class IslemLogSearchViewModel : BaseViewModel
    {
        [RResourceDisplayName("IslemLog", "LabelEntityName")]
        public string EntityName { get; set; }

        [RResourceDisplayName("IslemLog", "LabelEntityFieldName")]
        public string EntityFieldName { get; set; }

        [RResourceDisplayName("IslemLog", "LabelEntityIdValue")]
        [RInteger]
        public int EntityIdValue { get; set; }

        [RResourceDisplayName("IslemLog", "LabelOldValue")]
        public string OldValue { get; set; }

        [RResourceDisplayName("IslemLog", "LabelNewValue")]
        public string NewValue { get; set; }

        [RResourceDisplayName("IslemLog", "LabelAddedNew")]
        [OperationSelect(controlName: "AddedNew", showSelect: true)]
        public int? AddedNew { get; set; }

        [RResourceDisplayName("ReportServer", "LabelEnabledServer")]
        [ServerSelect(controlName: "EnabledServer", showSelect: false)]
        public int EnabledServer { get; set; }
    }

    public class IslemLogViewModel : BaseViewModel
    {
        [RResourceDisplayName("IslemLog", "LabelKullaniciAdi")]
        public string KullaniciAdi { get; set; }

        public long KullaniciId { get; set; }

        [RResourceDisplayName("IslemLog", "LabelIslemAdi")]
        public string IslemAdi { get; set; }

        [RResourceDisplayName("IslemLog", "LabelRequestMessageDate")]
        public System.DateTime RequestMessageDate { get; set; }

        [RResourceDisplayName("IslemLog", "LabelResponseStatusId")]
        public int ResponseStatusId { get; set; }

        [RResourceDisplayName("IslemLog", "LabelEntityName")]
        public string EntityName { get; set; }

        [RResourceDisplayName("IslemLog", "LabelEntityIdValue")]
        public int EntityIdValue { get; set; }

        [RResourceDisplayName("IslemLog", "LabelAddedNew")]
        public int AddedNew { get; set; }

        [RResourceDisplayName("IslemLog", "LabelEntityFieldName")]
        public string EntityFieldName { get; set; }

        [RResourceDisplayName("IslemLog", "LabelOldValue")]
        public string OldValue { get; set; }

        [RResourceDisplayName("IslemLog", "LabelNewValue")]
        public string NewValue { get; set; }
    }
}
