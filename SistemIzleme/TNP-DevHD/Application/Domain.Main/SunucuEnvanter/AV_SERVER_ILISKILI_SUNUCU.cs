using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.DomainCore;

namespace Domain.Main.Envanter
{
    public partial class AvServerIliskiliSunucu : REntity
    {
        public AvServerIliskiliSunucu()
        {
        }

        public long ServerID { get; set; }
        public long ParentID { get; set; }
        public AvServer Server { get; set; }
    }
}