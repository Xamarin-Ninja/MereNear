using System.Collections.Generic;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class NotificationsPage : ContentPage
    {
        public List<NotificationListItem> notificationlist { get; set; }

        public NotificationsPage()
        {
            InitializeComponent();

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
    }
}
