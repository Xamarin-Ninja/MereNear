﻿using MereNear.ViewModels.Common;
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
	public class PickLocationMapPageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private string _address;
        private Position _addressPosition;
        #endregion

        #region Public Variables
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
        
        public Position AddressPosition
        {
            get { return _addressPosition; }
            set { SetProperty(ref _addressPosition, value); }
        }
        #endregion

        #region Constructor
        public PickLocationMapPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MessagingCenter.Subscribe<string,Position>(this, "LocationAddress", (sender, pickedposition) =>
            {
                Address = sender;
                AddressPosition = pickedposition;

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
                    var param = new NavigationParameters();
                    param.Add("Address", Address);
                    param.Add("AddressPosition", AddressPosition);
                    await _navigationService.NavigateAsync(nameof(ChooseCategoryPage),param);
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
    }
}
