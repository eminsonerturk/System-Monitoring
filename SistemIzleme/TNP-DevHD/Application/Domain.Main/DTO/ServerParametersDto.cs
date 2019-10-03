using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ServerParametersDto : RDtOEntity
    {
        public long Id { get; set; }
        public long SunucuFid { get; set; }
        public string Kod { get; set; }
        public string Deger { get; set; }
        public bool SifrelensinMi { get; set; }
        public bool? ServisKontrolEdilsinMi { get; set; }
    }
}
