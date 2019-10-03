using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationSolutionDto : RDtOEntity
    {
        public long Id { get; set; } 
        public long EntegrasyonFid { get; set; }
        public string SorunTanimi { get; set; }
        public string SorunCozumu { get; set; }
    }
}
