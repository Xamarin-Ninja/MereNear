using MereNear.Views.ViewCells;
using Microsoft.AspNet.SignalR.Client;
using SignalR.Interface;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatServices))]
namespace SignalR.Interface
{
    public class ChatServices : IChatServices
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;

        public event EventHandler<ChatItem> OnMessageReceived;

        public string callingmethod = "";

        public ChatServices()
        {
            _connection = new HubConnection("http://xamarin-chat.azurewebsites.net/");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }

        #region IChatServices implementation

        public async Task Connect()
        {
            await _connection.Start();

            _proxy.On("GetMessage", (string currentuser, int messagetype) => OnMessageReceived(this, new ChatItem
            {
                MessageType = messagetype,
                CurrentUser = currentuser
            }));
        }

        public async Task Send(ChatItem chatmessage, string roomName)
        {
            callingmethod = "message";
            _proxy.Invoke("SendMessage", chatmessage.CurrentUser, chatmessage.Message, roomName);
        }

        public async Task SendDeal(ChatItem chatmessage, string roomName)
        {
            callingmethod = "messagetype";
            _proxy.Invoke("SendMessage", chatmessage.CurrentUser, chatmessage.MessageType, roomName);
        }

        public async Task SendLocation(ChatItem chatmessage, string roomName)
        {
            callingmethod = "messagetype";
            _proxy.Invoke("SendMessage", chatmessage.CurrentUser, chatmessage.MessageType, roomName);
        }

        public async Task JoinRoom(string roomName)
        {
            _proxy.Invoke("JoinRoom", roomName);
        }

        #endregion
    }
}
