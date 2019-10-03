using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces.SunucuEnvanter
{
    class IIISBindingList
    {
        public string ServerIp { get; set; }

        public string SiteName { get; set; }

        public string AppPoolName { get; set; }

        public string Type { get; set; }

        public string Hostname { get; set; }

        public string Port { get; set; }
    }
}
