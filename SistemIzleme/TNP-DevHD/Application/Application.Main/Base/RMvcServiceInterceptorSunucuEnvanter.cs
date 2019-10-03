using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.AppCore;
using Rota2.DataCore;
using Rota2.IoC;

namespace Application.Main.Base
{
    public class RMvcServiceInterceptorSunucuEnvanter : RMvcServiceInterceptor
    {
        protected override Rota2.DataCore.REfUnitOfWork ResolveUoW()
        {
            return (REfUnitOfWork)RDependencyFactory.Resolve<IQueryableUnitOfWork>("SunucuEnvanterDbContext");
        }
    }
}
