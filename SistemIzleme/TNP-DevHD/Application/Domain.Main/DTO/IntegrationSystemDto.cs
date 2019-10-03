using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationSystemDto : RDtOEntity
    {
        public long Id { get; set; }
        public long EntegrasyonFid { get; set; }
        public long SistemFid { get; set; }
        public long DefEntIletisimModeliFid { get; set; }
        public long DefEntVeriTipiFid { get; set; }
        public long DefVeriAkisYonuFid { get; set; }
        public string Aciklama { get; set; }
    }
}
