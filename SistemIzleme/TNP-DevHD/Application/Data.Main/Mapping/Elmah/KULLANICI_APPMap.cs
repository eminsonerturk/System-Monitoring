
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Main.Models;
using Rota2.DataCore.Mapping;


namespace Data.Main.Models.Mapping
{
    public class KullaniciAppMap : BaseMap<KullaniciApp>
    {
        public KullaniciAppMap() : base(true)
        {            
            // Properties
            this.Property(t => t.Kullaniciadi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ApplicationName)
                .IsRequired()
                .HasMaxLength(60);

            this.HasKey(t => t.KullaniciId);

            // Table & Column Mappings
            this.ToTable("KULLANICI_APP");

            this.Property(t => t.KullaniciId).HasColumnName("Id");

            this.Property(t => t.Kullaniciadi).HasColumnName("KullaniciAdi");
			
            this.Property(t => t.ApplicationName).HasColumnName("Application_Name");
			
        }
    }
}

