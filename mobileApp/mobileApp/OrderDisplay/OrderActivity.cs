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

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = true, Icon = "@drawable/icon")]
    class OrderActivity : Activity
    {

        private Button _btnBuyTicket;
        private TextView _txtMainFirstCity;
        private TextView _txtMainMiddleCity;
        private TextView _txtMainLastCity;
        private ListView _list;
        private List<RouteToDisplay> _items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.Order);

            LoadToolbar();
            LoadRouteCities();
            LoadEvents();

            _items = new List<RouteToDisplay>();
            _list = FindViewById<ListView>(Resource.Id.listRoutes);
            _list.ItemClick += _list_ItemClick;
            AddCities(new RouteToDisplay("Vilnius", "Siauliai", "Klaipeda", "11"));
            AddCities(new RouteToDisplay("Ukmerge", "Panevezys", "Palanga", "15"));
            AddCities(new RouteToDisplay("Kaunas", "Trakai", "Telsiai", "8"));
            AddCities(new RouteToDisplay("Vilnius", "Ukmerge", "Taujenai", "5"));

            LoadSetCities();

            
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

            //Show on the map
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

        }
    }
}