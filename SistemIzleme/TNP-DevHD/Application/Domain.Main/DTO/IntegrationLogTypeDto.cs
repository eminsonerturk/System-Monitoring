using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationLogTypeDto : RDtOEntity
    {
        public long Id { get; set; }
        public long EntegrasyonFid { get; set; }
        public long LogEkBilgiTipiFid { get; set; }
        public string Xpath { get; set; }
        public string VeriTipi { get; set; }
        public bool? LoglansinMi { get; set; }
    }
}
