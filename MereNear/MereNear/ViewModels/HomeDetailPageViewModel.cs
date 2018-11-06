using Acr.UserDialogs;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class HomeDetailPageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private Color _satelliteButtonColor = Color.Transparent;
        private Color _satelliteButtonTextColor = Color.Gray;

        private Color _mapButtonTextColor = Color.White;
        private Color _mapButtonColor = Color.FromHex("#3498db");

        private string _searchBarText;
        #endregion

        #region Public Variables
        public Color SatelliteButtonColor
        {
            get { return _satelliteButtonColor; }
            set { SetProperty(ref _satelliteButtonColor, value); }
        }

        public Color SatelliteButtonTextColor
        {
            get { return _satelliteButtonTextColor; }
            set { SetProperty(ref _satelliteButtonTextColor, value); }
        }

        public Color MapButtonColor
        {
            get { return _mapButtonColor; }
            set { SetProperty(ref _mapButtonColor, value); }
        }

        public Color MapButtonTextColor
        {
            get { return _mapButtonTextColor; }
            set { SetProperty(ref _mapButtonTextColor, value); }
        }

        public string SearchBarText
        {
            get { return _searchBarText; }
            set { SetProperty(ref _searchBarText, value); }
        }
        #endregion

        #region Command
        public ICommand MapViewCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (MapButtonColor != Color.FromHex("#3498db"))
                    {
                        MapButtonColor = Color.FromHex("#3498db");
                        MapButtonTextColor = Color.White;
                        SatelliteButtonColor = Color.Transparent;
                        SatelliteButtonTextColor = Color.Gray;
                        if(string.IsNullOrEmpty(SearchBarText) || string.IsNullOrWhiteSpace(SearchBarText))
                        {
                            MessagingCenter.Send("Standard","MapType");
                        }
                        else
                        {
                            Application.Current.Properties["MapType"] = "Standard";
                            Geocoder gc = new Geocoder();
                            IEnumerable<Position> result = await gc.GetPositionsForAddressAsync(SearchBarText);
                            MessagingCenter.Send(result, "SearchBarWithMapView");
                        }
                    }
                });
            }
        }

        public ICommand SatelliteViewCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (SatelliteButtonColor != Color.FromHex("#3498db"))
                    {
                        SatelliteButtonColor = Color.FromHex("#3498db");
                        SatelliteButtonTextColor = Color.White;
                        MapButtonColor = Color.Transparent;
                        MapButtonTextColor = Color.Gray;
                        if (string.IsNullOrEmpty(SearchBarText) || string.IsNullOrWhiteSpace(SearchBarText))
                        {
                            MessagingCenter.Send("Satellite", "MapType");
                        }
                        else
                        {
                            Application.Current.Properties["MapType"] = "Satellite";
                            Geocoder gc = new Geocoder();
                            IEnumerable<Position> result = await gc.GetPositionsForAddressAsync(SearchBarText);
                            MessagingCenter.Send(result, "SearchBarWithMapView");
                        }
                    }
                });
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (!string.IsNullOrEmpty(SearchBarText) || !string.IsNullOrWhiteSpace(SearchBarText))
                    {
                        Geocoder gc = new Geocoder();
                        IEnumerable<Position> result = await gc.GetPositionsForAddressAsync(SearchBarText);
                        MessagingCenter.Send(result, "SearchBarWithMapView");
                    }
                });
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Loading...");
                        await Task.Delay(500);
                        await _navigationService.NavigateAsync(nameof(PlumberDetail), null, null, true);
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region Constructor
        public HomeDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //Application.Current.Properties["MapType"] = "Standard";
            MessagingCenter.Subscribe<string>(this, "SearchBarKeyboard", async (sender) =>
            {
                if (!string.IsNullOrEmpty(SearchBarText) || !string.IsNullOrWhiteSpace(SearchBarText))
                {
                    Geocoder gc = new Geocoder();
                    IEnumerable<Position> result = await gc.GetPositionsForAddressAsync(SearchBarText);
                    MessagingCenter.Send(result, "SearchBarWithMapView");
                }
            });
        }
        #endregion

        #region Private Methods
        
        #endregion
    }
}
