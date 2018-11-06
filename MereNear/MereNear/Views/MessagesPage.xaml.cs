using System.Collections.Generic;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class MessagesPage : ContentPage
    {
        public List<MessagesListItems> messageList { get; set; }

        public MessagesPage()
        {
            InitializeComponent();
            //messageList = new List<MessagesListItems>();
            //var msglist1 = new MessagesListItems() { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm",Name = "Himanshu" };
            //var msglist2 = new MessagesListItems() { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Pardeep" };
            //var msglist3 = new MessagesListItems() { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Mohit" };
            //var msglist4 = new MessagesListItems() { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png", Time = "01:40pm", Name = "Rakesh" };

            //messageList.Add(msglist1);
            //messageList.Add(msglist2);
            //messageList.Add(msglist3);
            //messageList.Add(msglist4);

            //MesagesList.ItemsSource = messageList;       
            
        }

        private void MesagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var item = (MessagesListItems)e.SelectedItem;
            //Navigation.PushAsync(new ChatPage(item));
            MesagesList.SelectedItem = null;
        }
    }
    public class MessagesListItems
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
    }
}
