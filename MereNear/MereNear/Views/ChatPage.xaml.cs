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

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
