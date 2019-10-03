using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using System.Globalization;
using System.Reflection;
using Application.Main;
using System.IO;
using Domain.Main.Models;

namespace Mvc.UI.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}
