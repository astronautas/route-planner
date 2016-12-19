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
    class DialogRegister : DialogFragment
    {
        private TextView _txtCongratsOnReg;
        private Button _btnRegDialogProceed;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_register, container, false);
            _txtCongratsOnReg = view.FindViewById<TextView>(Resource.Id.txtCongratsOnReg);
            _txtCongratsOnReg.Text = "Sveikiname prisiregistravus!";
            _btnRegDialogProceed = view.FindViewById<Button>(Resource.Id.btnRegDialogProceed);

            _btnRegDialogProceed.Click += RegProceedButtonClicked;

            return view;
        }

        private void RegProceedButtonClicked(object sender, EventArgs args)
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