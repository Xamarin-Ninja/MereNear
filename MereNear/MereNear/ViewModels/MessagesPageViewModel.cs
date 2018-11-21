using Acr.UserDialogs;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MereNear.ViewModels
{
	public class MessagesPageViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        private ObservableCollection<MessagesListItems> _personChatList = new ObservableCollection<MessagesListItems>();
        private string _personRoomName;
        private MessagesListItems _personChatListDetail;

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


        public MessagesPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetPersonChatList();
        }

        private void GetPersonChatList()
        {
            PersonChatList.Add(new MessagesListItems { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Rahul", IsUnread = true});
            PersonChatList.Add(new MessagesListItems { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Pardeep", IsUnread = false });
        }

        public async void GetNavigation()
        {
            await _navigationService.NavigateAsync(nameof(ChatPage));
        }
    }
}
