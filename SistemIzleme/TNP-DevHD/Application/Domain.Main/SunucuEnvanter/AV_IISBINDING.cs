using Domain.Main.Envanter;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Envanter
{
    public partial class AV_IISBINDING : REntity
    {
        public AV_IISBINDING()
        {
            this.IISSites = new List<AV_IISBINDING>();
        }

        public string SiteName { get; set; }

        public virtual ICollection<AV_IISBINDING> IISSites { get; set; }
    }
}
