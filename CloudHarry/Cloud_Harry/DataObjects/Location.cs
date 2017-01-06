using Microsoft.Azure.Mobile.Server;
using System;

namespace Cloud_Harry.DataObjects
{
    public class Location : EntityData
    {
        public string Name { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }

        public string Geolocation { get; set; }

        public DateTime CreatedTimeStamp { get; set; }
    }
}