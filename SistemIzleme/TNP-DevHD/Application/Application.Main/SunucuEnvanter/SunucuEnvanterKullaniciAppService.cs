using Application.Main.Interfaces.SunucuEnvanter;
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
    public class SunucuEnvanterKullaniciAppService : SunucuEnvanterDbAppService<AvKullanici>, ISunucuEnvanterKullaniciAppService
    {

         #region Constructor
        public SunucuEnvanterKullaniciAppService(ISunucuEnvanterDbRepository<AvKullanici> rep)
            : base(rep)
        {
        }
        #endregion

        public AvKullanici GetUserByUserName(string userName)
        {
            return rep.GetFiltered(a => a.KullaniciAdi == userName).FirstOrDefault();
        }

        public override void PrepareEntityForCreateAfterValidate(AvKullanici entity, List<string> errors)
        {
            base.PrepareEntityForCreateAfterValidate(entity, errors);
        }
    }
}
