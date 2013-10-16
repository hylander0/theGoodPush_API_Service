using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theGoodPushService.Models
{
    public class DeviceSetting
    {
        public String DeviceToken { get; set; }
        public String Alias { get; set; }
        public bool IsPushEnabled { get; set; }
        public bool IsSoundEnabled { get; set; }
    }
}