using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.Views
{
    public partial class PickLocationMapPage : ContentPage
    {
        public string address;
        public PickLocationMapPage()
        {
            InitializeComponent();
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(30.711262, 76.686310), Distance.FromMiles(0.1)));
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
                    MessagingCenter.Send(address, "LocationAddress");
                }
            };
        }
    }
}
