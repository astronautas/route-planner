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

namespace mobileApp
{
    [Activity(Label = "mobileApp", MainLauncher = false, Icon = "@drawable/icon")]
    class GeneratedRoutes : Activity, IOnMapReadyCallback
    {
        public GoogleMap mMap;
        MapFragment mapFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.generatedroute);

            mapFragment = new MapFragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.fragmentMap, mapFragment);
            ft.Commit();
            
            SetUpMap();
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