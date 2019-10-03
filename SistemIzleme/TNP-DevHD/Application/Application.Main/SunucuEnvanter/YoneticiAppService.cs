
using Application.Main.Interfaces.SunucuEnvanter;
using Application.ViewModels.Envanter;
using Data.Main;
using Domain.Main;
using Domain.Main.Envanter;
using Rota2.AppCore;
using Rota2.DataCore;
using Rota2.DomainCore;
using Rota2.DomainCore.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Main.SunucuEnvanter
{
    public class YoneticiAppService : SunucuEnvanterDbAppService<AvYonetici>, IYoneticiAppService
    {

         #region Constructor

        public YoneticiAppService(ISunucuEnvanterDbRepository<AvYonetici> rep)
            : base(rep)
        {}

        #endregion

        #region crud methods

        public AvYonetici GetYoneticiById(long Id)
        {
            AvYonetici _yonetici = (from yonetici in rep.Table
                                    where yonetici.Id == Id
                                    select yonetici).FirstOrDefault();
            return _yonetici;
        }
        public List<string> GetAllYoneticiAdi()
        {
            var YoneticiList = (from yonetici in rep.Table
                                select yonetici.Ad).ToList();
            return YoneticiList;
        }

        public List<AvYonetici> GetAllYonetici()
        {
            var YoneticiList = (from yonetici in rep.Table select yonetici).ToList();
            return YoneticiList;
        }
        public AvYonetici GetYonetici(string Ad)
        {
            AvYonetici _Yonetici = (from yonetici in rep.Table
                                    where yonetici.Ad.Equals(Ad)
                                    select yonetici).FirstOrDefault();
            return _Yonetici;
        }
        public void CreateYonetici(string Ad, string EMail)
        {
            AvYonetici yeniYonetici = new AvYonetici()
            {
                Ad = Ad,
                EMail = EMail
            };

            rep.Add(yeniYonetici);
        }
        public void UpdateYonetici(long Id, string Ad, string EMail)
        {
            AvYonetici yonetici = rep.Get(Id);
            yonetici.Ad = Ad;
            yonetici.EMail = EMail;
            rep.Modify(yonetici);
        }
        public void DeleteYonetici(long Id)
        {
            AvYonetici yonetici = rep.Get(Id);
            rep.Remove(yonetici);
        }

        #endregion

    }
}
