using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;
using Domain.Main.Envanter;

namespace Domain.Main.Envanter
{
    public partial class AvServerTipi:REntity
    {
        public AvServerTipi() 
        {
            this.Server = new List<AvServer>();
        }
        public string Ad { get; set; }
        public virtual ICollection<AvServer> Server { get; set; }
    }
}
