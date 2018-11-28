using Acr.UserDialogs;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.Views
{
    public partial class PickLocationMapPage : ContentPage
    {
        public string address { get; set; }
        public Plugin.Geolocator.Abstractions.Position location;
        public bool? response;
        public PickLocationMapPage()
        {
            InitializeComponent();

            GetCurrentPosition();
            customMap.PropertyChanged += async (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                var m = (Map)sender;
                if (m.VisibleRegion != null)
                {
                    // Debug.WriteLine("Lat: " + m.VisibleRegion.Center.Latitude.ToString() + " Lon:" + m.VisibleRegion.Center.Longitude.ToString());
                    var pickedposition = m.VisibleRegion.Center;
                    Geocoder gc = new Geocoder();

                    IEnumerable<string> pickedaddress = await gc.GetAddressesForPositionAsync(pickedposition);

                    address = pickedaddress.First().ToString();
                    MessagingCenter.Send(address, "LocationAddress", pickedposition);
                }
            };
        }

        private async void GetCurrentPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            try
            {
                location = await locator.GetPositionAsync(TimeSpan.FromTicks(10000));
            }
            catch (TaskCanceledException ex)
            {
                response = Convert.ToBoolean(ex.CancellationToken.IsCancellationRequested);
            }
            if (response.HasValue)
            {
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(30.7110779,76.686422), Distance.FromMiles(0.5)));
                var pickedposition = new Position(30.7110779, 76.686422);
                Geocoder gc = new Geocoder();

                IEnumerable<string> pickedaddress = await gc.GetAddressesForPositionAsync(pickedposition);

                address = pickedaddress.First().ToString();
                MessagingCenter.Send(address, "LocationAddress", pickedposition);
            }
            else
            {
                double? latitude = Convert.ToDouble(location.Latitude);
                double? longitude = Convert.ToDouble(location.Longitude);
                var pickedposition = new Position(latitude.Value, longitude.Value);
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude.Value, longitude.Value), Distance.FromMiles(0.5)));
                Geocoder gc = new Geocoder();

                IEnumerable<string> pickedaddress = await gc.GetAddressesForPositionAsync(pickedposition);

                address = pickedaddress.First().ToString();
                MessagingCenter.Send(address, "LocationAddress", pickedposition);
            }

        }
    }
}
