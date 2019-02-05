using MereNear.Interface;
using MereNear.Model;
using MereNear.Services.ApiService.Common;
using MereNear.Services.LiteDB.NotificationModelDB;
using MereNear.ViewModels.Common;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
    public class NotificationsPageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private readonly IWebApiRestClient _webApiRestClient;
        private readonly INotificationDBService notificationDBService;
        private ToastMessage toastMessage;

        private ObservableCollection<NotificationModel> _notificationList = new ObservableCollection<NotificationModel>();
        #endregion

        #region Public Variables
        public ObservableCollection<NotificationModel> NotificationList
        {
            get { return _notificationList; }
            set { SetProperty(ref _notificationList, value); }
        }
        #endregion

        #region Constructor
        public NotificationsPageViewModel(INavigationService navigationService, IWebApiRestClient webApiRestClient)
        {
            _navigationService = navigationService;
            _webApiRestClient = webApiRestClient;
            toastMessage = DependencyService.Get<ToastMessage>();
            notificationDBService = DependencyService.Get<INotificationDBService>();

            AddNotify = new Command(add_click);
            var IsNotificationDBExist = notificationDBService.IsNotificationDbPresentInDB();
            if (IsNotificationDBExist)
            {
                IEnumerable<NotificationModel> notifications = notificationDBService.ReadAllItems();
                foreach(var item in notifications)
                {
                    NotificationList.Add(item);
                }
            }
            MessagingCenter.Subscribe<string>(this, "Notification Recieved", (sender) =>
            {
                var data = sender;
                var newjob = new NotificationModel()
                {
                    Text = data,
                    Icon = "logo.png",
                    Time = "Now"
                };
                NotificationList.Add(newjob);
                notificationDBService.CreateNotificationModeInDB(newjob);
                toastMessage.Show("You have recieved a new notification.");
            });
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
