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

        public MVDSMonitorStepSettingsRequest SettingsAsRequest()
        {
            return JsonConvert.DeserializeObject<MVDSMonitorStepSettingsRequest>(Settings);

        }


    }
    public enum MVDMonitorStepTypes : short
    {
        Request = 0,
        StatusCode = 1,
        HeaderExist = 2,
        BodyContains = 3

    }
    public class MVDSMonitorStepSettingsRequest
    {
        public string Url { get; set; }
    }

}