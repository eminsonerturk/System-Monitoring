using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;


namespace Domain.Main.Models
{

    public partial class EntityFieldName : REntity
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
    }
}

