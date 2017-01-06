using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portable.Model;
using Xamarin.Forms;
using Portable.Services;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Maps;

namespace Portable
{
    public partial class LocationDetailPage : ContentPage
    {
        private readonly DataManager _dataManager;
        private Location vm;

        public LocationDetailPage()
        {
            _dataManager = DataManager.DefaultManager;
            vm = new Location();
            BindingContext = vm;
            Title = "New Location";
            InitializeComponent();
        }

        public LocationDetailPage(Location location)
        {
            _dataManager = DataManager.DefaultManager;
            vm = location;
            BindingContext = vm;
            Title = vm.Name;
            InitializeComponent();
            SetMap(location.Latitude, location.Longitude);
        }
        private async void OnSaveLocation(object sender,EventArgs e)
        {
            await _dataManager.SaveLocationAsync(vm);
            await Navigation.PopToRootAsync();
        }
        private async void OnGetCurrentLocation(object sender, EventArgs e)
        {
            //Get CUrrent Location
            var geoService = new GeoCodingService();
            var results = await geoService.GetCurrentLocation();

            vm.Latitude = results.Latitude;
            vm.Longitude = results.Longitude;
            vm.Altitude = results.Altitude;

            //Reverse GeoCode
         
                //Reverse GeoCode Results
                var reverseResults = await geoService.ReverseGeoCodePosition(results.Latitude, results.Longitude);

                vm.Geolocation = reverseResults.FirstOrDefault();

                if (vm.Name == null)
                {
                    vm.Name = vm.Geolocation;
                }
            await _dataManager.SaveLocationAsync(vm);
            BindingContext = vm;
            SetMap(vm.Latitude, vm.Longitude);
        }
        private void SetMap(double latitude, double longitude)
        {
            
            LocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(latitude, longitude), Distance.FromMiles(0.3)));
        }
        private void OnReverseGeoCodeLocation(object sender, EventArgs e)
        {

        }
    }
}
