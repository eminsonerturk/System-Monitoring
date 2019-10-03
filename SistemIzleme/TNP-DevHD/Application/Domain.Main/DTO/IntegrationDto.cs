using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationDto : RDtOEntity
    {
        public long Id { get; set; }
        public long DefEntCalTipiFid { get; set; }
        public long DefProjeStatusFid { get; set; }
        public long DefEntPlatformFid { get; set; }
        public string Kod { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime? ProjeBaslangicTarihi { get; set; }
        public DateTime? ProjeBitisTarihi { get; set; }
        public int ProjeGerceklestirimYuzdesi { get; set; }
        public int DizinYedeklemeGunLimiti { get; set; }
        public int YedekSilmeGunLimiti { get; set; }
        public int LogArsivlemeGunLimiti { get; set; }
        public int LogArsivSilmeGunLimiti { get; set; }

        public string CodeAndName { get; set; }
        public string WorkTypeDescription { get; set; }
        public string PlatformDescription { get; set; }

        public List<IntegrationPartyDto> IntegrationPartyDtoList { get; set; }
        public List<IntegrationSolutionDto> IntegrationSolutionDtoList { get; set; }
        public List<IntegrationSystemDto> IntegrationSystemDtoList { get; set; }
        public List<IntegrationLogTypeDto> IntegrationLogTypeDtoList { get; set; }
        public List<IntegrationArtifactDto> IntegrationArtifactDtoList { get; set; }
        public List<IntegrationNameDto> IntegrationNameDtoList { get; set; }
        public List<IntegrationRepeatHistoryTypeDto> IntegrationRepeatHistoryTypeDtoList { get; set; }
    }
}
