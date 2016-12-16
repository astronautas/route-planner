using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Views;
using Java.Interop;

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            
            LoadToolbar();
            LoadEvents();
        }

        private void LoadToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Route Planner";
        }

        private void LoadEvents()
        {
            Button button = FindViewById<Button>(Resource.Id.SearchRoutesBtn);

            button.Click += HandleSearchRoutesBtnClick;
        }

        private void HandleSearchRoutesBtnClick(object sender, EventArgs ea)
        {
            var firstCity = FindViewById<EditText>(Resource.Id.firstCity).Text;
            var secondCity = FindViewById<EditText>(Resource.Id.secondCity).Text;

            // Call route search here
        }
    }
}

