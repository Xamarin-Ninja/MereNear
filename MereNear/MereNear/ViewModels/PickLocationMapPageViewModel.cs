using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class PickLocationMapPageViewModel : BaseViewModel, INavigationAware
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private string _address;
        private string _dropAddress;

        private bool _isDropLocation;

        private Position _addressPosition;
        private Position _dropAddressPosition;
        #endregion

        #region Public Variables
        public Position LocationAddressPosition { get; set; }
        public string LocationAddress { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public string lastnavigatedpage = "";

        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public string DropAddress
        {
            get { return _dropAddress; }
            set { SetProperty(ref _dropAddress, value); }
        }

        public bool IsDropLocation
        {
            get { return _isDropLocation; }
            set { SetProperty(ref _isDropLocation, value); }
        }


        public Position AddressPosition
        {
            get { return _addressPosition; }
            set { SetProperty(ref _addressPosition, value); }
        }

        public Position DropAddressPosition
        {
            get { return _dropAddressPosition; }
            set { SetProperty(ref _dropAddressPosition, value); }
        }
        #endregion

        #region Constructor
        public PickLocationMapPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MessagingCenter.Subscribe<string,Position>(this, "LocationAddress", (sender, pickedposition) =>
            {
                if (lastnavigatedpage == "JobOptionPage")
                {
                    Address = sender;
                    AddressPosition = pickedposition; 
                }
                if(lastnavigatedpage == "HomeDeliveryOption")
                {
                    DropAddress = sender;
                    DropAddressPosition = pickedposition;
                }

            });
        }
        #endregion

        #region Commands
        public ICommand NextButtonCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    if (lastnavigatedpage == "JobOptionPage")
                    {
                        var param = new NavigationParameters();
                        param.Add("Address", Address);
                        param.Add("AddressPosition", AddressPosition);
                        await _navigationService.NavigateAsync(nameof(ChooseCategoryPage), param); 
                    }

                    if (lastnavigatedpage == "HomeDeliveryOption")
                    {
                        var param = new NavigationParameters();
                        param.Add("Address", Address);
                        param.Add("AddressPosition", AddressPosition);
                        param.Add("DropAddress", DropAddress);
                        param.Add("DropAddressPosition", DropAddressPosition);
                        param.Add("Categoryname", CategoryName);
                        param.Add("Categoryimage", CategoryImage);
                        await _navigationService.NavigateAsync(nameof(PostDescriptionPage), param);
                    }
                });
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Navigation Parameters
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("JobOptionPage"))
            {
                lastnavigatedpage = (string)parameters["JobOptionPage"];
                IsDropLocation = false;
            }
            if (parameters.ContainsKey("HomeDeliveryOption"))
            {
                lastnavigatedpage = (string)parameters["HomeDeliveryOption"];
                IsDropLocation = true;
            }
            if (parameters.ContainsKey("Address"))
            {
                Address = (string)parameters["Address"];
            }
            if (parameters.ContainsKey("Categoryname"))
            {
                CategoryName = (string)parameters["Categoryname"];
            }
            if (parameters.ContainsKey("Categoryimage"))
            {
                CategoryImage = (string)parameters["Categoryimage"];
            }
            if (parameters.ContainsKey("AddressPosition"))
            {
                AddressPosition = (Position)parameters["AddressPosition"];
            }
        }
        #endregion
    }
}
