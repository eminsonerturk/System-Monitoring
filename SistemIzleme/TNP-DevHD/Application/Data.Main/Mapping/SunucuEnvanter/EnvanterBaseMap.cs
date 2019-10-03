using Rota2.DataCore.Mapping;
using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Main.Mapping
{
    public class EnvanterBaseMap<T> : BaseMap<T> where T : REntity
    {
        protected string schemaName;
        public EnvanterBaseMap()
            : base()
        {
        }
        protected override void SetSchemaName()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EFSchemaName"]))
            {
                schemaName = ConfigurationManager.AppSettings["EFSchemaName"];
            }            
        }
    }

}
