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

namespace mobileApp
{
    static class CalculateRoute
    {
        public static List<Position> GetPositions(AssetManager assets)
        {
            List<Position> list = new List<Position>();
            using (StreamReader reader = new StreamReader(assets.Open("routepoints.txt")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var words = line.Split(' ');
                    list.Add(new Position(Convert.ToDouble(words[1]), Convert.ToDouble(words[0])));
                }
            }
            return list;
        }
    }
}