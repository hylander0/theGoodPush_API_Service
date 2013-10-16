using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using theGoodPushService.DataModels;

namespace theGoodPushService.Controllers
{
    public class SettingsController : ApiController
    {

        private GoodPushContext db = new GoodPushContext();

        // Get api/Settings/GetDeviceSetting
        [HttpGet]
        [ActionName("GetDeviceSetting")]
        public Models.DeviceSetting GetDeviceSetting(string deviceToken, string alias)
        {
            Models.DeviceSetting retval;
            if (string.IsNullOrEmpty(deviceToken) && string.IsNullOrEmpty(alias))
                return null;

            if (string.IsNullOrEmpty(alias))
            {
                retval = db.DeviceSettings
                    .Where(w => w.DeviceToken == deviceToken)
                    .Select(s => new Models.DeviceSetting { 
                        DeviceToken = s.DeviceToken,
                        Alias = s.Alias,
                        IsPushEnabled = s.IsPushEnabled,
                        IsSoundEnabled = s.IsSoundEnabled
                    }).FirstOrDefault();
            }
            else
            {
                retval = db.DeviceSettings
                    .Where(w => w.Alias == alias)
                    .Select(s => new Models.DeviceSetting
                    {
                        DeviceToken = s.DeviceToken,
                        Alias = s.Alias,
                        IsPushEnabled = s.IsPushEnabled,
                        IsSoundEnabled = s.IsSoundEnabled
                    }).FirstOrDefault();
            }

            return retval;

        }

        // SET api/Settings/SetDeviceSetting
        [HttpPost]
        [ActionName("SetDeviceSetting")]
        public void SetDeviceSetting(Models.DeviceSetting setting)
        {
            DataModels.DeviceSetting settingToSave;
            if (string.IsNullOrEmpty(setting.Alias) && string.IsNullOrEmpty(setting.DeviceToken))
                return;

            settingToSave = db.DeviceSettings.Where(w => w.DeviceToken.ToLower() == setting.DeviceToken.ToLower()).FirstOrDefault();

            if (settingToSave == null)
            {
                settingToSave = new DeviceSetting();
                db.Entry(settingToSave).State = EntityState.Added;
            }
            else
                db.Entry(settingToSave).State = EntityState.Modified;

            settingToSave.Alias = setting.Alias;
            settingToSave.DeviceToken = setting.DeviceToken;
            settingToSave.IsPushEnabled = setting.IsPushEnabled;
            settingToSave.IsSoundEnabled = setting.IsSoundEnabled;

            db.SaveChanges();
           
        }
    }
}
