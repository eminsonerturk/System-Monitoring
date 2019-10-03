using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Elmah
{
    public class MessageLogViewModel : BaseViewModel
    {
        public decimal KullaniciId { get; set; }
        public string IslemAdi { get; set; }
        public DateTime RequestMessageDate { get; set; }
        public DateTime ResponseMessageDate { get; set; }
        public decimal ResponseStatusId { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
