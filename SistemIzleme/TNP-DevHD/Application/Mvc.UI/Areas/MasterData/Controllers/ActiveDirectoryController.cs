using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using ActiveDirectory.Models;
using System.DirectoryServices;


namespace ActiveDirectory.Controllers
{ 
    public class ActiveDirectoryController : Rota2.MvcUtils.Controllers.BaseController
    {
        // GET: Search
        public ActionResult Index()
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain);

            // Security grupları için (Query By Example - QBE)
            GroupPrincipal qbeGroup = new GroupPrincipal(context);
            qbeGroup.IsSecurityGroup = true;

            PrincipalSearcher search = new PrincipalSearcher(qbeGroup);

            // Bulunan grupların tutulacağı liste
            var groups = new List<ActiveDirectoryGroup>();

            foreach (var found in search.FindAll())
            {
                ActiveDirectoryGroup currentGroup = new ActiveDirectoryGroup();
                currentGroup.groupName = found.Name;
                currentGroup.isSecurityGroup = true;
                groups.Add(currentGroup);
            }

            // Mail grupları için
            qbeGroup.IsSecurityGroup = false;

            search = new PrincipalSearcher(qbeGroup);

            foreach (var found in search.FindAll())
            {
                ActiveDirectoryGroup currentGroup = new ActiveDirectoryGroup();
                currentGroup.groupName = found.Name;
                groups.Add(currentGroup);
            }

            return View(groups);
        }

        [HttpPost]
        public JsonResult MembersOfGroup(string groupName = "_Agency_BI_Agency")
        {
            if (groupName != "")
            {
                PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
                GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, groupName);

                //Grup yöneticisini bulma
                DirectoryEntry obj = (DirectoryEntry)group.GetUnderlyingObject();
                var owner = obj.Properties["managedBy"];

                // Grup üyelerinin tutulacağı liste
                var members = new List<ActiveDirectoryMember>();

                foreach (Principal principal in group.Members)
                {
                    // Admin hariç tüm üyeler üye listesine ekleniyor.
                    // Admin daha sonra bulunup, listenin en başına eklenecek.
                    if (owner.Value == null || principal.DistinguishedName.ToString() != owner.Value.ToString())
                    {
                        ActiveDirectoryMember currentMember = new ActiveDirectoryMember();
                        currentMember.userName = principal.Name;
                        currentMember.userMail = principal.UserPrincipalName;
                        currentMember.isAdmin = false;

                        members.Add(currentMember);
                    }
                }

                if (owner.Value != null)
                {
                    // Admin'in mail adresinin bulunması için, kullanıcı aranıyor.
                    UserPrincipal userAdmin = UserPrincipal.FindByIdentity(principalContext, owner.Value.ToString());
                    ActiveDirectoryMember admin = new ActiveDirectoryMember();
                    admin.userName = userAdmin.Name;
                    admin.userMail = userAdmin.UserPrincipalName;
                    admin.isAdmin = true;

                    if (!members.Contains(admin))
                    {
                        members.Insert(0, admin);
                    }
                }

                return Json(members, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true);
            }
        }

        [HttpPost]
        public JsonResult MembershipsOfUser(string userName)
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, userName);

                // "userName"e sahip kullanıcı bulunursa
                if (user != null)
                {
                    // Kullanıcının kayıtlı olduğu gruplar bulunuyor
                    PrincipalSearchResult<Principal> principalList = user.GetGroups();

                    List<ActiveDirectoryGroup> groups = new List<ActiveDirectoryGroup>();

                    foreach (Principal found in principalList)
                    {
                        ActiveDirectoryGroup currentGroup = new ActiveDirectoryGroup();
                        currentGroup.groupName = found.Name;

                        // Grubun ismi verilerek, "security" veya "mail" grubu olduğu kontrol ediliyor.
                        GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, currentGroup.groupName);

                        if (group.IsSecurityGroup == true)
                        {
                            currentGroup.isSecurityGroup = true;
                        }
                        else
                        {
                            currentGroup.isSecurityGroup = false;
                        }

                        groups.Add(currentGroup);
                    }

                    return Json(groups, JsonRequestBehavior.AllowGet);
                }
                // "userName"e sahip kullanıcı bulunamazsa, "null" data gönderiliyor.
                else
                {
                    return Json(true);
                }
            }
            catch (MultipleMatchesException)
            {
                // Aynı ad-soyad'la kayıtlı birden çok kullanıcı varsa, "kayıt bulunamadı" mesajı döndürülüyor.
                // Kullanıcıya ulaşmak için "username" veya "mail" ile aramak yapmak gerekiyor.
                return Json(true);
            }
        }
    }
}