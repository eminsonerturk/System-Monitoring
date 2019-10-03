using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;

namespace Data.Main.Mapping.Envanter
{
    public partial class AvServerUygulamalarMap : EnvanterBaseMap<AvServerUygulamalar>
    {
        public AvServerUygulamalarMap()
        {
            // Properties
            this.Property(t => t.ApplicationName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SERVER_UYGULAMALAR", schemaName);
            this.Property(t => t.ServerID).HasColumnName("SERVER_ID");
            this.Property(t => t.ApplicationName).HasColumnName("APPLICATION_NAME");

            // Relationships
            this.HasRequired(t => t.Server)
               .WithMany(t => t.ServerUygulamalar)
               .HasForeignKey(p => p.ServerID);
        }
    }
}
