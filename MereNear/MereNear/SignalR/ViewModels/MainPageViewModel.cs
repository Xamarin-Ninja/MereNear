using Acr.UserDialogs;
using MereNear;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SignalR.Interface;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SignalR.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private IChatServices _chatServices;
        private string _roomName;
        private bool _isMine;
        public bool IsMine
        {
            get { return _isMine; }
            set { SetProperty(ref _isMine, value); }
        }

        #region ChatMsgViewModel
        private ChatMessageViewModel _chatMessage;
        public ChatMessageViewModel ChatMessage
        {
            get { return _chatMessage; }
            set { SetProperty(ref _chatMessage, value); }
        }
        public ObservableCollection<DataChat> personChatList = new ObservableCollection<DataChat>();
        public bool roomAlreadyJoined = false;

        private ObservableCollection<ChatMessageViewModel> _messages;

        public ObservableCollection<ChatMessageViewModel> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private ObservableCollection<JoinRooms> joinRooms = new ObservableCollection<JoinRooms>();
        #endregion

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _chatServices = DependencyService.Get<IChatServices>();
            _chatMessage = new ChatMessageViewModel();

            _messages = new ObservableCollection<ChatMessageViewModel>();
            _chatServices.Connect();
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
        }

        void _chatServices_OnMessageReceived(object sender, ChatMessage e)
        {
            
            if(e.Name == App.CurrentUser)
            {
                IsMine = true;
            }
            else
            {
                IsMine = false;
            }
            if (!IsMine)
            {
                if (personChatList.Count > 0)
                {
                    foreach (var item in personChatList)
                    {
                        if (e.Name == item.PersonName)
                        {
                            item.IsNewMessage = true;
                        }
                    }
                } 
            }
            _messages.Add(new ChatMessageViewModel { Name = e.Name, Message = e.Message, IsMine = IsMine });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("RoomName"))
            {
                _roomName = (string)parameters["RoomName"];
            }
            if (parameters.ContainsKey("PersonChatList"))
            {
                personChatList = (ObservableCollection<DataChat>)parameters["PersonChatList"];
            }
        }

        //public ICommand JoinTapCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(async () =>
        //        {
        //            try
        //            {
                        
        //                if (joinRooms.Count > 0)
        //                {
        //                    foreach(var item in joinRooms)
        //                    {
        //                        if (_roomName == item.roomInfo)
        //                        {
        //                            roomAlreadyJoined = true;
        //                            break;
        //                        }
        //                    }

        //                }
        //                if (!roomAlreadyJoined)
        //                {
        //                    await _chatServices.JoinRoom(_roomName);
        //                    joinRooms.Add(new JoinRooms { roomInfo = _roomName }); 
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                UserDialogs.Instance.Alert(ex.Message);
        //            }
        //        });
        //    }
        //}
        public int a = 1;
        public ICommand SendCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {

                        //if (joinRooms.Count > 0)
                        //{
                        //    foreach (var item in joinRooms)
                        //    {
                        //        if (_roomName == item.roomInfo)
                        //        {
                        //            roomAlreadyJoined = true;
                        //            break;
                        //        }
                        //    }

                        //}
                        if (!roomAlreadyJoined)
                        {
                            if (a == 1)
                            {
                                await _chatServices.JoinRoom(_roomName);
                                a = 2;
                                //joinRooms.Add(new JoinRooms { roomInfo = _roomName });
                            }
                            await _chatServices.Send(new ChatMessage { Name = _chatMessage.Name, Message = _chatMessage.Message }, _roomName);
                        }
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                }); 
            }
        }
    }
}
