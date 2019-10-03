using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ServerIntegrationDirectoryDto : RDtOEntity
    {
        public long Id { get; set; }
        public long SunucuEntegrasyonFid { get; set; }
        public long DefEntDizinTipiFid { get; set; }
        public long DefDizinYedeklemeTipiFid { get; set; }
        public string DizinDeger { get; set; }
    }
}
