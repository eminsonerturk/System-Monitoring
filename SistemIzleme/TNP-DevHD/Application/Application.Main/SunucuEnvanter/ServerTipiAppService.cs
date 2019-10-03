
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
    public class ServerTipiAppService : SunucuEnvanterDbAppService<AvServerTipi>, IServerTipiAppService
    {

        #region Constructor
        public ServerTipiAppService(ISunucuEnvanterDbRepository<AvServerTipi> rep)
            : base(rep)
        {
        }
        #endregion

        public long GetServerTypeId(string ServerTipi)
        {
            var _id = (from serverTipi in rep.Table
                       where (serverTipi.Ad.Equals(ServerTipi))
                       select serverTipi.Id
                ).ToList();

            var id = _id.FirstOrDefault();

            return id;
        }
        public IEnumerable<ServerTipiListViewModel> GetServerTypeServiceParameters()
        {
            var serverTipiList = (from serverTipi in rep.Table
                                orderby serverTipi.Ad ascending
                                select new ServerTipiListViewModel
                                {
                                    Id = serverTipi.Id,
                                    Ad = serverTipi.Ad
                                });
            return serverTipiList;
        }

        public override void PrepareEntityForCreateAfterValidate(AvServerTipi entity, List<string> errors)
        {
            base.PrepareEntityForCreateAfterValidate(entity, errors);
        }

    }
}
