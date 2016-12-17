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

            var newFragment = new BottomToolbar();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.bottom_toolbar_container, newFragment);
            ft.Commit();

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

            //var searchBtn = FindViewById<View>(Resource.Id.searchBtn);
            //searchBtn.Click += onSearchClick;

            //var loginBtn = FindViewById<View>(Resource.Id.loginBtn);
            //loginBtn.Click += onLoginClick;
        }

        private void HandleSearchRoutesBtnClick(object sender, EventArgs ea)
        {
            var firstCity = FindViewById<EditText>(Resource.Id.firstCity).Text;
            var secondCity = FindViewById<EditText>(Resource.Id.secondCity).Text;
            StartActivity(typeof(GeneratedRoutes));
            // Call route search here
        }

        public void onLoginClick(object sender, EventArgs ea)
        {
            StartActivity(typeof(LoginActivity));
        }

        public void onSearchClick(object sender, EventArgs ea)
        {

        }
    }
}

