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
using Xamarin.Forms.Maps;

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

        private bool _isMenuVisible = false;

        public bool IsMenuVisible
        {
            get { return _isMenuVisible; }
            set { SetProperty(ref _isMenuVisible, value); }
        }
        private bool _isOverlayVisible = false;

        public bool IsOverlayVisible
        {
            get { return _isOverlayVisible; }
            set { SetProperty(ref _isOverlayVisible, value); }
        }
        private bool _isMakeDealVisible = false;

        public bool IsMakeDealVisible
        {
            get { return _isMakeDealVisible; }
            set { SetProperty(ref _isMakeDealVisible, value); }
        }

        private bool _isReportVisible = false;

        public bool IsReportVisible
        {
            get { return _isReportVisible; }
            set { SetProperty(ref _isReportVisible, value); }
        }

        private bool _isSendDealMessageButtonVisible = true;

        public bool IsSendDealMessageButtonVisible
        {
            get { return _isSendDealMessageButtonVisible; }
            set { SetProperty(ref _isSendDealMessageButtonVisible, value); }
        }

        

        private string _dealAmount;

        public string DealAmount
        {
            get { return _dealAmount; }
            set { SetProperty(ref _dealAmount, value); }
        }

        private string _currencyType;

        public string CurrencyType
        {
            get { return _currencyType; }
            set { SetProperty(ref _currencyType, value); }
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
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
        }
        void _chatServices_OnMessageReceived(object sender, ChatItem e)
        {

            if (e.MessageType!= 0)
            {
                SenderType = 1;
                _messages.Add(new ChatItem { Name = e.Name, MessageType = e.MessageType, DealAmount = e.DealAmount,CurrencyType = e.CurrencyType,Location = e.Location, Message = e.Message,SenderType = SenderType, Time = DateTime.Now.ToString("HH:mm") });
            }
           
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
                        await _chatServices.Send(new ChatItem { Name = App.CurrentUser, MessageType = 1, Message = MyMessage, Time = DateTime.Now.TimeOfDay.ToString()}, _roomName);
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }

        public ICommand MenuIconTapCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if(IsMenuVisible == false)
                    {
                        IsMenuVisible = true;
                        IsSendDealMessageButtonVisible = false;
                        return;
                    }
                    if (IsMenuVisible == true)
                    {
                        IsMenuVisible = false;
                        IsSendDealMessageButtonVisible = true;
                        return;
                    }
                });
            }
        }
        
        public ICommand ShareLocationCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    try
                    {

                        var mylocation = new Position(30.711000, 76.686306);

                        if (a == 1)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            a = 2;
                            //joinRooms.Add(new JoinRooms { roomInfo = _roomName });
                        }

                        await _chatServices.SendLocation(new ChatItem { MessageType = 3, Location = mylocation }, _roomName);
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }
        public ICommand ReportCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsOverlayVisible = true;
                    IsReportVisible = true;
                });
            }
        }

        public ICommand MakeDealCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsOverlayVisible = true;
                    IsMakeDealVisible = true;
                });
            }
        }
        public ICommand ClosePopupCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsOverlayVisible = false;
                    IsMakeDealVisible = false;
                    IsReportVisible = false;
                });
            }
        }

        public ICommand SubmitDealCommand
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
                        
                        await _chatServices.SendDeal(new ChatItem { DealAmount = "150", MessageType = 2,CurrencyType = CurrencyType, Time = DateTime.Now.TimeOfDay.ToString() }, _roomName);
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                    IsOverlayVisible = false;
                    IsMakeDealVisible = false;
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
