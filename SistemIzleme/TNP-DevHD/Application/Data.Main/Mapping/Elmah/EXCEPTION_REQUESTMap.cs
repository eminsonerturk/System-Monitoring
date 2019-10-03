using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Main.Models;
using Rota2.DataCore.Mapping;


namespace Data.Main.Models.Mapping
{
    public class ExceptionRequestMap : BaseMap<ExceptionRequest>
    {
        public ExceptionRequestMap()
        {            
            
            // Properties
            this.Property(t => t.MailAddress)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ExceptionType)
                .IsRequired();

            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("EXCEPTION_REQUEST");

            this.Ignore(t => t.ModifiedByUserId);
            this.Ignore(t => t.ModifiedDate);
            this.Ignore(t => t.CreatedByUserId);
            this.Ignore(t => t.CreatedDate);
            this.Ignore(t => t.IsActive);

            this.Property(t => t.MailAddress).HasColumnName("MAIL_ADDRESS");
			
            this.Property(t => t.ExceptionType).HasColumnName("EXCEPTION_TYPE");
			
            this.Property(t => t.ExceptionNumber).HasColumnName("EXCEPTION_NUMBER");
			
            this.Property(t => t.TimeInterval).HasColumnName("TIME_INTERVAL");
			
            this.Property(t => t.ExceptionCount).HasColumnName("EXCEPTION_COUNT");

            this.Property(t => t.ApplicationExp1).HasColumnName("APPLICATION_EXP1");

            this.Property(t => t.ApplicationExp2).HasColumnName("APPLICATION_EXP2");

        }
    }
}

