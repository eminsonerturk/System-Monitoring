using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationPartyDto : RDtOEntity
    {
        public long Id { get; set; }
        public long EntegrasyonFid { get; set; }
        public long PartiFid { get; set; }
        public long DefEntPartiRolFid { get; set; }
        public bool EpostaBildirimi { get; set; }
        public bool SmsBildirimi { get; set; }

        public List<IntegrationPartyLogHistoryTypeDto> IntegrationPartyLogHistoryTypeDtoList { get; set; }
    }
}
