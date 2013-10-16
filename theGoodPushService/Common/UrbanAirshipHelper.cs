using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theGoodPushService.Common
{
    public class UrbanAirshipHelper
    {
        private static string DEFAULT_DEVICE_TOKEN = "fb3e76aeffbea7e9ba3ee75f68ca16b5dcd688696b159a5270657a4c32dfd4da";
        private static string ALIAS = "john";
        public static void SendPush(int messageId, string name, int rating, int badgeNumber)
        {
            List<DataModels.DeviceSetting> settings = new DataModels.GoodPushContext()
                                                            .DeviceSettings.ToList();


            foreach (var setting in settings)
            {
                UrbanAirship.Client c = new UrbanAirship.Client();
                UrbanAirship.PushNotification p = c.CreatePush();

                p.NotificationMetaData = new UrbanAirship.Extensibility.JsonDictionary<string, object>();
                p.NotificationMetaData.Add("Id", messageId.ToString());

                p.NotificationMetaData.Add("name", name);

                p.DeviceTokens = new List<string>();
                p.Aliases = new List<string>();

                if (!string.IsNullOrEmpty(setting.Alias))
                    p.Aliases.Add(setting.Alias);
                else if (!string.IsNullOrEmpty(setting.DeviceToken))
                    p.DeviceTokens.Add(setting.DeviceToken);
                else
                    p.DeviceTokens.Add(DEFAULT_DEVICE_TOKEN);

                p.iOS.Alert = string.Format("You have recieved {0} {1} in your survey", rating, (rating > 1 ? "stars" : "star"));
                p.iOS.Badge = badgeNumber;
                if(setting.IsSoundEnabled)
                    p.iOS.Sound = "theGoodPush.m4a";
                if(setting.IsPushEnabled)
                    p.Send();
            }

        }
        public static void SendPush(string name, string messageText, int badgeNumber)
        {
            List<DataModels.DeviceSetting> settings = new DataModels.GoodPushContext()
                                                .DeviceSettings.ToList();


            foreach (var setting in settings)
            {
                UrbanAirship.Client c = new UrbanAirship.Client();
                UrbanAirship.PushNotification p = c.CreatePush(); ;

                p.NotificationMetaData = new UrbanAirship.Extensibility.JsonDictionary<string, object>();

                p.DeviceTokens = new List<string>();
                p.Aliases = new List<string>();
                if (!string.IsNullOrEmpty(setting.Alias))
                    p.Aliases.Add(setting.Alias);
                else if (!string.IsNullOrEmpty(setting.DeviceToken))
                    p.DeviceTokens.Add(setting.DeviceToken);
                else
                    p.DeviceTokens.Add(DEFAULT_DEVICE_TOKEN);
                p.iOS.Alert = string.Format("{0} said: '{1}'", name, messageText);
                p.iOS.Badge = badgeNumber;
                if (setting.IsSoundEnabled)
                    p.iOS.Sound = "theGoodPush.m4a";
                if (setting.IsPushEnabled)
                    p.Send();
            }

        }

    }
}