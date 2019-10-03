using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;


namespace Domain.Main.Models
{
    public partial class IslemLog : REntity
    {
        public long KullaniciId { get; set; }
        public string IslemAdi { get; set; }
        public System.DateTime RequestMessageDate { get; set; }
        public int ResponseStatusId { get; set; }
        public string EntityName { get; set; }
        public int EntityIdValue { get; set; }
        public int AddedNew { get; set; }
        public string EntityFieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; } 
    }
}

