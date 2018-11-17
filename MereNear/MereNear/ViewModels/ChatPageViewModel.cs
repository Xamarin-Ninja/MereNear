using Acr.UserDialogs;
using MereNear.Views.ViewCells;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SignalR.Interface;
using SignalR.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class ChatPageViewModel : BindableBase, INavigationAware
	{
        private readonly INavigationService _navigationService;
        private IChatServices _chatServices;
        private string _roomName;
        private int _senderType;
        public int SenderType
        {
            get { return _senderType; }
            set { SetProperty(ref _senderType, value); }
        }

        #region ChatMsgViewModel
        private ChatMessageViewModel _chatMessage;
        public ChatMessageViewModel ChatMessage
        {
            get { return _chatMessage; }
            set { SetProperty(ref _chatMessage, value); }
        }
        private ObservableCollection<ChatItem> _messages = new ObservableCollection<ChatItem>();
        public ObservableCollection<ChatItem> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private string _myMessage;

        public string MyMessage
        {
            get { return _myMessage; }
            set { SetProperty(ref _myMessage, value); }
        }


        //private ObservableCollection<ChatMessageViewModel> _messages;

        //public ObservableCollection<ChatMessageViewModel> Messages
        //{
        //    get { return _messages; }
        //    set { SetProperty(ref _messages, value); }
        //}


        #endregion

        public ChatPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _chatServices = DependencyService.Get<IChatServices>();
            _chatMessage = new ChatMessageViewModel();

            _roomName = "Rahul";

            _chatServices.Connect();
            //try
            //{
            //    if (a == 1)
            //    {
            //        _chatServices.JoinRoom(_roomName);
            //        a = 2;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    UserDialogs.Instance.Alert(ex.Message);
            //}
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
        }
        void _chatServices_OnMessageReceived(object sender, ChatItem e)
        {

            if (e.Name == App.CurrentUser)
            {
                SenderType = 1;
            }
            else
            {
                SenderType = 2;
            }
            _messages.Add(new ChatItem { Name = e.Name, Message = e.Message, SenderType = SenderType, Time = DateTime.Now.ToString("HH:mm")});
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

        public int a = 1;
        public ICommand SendCommand
        {
            get
            {
                return new DelegateCommand(async () =>
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
                        if (a == 1)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            a = 2;
                            //joinRooms.Add(new JoinRooms { roomInfo = _roomName });
                        }
                        await _chatServices.Send(new ChatItem { Name = App.CurrentUser, Message = MyMessage, Time = DateTime.Now.TimeOfDay.ToString()}, _roomName);
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }
        public ICommand JoinCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {
                        if (a == 1)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            a = 2;
                            //joinRooms.Add(new JoinRooms { roomInfo = _roomName });
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
