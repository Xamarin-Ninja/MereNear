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
	public class PickLocationMapPageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        private string _address;
        #endregion

        #region Public Variables
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
        #endregion

        #region Constructor
        public PickLocationMapPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MessagingCenter.Subscribe<string>(this, "LocationAddress", (sender) =>
            {
                Address = sender;
            });
        }
        #endregion

        #region Commands
        public ICommand NextButtonCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var param = new NavigationParameters();
                    param.Add("Address", Address);
                    await _navigationService.NavigateAsync(nameof(ChooseCategoryPage),param);
                });
            }
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
