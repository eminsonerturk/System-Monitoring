using Application.ViewModels.Islem.DropDownAttributes;
using Rota2.DataCore;
using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Islem
{
    public class OracleKullaniciSearchViewModel : BaseViewModel
    {
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }

    public class OracleKullaniciViewModel : BaseViewModel
    {
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
