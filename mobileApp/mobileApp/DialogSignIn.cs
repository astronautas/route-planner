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
    class DialogSignIn : DialogFragment
    {
        private EditText _txtLoginName;
        private EditText _txtLoginPassowrd;
        private Button _btnSignIn;

        public EventHandler<OnSignInEventArgs> _onSignInComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_sign_in, container, false);
            _txtLoginName = view.FindViewById<EditText>(Resource.Id.txtLoginName);
            _txtLoginPassowrd = view.FindViewById<EditText>(Resource.Id.txtLoginPassword);
            _btnSignIn = view.FindViewById<Button>(Resource.Id.btnDialogSignIn);

            _btnSignIn.Click += ButtonClicked;

            return view;
        }

        private void ButtonClicked(object sender, EventArgs args)
        {
            _onSignInComplete(this, new OnSignInEventArgs(_txtLoginName.Text, _txtLoginPassowrd.Text));
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