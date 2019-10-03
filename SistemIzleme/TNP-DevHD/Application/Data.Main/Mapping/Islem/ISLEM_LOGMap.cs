
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Main.Models;
using Rota2.DataCore.Mapping;


namespace Data.Main.Models.Mapping
{
    public class IslemLogMap : BaseMap<IslemLog>
    {
        public IslemLogMap() : base(true)
        {            
            //// Properties
            

            // Table & Column Mappings
            this.ToTable("YNA_LOG_SORGU_VW");

            this.HasKey(t => t.KullaniciId);

            this.Property(t => t.KullaniciId).HasColumnName("KULLANICI_ID");

            this.Property(t => t.IslemAdi).HasColumnName("ISLEM_ADI");

            this.Property(t => t.RequestMessageDate).HasColumnName("REQUEST_MESSAGE_DATE");

            this.Property(t => t.ResponseStatusId).HasColumnName("RESPONSE_STATUS_ID");

            this.Property(t => t.EntityName).HasColumnName("ENTITY_NAME");

            this.Property(t => t.EntityIdValue).HasColumnName("ENTITY_ID_VALUE");

            this.Property(t => t.AddedNew).HasColumnName("ADDED_NEW");

            this.Property(t => t.EntityFieldName).HasColumnName("ENTITY_FIELD_NAME");

            this.Property(t => t.OldValue).HasColumnName("OLD_VALUE");

            this.Property(t => t.NewValue).HasColumnName("NEW_VALUE");
        }
    }
}

