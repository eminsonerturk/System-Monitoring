using Application.ViewModels.Ssrs.DropDownAttributes;
using Rota2.DataCore;
using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ssrs
{
    public class ReportServerSearchViewModel : BaseViewModel
    {
        [RResourceDisplayName("ReportServer", "LabelReportName")]
        [FieldMapAttribute(EntityField = "ItemPath", Operand = "EndsWith")]
        public string ReportName { get; set; }

        [RResourceDisplayName("ReportServer", "LabelReportFolder")]
        [FieldMapAttribute(EntityField = "ItemPath", Operand = "StartsWith")]
        public string ReportFolder { get; set; }

        [FieldMapAttribute(EntityField = "LogEntryId", Operand = ">")]
        public int LogEntryId { get; set; }

        [RResourceDisplayName("ReportServer", "LabelStartDate")]
        [FieldMapAttribute(EntityField = "TimeStart", Operand = ">=")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [RResourceDisplayName("ReportServer", "LabelEndDate")]
        [FieldMapAttribute(EntityField = "TimeStart", Operand = "<=")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [RResourceDisplayName("ReportServer", "LabelEnabledServer")]
        [ServerSelect(controlName: "EnabledServer", showSelect: false)]
        public int EnabledServer { get; set; }

        public bool IsAutoRefresh { get; set; }

		[RResourceDisplayName("ReportServer", "LabelUserName")]
		[FieldMapAttribute(EntityField = "UserName", Operand = "StartsWith")]
		public string UserName { get; set; }
	}

    public class ReportServerViewModel : BaseViewModel
    {
        [RResourceDisplayName("ReportServer", "LabelUserName")]
        public string UserName { get; set; }
        [RResourceDisplayName("ReportServer", "LabelFormat")]
        public string Format { get; set; }
        [RResourceDisplayName("ReportServer", "LabelParameters")]
        public string Parameters { get; set; }
        [RResourceDisplayName("ReportServer", "LabelTimeStart")]
        public System.DateTime TimeStart { get; set; }
        [RResourceDisplayName("ReportServer", "LabelTimeEnd")]
        public System.DateTime TimeEnd { get; set; }
        public long LogEntryId { get; set; }
        [RResourceDisplayName("ReportServer", "LabelReportName")]
        public string ReportName { get; set; }
        [RResourceDisplayName("ReportServer", "LabelReportFolder")]
        public string ReportFolder { get; set; }
        [RResourceDisplayName("ReportServer", "LabelTotalTime")]
        public double TotalTime { get; set; }
    }
}
