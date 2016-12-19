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
using Android.Graphics;
using Android.Webkit;
using Android.Gms.Maps;
using System.Threading.Tasks;
using Android.Locations;
using Android.Gms.Maps.Model;
using System.IO;
using Android.Content.Res;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace mobileApp.OrderDisplay
{
    [Activity(Label = "mobileApp", MainLauncher = false, Icon = "@drawable/icon")]
    class OrderActivity : Activity, IOnMapReadyCallback
    {
        public GoogleMap mMap;
        MapFragment mapFragment;
        private Button _btnBuyTicket;
        private TextView _txtMainCities;
        private TextView _txtPrice;
        private TextView _txtTime;
        private ListView _list;
        private List<SubRoute> _items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Order);

            string text = Intent.GetStringExtra("ChosenRoute");
            Route route = JsonConvert.DeserializeObject<Route>(text);

            _items = new List<SubRoute>();
            
            AddSubRoutes(route);
            LoadSubRoutes();
            LoadFragment();
            SetUpMap();
            LoadToolbar();
            LoadRouteCities();
            LoadEvents();
            SetCities(route);
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                mapFragment.GetMapAsync(this);
            }
        }

        private void LoadFragment()
        {
            mapFragment = new MapFragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.fragmentMap, mapFragment);
            ft.Commit();
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            ShowOnMap();
        }

        private void SetCities(Route mainRoute)
        {
            _txtMainCities.Text = mainRoute.ToString();
            _txtPrice.Text = "Kaina: " + mainRoute.Cost.ToString() + "€";
            _txtTime.Text = "Trukme: " + mainRoute.Time.ToString() + "h";
        }

        public void AddSubRoutes(Route mainRoute)
        {
            foreach(SubRoute sr in mainRoute.RouteSubRoutes)
                _items.Add(sr);
        }

        private void LoadSubRoutes()
        {
            _list = FindViewById<ListView>(Resource.Id.listRoutes);
            _list.Enabled = false;
            ArrayAdapter<SubRoute> adapter = new ArrayAdapter<SubRoute>(this, Android.Resource.Layout.SimpleListItem1, _items);
            _list.Adapter = adapter;
        }

        private void ShowOnMap()
        {
            var polylineoption = new PolylineOptions();
            polylineoption.InvokeColor(Color.ParseColor("#509BFC"));
            polylineoption.Geodesic(true);

            List<Position> route = CalculateRoute.GetPositions(Assets);

            foreach (var pos in route)
            {
                polylineoption.Add(new LatLng(pos.Latitude, pos.Longitude));

            }

            var index = Convert.ToInt32((route.IndexOf(route.FirstOrDefault()) + route.IndexOf(route.LastOrDefault())) / 2);
            LatLng lastpos = new LatLng(route[index].Latitude, route[index].Longitude);

            mMap.AddPolyline(polylineoption);

            UpdateCameraPosition(lastpos);
        }
        private void UpdateCameraPosition(LatLng pos)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(pos);
            builder.Zoom(8);
            builder.Bearing(40);
            builder.Tilt(10);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            mMap.AnimateCamera(cameraUpdate);
        }
        


        private void LoadRouteCities()
        {
            _txtMainCities = FindViewById<TextView>(Resource.Id.txtMainCities);
            _txtPrice = FindViewById<TextView>(Resource.Id.txtPrice);
            _txtTime = FindViewById<TextView>(Resource.Id.txtTime);
        }

        private void LoadToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Route Planner";
        }

        private void LoadEvents()
        {

            _btnBuyTicket = FindViewById<Button>(Resource.Id.btnBuyTicket);
            _btnBuyTicket.Click += BuyTicketButton;
        }

        private void BuyTicketButton(object sender, EventArgs args)
        {
            //Send to Succeeded or failed payment or smth.
            StartActivity(typeof(OrderSuccess));
        }
    }
}