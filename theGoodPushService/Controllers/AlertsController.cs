using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using theGoodPushService.DataModels;

namespace theGoodPushService.Controllers
{
    public class AlertsController : ApiController
    {
        private GoodPushContext db = new GoodPushContext();

        // GET api/Alerts/GetAllAlerts
        [HttpGet]
        [ActionName("GetAllAlerts")]
        public IEnumerable<Alert> GetAllAlerts()
        {
            db.Alerts.ToList().ForEach(f =>
            {
                db.Entry(f).State = EntityState.Modified;
                f.IsRead = true;
            });
            db.SaveChanges();
            return db.Alerts.AsEnumerable();
        }

        //GET api/Alerts/RemoveAllAlerts
        [HttpGet]
        [ActionName("RemoveAllAlerts")]
        public HttpResponseMessage RemoveAllAlerts()
        {
            List<Alert> alert = db.Alerts.ToList();
            if (alert == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            alert.ForEach(f => {
                db.Alerts.Remove(f);
            });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, alert);

        }


        // GET api/Alerts/5
        public Alert GetAlert(string id)
        {
            Alert alert = db.Alerts.Find(id);
            //if (alert == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}

            return alert;
        }

        // PUT api/Alerts/5
        public HttpResponseMessage PutAlert(int id, Alert alert)
        {
            if (ModelState.IsValid && id == alert.Id)
            {
                db.Entry(alert).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Alerts
        public HttpResponseMessage PostAlert(Alert alert)
        {
            if (ModelState.IsValid)
            {
                db.Alerts.Add(alert);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, alert);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = alert.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Alerts/5
        public HttpResponseMessage DeleteAlert(string id)
        {
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Alerts.Remove(alert);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, alert);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}