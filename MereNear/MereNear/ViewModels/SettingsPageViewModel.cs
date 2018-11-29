using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class SettingsPageViewModel : BindableBase
	{
        #region Private Variable
        private readonly INavigationService _navigationService;
        #endregion

        #region Public Variable

        #endregion

        #region Command
        public ICommand HeaderLeftIconCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessagingCenter.Send("HamburgurClick", "OpenMasterDetailPage");
                });
            }
        }

        public ICommand ChangeNumberCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.NavigateAsync(nameof(ChangPhoneNumber));
                });
            }
        }
        #endregion

        #region Constructor
        public SettingsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
