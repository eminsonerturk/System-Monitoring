using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;
using Domain.Main.Envanter;

namespace Domain.Main.Envanter
{
    public partial class AvYoneticiServer:REntity
    {
        public AvYoneticiServer()
        {
        }

        public long YoneticiId { get; set; }
        public long ServerId { get; set; }

        public virtual AvYonetici Yonetici { get; set; }
        public virtual AvServer Server { get; set; }

    }
}
