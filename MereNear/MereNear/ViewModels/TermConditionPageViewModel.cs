using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MereNear.ViewModels
{
	public class TermConditionPageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        #endregion

        #region Public Variables

        #endregion

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region Construtor
        public TermConditionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
