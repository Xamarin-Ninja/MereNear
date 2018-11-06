using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Interface
{
    public interface ISignalRClientService
    {
        void Like();
        void Dislike();
        void Setup();
        event EventHandler<string> IncreaseLikeCountHandeler;
    }
}
