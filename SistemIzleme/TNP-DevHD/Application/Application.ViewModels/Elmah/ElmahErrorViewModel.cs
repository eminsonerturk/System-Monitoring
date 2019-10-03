using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.DataCore;
using System.ComponentModel.DataAnnotations;
using Application.ViewModels.Elmah.DropDownAttributes;

namespace Application.ViewModels.Elmah
{
    public class ElmahErrorSearchViewModel : BaseViewModel
    {
        [RResourceDisplayName("Elmah", "LabelErrorIdString")]
        public string ErrorIdString { get; set; }
        public System.Guid ErrorId { get; set; }
        [RResourceDisplayName("Elmah", "LabelHost")]
        public string Host { get; set; }
        [RResourceDisplayName("Elmah", "LabelType")]
        public string Type { get; set; }
        [RResourceDisplayName("Elmah", "LabelMessage")]
        public string Message { get; set; }
        [RResourceDisplayName("Elmah", "LabelSource")]
        public string Source { get; set; }
        [RResourceDisplayName("Elmah", "LabelUser")]
        public string User { get; set; }
        [RResourceDisplayName("Elmah", "LabelSequence")]
        public int Sequence { get; set; }

        [RResourceDisplayName("Elmah", "LabelMessageNotLike")]
        public string MessageNotLike { get; set; }

        [RResourceDisplayName("Elmah", "LabelApplication")]
        [ApplicationSelect(controlName: "Application", showSelect: true, isMultiSelect: true)]
        public List<string> Application { get; set; }

        [RResourceDisplayName("Elmah", "LabelStartDate")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [RResourceDisplayName("Elmah", "LabelEndDate")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [RResourceDisplayName("Elmah", "LabelKayitYaratmaTarihi")]
        public Nullable<System.DateTime> KayitYaratmaTarihi { get; set; }
        public bool IsAutoRefresh { get; set; }
    }

    public class ElmahErrorViewModel : BaseViewModel
    {
        public System.Guid ErrorId { get; set; }
        [RResourceDisplayName("Elmah", "LabelApplication")]
        public string Application { get; set; }
        [RResourceDisplayName("Elmah", "LabelHost")]
        public string Host { get; set; }
        [RResourceDisplayName("Elmah", "LabelType")]
        public string Type { get; set; }
        [RResourceDisplayName("Elmah", "LabelSource")]
        public string Source { get; set; }
        [RResourceDisplayName("Elmah", "LabelMessage")]
        public string Message { get; set; }
        [RResourceDisplayName("Elmah", "LabelUser")]
        public string User { get; set; }
        [RResourceDisplayName("Elmah", "LabelSequence")]
        public int Sequence { get; set; }
        [RResourceDisplayName("Elmah", "LabelKayitYaratmaTarihi")]
        public Nullable<System.DateTime> KayitYaratmaTarihi { get; set; }
    }
}
