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
	public class SignupPageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;

        private ImageSource _checkImage = "check.png";
        private string _mobileNumber;
        private string _personName;
        #endregion

        #region Public Variables
        public int a;
        public string OTPNumber;
        public ImageSource CheckImage
        {
            get { return _checkImage; }
            set { SetProperty(ref _checkImage, value); }
        }

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { SetProperty(ref _mobileNumber, value); }
        }

        public string PersonName
        {
            get { return _personName; }
            set { SetProperty(ref _personName, value); }
        }
        #endregion

        #region Command
        public ICommand FooterLabelCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.GoBackAsync();
                });
            }
        }

        public ICommand SignupCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Loading");
                        await Task.Delay(1000);
                        Application.Current.Properties["OTPNumber"] = OTPNumber = GenerateRandomNo().ToString();
                        //var smsMessanger = CrossMessaging.Current.SmsMessenger;
                        //if (smsMessanger.CanSendSms)
                        //{
                        //    smsMessanger.SendSmsInBackground(MobileNumber, OTPNumber);
                        await _navigationService.NavigateAsync(nameof(SendOtpPage), null, null, true);
                        //}
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to SendOtp Page:" + ex.Message);
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
        }
        #endregion

        #region Constructor
        public SignupPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            a = 1;
        }
        #endregion

        #region Private Methods
        private int GenerateRandomNo()
        {
            Random _rdm = new Random();
            int _min = 0000;
            int _max = 9999;
            return _rdm.Next(_min, _max);
        }
        #endregion
    }
}
