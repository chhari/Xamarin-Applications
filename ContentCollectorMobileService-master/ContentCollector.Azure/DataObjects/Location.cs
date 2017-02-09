using System;
using Microsoft.Azure.Mobile.Server;

namespace ContentCollector.Azure.DataObjects
{
    public class Location : EntityData
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }

        public string Geolocation { get; set; }

    }
}