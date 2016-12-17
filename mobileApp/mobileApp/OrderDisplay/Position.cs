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
    class Position
    {
        public double Longitude
        {
            get;
            set;
        }
        public double Latitude
        {
            get;
            set;
        }
        public Position(double lng, double lat)
        {
            Longitude = lng;
            Latitude = lat;
        }
    }
}