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
    class RegistrationActivity : Activity
    {
        private EditText _txtRegisterEmail;
        private EditText _txtRegisterPassword;
        private EditText _txtRegCardNumber;
        private EditText _txtRegCardCode;
        private EditText _txtRegCardDate;
        private Button _btnRegister;
        private ImageButton _regbtnFB;
        private ImageButton _regbtnTwitter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

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
            _btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            _btnRegister.Click += RegisterButtonClick;

            _regbtnFB = FindViewById<ImageButton>(Resource.Id.regbtnFB);
            _regbtnFB.Click += RegisterWithFacebookClick;

            _regbtnTwitter = FindViewById<ImageButton>(Resource.Id.regbtnTwitter);
            _regbtnTwitter.Click += RegisterWithTwitterClick;
        }
        private void RegisterButtonClick(object sender, EventArgs args)
        {
            _txtRegisterEmail = FindViewById<EditText>(Resource.Id.txtRegisterEmail);
            _txtRegisterPassword = FindViewById<EditText>(Resource.Id.txtRegisterPassword);
            _txtRegCardNumber = FindViewById<EditText>(Resource.Id.txtRegCardNumber);
            _txtRegCardCode = FindViewById<EditText>(Resource.Id.txtRegCardCode);
            _txtRegCardDate = FindViewById<EditText>(Resource.Id.txtRegCardDate);

            //Save data

        }
        private void RegisterWithFacebookClick(object sender, EventArgs args)
        {
            //Implement Registration with facebook
        }
        private void RegisterWithTwitterClick(object sender, EventArgs args)
        {
            //Implemetn Registration with twitter
        }

    }
}