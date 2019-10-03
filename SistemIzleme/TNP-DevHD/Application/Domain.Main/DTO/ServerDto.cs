using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ServerDto : RDtOEntity
    {
        public long Id { get; set; }
        public long? DefSunucuTipiFid { get; set; }
        public long? DefSunucuVersiyonFid { get; set; }
        public string SunucuAdi { get; set; }
        public string SunucuIP { get; set; }
        public string Domain { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string ServisAdresi { get; set; }
        public string SqlServerIP { get; set; }

        public List<ServerParametersDto> ServerParametersDtoList { get; set; }
    }
}
