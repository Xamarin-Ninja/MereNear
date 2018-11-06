using MereNear;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SignalR.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SignalR.ViewModels
{
	public class LoginPageViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        private string _user_First_Name;
        private string _user_Last_Name;

        public string User_First_Name
        {
            get { return _user_First_Name; }
            set { SetProperty(ref _user_First_Name, value); }
        }
        public string User_Last_Name
        {
            get { return _user_Last_Name; }
            set { SetProperty(ref _user_Last_Name, value); }
        }
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public ICommand LoginCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    App.CurrentUser = User_First_Name;/* + " " + User_Last_Name;*/
                    _navigationService.NavigateAsync(nameof(PersonList));
                });
            }
        }

    }
}
