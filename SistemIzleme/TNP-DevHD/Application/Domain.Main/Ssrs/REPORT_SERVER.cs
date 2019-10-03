using System;
using System.Collections.Generic;
using System.Globalization;
using Rota2.DomainCore;


namespace Domain.Main.Models
{
    public partial class ReportServer : REntity
    {
        public string InstanceName { get; set; }
        public string ItemPath { get; set; }
        public string UserName { get; set; }
        public string ExecutionId { get; set; }
        public string RequestType { get; set; }
        public string Format { get; set; }
        public string Parameters { get; set; }
        public string ItemAction { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public int TimeDataRetrieval { get; set; }
        public int TimeProcessing { get; set; }
        public int TimeRendering { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public long ByteCount { get; set; }
        public long RowCount { get; set; }
        public string AdditionalInfo { get; set; }
        public long LogEntryId { get; set; }
    }
}

