using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace theGoodPushService.DataModels
{

    [Table("Alert")]
    public class Alert
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Msg { get; set; }
        public DateTime Dtm { get; set; }
        public int  Importance { get; set; }
        public bool IsRead { get; set; }

    }
}