using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Envanter
{
    public class AV_INSTALLEDAPPLICATIONS
    {
        public AV_INSTALLEDAPPLICATIONS()
        {
            this.InstalledApplications = new List<AV_INSTALLEDAPPLICATIONS>();
        }

        public string AppList { get; set; }
        public virtual ICollection<AV_INSTALLEDAPPLICATIONS> InstalledApplications { get; set; }
    }
}
