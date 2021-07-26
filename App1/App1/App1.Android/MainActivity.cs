using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Firebase;
using Firebase.Messaging;
using System;
using System.Collections.Generic;

namespace App1.Droid
{
    [Activity(Label = "App1Xamarin", Icon = "@mipmap/ic_launcher_round", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        //internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

           FirebaseOptions options = new FirebaseOptions.Builder() //com.companyname.App1
              .SetApplicationId("com.companyname.App1")
              .SetApiKey("AIzaSyAIUCp8VYE9491jdPKP_laT6qY3oqq4O1A")
              .SetGcmSenderId("564939494409")
              .Build();

            bool hasBeenInitialized = false;
            IList<FirebaseApp> firebaseApps = FirebaseApp.GetApps(Application.Context);
            foreach (FirebaseApp app in firebaseApps)
            {
                if (app.Name.Equals(FirebaseApp.DefaultAppName))
                {
                    hasBeenInitialized = true;
                    FirebaseApp firebaseApp = app;
                }
            }

            if (!hasBeenInitialized)
            {
                FirebaseApp firebaseApp = FirebaseApp.InitializeApp(Application.Context, options);
            }
            abone_ol("Gecikme");

            LoadApplication(new App());
        }

        private void abone_ol(string konu)
        {

            FirebaseMessaging.Instance.SubscribeToTopic(konu);
        }

    }
}