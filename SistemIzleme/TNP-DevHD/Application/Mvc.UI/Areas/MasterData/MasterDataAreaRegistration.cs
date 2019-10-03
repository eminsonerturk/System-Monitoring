﻿using System.Web.Mvc;

namespace Mvc.UI.Areas.MasterData
{
    public class MasterDataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MasterData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MasterData_default",
                "MasterData/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
