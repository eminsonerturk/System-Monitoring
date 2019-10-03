using Rota2.MvcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Envanter
{
    public class ServerUygulamalarViewModel : ServerUygulamalarCrudViewModel
    {
    }

    public class ServerUygulamalarCrudViewModel : BaseViewModel
    {
        public long ServerID { get; set; }
        public string ApplicationName { get; set; }

    }
}
