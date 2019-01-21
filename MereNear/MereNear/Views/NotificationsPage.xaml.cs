using ContextMenu;
using MereNear.Resources;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class NotificationsPage : ContentPage
    {
        public List<NotificationListItem> notificationlist { get; set; }

        protected T GetParent<T>(Button button, Element parent) where T : BaseActionViewCell
        {
            if (!(parent is T actionViewCell))
            {
                actionViewCell = GetParent<T>(button, parent.Parent);
            }

            return actionViewCell;
        }
        public NotificationsPage()
        {
            InitializeComponent();
            NotificationTitle.TitleText = AppResources.NotificationsTab;
            notificationlist = new List<NotificationListItem>();
            var job = new NotificationListItem() { Text = "Job Completed", Icon = "logo.png" ,Time = "15 minutes ago" };
            var job1 = new NotificationListItem() { Text = "Someone sent a message", Icon = "logo.png", Time = "16 minutes ago" };
            notificationlist.Add(job);
            notificationlist.Add(job1);
            notificationlist.Add(job);
            notificationlist.Add(job1);
            notificationlist.Add(job);
            notificationlist.Add(job1);
            notificationlist.Add(job);
            notificationlist.Add(job1);
            notificationlist.Add(job);
            notificationlist.Add(job1);
 

            NotificationList.ItemsSource = notificationlist;
        }

        public class NotificationListItem
        {
            public string Text { get; set; }
            public string Icon { get; set; }
            public string Time { get; set; }
        }

        private void MenuItem_Clicked(object sender, System.EventArgs e)
        {
           
        }

        private void NotificationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NotificationList.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }


        private void DeleteClicked(object sender, System.EventArgs e)
        {

        }

        private void ListViewLeftSwiped(object sender, SwipedEventArgs e)
        {

        }

        private void ListViewRightSwiped(object sender, SwipedEventArgs e)
        {

        }
    }
}
