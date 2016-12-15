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
    [Activity(Label = "mobileApp", MainLauncher = true, Icon = "@drawable/icon")]
    class OrderActivity : Activity
    {

        private Button _btnBuyTicket;
        private TextView _txtMainFirstCity;
        private TextView _txtMainMiddleCity;
        private TextView _txtMainLastCity;
        private ListView _list;
        private List<string> _items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.Order);

            LoadToolbar();
            LoadRouteCities();
            LoadEvents();

            _items = new List<string>();
            _list = FindViewById<ListView>(Resource.Id.listRoutes);

            AddCities("Vilnius", "Siauliai", "Klaipeda", "11");
            AddCities("Ukmerge", "Panevezys", "Palanga", "15");
            AddCities("Kaunas", "Trakai", "Telsiai", "8");
            AddCities("Vilnius", "Ukmerge", "Taujenai", "5");

            LoadSetCities();

            
        }

        public void AddCities(string first, string middle, string last, string price)
        {
            string item = first + "  -  " + middle + "  -  " + last + "   :   " + price + "$";
            _items.Add(item);
        }

        private void LoadSetCities()
        {

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _items);
            _list.Adapter = adapter;
        }

        private void LoadRouteCities()
        {
            _txtMainFirstCity = FindViewById<TextView>(Resource.Id.txtMainFirstCity);
            _txtMainMiddleCity = FindViewById<TextView>(Resource.Id.txtMainMiddleCity);
            _txtMainLastCity = FindViewById<TextView>(Resource.Id.txtMainLastCity);
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