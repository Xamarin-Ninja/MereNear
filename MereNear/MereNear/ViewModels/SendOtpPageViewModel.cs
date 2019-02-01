using Acr.UserDialogs;
using MereNear.Resources;
using MereNear.Services.ApiService.Common;
using MereNear.ViewModels.Common;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
    public class SendOtpPageViewModel : BaseViewModel,INavigationAware
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        protected readonly IWebApiRestClient _webApiRestClient;

        private string _activationCode;
        private string _otpMainLabel;
        private string _headerText="";

        private string _otp1;
        private string _otp2;
        private string _otp3;
        private string _otp4;
        
        #endregion

        #region Public Variables
        public string lastNavigatedPage { get; set; }
        public string ActivationCode
        {
            get { return _activationCode; }
            set { SetProperty(ref _activationCode, value); }
        }

        public string OTPMainLabel
        {
            get { return _otpMainLabel; }
            set { SetProperty(ref _otpMainLabel, value); }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }

        public string OTP1
        {
            get { return _otp1; }
            set { SetProperty(ref _otp1, value); }
        }

        public string OTP2
        {
            get { return _otp2; }
            set { SetProperty(ref _otp2, value); }
        }

        public string OTP3
        {
            get { return _otp3; }
            set { SetProperty(ref _otp3, value); }
        }

        public string OTP4
        {
            get { return _otp4; }
            set { SetProperty(ref _otp4, value); }
        }
        #endregion

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.GoBackAsync();
                });
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {
                        if (lastNavigatedPage == "LoginPage")
                        {
                            CallOTPApi();
                        }
                        else
                        {
                            await _navigationService.GoBackToRootAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to Home Page:" + ex.Message);
                    }
                });
            }
        }
        #endregion

        #region Constructor
        public SendOtpPageViewModel(INavigationService navigationService, IWebApiRestClient webApiRestClient)
        {
            try
            {
                _navigationService = navigationService;
                _webApiRestClient = webApiRestClient;

                MessagingCenter.Subscribe<string>(this, "OtpReceived", async (sender) =>
                {
                    ActivationCode = sender;
                    UserDialogs.Instance.ShowLoading("Fetching Code");
                    await Task.Delay(500);
                    OTP1 = ActivationCode[0].ToString();
                    OTP2 = ActivationCode[1].ToString();
                    OTP3 = ActivationCode[2].ToString();
                    OTP4 = ActivationCode[3].ToString();
                    UserDialogs.Instance.HideLoading();
                });
                MessagingCenter.Subscribe<string>(this, "OTPAutoFillComplete", async (sender) =>
                {
                    await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
                });
            }
            catch (Exception)
            {

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
            if (parameters.ContainsKey("LoginPage"))
            {
                var existingNumber = (string)parameters["LoginPage"];
                setString("LoginMobileNumber", existingNumber);

                OTPMainLabel = AppResources.OTPMainLabel;
                lastNavigatedPage = "LoginPage";
            }
            if (parameters.ContainsKey("ChangeNumber"))
            {
                var existingNumber = (string)parameters["ChangeNumber"];
                setString("LoginMobileNumber", existingNumber);

                OTPMainLabel = AppResources.OTPMainLabel;
                HeaderText = AppResources.VerifyNumberTitle;
                lastNavigatedPage = "ChangeNumber";
            }            
        }
        #endregion

        #region API Methods
        private async void CallOTPApi()
        {
            try
            {
                await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
