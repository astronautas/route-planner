using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = false, Icon = "@drawable/icon")]
    class LoginActivity : Activity
    {
        private EditText _txtLoginEmail;
        private EditText _txtLoginPassword;
        private Button _btnLogin;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

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
            _btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            _btnLogin.Click += LoginButtonClicked;
        }

        private void LoginButtonClicked(object sender, EventArgs args)
        {
            _txtLoginEmail = FindViewById<EditText>(Resource.Id.txtLoginEmail);
            _txtLoginPassword = FindViewById<EditText>(Resource.Id.txtLoginPassword);
        }
    }
}