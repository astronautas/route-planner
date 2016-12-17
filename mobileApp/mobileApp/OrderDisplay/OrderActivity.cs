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

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = false, Icon = "@drawable/icon")]
    class OrderActivity : Activity, IOnMapReadyCallback
    {
        public GoogleMap mMap;
        MapFragment mapFragment;
        private Button _btnBuyTicket;
        private TextView _txtMainFirstCity;
        private TextView _txtMainMiddleCity;
        private TextView _txtMainLastCity;
        private ListView _list;
        private List<RouteToDisplay> _items;
        private Polyline finalRoute;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Order);

            LoadToolbar();
            LoadRouteCities();
            LoadEvents();
            LoadFragment();
            SetUpMap();

            _items = new List<RouteToDisplay>();
            _list = FindViewById<ListView>(Resource.Id.listRoutes);
            _list.ItemClick += _list_ItemClick;

            //For prototype
            AddCities(new RouteToDisplay("Vilnius", "Siauliai", "Klaipeda", "11"));
            AddCities(new RouteToDisplay("Ukmerge", "Panevezys", "Palanga", "15"));
            AddCities(new RouteToDisplay("Kaunas", "Trakai", "Telsiai", "8"));
            AddCities(new RouteToDisplay("Vilnius", "Ukmerge", "Taujenai", "5"));

            LoadSetCities();

            
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
        }

        private void _list_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            for (int a = 0; a < e.Parent.ChildCount; a++)
            {
                e.Parent.GetChildAt(a).SetBackgroundColor(Color.Transparent);
            }

            e.View.SetBackgroundColor(Color.ParseColor("#fcb150"));
            SetMainCities(_items[(int)e.Id]);
            

        }

        private void SetMainCities(RouteToDisplay item)
        {
            _txtMainFirstCity.Text = item.FirstCity;
            _txtMainMiddleCity.Text = item.MiddleCity;
            _txtMainLastCity.Text = item.LastCity;

            if(item.FirstCity == "Vilnius" && item.MiddleCity == "Ukmerge" && item.LastCity == "Taujenai")
            {

                ShowOnMap();

            }
            else
            {
                finalRoute.Remove();
            }
            //Show on the map
        }

        private void ShowOnMap()
        {
            var polylineoption = new PolylineOptions();
            polylineoption.InvokeColor(Color.Red);
            polylineoption.Geodesic(true);

            List<Position> route = CalculateRoute.GetPositions(Assets);

            foreach (var pos in route)
            {
                polylineoption.Add(new LatLng(pos.Latitude, pos.Longitude));

            }

            var index = Convert.ToInt32((route.IndexOf(route.FirstOrDefault()) + route.IndexOf(route.LastOrDefault())) / 2);
            LatLng lastpos = new LatLng(route[index].Latitude, route[index].Longitude);

            finalRoute = mMap.AddPolyline(polylineoption);

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

        public void AddCities(RouteToDisplay item)
        {
            _items.Add(item);
        }

        private void LoadSetCities()
        {
            ArrayAdapter<RouteToDisplay> adapter = new ArrayAdapter<RouteToDisplay>(this, Android.Resource.Layout.SimpleListItem1, _items);
            _list.Adapter = adapter;
        }


        private void LoadRouteCities()
        {
            _txtMainFirstCity = FindViewById<TextView>(Resource.Id.txtMainFirstCity);
            _txtMainMiddleCity = FindViewById<TextView>(Resource.Id.txtMainMiddleCity);
            _txtMainLastCity = FindViewById<TextView>(Resource.Id.txtMainLastCity);

            _txtMainFirstCity.Text = null;
            _txtMainMiddleCity.Text = null;
            _txtMainLastCity.Text = null;
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
        }
    }
}