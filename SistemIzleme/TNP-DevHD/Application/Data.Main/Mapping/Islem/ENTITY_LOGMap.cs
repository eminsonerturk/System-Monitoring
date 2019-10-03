using Rota2.DataCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Main.Models;

namespace Data.Main.Models.Mapping
{
    public class EntityLogMap : BaseMap<EntityLog>
    {
        public EntityLogMap()
        {
            this.Property(t => t.MessageLogId)
                .IsRequired();
            this.Property(t => t.EntityName)
                .HasMaxLength(250);


            this.ToTable("ENTITY_LOG");

            this.Property(t => t.MessageLogId).HasColumnName("MESSAGE_LOG_ID");

            this.Property(t => t.EntityName).HasColumnName("ENTITY_NAME");

            this.Property(t => t.EntityIdValue).HasColumnName("ENTITY_ID_VALUE");

            this.Property(t => t.AddedNew).HasColumnName("ADDED_NEW");

            this.Property(t => t.OperationTime).HasColumnName("OPERATION_TIME");

        }
    }
}
