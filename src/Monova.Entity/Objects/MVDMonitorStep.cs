using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Monova.Entity
{
    [Table("MonitorStep")]
    public class MVDMonitorStep
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MonitorId { get; set; }
        public MVDMonitorStepTypes Type { get; set; }

        //Verileri JSON olarak tuttuğumuz alan
        public string Settings { get; set; }
        public int Interval { get; set; }
        public MVDMonitorStepStatusType Status { get; set; }


        public MVDSMonitorStepSettingsRequest SettingsAsRequest()
        {
            return JsonConvert.DeserializeObject<MVDSMonitorStepSettingsRequest>(Settings);

        }



    }
    public enum MVDMonitorStepStatusType : short
    {

        Unknown = 0,
        Pending = 1,
        Success = 2,
        Fail = 3,
        Warning = 4
    }
    public enum MVDMonitorStepTypes : short
    {
        Unknown = 0,
        Request = 1,
        StatusCode = 2,
        HeaderExist = 3,
        BodyContains = 4

    }
    public class MVDSMonitorStepSettingsRequest
    {
        public string Url { get; set; }
    }

}