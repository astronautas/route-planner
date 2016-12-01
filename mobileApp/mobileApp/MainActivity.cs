using Android.App;
using Android.Widget;
using Android.OS;

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            int count = 1;
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

