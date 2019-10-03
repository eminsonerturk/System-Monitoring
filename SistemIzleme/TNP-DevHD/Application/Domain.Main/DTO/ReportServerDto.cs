using Rota2.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.DTO
{
    public class ReportServerDto : REntity
    {
        public string ItemPath { get; set; }
        public string ReportName
        {
            get
            {
                string[] reportArray;
                reportArray = ItemPath.Split("/".ToCharArray());
                return reportArray.Last();
            }
            set { }
        }
        public string ReportFolder
        {
            get
            {
                string folderName;
                string[] reportArray;
                reportArray = ItemPath.Split("/".ToCharArray());
                folderName = reportArray[0];
                for (var i = 1; i < reportArray.Length - 1; i++)
                    folderName += "/" + reportArray[i];
                return folderName;
            }
            set { }
        }
        public string UserName { get; set; }
        public string Format { get; set; }
        public string Parameters { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public long LogEntryId { get; set; }

        public double TotalTime 
        {
            get
            {
                return (TimeEnd - TimeStart).TotalMilliseconds;
            }
            set { }
        }
    }
}
