
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Main.Models;
using Rota2.DataCore.Mapping;


namespace Data.Main.Models.Mapping
{
    public class ElmahErrorMap : BaseMap<ElmahError>
    {
        public ElmahErrorMap():base(true)
        {            
            // Properties
            this.Property(t => t.Application)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.Host)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Source)
                .IsRequired()
                .HasMaxLength(60);

            this.HasKey(t => t.Errorid);

            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.User)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Allxml)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ELMAH_Error");
            this.Property(t => t.Errorid).HasColumnName("ErrorId");
			
            this.Property(t => t.Application).HasColumnName("Application");
			
            this.Property(t => t.Host).HasColumnName("Host");
			
            this.Property(t => t.Type).HasColumnName("Type");
			
            this.Property(t => t.Source).HasColumnName("Source");
			
            this.Property(t => t.Message).HasColumnName("Message");
			
            this.Property(t => t.User).HasColumnName("User");
			
            this.Property(t => t.Statuscode).HasColumnName("StatusCode");
			
            this.Property(t => t.Timeutc).HasColumnName("TimeUtc");
			
            this.Property(t => t.Sequence).HasColumnName("Sequence");
			
            this.Property(t => t.Allxml).HasColumnName("AllXml");
			
            this.Property(t => t.Kayityaratmatarihi).HasColumnName("KayitYaratmaTarihi");
        }
    }
}

