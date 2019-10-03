using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ServerIntegrationDto : RDtOEntity
    {
        public long Id { get; set; }
        public long EntegrasyonFid { get; set; }
        public long SunucuFid { get; set; }
        public bool? LoglansinMi { get; set; }
        public DateTime? CalismaZamaniBaslangicSaati { get; set; }
        public DateTime? CalismaZamaniBitisSaati { get; set; }
        public int CalismaArasiBeklemeSuresi { get; set; }
        public int MaksimumCalismamaSuresiMesaiDisi { get; set; }
        public int? MaksimumCalismaSuresi { get; set; }
        public int MaksimumCalismamaSuresi { get; set; }
        public int? MaksimumAnlikAkisSayisi { get; set; }
        public bool? OtomatikTekrarIslemeAlinsinMi { get; set; }
        public int? OtomatikTekrarIslemBeklemeSuresi { get; set; }
        public int? OtomatikTekrarIslemDenemeSayi { get; set; }

        public List<ServerIntegrationParametersDto> ServerIntegrationParametersDtoList { get; set; }
        public List<ServerIntegrationDirectoryDto> ServerIntegrationDirectoryDtoList { get; set; }
    }
}
