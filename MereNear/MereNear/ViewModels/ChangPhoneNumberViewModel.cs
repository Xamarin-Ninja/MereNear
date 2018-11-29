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
        #endregion

        #region Public Variable
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
                return new DelegateCommand(() =>
                {

                });
            }
        }

        public ICommand ContinueCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsPopupVisible = true;
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
                    await _navigationService.NavigateAsync(nameof(SendOtpPage));
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
