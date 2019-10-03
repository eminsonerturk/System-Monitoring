using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rota2.DataCore.Mapping;
using Domain.Main;
using Domain.Main.Envanter;
using Data.Main.Mapping;

namespace Data.Main.Mapping.Envanter
{
    public class AvKullaniciMap : EnvanterBaseMap<AvKullanici>
    {
        public AvKullaniciMap()
        {
            // Properties
            this.Property(t => t.KullaniciAdi)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.KullaniciEMail)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("KULLANICI", schemaName);
            this.Property(t => t.KullaniciAdi).HasColumnName("KULLANICI_ADI");
            this.Property(t => t.KullaniciEMail).HasColumnName("KULLANICI_EMAIL");
            this.Property(t => t.IsAdmin).HasColumnName("IS_ADMIN");
        }
    }
}