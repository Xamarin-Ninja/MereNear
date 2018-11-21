using MereNear.Views.ViewCells;
using System;
using System.Threading.Tasks;

namespace SignalR.Interface
{
    public interface IChatServices
    {
        Task Connect();
        Task Send(ChatItem message, string roomName);
        Task SendDeal(ChatItem message, string roomName);
        Task JoinRoom(string roomName);
        event EventHandler<ChatItem> OnMessageReceived;
    }
}
