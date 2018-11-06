using Microsoft.AspNetCore.SignalR.Client;
using SignalR.Interface;
using System;
using System.Diagnostics;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalRClientService))]
namespace SignalR.Interface
{
    public class SignalRClientService: ISignalRClientService
    {
        private HubConnection Connection;

        public event EventHandler<string> IncreaseLikeCountHandeler;

        public async void Setup()
        {
            try
            {
                Connection = new HubConnectionBuilder()
                    .WithUrl("http://chatnet.azurewebsites.net/chatHub")
                    .Build();
                Connection.On<string, string>("ReceiveMessage", (user, message) =>
                {
                    Debug.WriteLine("DevMessage" + message);
                    IncreaseLikeCountHandeler.Invoke(this, message);
                });
                await Connection.StartAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine("DevMessage" + e.Message);
            }

        }

        public async void Like()
        {
            try
            {
                await Connection.InvokeAsync("SendMessage", "Mobiloitte", "Mobiloitte");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public void Dislike()
        {

        }
    }
}
