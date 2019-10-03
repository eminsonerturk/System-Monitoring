using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;


namespace Domain.Main.Models
{

    public partial class KullaniciApp : REntity
    {
        public int KullaniciId { get; set; }
        public string Kullaniciadi { get; set; }
        public string ApplicationName { get; set; }
    }
}

