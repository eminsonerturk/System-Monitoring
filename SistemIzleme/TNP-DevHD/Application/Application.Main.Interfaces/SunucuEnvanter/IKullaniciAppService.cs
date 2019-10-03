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
    public interface ISunucuEnvanterKullaniciAppService : ISunucuEnvanterDbAppService<AvKullanici>
     {
         [RServiceInterceptorViewAttribute]
         AvKullanici GetUserByUserName(string userName);
     }
}
