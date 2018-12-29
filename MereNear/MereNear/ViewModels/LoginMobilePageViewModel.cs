using Acr.UserDialogs;
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
	public class LoginMobilePageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private string _mobileNumber;
        #endregion

        #region Public Variables
        public string OTPNumber;
        public int a, b;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { SetProperty(ref _mobileNumber, value); }
        }
        #endregion

        #region Command
        public ICommand FooterLabelCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Loading");
                        await Task.Delay(1000);
                        //await _navigationService.NavigateAsync(nameof(SignupPage), null, true);
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to Signup Page:" + ex.Message);
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
        }

        public ICommand LoginCommand
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
        public LoginMobilePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            a = b = 1;
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
