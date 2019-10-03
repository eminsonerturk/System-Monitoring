using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;


namespace Domain.Main.Models
{

    public partial class ElmahError : REntity
    {
        public System.Guid Errorid { get; set; }
        public string Application { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
        public int Statuscode { get; set; }
        public System.DateTime Timeutc { get; set; }
        public int Sequence { get; set; }
        public string Allxml { get; set; }
        public Nullable<System.DateTime> Kayityaratmatarihi { get; set; }
    }
}

