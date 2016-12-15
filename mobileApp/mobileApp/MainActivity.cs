using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Views;

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Route Planner";
        }
    }
}

