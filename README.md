#the Good Push
##the API Service
---

###the Introduction


> **Note:** This project code is related to a presentation performed during a [CocoaHeads Meetup](http://www.meetup.com/Cleveland-CocoaHeads/events/135931172/) in Cleveland, Ohio. This demo is used in conjunction with the iOS client called [theGoodPush_iOS_Client](https://github.com/hylander0/theGoodPush_iOS_Client). 

###the Setup

This is a **Visual Studio 2012** project.  It is an **ASP.NET MVC/WebApi** project that provides a **REST/JSON** service endpoint and a push notification HTML form for sending push notifications.  This project uses Model First **Entity Framework** 5.0 and will use **IIS Express/LocalDB** to setup the database on first run (_no database setup required_).

This implementation also uses an **Urban Airship Service Wrapper** called [urbanairship-dot-net-client
](https://github.com/heapsource/urbanairship-dot-net-client). This is exclusively for sending push notification requests to Urban Airship's REST API's.

####Urban Airship Configuration

1. [Sign up](http://urbanairship.com/) for a Urban Airship Account
2. After signing up and [setting up an application in UrbanAirship](http://docs.urbanairship.com/build/ios.html#set-up-your-application-with-apple) you will be provided an **App Key** and an **App Master Secret** (not to be mistaken for the App Secret).  You will apply both of those values to the **web.config** file found [here](https://github.com/hylander0/theGoodPush_API_Service/blob/master/theGoodPushService/Web.config#L12)
3. Alternitively, you may want to set a default **DeviceToken** (iOS) [here](https://github.com/hylander0/theGoodPush_API_Service/blob/master/theGoodPushService/Web.config#L12)


####Application setup

This project should run an IIS instance (opposed to the IISExpress).  This will allow the service to be available to devices and browsers outside the environment itself.  [Here](http://www.iis.net/learn/develop/using-visual-studio-with-iis/using-visual-studio-2008-with-iis) is a good resource for properly running this application under IIS.  You will also need to point the **Entity Framework** [Connection string](https://github.com/hylander0/theGoodPush_API_Service/blob/master/theGoodPushService/Web.config#L14) to a full **SQL server** instance instead of using the **LocalDB**. 

###the Author

* Justin Hyland - Email: justin.hyland@live.com

## MIT License

Copyright (c) 2012, 2013 Heapsource.com and Contributors - http://www.heapsource.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/hylander0/thegoodpush_api_service/trend.png)](https://bitdeli.com/free "Bitdeli Badge")

