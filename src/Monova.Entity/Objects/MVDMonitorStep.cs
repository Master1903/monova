using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monova.Entity
{
    [Table("MonitorStep")]
    public class MVDMonitorStep
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MonitorId { get; set; }
        public MVDMonitorStepTypes Type { get; set; }
        public string Settings { get; set; }


    }
    public enum MVDMonitorStepTypes : short
    {
        Request = 0,
        StatusCode = 1,
        HeaderExist = 3,
        BodyContains = 4

    }

}