using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theGoodPushService.Common;

namespace theGoodPushService.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SubmitAlert(Models.SurveyAlert s)
        {
            DataModels.Alert alertToAdd = new DataModels.Alert();
            alertToAdd.Dtm = DateTime.Now;
            alertToAdd.Name = s.Name;
            alertToAdd.Msg = s.Comment;
            alertToAdd.Importance = s.Rating;
            DataModels.GoodPushContext db = new DataModels.GoodPushContext();

            db.Alerts.Add(alertToAdd);
            
            alertToAdd.Id = db.SaveChanges();
            int bgNum = db.Alerts.Where(w => w.IsRead == false).Count();
            bgNum =+ db.Messages.Where(w => w.IsRead == false).Count();
            try
            {
                UrbanAirshipHelper.SendPush(alertToAdd.Id, alertToAdd.Name, alertToAdd.Importance, bgNum);
            }
            catch (Exception ex)
            {
                return Json(new { status = String.Format("Saved but Notification failed to get delivered. Error: {0}", ex.Message) });
            }
            
            return Json(new { status = "Success" });
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult SubmitMessage(Models.Message msg)
        {

            try
            {
                DataModels.Message msgToAdd = new DataModels.Message();
                msgToAdd.IsRead = false;
                msgToAdd.Name = msg.Name;
                msgToAdd.Msg = msg.MessageText;
                msgToAdd.Dtm = DateTime.Now;
                DataModels.GoodPushContext db = new DataModels.GoodPushContext();

                db.Messages.Add(msgToAdd);

                msgToAdd.Id = db.SaveChanges();
                int bgNum = db.Alerts.Where(w => w.IsRead == false).Count();
                bgNum = +db.Messages.Where(w => w.IsRead == false).Count();
                UrbanAirshipHelper.SendPush(msg.Name, msg.MessageText, bgNum);
            }
            catch (Exception ex)
            {
                return Json(new { status = String.Format("Saved but Notification failed to get delivered. Error: {0}", ex.Message) });
            }

            return Json(new { status = "Success" });
        }


    }
}
