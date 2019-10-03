using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvYoneticiServerMap : EnvanterBaseMap<AvYoneticiServer>
    {
        public AvYoneticiServerMap()
        {

            // Table & Column Mappings
            this.ToTable("YONETICI_SERVER", schemaName);
            this.Property(t => t.YoneticiId).HasColumnName("YONETICI_ID");
            this.Property(t => t.ServerId).HasColumnName("SERVER_ID");

            // Relationships
            this.HasRequired(t => t.Server)
                .WithMany(t => t.ServerYoneticis)
                .HasForeignKey(p => p.ServerId);

            this.HasRequired(t => t.Yonetici)
                .WithMany(t => t.YoneticiServers)
                .HasForeignKey(p => p.YoneticiId);
        }
    }
}