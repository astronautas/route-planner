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
    class RouteToDisplay
    {
        public string FirstCity
        {
            get;
            set;
        }
        public string MiddleCity
        {
            get;
            set;
        }
        public string LastCity
        {
            get;
            set;
        }
        public string Price
        {
            get;
            set;
        }

        public RouteToDisplay(string firstCity, string middleCity, string lastCity, string price)
        {
            FirstCity = firstCity;
            MiddleCity = middleCity;
            LastCity = lastCity;
            Price = price;
        }

        public override string ToString()
        {
            string str = FirstCity + "  -  " + MiddleCity + "  -  " + LastCity + "   :   " + Price + "€";
            return str;
        }
    }
}