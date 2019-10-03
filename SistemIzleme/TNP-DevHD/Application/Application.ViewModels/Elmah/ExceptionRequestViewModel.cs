using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Elmah
{
    public class ExceptionRequestViewModel : BaseViewModel
    {
        [RResourceDisplayName("Elmah","LabelMailAddress")]
        public string MailAddress { get; set; }
        [RResourceDisplayName("Elmah", "LabelExceptionType")]
        public string ExceptionType { get; set; }
        [RResourceDisplayName("Elmah", "LabelExceptionNumber")]
        public int ExceptionNumber { get; set; }
        [RResourceDisplayName("Elmah", "LabelTimeInterval")]
        public int TimeInterval { get; set; }
        [RResourceDisplayName("Elmah", "LabelExceptionCount")]
        public Nullable<int> ExceptionCount { get; set; }
        [RResourceDisplayName("Elmah", "LabelApplicationExpression")]
        public string ApplicationExp1 { get; set; }

        [RResourceDisplayName("Elmah", "LabelApplicationExpression2")]
        public string ApplicationExp2 { get; set; }

    }
}
