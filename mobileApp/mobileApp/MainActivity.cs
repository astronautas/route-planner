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
        private Button _btnSignUp;
        private Button _btnSignIn;
        private ProgressBar _progressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _btnSignUp = FindViewById<Button>(Resource.Id.buttonSignUp);
            _btnSignIn = FindViewById<Button>(Resource.Id.buttonSignIn);

            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            _btnSignUp.Click += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignUp signUpDialog = new DialogSignUp();
                signUpDialog.Show(transaction, "dialog fragment");

                signUpDialog._onSignUpComplete += OnSignUp;
            };

            _btnSignIn.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignIn signInDialog = new DialogSignIn();
                signInDialog.Show(transaction, "dialog fragment");

                signInDialog._onSignInComplete += OnSignIn;
            };



        }


        void OnSignUp(object sender, OnSignUpEventArgs args)
        {
            _progressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(() => RequestSignUp(args));
            thread.Start();

        }

        void OnSignIn(object sender, OnSignInEventArgs args)
        {
            _progressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(() => RequestSignIn(args));
            thread.Start();
        }
        //Po sign up dialoge nuspaudimo gaunam user input reiktu irasyt i serveri ar patikrint
        private void RequestSignUp(OnSignUpEventArgs args)
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => _progressBar.Visibility = ViewStates.Invisible);
        }
        private void RequestSignIn(OnSignInEventArgs args)
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => _progressBar.Visibility = ViewStates.Invisible);
        }
    }
}

