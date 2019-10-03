using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvServerMap : EnvanterBaseMap<AvServer>
    {
        public AvServerMap()
        {
            // Properties
            this.Property(t => t.ServerIp)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ComputerName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Aciklama)
                .IsRequired()
                .HasMaxLength(1000);
             
        


            // Table & Column Mappings
            this.ToTable("SERVER", schemaName);
            this.Property(t => t.ServerIp).HasColumnName("SERVER_IP");
            this.Property(t => t.ComputerName).HasColumnName("SERVER_COMPUTER_NAME");
            this.Property(t => t.Aciklama).HasColumnName("ACIKLAMA");
            this.Property(t => t.ServerTipiId).HasColumnName("SERVER_TIPI_ID");
            this.Property(t => t.LokasyonId).HasColumnName("LOKASYON_ID");
            this.Property(t => t.OperatingSystemId).HasColumnName("OPERATING_SYSTEM_ID");
            this.Property(t => t.PingYapilsinMi).HasColumnName("PingYapilsinMi");

            // Relationships
            this.HasRequired(t => t.Lokasyon)
                .WithMany(t => t.Server)
                .HasForeignKey(p => p.LokasyonId);

            this.HasRequired(t => t.ServerTipi)
                .WithMany(t => t.Server)
                .HasForeignKey(p => p.ServerTipiId);

            this.HasRequired(t => t.OperatingSystem)
                .WithMany(t => t.Server)
                .HasForeignKey(p => p.OperatingSystemId);
        }
    }
}