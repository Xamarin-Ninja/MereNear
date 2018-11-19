using MereNear.Views;
using MereNear.Views.Common;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MereNear.ViewModels
{
	public class JobOptionPageViewModel : BindableBase,INavigationAware
	{

        #region Private Variables
        private readonly INavigationService _navigationService;
        #endregion

        #region Commnad

        public ICommand PostJobCliked
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.NavigateAsync(nameof(PickLocationMapPage));
                    
                });
            }
        }
        public ICommand LookingForAJobCliked
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.NavigateAsync(nameof(ChooseCategoryPage));
                });
            }
        }
        public ICommand BackIconCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
                });
            }
        }
        #endregion
        public JobOptionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            
        }
    }
}
