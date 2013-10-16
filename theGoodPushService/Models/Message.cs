using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theGoodPushService.Models
{
    public class Message
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String MessageText { get; set; }
        public DateTime Dtm { get; set; }
    }
}