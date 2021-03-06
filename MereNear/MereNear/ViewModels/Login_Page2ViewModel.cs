﻿using Acr.UserDialogs;
using LiteDB.UserModelDB;
using MereNear.Model;
using MereNear.Services.ApiService.Common;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class Login_Page2ViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        protected readonly IWebApiRestClient _webApiRestClient;
        private readonly IUserDBService userDBService;

        private string _mobileNumber;
        #endregion

        #region Public Variables
        public UserModel userLogin = new UserModel();
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { SetProperty(ref _mobileNumber, value); }
        }

        public LoginModel loginModel = new LoginModel();
        #endregion

        #region Constructor
        public Login_Page2ViewModel(INavigationService navigationService, IWebApiRestClient webApiRestClient)
        {
            _navigationService = navigationService;
            _webApiRestClient = webApiRestClient;

            userDBService = DependencyService.Get<IUserDBService>();
        }
        #endregion

        #region Command
        public ICommand NextButton
        {
            get
            {
                try
                {
                    return new DelegateCommand(async () =>
                           {
                               try
                               {
                                   if (MobileNumber != null)
                                   {
                                       if (MobileNumber.Length == 10)
                                       {
                                           //GetLoginApi();
                                           var param = new NavigationParameters();
                                           param.Add("LoginPage", MobileNumber);
                                           userLogin.UserID = MobileNumber;
                                           userDBService.CreateUserModelInDB(userLogin);
                                           await _navigationService.NavigateAsync(nameof(SendOtpPage), param);
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
                               }
                               catch (Exception)
                               {

                               }
                           });
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public ICommand BackIconCommand
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

        #region ApiMethod
        public async void GetLoginApi()
        {
            try
            {
                loginModel.MobileNumber = MobileNumber;
                var result = await _webApiRestClient.PostAsync<LoginModel, LoginResponse>("?func=login", loginModel);
                Debug.WriteLine("ex:", result.code);
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
