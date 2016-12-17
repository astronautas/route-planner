using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobileApp
{
    class Route
    {
        public List<SubRoute> RouteSubRoutes
        {
            get;
            set;
        }

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

        public Stop MiddleCity
        {
            get;
            set;
        }

        public double Cost
        {
            get;
            set;
        }
        public double Time
        {
            get;
            set;
        }

        public void SetMiddleCity()
        {
            var stops = GetStops();
            MiddleCity = stops[Convert.ToInt32((stops.IndexOf(stops.FirstOrDefault()) + stops.IndexOf(stops.LastOrDefault())) / 2)];
        }

        public Route()
        {

        }

        public Route(Stop source, Stop destination)
        {
            RouteSubRoutes = new List<SubRoute>();
            Source = source;
            Destination = destination;
        }

        public List<SubRoute> GetSubRoutes()
        {
            return RouteSubRoutes;
        }

        public List<Stop> GetStops()
        {
            var stops = RouteSubRoutes.Select(x => x.From).ToList();
            stops.Add(Destination);
            return stops;
        }

        public void AddSubRoute(SubRoute subRoute)
        {
            RouteSubRoutes.Add(subRoute);
            SetMiddleCity();
            Cost = RouteSubRoutes.Sum(x => x.Cost);
            Time = RouteSubRoutes.Sum(x => x.Time);
        }

        public override string ToString()
        {
            return MiddleCity == null? Source.Name + "  -  " + Destination.Name : Source.Name + "  -  " +  MiddleCity.Name + "  -  " + Destination.Name;
        }
    }
}