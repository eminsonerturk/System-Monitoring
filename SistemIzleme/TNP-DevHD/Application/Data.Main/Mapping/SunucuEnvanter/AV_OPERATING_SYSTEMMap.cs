using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvOperatingSystemMap : EnvanterBaseMap<AvOperatingSystem>
    {
        public AvOperatingSystemMap()
        {
            // Properties
            this.Property(t => t.Ad)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("OPERATING_SYSTEM", schemaName);
            this.Property(t => t.Ad).HasColumnName("AD");
        }
    }
}