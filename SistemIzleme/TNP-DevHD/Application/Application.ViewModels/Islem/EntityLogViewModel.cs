using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Elmah
{
    public class EntityLogViewModel : BaseViewModel
    {
        public int MessageLogId { get; set; }
        public string EntityName { get; set; }
        public decimal EntityIdValue { get; set; }
        public decimal AddedNew { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
