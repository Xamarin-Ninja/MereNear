using MereNear.Resources;
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
            MessagesTitle.TitleText = AppResources.MessagesTab;
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
        public bool IsUnread { get; set; }
    }
}
