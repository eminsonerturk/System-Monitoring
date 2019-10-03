
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Main.Models;
using Rota2.DataCore.Mapping;


namespace Data.Main.Models.Mapping
{
    public class EntityNameMap : BaseMap<EntityName>
    {
        public EntityNameMap() : base(true)
        {            
            // Properties
            this.Property(t => t.TableName)
                .HasMaxLength(250);
            // Table & Column Mappings
            this.HasKey(t => t.TableName);
            this.ToTable("ENTITY_NAME");
            this.Property(t => t.TableName).HasColumnName("TABLE_NAME");
        }
    }
}

