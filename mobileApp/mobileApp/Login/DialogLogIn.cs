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
    class DialogLogIn : DialogFragment
    {
        private TextView _txtCongratsOnLogin;
        private Button _btnDialogProceed;
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_log_in, container, false);
            _txtCongratsOnLogin = view.FindViewById<TextView>(Resource.Id.txtCongratsOnLogin);
            _txtCongratsOnLogin.Text = "Sveikiname prisijungus!";
            _btnDialogProceed = view.FindViewById<Button>(Resource.Id.btnDialogProceed);

            _btnDialogProceed.Click += ProceedButtonClicked;

            return view;
        }

        private void ProceedButtonClicked(object sender, EventArgs args)
        {
            Dismiss();
            var intent = new Intent(this.Activity, typeof(MainActivity));
            StartActivity(intent);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}