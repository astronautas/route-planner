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
        private Button _btnToRegistration;
        private ImageButton _btnLogFB;
        private ImageButton _btnLogTwitter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

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

            _btnLogFB = FindViewById<ImageButton>(Resource.Id.btnLogFB);
            _btnLogFB.Click += ButtonLogWithTwitterClicked;

            _btnLogTwitter = FindViewById<ImageButton>(Resource.Id.btnLogTwitter);
            _btnLogTwitter.Click += ButtonLogWithFBClicked;

            _btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            _btnLogin.Click += LoginButtonClicked;

            _btnToRegistration = FindViewById<Button>(Resource.Id.btnToRegistration);
            _btnToRegistration.Click += RegisterHereButtonClicked;

            var searchBtn = FindViewById<ImageView>(Resource.Id.searchBtn);
            searchBtn.Click += onSearchClick;

            var loginBtn = FindViewById<ImageView>(Resource.Id.loginBtn);
            loginBtn.Click += onLoginClick;
        }

        private void ButtonLogWithFBClicked(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void ButtonLogWithTwitterClicked(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void RegisterHereButtonClicked(object sendeer, EventArgs args)
        {
            StartActivity(typeof(RegistrationActivity));
        }

        private void LoginButtonClicked(object sender, EventArgs args)
        {
            _txtLoginEmail = FindViewById<EditText>(Resource.Id.txtLoginEmail);
            _txtLoginPassword = FindViewById<EditText>(Resource.Id.txtLoginPassword);

            OpenDialog();
        }

        // Bottom toolbar events
        public void onLoginClick(object sender, EventArgs ea)
        {
            StartActivity(typeof(LoginActivity));
        }

        public void onSearchClick(object sender, EventArgs ea)
        {
            StartActivity(typeof(MainActivity));
        }
        private void OpenDialog()
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogLogIn logInDialog = new DialogLogIn();
            logInDialog.Show(transaction, "dialog fragment");
        }
    }
}