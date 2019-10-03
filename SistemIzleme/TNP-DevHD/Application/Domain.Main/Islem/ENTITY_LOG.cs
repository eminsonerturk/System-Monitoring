using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Models
{
    public partial class EntityLog : REntity
    {
        public int MessageLogId { get; set; }
        public string EntityName { get; set; }
        public decimal EntityIdValue { get; set; }
        public decimal AddedNew { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
