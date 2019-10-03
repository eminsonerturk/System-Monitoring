using Domain.Main.Envanter;
using System.Collections.Generic;

namespace Application.Main.Interfaces.SunucuEnvanter
{
    public interface IYoneticiAppService : ISunucuEnvanterDbAppService<AvYonetici>
    {
        AvYonetici GetYoneticiById(long Id);
        List<string> GetAllYoneticiAdi();
        List<AvYonetici> GetAllYonetici();
        AvYonetici GetYonetici(string Ad);
        void CreateYonetici(string Ad, string EMail);
        void UpdateYonetici(long Id, string Ad, string EMail);
        void DeleteYonetici(long Id);
    }
}
