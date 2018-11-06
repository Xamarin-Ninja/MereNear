using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.Common
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapView : ContentView
	{
        public double latitude;
        public double longitude;

        public MapView ()
		{
			InitializeComponent ();
            GetCurrentLoactionAsync(MapType.Street);
            GetMessagingCenterData();
            GetDataWithBlankSearch();
            var pickLocation = GetMapCenterLocation();

        }

        internal Func<Position> NativeGetMapCenterLocation { get; set; }

        public Position GetMapCenterLocation()
        {
            if (NativeGetMapCenterLocation != null)
            {
                return NativeGetMapCenterLocation();
            }
            else
            {
                return new Position(0, 0);
            }
        }
        

        private void GetDataWithBlankSearch()
        {
            MessagingCenter.Subscribe<string>(this, "BlankSearhBar",(sender)=> 
            {

            });
        }

        private void GetMessagingCenterData()
        {
            MessagingCenter.Subscribe<string>(this, "MapType", (sender) =>
            {
                var maptype = sender;
                if(maptype == "Standard")
                {
                    GetCurrentLoactionAsync(MapType.Street);
                }
                else if (maptype == "Satellite")
                {
                    GetCurrentLoactionAsync(MapType.Satellite);
                }
            });
        }

        private async void GetCurrentLoactionAsync(MapType mapType)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var location = await locator.GetPositionAsync(TimeSpan.FromTicks(10000));
            LoadMap(location.Latitude, location.Longitude, mapType);
        }

        private void LoadMap(double lat, double longi, MapType mapType)
        {
            var map = new Map()
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = mapType
            };


            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(lat, longi),
                Distance.FromMiles(0.5)));

            Content = map;

            MessagingCenter.Subscribe<IEnumerable<Position>>(this, "SearchBarWithMapView", (sender) =>
            {
                try
                {
                    if (Application.Current.Properties.ContainsKey("MapType"))
                    {
                        if (Application.Current.Properties["MapType"].ToString() == "Standard")
                        {
                            Application.Current.Properties.Remove("MapType");
                            map.MapType = MapType.Street;
                        }
                        else if (Application.Current.Properties["MapType"].ToString() == "Satellite")
                        {
                            Application.Current.Properties.Remove("MapType");
                            map.MapType = MapType.Satellite;
                        } 
                    }

                    if (map.Pins.Count != 0)
                    {
                        for (int x = 0; x <= map.Pins.Count; x++)
                        {
                            map.Pins.RemoveAt(0);
                        } 
                    }

                    foreach (Position pos in sender)
                    {
                        System.Diagnostics.Debug.WriteLine("Lat: {0}, Lng: {1}", pos.Latitude, pos.Longitude);
                        latitude = pos.Latitude;
                        longitude = pos.Longitude;

                        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMiles(0.5)));
                        var position = new Position(latitude, longitude);
                        var pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = position,
                            Label = "IntilaQ",
                            Address = "www.intilaq.tn",
                        };
                        map.Pins.Add(pin);
                        Content = map;
                    }
                }
                catch
                (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

            });
        }
    }
}