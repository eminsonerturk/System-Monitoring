using Rota2.DataCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Main.Models;

namespace Data.Main.Models.Mapping
{
    public class EntityFieldLogMap : BaseMap<EntityFieldLog>
    {
        public EntityFieldLogMap(): base(true)
        {
            this.Property(t => t.EntityFieldName)
                .IsRequired();
            this.Property(t => t.EntityFieldName)
                .HasMaxLength(30);
            this.Property(t => t.OldValue)
                .HasMaxLength(4000);
            this.Property(t => t.NewValue)
                .HasMaxLength(4000);

            this.ToTable("ENTITY_FIELD_LOG");

            this.Property(t => t.EntityLogId).HasColumnName("ENTITY_LOG_ID");

            this.Property(t => t.EntityFieldName).HasColumnName("ENTITY_FIELD_NAME");

            this.Property(t => t.OldValue).HasColumnName("OLD_VALUE");

            this.Property(t => t.NewValue).HasColumnName("NEW_VALUE");
        }
    }
}
