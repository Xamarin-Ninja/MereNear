using Acr.UserDialogs;
using MereNear.Resources;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

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
            ChooseLocationLabel.Text = AppResources.ChooseLocationLabel;
            DropLocationLabel.Text = AppResources.DropLocationLabel;
            NextButton.Text = AppResources.NextButton;
            try
            {
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
            catch (Exception ex)
            {

            }
        }

        private async void GetCurrentPosition()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                try
                {
                    location = await locator.GetPositionAsync(TimeSpan.FromTicks(5000));
                }
                catch (TaskCanceledException ex)
                {
                    response = Convert.ToBoolean(ex.CancellationToken.IsCancellationRequested);
                }
                catch (Exception ex)
                {
                    response = true;
                }
                if (response.HasValue)
                {
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(30.7110779, 76.686422), Distance.FromMiles(0.5)));
                    var pickedposition = new Position(30.7110779, 76.686422);
                    Geocoder gc = new Geocoder();

                    IEnumerable<string> pickedaddress = await gc.GetAddressesForPositionAsync(pickedposition);

                    address = pickedaddress.First().ToString();
                    MessagingCenter.Send(address, "LocationAddress", pickedposition);
                }
                else
                {
                    double latitude = Convert.ToDouble(location.Latitude);
                    double longitude = Convert.ToDouble(location.Longitude);
                    var pickedposition = new Position(latitude, longitude);
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMiles(0.5)));
                    Geocoder gc = new Geocoder();

                    IEnumerable<string> pickedaddress = await gc.GetAddressesForPositionAsync(pickedposition);

                    address = pickedaddress.First().ToString();
                    MessagingCenter.Send(address, "LocationAddress", pickedposition);
                }
            }
            catch (Exception ex)
            {

            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
