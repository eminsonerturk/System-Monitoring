using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Models
{
    public partial class MessageLog : REntity
    {
        public decimal KullaniciId { get; set; }
        public string IslemAdi { get; set; }
        public DateTime RequestMessageDate { get; set; }
        public DateTime ResponseMessageDate { get; set; }
        public decimal ResponseStatusId { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
