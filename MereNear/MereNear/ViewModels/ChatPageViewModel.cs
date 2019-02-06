using Acr.UserDialogs;
using MereNear.Services.LiteDB.ChatModelDB;
using MereNear.ViewModels.Common;
using MereNear.Views;
using MereNear.Views.ViewCells;
using Plugin.LocalNotifications;
using Prism.Commands;
using Prism.Navigation;
using SignalR.Interface;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class ChatPageViewModel : BaseViewModel, INavigationAware
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        //private IChatServices _chatServices;

        private string _roomName;
        private string _dealAmount;
        private string _currencyType;
        private string _senderImage;
        private string _senderName;
        private int _purchaseCostValue;
        private int _serviceChargeValue;

        private int _senderType;

        private bool _isMenuVisible = false;
        private bool _isOverlayVisible = false;
        private bool _isMakeDealVisible = false;
        private bool _isReportVisible = false;
        private bool _isSendDealMessageButtonVisible = true;
        #endregion

        #region Public Variables
        public int SenderType
        {
            get { return _senderType; }
            set { SetProperty(ref _senderType, value); }
        } 

        public bool IsMenuVisible
        {
            get { return _isMenuVisible; }
            set { SetProperty(ref _isMenuVisible, value); }
        }

        public bool IsOverlayVisible
        {
            get { return _isOverlayVisible; }
            set { SetProperty(ref _isOverlayVisible, value); }
        }

        public bool IsMakeDealVisible
        {
            get { return _isMakeDealVisible; }
            set { SetProperty(ref _isMakeDealVisible, value); }
        }

        public bool IsReportVisible
        {
            get { return _isReportVisible; }
            set { SetProperty(ref _isReportVisible, value); }
        }

        public bool IsSendDealMessageButtonVisible
        {
            get { return _isSendDealMessageButtonVisible; }
            set { SetProperty(ref _isSendDealMessageButtonVisible, value); }
        }

        public int ServiceChargeValue
        {
            get { return _serviceChargeValue; }
            set { SetProperty(ref _serviceChargeValue, value); }
        }

        public int PurchaseCostValue
        {
            get { return _purchaseCostValue; }
            set { SetProperty(ref _purchaseCostValue, value); }
        }

        public string CurrencyType
        {
            get { return _currencyType; }
            set { SetProperty(ref _currencyType, value); }
        }

        public string SenderImage
        {
            get { return _senderImage; }
            set { SetProperty(ref _senderImage, value); }
        }

        public string SenderName
        {
            get { return _senderName; }
            set { SetProperty(ref _senderName, value); }
        }

        public string currentuser { get; set; }
        #endregion

        #region ChatMsgViewModel
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
        #endregion

        #region Constructor
        public ChatPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            currentuser = getString("LoginMobileNumber");

            _roomName = "Rahul";

            _chatServices.Connect();
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
            var chatRecordExist = chatModelDbService.IsChatDbPresentInDB();
            if (chatRecordExist)
            {
                var previousChat = chatModelDbService.ReadAllItems();
                foreach(var data in previousChat.ToList())
                {
                    _messages.Add(data);
                }
            }
            CrossLocalNotifications.Current.Show("merenear", "You have a new message");
        }
        #endregion

        #region Private/public Methods
        void _chatServices_OnMessageReceived(object sender, ChatItem e)
        {
            if (e.MessageType != 0)
            {
                if (e.CurrentUser == currentuser)
                {
                    SenderType = 1;
                }
                else
                {
                    SenderType = 2;
                }
                var chatRecord = new ChatItem { Name = e.Name, MessageType = e.MessageType, PurchaseAmount = e.PurchaseAmount, ServiceAmount = e.ServiceAmount, SubtotalAmount = e.SubtotalAmount, TotalAmout = e.TotalAmout, CurrencyType = e.CurrencyType, Location = e.Location, Message = e.Message, SenderType = SenderType, Time = DateTime.Now.ToString("HH:mm") };
                _messages.Add(chatRecord);
                chatModelDbService.CreateChatModelInDB(chatRecord);
                var previousChat = chatModelDbService.ReadAllItems();
            }
            else
            {
                if (e.CurrentUser == currentuser)
                {
                    SenderType = 1;
                }
                else
                {
                    SenderType = 2;
                }
                _messages.Add(new ChatItem { Name = e.Name, MessageType = 1, PurchaseAmount = e.PurchaseAmount, ServiceAmount = e.ServiceAmount, SubtotalAmount = e.SubtotalAmount, TotalAmout = e.TotalAmout, CurrencyType = e.CurrencyType, Location = e.Location, Message = e.Message, SenderType = SenderType, Time = DateTime.Now.ToString("HH:mm") });
            }
           
        }
        #endregion

        #region Navigation Parameters
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("SingleChatMessage"))
            {
                var data = (MessagesListItems)parameters["SingleChatMessage"];
                SenderName = data.Name;
                SenderImage = data.Icon;
            }
        }
        #endregion

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.GoBackAsync();
                });
            }
        }

        public ICommand SendCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        var roomjoiner = getBool("RoomJoin");
                        if (!roomjoiner)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            setBool("RoomJoin", true);
                        }
                        await _chatServices.Send(new ChatItem {CurrentUser = currentuser, MessageType = 1, Message = MyMessage, Time = DateTime.Now.ToString("HH:mm") }, _roomName);
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

                        var roomjoiner = getBool("RoomJoin");
                        if (!roomjoiner)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            setBool("RoomJoin", true);
                        }

                        await _chatServices.SendLocation(new ChatItem { CurrentUser = currentuser, MessageType = 3, Location = mylocation, Time = DateTime.Now.ToString("HH:mm") }, _roomName);
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
                        var roomjoiner = getBool("RoomJoin");
                        if (!roomjoiner)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            setBool("RoomJoin", true);
                        }

                        await _chatServices.SendDeal(new ChatItem { CurrentUser = currentuser, PurchaseAmount = PurchaseCostValue, ServiceAmount = ServiceChargeValue, SubtotalAmount = PurchaseCostValue + ServiceChargeValue, TotalAmout = (PurchaseCostValue + ServiceChargeValue)*(5/100), MessageType = 2, CurrencyType = CurrencyType, Time = DateTime.Now.ToString("HH:mm") }, _roomName);
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
                        var roomjoiner = getBool("RoomJoin");
                        if (!roomjoiner)
                        {
                            await _chatServices.JoinRoom(_roomName);
                            setBool("RoomJoin", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }
        #endregion
    }
}
