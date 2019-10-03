using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvYoneticiMap : EnvanterBaseMap<AvYonetici>
    {
        public AvYoneticiMap()
        {
            // Properties
            this.Property(t => t.Ad)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.EMail)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("YONETICI", schemaName);
            this.Property(t => t.Ad).HasColumnName("AD");
            this.Property(t => t.EMail).HasColumnName("E_MAIL");


        }
    }
}