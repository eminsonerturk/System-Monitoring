using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ServerIntegrationParametersDto : RDtOEntity
    {
        public long Id { get; set; }
        public long SunucuEntegrasyonFid { get; set; }
        public string Kod { get; set; }
        public string Deger { get; set; }
    }
}
