using Application.Main.Interfaces;
using Application.ViewModels.Envanter;
using Domain.Main;
using Domain.Main.Envanter;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using Rota2.MvcUtils.Mappers;
using Rota2.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Application.Resources;
using Application.Main.Interfaces.SunucuEnvanter;
using Rota2.Objects.Controllers;

namespace Mvc.UI.Areas.Envanter.Controllers
{
    public class YoneticiController : Crud7Controller<AvYonetici, YoneticiCrudViewModel, YoneticiSearchViewModel, YoneticiListViewModel, YoneticiSelectSearchViewModel, YoneticiSelectListViewModel>
    {
        #region constructor

        IYoneticiAppService _service;
        Application.Main.Interfaces.SunucuEnvanter.ISunucuEnvanterServerAppService _serverService;
        IYoneticiServerAppService _yoneticiServerService;
        public YoneticiController(IYoneticiAppService srv,
            IMapper<AvYonetici, YoneticiCrudViewModel> crudMapper, IMapper<AvYonetici, YoneticiListViewModel> listMapper, IMapper<AvYonetici, YoneticiSelectListViewModel> selectListMapper,
            IYoneticiServerAppService yoneticiServerService, Application.Main.Interfaces.SunucuEnvanter.ISunucuEnvanterServerAppService serverService)
            : base(srv, crudMapper, listMapper, selectListMapper)
        {
            _service = srv;
            _serverService = serverService;
            _yoneticiServerService = yoneticiServerService;
            CrudOnIndex = true;
            AutoFilter = true;
        }

        #endregion

        #region crud methods
        
        public ActionResult GetYoneticiById(long Id)
        {
            List<string> _Yonetici = new List<string>();
            AvYonetici Yonetici = _service.GetYoneticiById(Id);
            _Yonetici.Add(Yonetici.Ad);
            _Yonetici.Add(Yonetici.EMail);

            return Json(new { _Yonetici = _Yonetici }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GridReadYoneticiParameters(long Id, [DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<YoneticiListViewModel> yoneticiServiceParameters = _yoneticiServerService.GetYoneticiServiceParameters(Id);
            return Json(yoneticiServiceParameters.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllYoneticiForDropDown()
        {
            List<string> YoneticiList = new List<string>();
            YoneticiList = _service.GetAllYoneticiAdi();
            return Json(new { YoneticiList = YoneticiList }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddYoneticiToSpecificServer(long _Id, string _Ad)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageAddManager);
            AvServer _server = _serverService.GetServer(_Id);
            AvYonetici _yonetici = _service.GetYonetici(_Ad);
            bool eklendi = _yoneticiServerService.AddManagerToSpecificServer(_server, _yonetici);

            if (!eklendi)
            {
                sJRS.Statu = Application.Enumerations.ServiceManagement.jsonResultFailLabel;
                sJRS.SuccessMessages.Remove(Application.Resources.Control.MessageAddManager);
                sJRS.SuccessMessages.Add(Application.Resources.Control.MessageCouldNotAddManager);
            }

            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateYonetici(string Ad, string EMail)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageCreateManager);

            bool isExistSorumlu = false;
            List<AvYonetici> YoneticiList = new List<AvYonetici>();
            YoneticiList = _service.GetAllYonetici();
            AvYonetici updated = null;
            for(int i = 0; i < YoneticiList.Count; i++)
            {
                if (Ad == YoneticiList[i].Ad || EMail == YoneticiList[i].EMail)
                {
                    updated = YoneticiList[i];
                    isExistSorumlu = true;
                    break;
                }
            }
            if (isExistSorumlu == true)
            {
                _service.UpdateYonetici(updated.Id, Ad, EMail);
                return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
            }
            else
            {
                _service.CreateYonetici(Ad, EMail);
                return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetYoneticiListForSpecificServer(long Id)
        {
            List<string> YoneticiList = new List<string>();
            YoneticiList = _yoneticiServerService.GetYoneticiListForSpecificServer(Id);

            return Json(new { YoneticiList = YoneticiList }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateYoneticiFromPopUp(long Id, string Ad, string EMail)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageUpdateManager);
            _service.UpdateYonetici(Id, Ad, EMail);

            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveYoneticiFromSpecificServer(long Id, string Ad)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageRemoveManager);
            _yoneticiServerService.RemoveYoneticiFromSpecificServer(Id, Ad);

            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteYonetici(long Id)
        {
            SimpleJsonResult sJRS = new SimpleJsonResult() { Statu = Application.Enumerations.ServiceManagement.jsonResultSuccessLabel };
            sJRS.SuccessMessages = new List<string>();
            sJRS.SuccessMessages.Add(Application.Resources.Control.MessageDeleteManager);
            _yoneticiServerService.RemoveYoneticiFromSpecificServerByYoneticiId(Id);
            _service.DeleteYonetici(Id);

            return Json(JsonConvert.SerializeObject(sJRS), JsonRequestBehavior.AllowGet);
        }

        #endregion

    }

}