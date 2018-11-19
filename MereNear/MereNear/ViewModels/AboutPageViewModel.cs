﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class AboutPageViewModel : BindableBase
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
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
        #endregion

        #region Constructor
        public AboutPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Public Methods

        #endregion

    }
}
