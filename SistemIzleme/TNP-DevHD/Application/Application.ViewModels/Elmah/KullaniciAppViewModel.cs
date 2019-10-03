using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Elmah
{
    public class KullaniciAppViewModel : BaseViewModel
    {
        public int KullaniciId { get; set; }
        public string ApplicationName { get; set; }
    }
}
