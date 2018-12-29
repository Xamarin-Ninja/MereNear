using Acr.UserDialogs;
using MereNear.Services;
using MereNear.ViewModels.Common;
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

namespace MereNear.ViewModels
{
	public class ProfilePageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private bool _isCertifiedClicked = false;
        private string _personName;
        private string _personMobileNumber;
        private string _certificationText = "GET CERTIFIED";
        #endregion
                     
        
        
        #region Public Variables

        public string PersonName
        {
            get { return _personName; }
            set { SetProperty(ref _personName, value); }
        }

        public string PersonMobileNumber
        {
            get { return _personMobileNumber; }
            set { SetProperty(ref _personMobileNumber, value); }
        }
        public bool IsCertifiedClicked
        {
            get { return _isCertifiedClicked; }
            set { SetProperty(ref _isCertifiedClicked, value); }
        }
        public string CertificationText
        {
            get { return _certificationText; }
            set { SetProperty(ref _certificationText, value); }
        }
        #endregion

        #region Command

        public ICommand GetCertifiedClicked
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsCertifiedClicked = true;
                });
            }
        }
        
        public ICommand CertificationSubmitCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CertificationText = "CERTIFIED";
                });
            }
        }
        public ICommand HeaderRightIconCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.NavigateAsync(nameof(EditProfilePage));
                });
            }
        }

        #endregion

        #region Constructor
        public ProfilePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
