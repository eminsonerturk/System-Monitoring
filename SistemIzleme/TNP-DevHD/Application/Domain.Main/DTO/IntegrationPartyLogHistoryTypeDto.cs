using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationPartyLogHistoryTypeDto : RDtOEntity
    {
        public long Id { get; set; }
        public long EntegrasyonPartiFid { get; set; }
        public long DefEntLogTarihceTipiFid { get; set; }
    }
}
