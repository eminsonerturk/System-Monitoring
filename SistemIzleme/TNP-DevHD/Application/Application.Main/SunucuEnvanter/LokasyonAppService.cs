
using Application.Main.Interfaces.SunucuEnvanter;
using Application.ViewModels.Envanter;
using Data.Main;
using Domain.Main;
using Domain.Main.Envanter;
using Rota2.AppCore;
using Rota2.DomainCore;
using Rota2.DomainCore.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Main.SunucuEnvanter
{
    public class LokasyonAppService : SunucuEnvanterDbAppService<AvLokasyon>, ILokasyonAppService
    {

        #region Constructor
        public LokasyonAppService(ISunucuEnvanterDbRepository<AvLokasyon> rep)
            : base(rep)
        {
        }
        #endregion

        public long GetLocationId(string Lokasyon)
        {
            var _id = (from lokasyon in rep.Table
                       where (lokasyon.Ad.Equals(Lokasyon))
                       select lokasyon.Id
                ).ToList();

            var id = _id.FirstOrDefault();

            return id;
        }
        public IEnumerable<LokasyonListViewModel> GetLocationServiceParameters()
        {
            var lokasyonList = (from lokasyon in rep.Table
                                  orderby lokasyon.Ad ascending
                                  select new LokasyonListViewModel
                                  {
                                      Id = lokasyon.Id,
                                      Ad = lokasyon.Ad
                                  });
            return lokasyonList;
        }
    }
}
