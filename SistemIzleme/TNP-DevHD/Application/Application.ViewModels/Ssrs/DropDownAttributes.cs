using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rota2.MvcUtils.Attributes;
using System.Web.Configuration;


namespace Application.ViewModels.Ssrs.DropDownAttributes
{

    public class ServerSelect : RSelectControlAttributeMetaDataAware
    {
        public ServerSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "ReportServer";
            ActionName = "CustomReadDataForServerSelect";
            Name = controlName;
            TextField = "Text";
            ValueField = "Value";
            LoadDataSourceOnce = true;
        }
    }
}
