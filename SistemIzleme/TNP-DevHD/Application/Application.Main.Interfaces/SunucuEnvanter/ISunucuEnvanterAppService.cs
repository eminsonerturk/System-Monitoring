using Domain.Main.Envanter;
using System.Collections.Generic;

namespace Application.Main.Interfaces.SunucuEnvanter
{
    public interface ISunucuEnvanterAppService : ISunucuEnvanterDbAppService<AvServerUygulamalar>
    {
        List<string> GetAppName(long Id);
        void AddServerApp(long Id, List<string> appNames);
        void DeleteServerApp(long Id);
    }
}
