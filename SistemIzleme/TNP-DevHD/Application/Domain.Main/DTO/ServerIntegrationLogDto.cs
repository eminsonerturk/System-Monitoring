using Domain.Main.Models;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ServerIntegrationLogDto : RDtOEntity
    {
        public long Id { get; set; }
        public long SunucuEntegrasyonFid { get; set; }
        public string GelenDosyaAdi { get; set; }
        public decimal? GelenDosyaBoyutuKb { get; set; }
        public byte[] GelenDosya { get; set; }
        public DateTime IslemBaslamaTarihi { get; set; }
        public DateTime? IslemBitisTarihi { get; set; }
        public long DefEntDurumFid { get; set; }
        public string Guid { get; set; }
        public string ReferenceGuid { get; set; }
        public decimal CalSuresi { get; set; }
        public decimal YenidenIslemeAlindiMi { get; set; }
        public decimal DosyaDegismisMi { get; set; }
        public decimal? AktifMi { get; set; }
        public bool? OtoYenidenIslemYapilsinMi { get; set; }
        public string AnlikDurumu { get; set; }
        public string PasifYapanKullanici { get; set; }
        public int? HataTarihceSayisi { get; set; }
        public int? UyariTarihceSayisi { get; set; }
        public int? SistemDonusumTarihceSayisi { get; set; }
        public int? BilgiTarihceSayisi { get; set; }

        
    }
}
