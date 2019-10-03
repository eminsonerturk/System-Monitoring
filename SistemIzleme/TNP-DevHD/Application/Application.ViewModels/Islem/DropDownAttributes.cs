using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rota2.MvcUtils.Attributes;
using System.Web.Configuration;


namespace Application.ViewModels.Islem.DropDownAttributes
{


    public class EntityNameSelect : RSelectControlAttributeMetaDataAware
    {
        public EntityNameSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "EntityName";
            ActionName = "EntityReadData";
            TextField = "EntityName";
            ValueField = "EntityName";
            Name = controlName;
            IsAutoComplete = true;
            AutoCompleteMinLength = 3;
            LoadDataSourceOnce = false;
        }
    }

    public class EntityFieldNameSelect : RSelectControlAttributeMetaDataAware
    {
        public EntityFieldNameSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "EntityFieldName";
            ActionName = "EntityFieldReadData";
            TextField = "EntityFieldName";
            ValueField = "EntityFieldName";
            Name = controlName;
            IsAutoComplete = false;
            AutoCompleteMinLength = 3;
        }
    }

    public class ServerSelect : RSelectControlAttributeMetaDataAware
    {
        public ServerSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "IslemLog";
            ActionName = "CustomReadDataForServerSelect";
            Name = controlName;
            TextField = "Text";
            ValueField = "Value";
            LoadDataSourceOnce = true;

            //string[] YnaLog = (WebConfigurationManager.AppSettings["YnaLogDbConnectionString"].ToString()).Split('=', ';');
            //string[] YnaTestLog = (WebConfigurationManager.AppSettings["YnaLogTestDbConnectionString"].ToString()).Split('=', ';');

            //ShowOptionLabel = showSelect;
            //Name = controlName;
            //IsStaticContent = true;
            //StaticContent = new List<SelectListItem>() 
            //{
            //    new SelectListItem() {
            //        Text = YnaLog[1] + " ( Canlı )",
            //        Value = "0"
            //    },
            //    new SelectListItem() {
            //        Text = YnaTestLog[1] + " ( Test )",
            //        Value = "1"
            //    }
            //};
        }
    }

    public class OperationSelect : RSelectControlAttributeMetaDataAware
    {
        public OperationSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            Name = controlName;
            IsStaticContent = true;
            StaticContent = new List<SelectListItem>() 
            {
                new SelectListItem() {
                    Text = "Update",
                    Value = "0"
                },
                new SelectListItem() {
                    Text = "Insert",
                    Value = "1"
                },
                new SelectListItem() {
                    Text = "Delete",
                    Value = "2"
                }
            };
        }
    }
}
