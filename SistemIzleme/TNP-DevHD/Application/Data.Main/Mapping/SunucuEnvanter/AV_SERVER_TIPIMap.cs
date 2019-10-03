using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvServerTipiMap : EnvanterBaseMap<AvServerTipi>
    {
        public AvServerTipiMap()
        {
            // Properties
            this.Property(t => t.Ad)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("SERVER_TIPI", schemaName);
            this.Property(t => t.Ad).HasColumnName("AD");
        }
    }
}