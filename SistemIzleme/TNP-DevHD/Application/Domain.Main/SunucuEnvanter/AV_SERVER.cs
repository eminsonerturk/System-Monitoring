using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;
using Domain.Main.Envanter;

namespace Domain.Main.Envanter
{
    public partial class AvServer:REntity
    {
        public AvServer() 
        {
            this.ServerYoneticis = new List<AvYoneticiServer>();
            this.ServerUygulamalar = new List<AvServerUygulamalar>();
            this.ServerIliskiliSunucu = new List<AvServerIliskiliSunucu>();
        }

        public long LokasyonId { get; set; }
        public long ServerTipiId { get; set; }
        public long OperatingSystemId { get; set; }
        public string ServerIp { get; set; }
        public string ComputerName { get; set; }
        public string Aciklama { get; set; }
        public bool? PingYapilsinMi { get; set; }

        public virtual AvLokasyon Lokasyon { get; set; }
        public virtual AvServerTipi ServerTipi { get; set; }
        public virtual AvOperatingSystem OperatingSystem { get; set; }
        public virtual ICollection<AvYoneticiServer> ServerYoneticis { get; set; }
        public virtual ICollection<AvServerUygulamalar>  ServerUygulamalar { get; set; }
        public virtual ICollection<AvServerIliskiliSunucu> ServerIliskiliSunucu { get; set; }
    }
}
