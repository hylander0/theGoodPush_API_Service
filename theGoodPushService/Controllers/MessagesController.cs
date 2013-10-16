using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using theGoodPushService.DataModels;
using theGoodPushService.Models;

namespace theGoodPushService.Controllers
{
    public class MessagesController : ApiController
    {
        private GoodPushContext db = new GoodPushContext();

        
        // GET api/Messages/GetAllMessages
        [HttpGet]
        [ActionName("GetAllMessages")]
        public IEnumerable<theGoodPushService.DataModels.Message> GetAllMessages()
        {
            db.Messages.ToList().ForEach(f =>
            {
                db.Entry(f).State = EntityState.Modified;
                f.IsRead = true;
            });
            db.SaveChanges();
            return db.Messages.AsEnumerable();
        }
    }
}
