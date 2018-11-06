using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SignalR.Models;
using SignalR.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SignalR.ViewModels
{
	public class PersonListViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        private ObservableCollection<DataChat> _personChatList = new ObservableCollection<DataChat>();
        private string _personRoomName;
        private DataChat _personChatListDetail;

        public string PersonRoomName
        {
            get { return _personRoomName; }
            set { SetProperty(ref _personRoomName, value); }
        }
        public ObservableCollection<DataChat> PersonChatList
        {
            get { return _personChatList; }
            set { SetProperty(ref _personChatList, value); }
        }
        public DataChat PersonChatListDetail
        {
            get { return _personChatListDetail; }
            set
            {
                SetProperty(ref _personChatListDetail, value);
                if(_personChatListDetail == null)
                {
                    return;
                }
                else
                {
                    if(PersonChatListDetail.PersonName == "Pardeep")
                    {
                        PersonRoomName = "Pardeep";
                    }
                    else if(PersonChatListDetail.PersonName == "Rahul")
                    {
                        PersonRoomName = "Rahul";
                    }
                    var param = new NavigationParameters();
                    param.Add("RoomName", PersonRoomName);
                    param.Add("PersonChatList", PersonChatList);
                    _navigationService.NavigateAsync(nameof(ChatPage));

                }
            }
        }
        public PersonListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetPersonChatList();
        }

        private void GetPersonChatList()
        {
            PersonChatList.Add(new DataChat { PersonName = "Pardeep" });
            PersonChatList.Add(new DataChat { PersonName = "Rahul" });
        }
    }
}
