using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rota2.MvcUtils.Attributes;

namespace Application.ViewModels.MasterData.SelectAttributes
{    
    public class ServerSelect : RSelectControlAttributeMetaDataAware
    {
        public ServerSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Server";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "ServerIp";
            Name = controlName;
        }

        public ServerSelect(string controlName, bool showSelect, bool isAutoComplete)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Server";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "ServerIp";
            Name = controlName;
            IsAutoComplete = isAutoComplete;
            AutoCompleteMinLength = 1;
        }
    }
    public class KullaniciSelect : RSelectControlAttributeMetaDataAware
    {
        public KullaniciSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Kullanici";
            ActionName = "ReadDataForSelect";
            TextField = "KullaniciAd";
            ValueField = "Id";
            Name = controlName;
        }

        public KullaniciSelect(string controlName, bool showSelect, bool isAutoComplete)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Kullanici";
            ActionName = "ReadDataForSelect";
            TextField = "KullaniciAd";
            ValueField = "Id";
            Name = controlName;
            IsAutoComplete = isAutoComplete;
            AutoCompleteMinLength = 2;
        }
    }
    public class ServerTipiSelect : RSelectControlAttributeMetaDataAware
    {
        public ServerTipiSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "ServerTipi";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
        }

        public ServerTipiSelect(string controlName, bool showSelect, bool isAutoComplete)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "ServerTipi";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
            IsAutoComplete = isAutoComplete;
            AutoCompleteMinLength = 1;
        }
    }
    public class LokasyonSelect : RSelectControlAttributeMetaDataAware
    {
        public LokasyonSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Lokasyon";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
        }

        public LokasyonSelect(string controlName, bool showSelect, bool isAutoComplete)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Lokasyon";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
            IsAutoComplete = isAutoComplete;
            AutoCompleteMinLength = 1;
        }
    }
    public class OperatingSystemSelect : RSelectControlAttributeMetaDataAware
    {
        public OperatingSystemSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "OperatingSystem";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
        }

        public OperatingSystemSelect(string controlName, bool showSelect, bool isAutoComplete)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "OperatingSystem";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
            IsAutoComplete = isAutoComplete;
            AutoCompleteMinLength = 1;
        }
    }
    public class YoneticiSelect : RSelectControlAttributeMetaDataAware
    {
        public YoneticiSelect(string controlName, bool showSelect)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Yonetici";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
        }

        public YoneticiSelect(string controlName, bool showSelect, bool isAutoComplete)
        {
            ShowOptionLabel = showSelect;
            ControllerName = "Yonetici";
            ActionName = "ReadDataForSelect";
            TextField = "Ad";
            ValueField = "Id";
            Name = controlName;
            IsAutoComplete = isAutoComplete;
            AutoCompleteMinLength = 1;
        }
    }
    
}
