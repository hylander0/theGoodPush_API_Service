using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace theGoodPushService.DataModels
{

    [Table("DeviceSetting")]
    public class DeviceSetting
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String DeviceToken { get; set; }
        public String Alias { get; set; }
        public bool IsPushEnabled { get; set; }
        public bool IsSoundEnabled { get; set; }
    }
}