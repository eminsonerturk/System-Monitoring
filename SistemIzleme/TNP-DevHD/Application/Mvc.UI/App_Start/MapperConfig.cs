using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Domain.Main;
using Domain.Main.Models;
using Domain.Main.DTO;
using Application.ViewModels.Elmah;
using Application.ViewModels.Ssrs;
using Application.ViewModels.Islem;
using Application.ViewModels;
using Domain.Main.Envanter;
using Application.ViewModels.Envanter;

namespace Mvc.UI
{
    public static class MapperConfig
    {
        public static void SetMaps()
        {
            #region ElmahError
            Mapper.CreateMap<ElmahErrorDto, ElmahErrorViewModel>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
               .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            Mapper.CreateMap<ElmahError, ElmahErrorViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
                .ForSourceMember(src => src.Statuscode, opt => opt.Ignore())
                .ForSourceMember(src => src.Allxml, opt => opt.Ignore())
                .ForSourceMember(src => src.Timeutc, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            Mapper.CreateMap<ElmahErrorViewModel, ElmahError>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.Statuscode, opt => opt.Ignore())
                .ForMember(dest => dest.Allxml, opt => opt.Ignore())
                .ForMember(dest => dest.Timeutc, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            //REPORT SERVER
            Mapper.CreateMap<ReportServerDto, ReportServerViewModel>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
              .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            Mapper.CreateMap<ReportServer, ReportServerViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.TotalTime, opt => opt.Ignore())
                .ForMember(dest => dest.ReportFolder, opt => opt.Ignore())
                .ForMember(dest => dest.ReportName, opt => opt.Ignore());

            Mapper.CreateMap<ReportServerViewModel, ReportServer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.InstanceName, opt => opt.Ignore())
                .ForMember(dest => dest.ItemPath, opt => opt.Ignore())
                .ForMember(dest => dest.ExecutionId, opt => opt.Ignore())
                .ForMember(dest => dest.RequestType, opt => opt.Ignore())
                .ForMember(dest => dest.ItemAction, opt => opt.Ignore())
                .ForMember(dest => dest.TimeDataRetrieval, opt => opt.Ignore())
                .ForMember(dest => dest.TimeProcessing, opt => opt.Ignore())
                .ForMember(dest => dest.TimeRendering, opt => opt.Ignore())
                .ForMember(dest => dest.Source, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ByteCount, opt => opt.Ignore())
                .ForMember(dest => dest.RowCount, opt => opt.Ignore())
                .ForMember(dest => dest.AdditionalInfo, opt => opt.Ignore());

            //EXCEPTION REQUEST
            Mapper.CreateMap<ExceptionRequestViewModel, ExceptionRequest>();

            Mapper.CreateMap<ExceptionRequest, ExceptionRequestViewModel>();
            #endregion

            #region Elmah
            //Elmah

            #region Server

            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerCrudViewModel>()
                .ForMember(view => view.PingYapilsinMi, opt => opt.MapFrom(entity => entity.PingYapilsinMi));
            Mapper.CreateMap<Application.ViewModels.Envanter.ServerCrudViewModel, AvServer>()
                .ForMember(dest => dest.Lokasyon, opr => opr.Ignore())
                .ForMember(dest => dest.ServerTipi, opr => opr.Ignore())
                .ForMember(dest => dest.OperatingSystem, opr => opr.Ignore())
                .ForMember(dest => dest.ServerYoneticis, opr => opr.Ignore());
            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerSearchViewModel>();
            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerSelectSearchViewModel>();
            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerSelectListViewModel>();

            #endregion

            #region ServerTipi

            Mapper.CreateMap<AvServerTipi, ServerTipiCrudViewModel>();
            Mapper.CreateMap<ServerTipiCrudViewModel, AvServerTipi>()
                .ForMember(dest => dest.Server, opr => opr.Ignore());
            Mapper.CreateMap<AvServerTipi, ServerTipiSearchViewModel>();
            Mapper.CreateMap<AvServerTipi, ServerTipiListViewModel>();
            Mapper.CreateMap<AvServerTipi, ServerTipiSelectSearchViewModel>();
            Mapper.CreateMap<AvServerTipi, ServerTipiSelectListViewModel>();

            #endregion

            #region Lokasyon

            Mapper.CreateMap<AvLokasyon, LokasyonCrudViewModel>();
            Mapper.CreateMap<LokasyonCrudViewModel, AvLokasyon>()
                .ForMember(dest => dest.Server, opr => opr.Ignore());
            Mapper.CreateMap<AvLokasyon, LokasyonSearchViewModel>();
            Mapper.CreateMap<AvLokasyon, LokasyonListViewModel>();
            Mapper.CreateMap<AvLokasyon, LokasyonSelectSearchViewModel>();
            Mapper.CreateMap<AvLokasyon, LokasyonSelectListViewModel>();

            #endregion

            #region OperatingSystem

            Mapper.CreateMap<AvOperatingSystem, OperatingSystemCrudViewModel>();
            Mapper.CreateMap<OperatingSystemCrudViewModel, AvOperatingSystem>()
                .ForMember(dest => dest.Server, opr => opr.Ignore());
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemSearchViewModel>();
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemListViewModel>();
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemSelectSearchViewModel>();
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemSelectListViewModel>();

            #endregion

            #region Yonetici

            Mapper.CreateMap<AvYonetici, YoneticiCrudViewModel>()
                .ForMember(view => view.Ad, opt => opt.MapFrom(entity => entity.Ad))
                .ForMember(view => view.ADEmail, opt => opt.MapFrom(entity => entity.EMail))
                .ForMember(view => view.EMail, opt => opt.MapFrom(entity => entity.EMail));
            Mapper.CreateMap<YoneticiCrudViewModel, AvYonetici>()
                .ForMember(dest => dest.EMail, opr => opr.MapFrom(a => a.ADEmail.Trim()))
                 .ForMember(dest => dest.Ad, opr => opr.MapFrom(a => a.Ad))
                .ForMember(dest => dest.YoneticiServers, opr => opr.Ignore());
            Mapper.CreateMap<AvYonetici, YoneticiListViewModel>()
                .ForMember(view => view.Ad, opt => opt.MapFrom(entity => entity.Ad))
                .ForMember(view => view.ADEmail, opt => opt.MapFrom(entity => entity.EMail));
            Mapper.CreateMap<AvYonetici, YoneticiSelectListViewModel>()
                .ForMember(view => view.Ad, opt => opt.MapFrom(entity => entity.Ad))
                .ForMember(view => view.ADEmail, opt => opt.MapFrom(entity => entity.EMail));


            #endregion

            #endregion



            Mapper.CreateMap<EntityFieldLogViewModel, EntityFieldLog>();

            Mapper.CreateMap<EntityFieldLog, EntityFieldLogViewModel>();

            Mapper.CreateMap<EntityLogViewModel, EntityLog>();

            Mapper.CreateMap<EntityLog, EntityLogViewModel>();

            Mapper.CreateMap<MessageLogViewModel, MessageLog>();

            Mapper.CreateMap<MessageLog, MessageLogViewModel>();

            #region Sunucu Envanter

            #region Kullanici

            Mapper.CreateMap<AvKullanici, KullaniciCrudViewModel>()
                 .ForMember(view => view.KullaniciAd, opt => opt.MapFrom(entity => entity.KullaniciAdi))
                 .ForMember(view => view.IsAdmin, opt => opt.MapFrom(entity => entity.IsAdmin == null ? false : entity.IsAdmin))
                 .ForMember(view => view.KullaniciEMail, opt => opt.MapFrom(entity => entity.KullaniciEMail));
            Mapper.CreateMap<KullaniciCrudViewModel, AvKullanici>()
                 .ForMember(dest => dest.KullaniciEMail, opr => opr.MapFrom(a => a.KullaniciEMail.Trim()))
                 .ForMember(dest => dest.KullaniciAdi, opr => opr.MapFrom(a => a.KullaniciAd))
                 .ForMember(dest => dest.CreatedByUserId, opr => opr.MapFrom(a => a.CreatedByUserId))
                 .ForMember(dest => dest.ModifiedByUserId, opr => opr.MapFrom(a => a.ModifiedByUserId))
                 .ForMember(dest => dest.CreatedDate, opr => opr.MapFrom(a => a.CreatedDate))
                 .ForMember(dest => dest.ModifiedDate, opr => opr.MapFrom(a => a.ModifiedDate))
                 .ForMember(dest => dest.IsActive, opr => opr.MapFrom(a => a.IsActive));
            Mapper.CreateMap<AvKullanici, KullaniciListViewModel>()
                .ForMember(view => view.KullaniciAd, opt => opt.MapFrom(entity => entity.KullaniciAdi))
                .ForMember(view => view.KullaniciEMail, opt => opt.MapFrom(entity => entity.KullaniciEMail));
            Mapper.CreateMap<AvKullanici, KullaniciSelectListViewModel>()
                .ForMember(view => view.KullaniciAd, opt => opt.MapFrom(entity => entity.KullaniciAdi))
                .ForMember(view => view.KullaniciEMail, opt => opt.MapFrom(entity => entity.KullaniciEMail));

            #endregion

            #region Server

            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerCrudViewModel>()
                .ForMember(view => view.PingYapilsinMi, opt => opt.MapFrom(entity => entity.PingYapilsinMi));
            Mapper.CreateMap<Application.ViewModels.Envanter.ServerCrudViewModel, AvServer>()
                .ForMember(dest => dest.Lokasyon, opr => opr.Ignore())
                .ForMember(dest => dest.ServerTipi, opr => opr.Ignore())
                .ForMember(dest => dest.OperatingSystem, opr => opr.Ignore())
                .ForMember(dest => dest.ServerYoneticis, opr => opr.Ignore());
            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerSearchViewModel>();
            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerSelectSearchViewModel>();
            Mapper.CreateMap<AvServer, Application.ViewModels.Envanter.ServerSelectListViewModel>();

            #endregion
            
            #region IISBinding
            Mapper.CreateMap<AV_IISBINDING, Application.ViewModels.Envanter.IISCrudViewModel>()
                 .ForMember(dest => dest.SiteName, opr => opr.Ignore());


            #endregion

            #region Lokasyon

            Mapper.CreateMap<AvLokasyon, LokasyonCrudViewModel>();
            Mapper.CreateMap<LokasyonCrudViewModel, AvLokasyon>()
                .ForMember(dest => dest.Server, opr => opr.Ignore());
            Mapper.CreateMap<AvLokasyon, LokasyonSearchViewModel>();
            Mapper.CreateMap<AvLokasyon, LokasyonListViewModel>();
            Mapper.CreateMap<AvLokasyon, LokasyonSelectSearchViewModel>();
            Mapper.CreateMap<AvLokasyon, LokasyonSelectListViewModel>();

            #endregion

            #region ServerTipi

            Mapper.CreateMap<AvServerTipi, ServerTipiCrudViewModel>();
            Mapper.CreateMap<ServerTipiCrudViewModel, AvServerTipi>()
                .ForMember(dest => dest.Server, opr => opr.Ignore());
            Mapper.CreateMap<AvServerTipi, ServerTipiSearchViewModel>();
            Mapper.CreateMap<AvServerTipi, ServerTipiListViewModel>();
            Mapper.CreateMap<AvServerTipi, ServerTipiSelectSearchViewModel>();
            Mapper.CreateMap<AvServerTipi, ServerTipiSelectListViewModel>();

            #endregion

            #region OperatingSystem

            Mapper.CreateMap<AvOperatingSystem, OperatingSystemCrudViewModel>();
            Mapper.CreateMap<OperatingSystemCrudViewModel, AvOperatingSystem>()
                .ForMember(dest => dest.Server, opr => opr.Ignore());
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemSearchViewModel>();
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemListViewModel>();
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemSelectSearchViewModel>();
            Mapper.CreateMap<AvOperatingSystem, OperatingSystemSelectListViewModel>();

            #endregion

            #region Yonetici

            Mapper.CreateMap<AvYonetici, YoneticiCrudViewModel>()
                .ForMember(view => view.Ad, opt => opt.MapFrom(entity => entity.Ad))
                .ForMember(view => view.ADEmail, opt => opt.MapFrom(entity => entity.EMail))
                .ForMember(view => view.EMail, opt => opt.MapFrom(entity => entity.EMail));
            Mapper.CreateMap<YoneticiCrudViewModel, AvYonetici>()
                .ForMember(dest => dest.EMail, opr => opr.MapFrom(a => a.ADEmail.Trim()))
                 .ForMember(dest => dest.Ad, opr => opr.MapFrom(a => a.Ad))
                .ForMember(dest => dest.YoneticiServers, opr => opr.Ignore());
            Mapper.CreateMap<AvYonetici, YoneticiListViewModel>()
                .ForMember(view => view.Ad, opt => opt.MapFrom(entity => entity.Ad))
                .ForMember(view => view.ADEmail, opt => opt.MapFrom(entity => entity.EMail));
            Mapper.CreateMap<AvYonetici, YoneticiSelectListViewModel>()
                .ForMember(view => view.Ad, opt => opt.MapFrom(entity => entity.Ad))
                .ForMember(view => view.ADEmail, opt => opt.MapFrom(entity => entity.EMail));

            #endregion

            #endregion

            //Mapper.AssertConfigurationIsValid();
        }
    }
}
