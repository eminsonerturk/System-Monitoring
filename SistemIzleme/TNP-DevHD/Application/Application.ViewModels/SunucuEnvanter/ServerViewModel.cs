using Application.ViewModels.MasterData.SelectAttributes;
using Rota2.MvcUtils;
using Rota2.MvcUtils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.ViewModels.Envanter
{
    public class ServerSearchViewModel : ServerCrudViewModel
    {
    }

    public class ServerListViewModel : ServerCrudViewModel
    {

    }

    public class ServerSelectSearchViewModel : ServerSelectListViewModel
    {

    }
    public class ServerSelectListViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelServerIp")]
        public string ServerIp { get; set; }
    }

    public class ServerCrudViewModel : BaseViewModel
    {
        [RResourceDisplayName("Envanter", "LabelServerIp")]
        public string ServerIp { get; set; }

        [RResourceDisplayName("Envanter", "LabelComputerName")]
        public string ComputerName { get; set; }

        [RResourceDisplayName("Envanter", "LabelAciklama")]
        public string Aciklama { get; set; }
        
        [RResourceDisplayName("Envanter", "LabelLokasyonAd")]
        [LokasyonSelect(controlName: "LokasyonId", showSelect: true)]
        public long LokasyonId { get; set; }
        public string LokasyonAd { get; set; }

        [RResourceDisplayName("Envanter", "LabelServerTipiAd")]
        [ServerTipiSelect(controlName: "ServerTipiId", showSelect: true)]
        public long ServerTipiId { get; set; }
        public string ServerTipiAd { get; set; }

        [RResourceDisplayName("Envanter", "LabelOperatingSystemAd")]
        [OperatingSystemSelect(controlName: "OperatingSystemId", showSelect: true)]
        public long OperatingSystemId { get; set; }
        public string OperatingSystemAd { get; set; }

        [RResourceDisplayName("Envanter", "LabelPingYapilsinMi")]
        [RBooleanSelect(controlName: "LabelPingYapilsinMi", showSelect: true, isStaticContent: true)]
        public bool? PingYapilsinMi { get; set; }
    }
}
