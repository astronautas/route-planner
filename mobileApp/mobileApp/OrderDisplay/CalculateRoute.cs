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
using System.IO;
using Android.Content.Res;

namespace mobileApp.OrderDisplay
{
    static class CalculateRoute
    {
        public static List<Position> GetPositions(AssetManager assets)
        {
            List<Position> list = new List<Position>();
            /* using (StreamReader reader = new StreamReader(assets.Open("routepoints.txt")))
             {
                 while (!reader.EndOfStream)
                 {
                     var line = reader.ReadLine();
                     var words = line.Split(' ');
                     double lng;
                     double lat;
                     Double.TryParse(words[1], out lng);
                     Double.TryParse(words[0], out lat);
                     list.Add(new Position(lng, lat));
                 }
             }
             return list;*/
            Coords coordinates = new Coords();
            for(int i = 0; i < coordinates.Count(); i=i+2)
            {
                list.Add(new Position(coordinates[i+1], coordinates[i]));
            }
            return list;
        }
    }
}