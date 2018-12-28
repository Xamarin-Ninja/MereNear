using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MereNear.ViewModels
{
	public class ChangPhoneNumberViewModel : BindableBase
	{
        #region Private Variable
        private readonly INavigationService _navigationService;

        private string _currentNumberLabel;
        private bool _isPopupVisible;

        private string _mobileNumber;
        #endregion

        #region Public Variable
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { SetProperty(ref _mobileNumber, value); }
        }

        private string CurrentNumberLabel
        {
            get { return _currentNumberLabel; }
            set { SetProperty(ref _currentNumberLabel, value); }
        }

        public bool IsPopupVisible
        {
            get { return _isPopupVisible; }
            set { SetProperty(ref _isPopupVisible, value); }
        }
        #endregion

        #region Command
        public ICommand BackButtonCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.GoBackAsync();
                });
            }
        }

        public ICommand ContinueCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    if (MobileNumber != null)
                    {
                        if (MobileNumber.Length == 10)
                        {
                            IsPopupVisible = true;
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Warning", "Please enter valid mobile number", "Ok");
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Warning", "Please enter mobile number", "Ok");
                    }
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsPopupVisible = false;
                });
            }
        }

        public ICommand YesCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    var param = new NavigationParameters();
                    param.Add("ChangeNumber", MobileNumber);
                    await _navigationService.NavigateAsync(nameof(SendOtpPage),param);
                });
            }
        }
        #endregion

        #region Constructor
        public ChangPhoneNumberViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
