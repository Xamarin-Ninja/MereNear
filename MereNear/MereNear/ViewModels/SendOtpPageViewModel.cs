using Acr.UserDialogs;
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
	public class SendOtpPageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        #endregion

        #region Public Variables

        #endregion

        #region Command
        public ICommand SubmitCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {
                        await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
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
        public SendOtpPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
