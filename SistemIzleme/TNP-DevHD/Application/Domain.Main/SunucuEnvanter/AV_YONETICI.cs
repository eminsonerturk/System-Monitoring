using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;
using Domain.Main.Envanter;

namespace Domain.Main.Envanter
{
    public partial class AvYonetici:REntity
    {
        public AvYonetici()
        {
            this.YoneticiServers = new List<AvYoneticiServer>();
        }

        public string Ad { get; set; }
        public string EMail { get; set; }

        public virtual ICollection<AvYoneticiServer> YoneticiServers { get; set; }

    }
}
