using System.Web.Mvc;

namespace Mvc.UI.Areas.Envanter
{
    public class EnvanterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SunucuEnvanter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SunucuEnvanter_default",
                "SunucuEnvanter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional } //cc
            );
        }
    }
}