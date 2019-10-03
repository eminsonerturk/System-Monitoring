using Application.Main.Interfaces;
using Application.ViewModels.Islem;
using Data.Main;
using Domain.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Main
{
    public class KullaniciAppService : IslemDbAppService<Kullanici>, Application.Main.Interfaces.IKullaniciAppService
    {
        #region Constructor
        public KullaniciAppService(IIslemDbRepository<Kullanici> pRep)
            : base(pRep)
        {
        }
        #endregion

        public List<Kullanici> GetUserNames()
        {
            var userList = (from p in rep.Table
                              select p).Distinct().ToList();
            return userList;
        }

        //public List<Kullanici> GetCache()
        //{
        //    List<Kullanici> kullanici = new List<Kullanici>();
        //    kullanici = HttpRuntime.Cache["Kullanici"] as List<Kullanici>;

        //    if (HttpRuntime.Cache["Kullanici"] == null)
        //    {
        //        kullanici = (from e in rep.Table
        //                     select e).ToList();

        //        HttpRuntime.Cache["Kullanici"] = kullanici;
        //    }

        //    return kullanici;
        //}

        //public IQueryable<Kullanici> UpdateCache()
        //{
        //    List<Kullanici> currentData = GetCache();

        //    var maxId = (from n in currentData
        //                 select n.Id).Max();

        //    var newData = (from e in rep.Table
        //                   where e.Id > maxId
        //                   select e).ToList();

        //    List<Kullanici> allData = currentData.Union(newData).ToList();
        //    HttpRuntime.Cache["Kullanici"] = allData;

        //    return allData.AsQueryable();
        //}
    }
}
