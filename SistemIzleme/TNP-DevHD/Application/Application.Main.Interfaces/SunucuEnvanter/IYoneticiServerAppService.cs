using Application.ViewModels.Envanter;
using Domain.Main;
using Domain.Main.Envanter;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Interfaces.SunucuEnvanter
{
    public interface IYoneticiServerAppService : ISunucuEnvanterDbAppService<AvYoneticiServer>
     {
        void DeleteServerConnection(long Id);
         IEnumerable<YoneticiListViewModel> GetYoneticiServiceParameters(long Id);
         bool AddManagerToSpecificServer(AvServer server, AvYonetici yonetici);
         List<string> GetYoneticiListForSpecificServer(long Id);
         void RemoveYoneticiFromSpecificServer(long Id);
         void RemoveYoneticiFromSpecificServerByYoneticiId(long Id);
         void RemoveYoneticiFromSpecificServer(long Id, string Ad);
     }
}
