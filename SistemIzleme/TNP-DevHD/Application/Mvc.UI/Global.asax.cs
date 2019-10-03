using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Rota2.CrossCuttingImp;
using Rota2.MvcUtils;
using FluentValidation;
using FluentValidation.Mvc;
using Rota2.CrossCutting;
using Rota2.IoC;
using Rota2.DomainCore;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using Rota2.AppCore;
using Mvc.UI.Controllers;
using Rota2.DataCore;
using Rota2.Context;
using Rota2.IoC.Unity.LifetimeManagers;
using Application.Main;
using System.Data.Entity;
using Rota2.MvcUtils.Mappers;
using System.Reflection;
using System.Web.Security;
using System.Security.Principal;
using System.Collections.Specialized;
using Application.Main.Interfaces;
using Application.Main.Base;
using System.Globalization;
using System.Threading;
using Data.Main;
using Rota2.Objects;
using System.DirectoryServices.AccountManagement;
using Domain.Main.Envanter;
using Rota2.Utils.Helpers;
using System.DirectoryServices;
using Application.Main.Interfaces.SunucuEnvanter;

namespace Mvc.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //ROTA2 BEGIN
            //Database.SetInitializer<DemoDbContext>(new System.Data.Entity.CreateDatabaseIfNotExists<DemoDbContext>());
            //Database.SetInitializer<DemoDbContext>(null);
            Rota2Config.SetMvcDefaultsFactories();
            Rota2Config.AddInterceptionExtension();
            Rota2Config.RegisterRota2HelpersForDependency();
            Rota2MvcConfig.RegisterControllersForDependency("Mvc.UI", "Rota2.Mvc5Utils");
            Rota2Config.RegisterAppServicesForDependency("Application.Main.Interfaces", "Application.Main", typeof(IElmahDbAppService<>), new InterceptionBehavior<RMvcServiceInterceptorElmah>());
            Rota2Config.RegisterAppServicesForDependency("Application.Main.Interfaces", "Application.Main", typeof(IReportDbAppService<>), new InterceptionBehavior<RMvcServiceInterceptorReport>());
            Rota2Config.RegisterAppServicesForDependency("Application.Main.Interfaces", "Application.Main", typeof(IIslemDbAppService<>), new InterceptionBehavior<RMvcServiceInterceptorIslem>());
            Rota2Config.RegisterAppServicesForDependency("Application.Main.Interfaces", "Application.Main", typeof(ISunucuEnvanterDbAppService<>), new InterceptionBehavior<RMvcServiceInterceptorSunucuEnvanter>());
            Rota2Config.RegisterRepositoriesForDependency(typeof(IIslemDbRepository<>), typeof(IslemDbRepository<>));
            Rota2Config.RegisterRepositoriesForDependency(typeof(IElmahDbRepository<>), typeof(ElmahDbRepository<>));
            Rota2Config.RegisterRepositoriesForDependency(typeof(IReportDbRepository<>), typeof(ReportDbRepository<>));
            Rota2Config.RegisterRepositoriesForDependency(typeof(ISunucuEnvanterDbRepository<>), typeof(SunucuEnvanterDbRepository<>));
            Rota2Config.RegisterRepositoriesForDependency("Domain.Main", "Data.Main");
            Rota2Config.RegisterFluentValidatorsForDependency("Mvc.UI", "Domain.Main");
            AppDependencyRegister.RegisterForUoW();
            MapperConfig.SetMaps();

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new UnityFluentValidationFactory()));
            ControllerBuilder.Current.SetControllerFactory(typeof(RHttpContextControllerFactory));
            //ROTA2 END

            RCustomModelBinderRegister.RegisterCurrentCultureDateTimeModelBinder();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string userName = User.Identity.Name;
            userName = userName.Substring(userName.LastIndexOf(@"\") + 1);
            PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(yourDomain, userName);

            if (userPrincipal != null)
            {
                Application.Main.Interfaces.SunucuEnvanter.

                ISunucuEnvanterKullaniciAppService kullaniciAppService = RDependencyFactory.Resolve<ISunucuEnvanterKullaniciAppService>();
                AvKullanici user = kullaniciAppService.GetUserByUserName(userName);
                if (user != null)
                {//user is admin
                    RSession.UserInfo = new UserInfo() { UserName = userName, UserId = user.Id, EMail = userPrincipal.EmailAddress, NameSurname = userPrincipal.DisplayName };
                    SetGroupInfos(userName);
                    Session["IsAdmin"] = user.IsAdmin;
                    Session["EMail"] = user.KullaniciEMail;
                }
                else
                {//user is not admin
                    RSession.UserInfo = new UserInfo() { UserName = userName, UserId = 9999, EMail = userPrincipal.EmailAddress, NameSurname = userPrincipal.DisplayName };
                    SetGroupInfos(userName);
                    Session["IsAdmin"] = false;
                    Session["EMail"] = userPrincipal.EmailAddress;
                }
            }
            else
            {
                Response.Redirect("/Home/AccessDenied");
            }
        }

        private void SetGroupInfos(string userName)
        {
            List<string> sidResult = new List<string>();
            List<string> mailResult = new List<string>();
            DirectorySearcher searcher = new System.DirectoryServices.DirectorySearcher();
            searcher.Filter = "(&((&(objectcategory=person)"
                + "(objectclass=user)))(sAMAccountName=*" + userName + "*))";
            System.DirectoryServices.SearchResultCollection userlist = searcher.FindAll();
            for (int i = 0; i < userlist.Count; i++)
            {
                var coll = userlist[i].Properties["memberOf"];
                foreach (var gr in coll)
                {
                    DirectoryEntry deUser = new DirectoryEntry("LDAP://" + gr);
                    SecurityIdentifier sid = new SecurityIdentifier(deUser.Properties["objectSid"][0] as byte[], 0);
                    sidResult.Add(sid.Value);
                    if (deUser.Properties["mail"].Count > 0)
                        mailResult.Add(deUser.Properties["mail"][0].ToString());
                }
            }
            RSession.ADGroupMailAdresses = mailResult;
            RSession.ADGroupSIDs = sidResult;
        }

        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.Session != null)
        //    {
        //        CultureInfo cultureInfo = (CultureInfo)this.Session["Culture"];
        //        if (cultureInfo == null)
        //        {
        //            string langName = "en";

        //            if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
        //                langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);

        //            cultureInfo = new CultureInfo(langName);
        //            this.Session["Culture"] = cultureInfo;
        //        }

        //        //Finally setting culture for each request
        //        Thread.CurrentThread.CurrentUICulture = cultureInfo;
        //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        //    }
        //}
    }
}