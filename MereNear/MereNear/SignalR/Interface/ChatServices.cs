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

        public ChatServices()
        {
            _connection = new HubConnection("http://xamarin-chat.azurewebsites.net/");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }

        #region IChatServices implementation

        public async Task Connect()
        {
            await _connection.Start();

            _proxy.On("GetMessage", (string name, string message) => OnMessageReceived(this, new ChatItem
            {
                Name = name,
                Message = message
            }));
        }

        public async Task Send(ChatItem message, string roomName)
        {
            _proxy.Invoke("SendMessage", message.Name, message.Message, roomName);
        }

        public async Task SendDeal(ChatItem message, string roomName)
        {
            _proxy.Invoke("SendMessage", message.DealAmount, message.CurrencyType, roomName);
        }

        public async Task JoinRoom(string roomName)
        {
            _proxy.Invoke("JoinRoom", roomName);
        }

        #endregion
    }
}
