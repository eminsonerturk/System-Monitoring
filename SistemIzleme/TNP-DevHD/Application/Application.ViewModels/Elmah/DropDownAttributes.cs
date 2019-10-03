using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rota2.MvcUtils.Attributes;


namespace Application.ViewModels.Elmah.DropDownAttributes
{

    public class ApplicationSelect : RSelectControlAttributeMetaDataAware
    {
        public ApplicationSelect(string controlName, bool showSelect,bool isMultiSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "ElmahError";
            ActionName = "ApplicationReadData";
            Name = controlName;
            IsMultiSelect = isMultiSelect;
            AutoCompleteMinLength = 0;
            LoadDataSourceOnce = true;
        }
    }
}
