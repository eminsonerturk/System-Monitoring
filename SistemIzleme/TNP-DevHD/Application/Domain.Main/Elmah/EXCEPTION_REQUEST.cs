using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;


namespace Domain.Main.Models
{

    public partial class ExceptionRequest : REntity
    {
        public string MailAddress { get; set; }
        public string ExceptionType { get; set; }
        public int ExceptionNumber { get; set; }
        public int TimeInterval { get; set; }
        public Nullable<int> ExceptionCount { get; set; }
        public string ApplicationExp1 { get; set; }

        public string ApplicationExp2 { get; set; }
    }
}

