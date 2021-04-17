using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Firebase.Iid;
using Firebase;

namespace MultiProjects.Droid
{
    [Activity(Label = "Quiz Bleat", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
           //CreateNotificationChannel();
            //  var token = GetToken().Result;
            // FirebaseApp.InitializeApp(Application.Context);
            // var t = FirebaseInstanceId.Instance.GetToken("334574478674", "FCM");
            LoadApplication(new App());
        }

        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private async Task<string> GetToken()  
        {
            string token =string.Empty;
            await Task.Run(() =>
            {
                 token = FirebaseInstanceId.Instance.GetToken("334574478674", "FCM");
                    Console.WriteLine("the token {0}", token);
                // https://firebase.google.com/docs/reference/android/com/google/firebase/iid/FirebaseInstanceId.html#public-string-gettoken-string-senderid,-string-scope
                if (token != "")
                {
                    // update saved token, send it to the backend, etc.
                }
                
            });
            return token;
        }
    }
}