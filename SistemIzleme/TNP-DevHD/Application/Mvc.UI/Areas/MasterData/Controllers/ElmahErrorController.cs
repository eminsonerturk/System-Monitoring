using Application.ViewModels.Elmah;
using Data.Main.Models;
using Rota2.DomainCore;
using Rota2.MvcUtils.Controllers;
using Rota2.MvcUtils.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Main.Interfaces;
using Domain.Main.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Application.ViewModels;
using System.Text;
using System.IO;
using Rota2.MvcUtils.Attributes;
using Domain.Main.DTO;

namespace Mvc.UI.Areas.MasterData.Controllers
{
    public class ElmahErrorController : Crud5Controller<ElmahError,ElmahErrorViewModel, ElmahErrorSearchViewModel, ElmahErrorViewModel>
    {
        protected readonly IElmahErrorAppService elmahErrorService;
        protected readonly IMapper<ElmahErrorDto, ElmahErrorViewModel> dtoMapper;

        public ElmahErrorController(IElmahErrorAppService elmahErrorSrv,
            IMapper<ElmahError, ElmahErrorViewModel> v,IMapper<ElmahErrorDto, ElmahErrorViewModel> _dtoMapper)
            : base(elmahErrorSrv, v, v)
        {
            CrudOnIndex = true;
            AutoFilter = false;
            elmahErrorService = elmahErrorSrv;
            dtoMapper = _dtoMapper;
        }

        [HttpPost]
        protected override JsonResult GetGridData(DataSourceRequest request, ElmahErrorSearchViewModel searchModel)
        {
            if (searchModel.Application != null && searchModel.Application.Count != 0 && searchModel.Application.Contains("YNA_TUM"))
            {
                List<string> temp = elmahErrorService.GetApplicationList();
                foreach (var e in temp)
                    if (e.IndexOf("YNA") != -1)
                        searchModel.Application.Add(e);
                searchModel.Application.Remove("YNA_TUM");
            }

            IEnumerable<ElmahErrorDto> list = elmahErrorService.WhereDto<ElmahErrorSearchViewModel, ElmahErrorDto>(searchModel);
            var res = dtoMapper.MapToModel(list);
            return Json(res.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApplicationReadData([DataSourceRequest]DataSourceRequest request)
        {
            List<string> applicationList = elmahErrorService.GetApplicationList();
            return Json(applicationList, JsonRequestBehavior.AllowGet);
        }

        [NoAntiForgeryCheck]
        public string AllXmlReadData(string errorId)
        {
            return elmahErrorService.GetAllXml(errorId);
        }

        [NoAntiForgeryCheck]
        public FileStreamResult AllXmlExportData(string ErrorId)
        {
            var xml = AllXmlReadData(ErrorId);

            var byteArray = Encoding.ASCII.GetBytes(xml);
            var stream = new MemoryStream(byteArray);

            return File(stream, "application/txt", "errorLog.xml");
        }
    }
}
