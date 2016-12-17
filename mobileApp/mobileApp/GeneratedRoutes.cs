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
using Android.Gms.Maps;
using Android.Graphics;
using mobileApp.OrderDisplay;
using Newtonsoft.Json;

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = false, Icon = "@drawable/icon")]
    class GeneratedRoutes : Activity, IOnMapReadyCallback
    {
        public GoogleMap mMap;
        MapFragment mapFragment;
        private ScrollView _generatedRoutesView;
        private List<Route> _generatedRoutes = new List<Route>(); //temp

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.generatedroute);

            mapFragment = new MapFragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.fragmentMap, mapFragment);
            ft.Commit();
            
            SetUpMap();
            _generatedRoutesView = FindViewById<ScrollView>(Resource.Id.routesScrollView);
            //testing
            var vilnius = new Stop("Vilnius");
            var klaipeda = new Stop("Klaipeda");
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));
            _generatedRoutes.Add(new Route(vilnius, klaipeda));

            ShowGeneratedRoutes();
        }

        private void ShowGeneratedRoutes() //drawing UI elements needs to be fixed
        {
            TableLayout layout = FindViewById<TableLayout>(Resource.Id.routeList);
            foreach (var route in _generatedRoutes)
            {
                var text = new TextView(this);
                text.Text = route.ToString();
                text.SetTextColor(new Color(252, 177, 80)); //our orange
                text.SetTextSize(Android.Util.ComplexUnitType.Pt, 10);
                //text.SetWidth();
                //text.SetHeight();

                var button = new Button(this);
                button.Text = "Pirkti";
                button.Background = Resources.GetDrawable(Resource.Drawable.OrangeActionBtn); //deprecated but fuck it
                button.SetTextColor(Color.White);
                button.Click += (obj, evnt) => { Order(route); };

                var tableRow = new TableRow(this);
                tableRow.SetMinimumHeight(250);
                tableRow.AddView(text);
                tableRow.AddView(button);

                layout.AddView(tableRow);
            }
        }

        private void Order(Route route)
        {
            //string output = string.Empty;
            string output = JsonConvert.SerializeObject(route);

            var activity2 = new Intent(this, typeof(OrderActivity));
            activity2.PutExtra("ChosenRoute", output);
            StartActivity(activity2);
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                mapFragment.GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
        }
    }
}