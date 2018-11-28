using MereNear.Views.ViewCells;
using System;
using System.Threading.Tasks;

namespace SignalR.Interface
{
    public interface IChatServices
    {
        Task Connect();
        Task Send(ChatItem chatitem, string roomName);
        Task SendDeal(ChatItem chatitem, string roomName);
        Task SendLocation(ChatItem chatitem, string roomName);
        Task JoinRoom(string roomName);
        event EventHandler<ChatItem> OnMessageReceived;
    }
}
