using Domain.Main.Models;
using Rota2.DataCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Main.Models.Mapping
{
    public class ReportServerMap : BaseMap<ReportServer>
    {
        public ReportServerMap()
            : base(true)
        {
            // Properties
            this.Property(t => t.ItemPath)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ExecutionLog3");

            this.HasKey(t => t.ExecutionId);

            this.Property(t => t.ItemPath).HasColumnName("ItemPath");
            
            this.Property(t => t.LogEntryId).HasColumnName("LogEntryId");

            this.Property(t => t.UserName).HasColumnName("UserName");

            this.Property(t => t.TimeEnd).HasColumnName("TimeEnd");

            this.Property(t => t.TimeStart).HasColumnName("TimeStart");

            this.Property(t => t.Format).HasColumnName("Format");

            this.Property(t => t.Parameters).HasColumnName("Parameters");

            this.Property(t => t.Source).HasColumnName("Source");

            this.Property(t => t.Status).HasColumnName("Status");

            this.Property(t => t.ByteCount).HasColumnName("ByteCount");

            this.Property(t => t.RowCount).HasColumnName("RowCount");

            this.Property(t => t.AdditionalInfo).HasColumnName("AdditionalInfo");

            this.Property(t => t.TimeRendering).HasColumnName("TimeRendering");

            this.Property(t => t.TimeProcessing).HasColumnName("TimeProcessing");

            this.Property(t => t.TimeDataRetrieval).HasColumnName("TimeDataRetrieval");

            this.Property(t => t.ItemAction).HasColumnName("ItemAction");

            this.Property(t => t.RequestType).HasColumnName("RequestType");

            this.Property(t => t.ExecutionId).HasColumnName("ExecutionId");

            this.Property(t => t.InstanceName).HasColumnName("InstanceName");

        }
    }
}
