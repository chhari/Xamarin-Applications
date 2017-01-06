using Xamarin.Forms.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Services
{
    public interface IGeoCodingService
    {
        Position NullPosition { get; }

        Task<Position> GeoCodeAddress(string addressString);

        Task<IEnumerable<string>> ReverseGeoCodePosition(double latitude, double longitude);

        Task<Position> GetCurrentLocation();
    }
}
