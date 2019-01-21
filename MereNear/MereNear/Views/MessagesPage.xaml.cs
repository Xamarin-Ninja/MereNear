using MereNear.Resources;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
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
