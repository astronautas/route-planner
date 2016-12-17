using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobileApp
{
    class Route
    {
        private List<SubRoute> _subRoutes;
        public Stop Source
        {
            get;
            set;
        }
        public Stop Destination
        {
            get;
            set;
        }

        public Route(Stop source, Stop destination)
        {
           _subRoutes = new List<SubRoute>();
            Source = source;
            Destination = destination;
        }

        public List<SubRoute> GetSubRoutes()
        {
            return _subRoutes;
        }

        public List<Stop> GetStops()
        {
            var stops = _subRoutes.Select(x => x.From).ToList();
            stops.Add(Destination);
            return stops;
        }

        public void AddSubRoute(SubRoute subRoute)
        {
            _subRoutes.Add(subRoute);
        }

        public double FullCost()
        {
            return _subRoutes.Sum(x => x.Cost);
        }

        public double FullTime()
        {
            return _subRoutes.Sum(x => x.Time);
        }
        

        public RouteToDisplay ToRouteDisplay()
        {
            //converts route for display
            throw new NotImplementedException();
        }
    }
}