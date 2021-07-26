using Android.App;
using Android.Content;
using Firebase.Messaging;
using Android.Support.V4.App;
using Android.Util;
using System.Collections.Generic;
using Android.OS;
using Android.Graphics;

namespace App1.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            var title = message.GetNotification().Title;
            var body = message.GetNotification().Body;
            SendNotification(title,body);
        }
        void SendNotification(string title,string messageBody)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot); 
                
                var notificationBuilder = new Android.App.Notification.Builder(this)
                            .SetContentTitle(title)
                            .SetSmallIcon(Resource.Mipmap.ic_launcher_round)
                            .SetContentText(messageBody)
                            .SetAutoCancel(true)
                            .SetContentIntent(pendingIntent);

                var notificationManager = NotificationManager.FromContext(this);

                notificationManager.Notify(0, notificationBuilder.Build());
            }
            else
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

                var notificationBuilder = new Android.App.Notification.Builder(this)
                            .SetContentTitle(title)
                            .SetSmallIcon(Resource.Mipmap.ic_launcher_round)
                            .SetContentText(messageBody)
                            .SetAutoCancel(true)
                            .SetContentIntent(pendingIntent)
                            .SetChannelId("10001");

                //var notificationManager = NotificationManager.FromContext(this);

                if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                {
                    // Notification channels are new in API 26 (and not a part of the
                    // support library). There is no need to create a notification 
                    // channel on older versions of Android.
                    return;
                }

                var channel = new NotificationChannel("10001", "FCM Notifications", NotificationImportance.Default)
                {
                    Description = "Firebase Cloud Messages appear in this channel"
                };

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);

                notificationManager.Notify(0, notificationBuilder.Build());
            }
        }
    }
}