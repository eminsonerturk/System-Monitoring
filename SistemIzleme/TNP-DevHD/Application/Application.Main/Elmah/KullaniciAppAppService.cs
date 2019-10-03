using Application.Main.Interfaces;
using Application.ViewModels.Elmah;
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
    public class KullaniciAppAppService : ElmahDbAppService<KullaniciApp>, IKullaniciAppAppService
    {
        #region Constructor
        public KullaniciAppAppService(IElmahDbRepository<KullaniciApp> pRep)
            : base(pRep)
        {
        }
        #endregion

        public List<string> GetSelectedAppList()
        {
            var userSelectionList = (from p in rep.Table
                                     where p.Kullaniciadi == HttpContext.Current.User.Identity.Name
                                     select p.ApplicationName).ToList();
            return userSelectionList;
        }

        public void UpdateSelectedAppList(KullaniciAppViewModel selectedApps)
        {
            var Users = rep.Table.Where(x => x.Kullaniciadi == HttpContext.Current.User.Identity.Name);

            foreach (var user in Users.ToList())
            {
                rep.Remove(user);
            }

            if (selectedApps.ApplicationName != null)
            {
                List<string> appList = selectedApps.ApplicationName.Split(",".ToCharArray()).ToList();
                for (var i = 0; i < appList.Count; i++)
                {
                    KullaniciApp currentUser = new KullaniciApp();
                    currentUser.Kullaniciadi = HttpContext.Current.User.Identity.Name;
                    currentUser.ApplicationName = appList[i].ToString();
                    rep.Add(currentUser);
                }
            }
        }
    }
}
