using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Main.Models;
using FluentValidation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Rota2.AppCore;
using Rota2.DataCore;
using Rota2.DomainCore;
using Rota2.IoC;
using Rota2.IoC.Unity.LifetimeManagers;

namespace Application.Main
{
    public static class AppDependencyRegister
    {
        public static void RegisterForUoW()
        {
            RDependencyFactory.Container.RegisterType<IQueryableUnitOfWork, ElmahDbContext>("ElmahDbContext", new PerExecutionContextLifetimeManager());
            RDependencyFactory.Container.RegisterType<IQueryableUnitOfWork, ReportDbContext>("ReportDbContext", new PerExecutionContextLifetimeManager());
            RDependencyFactory.Container.RegisterType<IQueryableUnitOfWork, IslemDbContext>("IslemDbContext", new PerExecutionContextLifetimeManager());
            RDependencyFactory.Container.RegisterType<IQueryableUnitOfWork, SunucuEnvanterDbContext>("SunucuEnvanterDbContext", new PerExecutionContextLifetimeManager());
        }
    }
}
