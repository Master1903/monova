using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monova.Entity
{
    [Table("MonitorStepLog")]
    public class MVDMonitorStepLog
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MonitorStepId { get; set; }
        public Guid MonitorId { get; set; } // Hızlı sonuç alabilmek için kullanıldı

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MVDMonitorStepStatusType Status { get; set; }
        public string Log { get; set; } // MonitorStep ile alakalı bir durum olursa buraya yazılacak 
    }
    public enum MVDMonitorStepStatusType : short
    {
        Fail = 0,
        Success = 1,
    }

}