using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Main.Envanter;

namespace Data.Main.Mapping.Envanter
{
    public partial class AvServerIliskiliSunucuMap : EnvanterBaseMap<AvServerIliskiliSunucu>
    {
        public AvServerIliskiliSunucuMap()
        {
            // Table & Column Mappings
            this.ToTable("SERVER_ILISKILI_SUNUCU", schemaName);
            this.Property(t => t.ServerID).HasColumnName("SERVER_ID");
            this.Property(t => t.ParentID).HasColumnName("PARENT_ID");

            // Relationships
            this.HasRequired(t => t.Server)
               .WithMany(t => t.ServerIliskiliSunucu)
               .HasForeignKey(p => p.ServerID);
        }
    }
}
