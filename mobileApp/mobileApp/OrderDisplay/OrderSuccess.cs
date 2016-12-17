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

namespace mobileApp.OrderDisplay
{
    [Activity(Label = "OrderSuccess")]
    public class OrderSuccess : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.order_success);

            var backBtn = FindViewById<Button>(Resource.Id.successBtn);

            backBtn.Click += (arg1, arg2) =>
            {
                StartActivity(typeof(MainActivity));
            };

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Route Planner";
        }
    }
}