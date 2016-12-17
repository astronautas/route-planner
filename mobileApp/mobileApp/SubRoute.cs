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
    class SubRoute
    {
        public Stop From
        {
            get;
            set;
        }
        public Stop To
        {
            get;
            set;
        }
        public double Cost
        {
            get;
            set;
        }
        public double Time
        {
            get;
            set;
        }

        public SubRoute(Stop from, Stop to, double cost, double time)
        {
            if(CheckIfProperCostAndTime(cost, time) && CheckIfProperStops(from,to))
            {
                From = from;
                From.DirectsTo = to;
                To = to;
                Cost = cost;
                Time = time;
            }
        }

        private bool CheckIfProperStops(Stop a, Stop b)
        {
            if (a.Name == b.Name)
                return false;
            return true;
                
        }

        private bool CheckIfProperCostAndTime(double cost, double time)
        {
            if (cost < 0 || time<0 | time >= 24)
                return false;
            return true;

        }

        public override string ToString()
        {
            return "From " + From.Name + " to " + To.Name + " costs " + Cost + " and takes " + Time + " time.";
        }
    }
}