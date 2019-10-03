
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Main.Models;
using Rota2.DataCore.Mapping;


namespace Data.Main.Models.Mapping
{
    public class EntityFieldNameMap : BaseMap<EntityFieldName>
    {
        public EntityFieldNameMap()
        {            
            // Properties
            this.Property(t => t.ColumnName)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("ENTITY_FIELD_NAME");
            this.Property(t => t.TableName).HasColumnName("TABLE_NAME");
			
            this.Property(t => t.ColumnName).HasColumnName("COLUMN_NAME");
        }
    }
}

