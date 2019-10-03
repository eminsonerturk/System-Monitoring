using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Elmah
{
    public class EntityFieldLogViewModel : BaseViewModel
    {
        public int EntityLogId { get; set; }
        public string EntityFieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
