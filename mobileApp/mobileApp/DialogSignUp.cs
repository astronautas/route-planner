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
    class DialogSignUp : DialogFragment
    {
        private EditText _txtFirstName;
        private EditText _txtEmail;
        private EditText _txtPassword;
        private Button _btnSignUp;

        public event EventHandler<OnSignUpEventArgs> _onSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            _txtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            _txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            _txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            _btnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogSignUp);

            _btnSignUp.Click += ButtonClicked;

            return view;
        }

        private void ButtonClicked(object sender, EventArgs args)
        {
            _onSignUpComplete(this, new OnSignUpEventArgs(_txtFirstName.Text, _txtEmail.Text, _txtPassword.Text));
            Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}