using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monova.Entity
{
    [Table("Monitor")]
    public class MVDMonitor
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public MVDMonitorStatusTypes MonitorStatus { get; set; }
        public MVDTestStatusTypes TestStatus { get; set; }
        public DateTime LastCheckDate { get; set; }
        public decimal UpTime { get; set; }
        public int LoadTime { get; set; }

        public int MonitorTime { get; set; }


    }

    public enum MVDMonitorStatusTypes : short //Monitor işlemi gerekli stepleri geçerse 1, geçmez ise 0, bazılarını geçmiş ise 2
    {
        Unknown = 0,
        Up = 1,
        Down = 2,
        Warning = 3
    }
    public enum MVDTestStatusTypes : short
    {
        Unknown = 0,
        AllPassed = 1,
        Fail = 2,
        Warning = 3

    }


}
