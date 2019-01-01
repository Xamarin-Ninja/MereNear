using MereNear.Resources;
using MereNear.Views.ViewCells;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();

            dealButton.Text = AppResources.MakeDealButton;
            reportButton.Text = AppResources.ReportButton;
            locationButton.Text = AppResources.ShareLocationButton;
            sendDealButton.Text = AppResources.PleaseSendDealButton;
            //var list = new List<ChatItem>() {
            //    new ChatItem(){
            //        SenderType = 2,
            //        Time = "19 : 22",
            //        Icon = "user_round.png",
            //        Message = "your car has been detailed as requested, let us know when you need pickup.",
            //    },
            //    new ChatItem(){
            //        SenderType = 1,
            //        Time = "Yesterday",
            //        Icon = "logout_icon.png",
            //        Message = "Thank you. Please pick up myself and 2 passengers at 12 King st. for 5 pm.",
            //    },
            //    new ChatItem(){
            //        SenderType = 2,
            //        Time = "19 : 22",
            //        Icon = "user_round.png",
            //        Message = "your car has been detailed as requested, let us know when you need pickup.",
            //    },
            //    new ChatItem(){
            //        SenderType = 1,
            //        Time = "Yesterday",
            //        Icon = "logout_icon.png",
            //        Message = "Thank you. Please pick up myself and 2 passengers at 12 King st. for 5 pm.",
            //    }
            //};
            //listView.ItemsSource = list;
            //SenderName.Text = messagesListItems.Name;
            //SenderImage.Source = messagesListItems.Icon;
        }

        private void chatlistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            chatTemplate.SelectedItem = null;
        }
    }
}
