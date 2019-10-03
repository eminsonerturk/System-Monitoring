using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Models
{
    public partial class EntityFieldLog : REntity
    {
        [Key]
        public int EntityLogId { get; set; }
        public string EntityFieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
