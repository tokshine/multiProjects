﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MultiProjects.Droid
{
    [Activity(Label = "Quiz App", 
        Icon = "@drawable/icon", 
        Theme="@style/SplashTheme",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            CallMainActivity();
        }

        private void CallMainActivity()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}