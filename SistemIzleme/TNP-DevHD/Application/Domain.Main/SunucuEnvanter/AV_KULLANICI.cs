using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;
using Domain.Main.Envanter;

namespace Domain.Main.Envanter
{
    public partial class AvKullanici:REntity
    {
        public AvKullanici()
        {}

        public string KullaniciAdi { get; set; }
        public string KullaniciEMail { get; set; }
        public bool? IsAdmin { get; set; }

    }
}
