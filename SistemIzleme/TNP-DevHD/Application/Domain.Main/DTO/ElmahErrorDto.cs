using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.DomainCore;

namespace Domain.Main.DTO
{
    public class ElmahErrorDto : REntity
    {
        public System.Guid Errorid { get; set; }
        public string Application { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
        public int Sequence { get; set; }
        public Nullable<System.DateTime> Kayityaratmatarihi { get; set; }
    }
}
