using Acr.UserDialogs;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class MessagesPageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        private ObservableCollection<MessagesListItems> _personChatList = new ObservableCollection<MessagesListItems>();
        private string _personRoomName;
        private MessagesListItems _personChatListDetail;
        #endregion

        #region Public Variables
        public string PersonRoomName
        {
            get { return _personRoomName; }
            set { SetProperty(ref _personRoomName, value); }
        }
        public ObservableCollection<MessagesListItems> PersonChatList
        {
            get { return _personChatList; }
            set { SetProperty(ref _personChatList, value); }
        }
        public MessagesListItems PersonChatListDetail
        {
            get { return _personChatListDetail; }
            set
            {
                SetProperty(ref _personChatListDetail, value);
                if (_personChatListDetail == null)
                {
                    return;
                }
                else
                {
                    //if (PersonChatListDetail.Name == "Pardeep")
                    //{
                    //    PersonRoomName = "Pardeep";
                    //}
                    //else if (PersonChatListDetail.Name == "Rahul")
                    //{
                    //    PersonRoomName = "Rahul";
                    //}
                    //var param = new NavigationParameters();
                    //param.Add("RoomName", PersonRoomName);
                    ////param.Add("PersonChatList", PersonChatList);
                    //_navigationService.NavigateAsync("/NavigationPage/ChatPage",param);
                    try
                    {
                        //App.Current.MainPage.Navigation.PushAsync(new ChatPage());
                        GetNavigation();
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }

                }
            }
        }
        #endregion

        #region Constructor
        public MessagesPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetPersonChatList();
        }
        #endregion

        #region Private/Public Methods
        private void GetPersonChatList()
        {
            PersonChatList.Add(new MessagesListItems { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Rahul", IsUnread = true});
            PersonChatList.Add(new MessagesListItems { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Pardeep", IsUnread = false });
        }

        public async void GetNavigation()
        {
            var param = new NavigationParameters();
            param.Add("SingleChatMessage", PersonChatListDetail);
            await _navigationService.NavigateAsync(nameof(ChatPage),param);
        }
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
        #endregion
    }
}
