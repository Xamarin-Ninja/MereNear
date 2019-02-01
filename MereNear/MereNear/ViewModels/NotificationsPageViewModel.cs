using MereNear.Services.ApiService.Common;
using MereNear.ViewModels.Common;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
    public class NotificationsPageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private readonly IWebApiRestClient _webApiRestClient;
        #endregion

        #region Public Variables

        #endregion

        #region Constructor
        public NotificationsPageViewModel(INavigationService navigationService, IWebApiRestClient webApiRestClient)
        {
            _navigationService = navigationService;
            _webApiRestClient = webApiRestClient;

            AddNotify = new Command(add_click);
        }
        #endregion

        #region Command
        public ICommand AddNotify { get; set; }

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

        #region Private/Public Methods
        private void add_click(object obj)
        {

        }
        #endregion

        #region Navigation Parameters

        #endregion
    }
}
