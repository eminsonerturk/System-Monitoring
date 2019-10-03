
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
    public class OperatingSystemAppService : SunucuEnvanterDbAppService<AvOperatingSystem>, IOperatingSystemAppService
    {

        #region Constructor
        public OperatingSystemAppService(ISunucuEnvanterDbRepository<AvOperatingSystem> rep)
            : base(rep)
        {
        }
        #endregion

        public long GetOperatingSystemId(string OperatingSystem)
        {
            var _id = (from operatingSystem in rep.Table
                       where (operatingSystem.Ad.Equals(OperatingSystem))
                       select operatingSystem.Id
               ).ToList();

            var id = _id.FirstOrDefault();

            return id;
        }
        public IEnumerable<OperatingSystemListViewModel> GetOperatingSystemServiceParameters()
        {
            var osList = (from os in rep.Table
                                orderby os.Ad ascending
                                select new OperatingSystemListViewModel
                                {
                                    Id = os.Id,
                                    Ad = os.Ad
                                });
            return osList;
        }
    }
}
