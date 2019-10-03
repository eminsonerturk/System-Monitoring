using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class IntegrationSearchDto : REntity
    {
        public long DefEntCalTipiFid { get; set; }
        public long DefProjeStatusFid { get; set; }
        public long DefEntPlatformFid { get; set; }
        public string Kod { get; set; }
        public string Ad { get; set; }
        public DateTime? ProjeBaslangicTarihi { get; set; }
        public DateTime? ProjeBitisTarihi { get; set; }
        public int ProjeGerceklestirimYuzdesi { get; set; }
        public int DizinYedeklemeGunLimiti { get; set; }
        public int YedekSilmeGunLimiti { get; set; }
        public int LogArsivlemeGunLimiti { get; set; }
        public int LogArsivSilmeGunLimiti { get; set; }
    }
}
