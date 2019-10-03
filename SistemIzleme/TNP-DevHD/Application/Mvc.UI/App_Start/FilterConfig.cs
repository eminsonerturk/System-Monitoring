using System.Web;
using System.Web.Mvc;
using Rota2.MvcUtils.Attributes;

namespace Mvc.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            //filters.Add(new AntiForgeryAuthAttribute());
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}