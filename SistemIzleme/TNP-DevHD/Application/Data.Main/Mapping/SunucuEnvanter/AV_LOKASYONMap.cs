using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvLokasyonMap : EnvanterBaseMap<AvLokasyon>
    {
        public AvLokasyonMap()
        {
            // Properties
            this.Property(t => t.Ad)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("LOKASYON", schemaName);
            this.Property(t => t.Ad).HasColumnName("AD");
        }
    }
}