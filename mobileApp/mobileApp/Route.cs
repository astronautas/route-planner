using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobileApp
{
    class Route
    {
        private List<Stop> _stops;
        private List<float> _costs;
        private List<float> _times;

        public Route()
        {
            _stops = null;
            _costs = null;
            _times = null;
        }

        public void AddStop(Stop stop, float cost, float time)
        {
            if (_stops != null)
            {
                _costs.Add(cost);
                _times.Add(time);
            }
            _stops.Add(stop);
        }

        public void AddSubRoute(Stop from, Stop to, float cost, float time)
        {
            _stops.Add(from);
            _stops.Add(to);
            _costs.Add(cost);
            _times.Add(time);
        }

        public float FullCost()
        {
            return _costs.Sum();
        }

        public float FullTime()
        {
            return _times.Sum();
        }

        public RouteToDisplay ToRouteDisplay()
        {
            //converts route for display
            throw new NotImplementedException();
        }
    }
}