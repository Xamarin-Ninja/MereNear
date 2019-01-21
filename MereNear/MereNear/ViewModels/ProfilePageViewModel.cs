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
	public class ProfilePageViewModel : BaseViewModel, INavigationAware
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private bool _isCertifiedClicked = false;
        private string _personName;
        private string _personMobileNumber;
        private string _certificationText = "GET CERTIFIED";

        private string _headerLeftIcon;
        private string _rightIconImage;
        #endregion

        #region Public Variables
        public string lastnavigatedpage = "";

        public string RightIconImage
        {
            get { return _rightIconImage; }
            set { SetProperty(ref _rightIconImage, value); }
        }

        public string HeaderLeftIcon
        {
            get { return _headerLeftIcon; }
            set { SetProperty(ref _headerLeftIcon, value); }
        }

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
        public ICommand HeaderLeftIconCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    if (lastnavigatedpage != "HomeDetailPage")
                    {
                        MessagingCenter.Send("HamburgurClick", "OpenMasterDetailPage");
                    }
                    else
                    {
                        await _navigationService.GoBackAsync();
                    }
                });
            }
        }

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
                    if (lastnavigatedpage != "HomeDetailPage")
                    {
                        await _navigationService.NavigateAsync(nameof(EditProfilePage)); 
                    }
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

        #region Navigation Parameters
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("HomeDetailPage"))
            {
                lastnavigatedpage = (string)parameters["HomeDetailPage"];
                HeaderLeftIcon = "back_arrow.png";
                RightIconImage = "";
            }
            else
            {
                HeaderLeftIcon = "menu.png";
                RightIconImage = "edit_profile.png";
            }
        }
        #endregion
    }
}
