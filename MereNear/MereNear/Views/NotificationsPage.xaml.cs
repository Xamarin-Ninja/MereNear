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
            var job = new NotificationListItem() { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Icon = "logo.png" ,Time = "15 minutes ago" };

            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);
            notificationlist.Add(job);

            NotificationList.ItemsSource = notificationlist;
        }

        public class NotificationListItem
        {
            public string Text { get; set; }
            public string Icon { get; set; }
            public string Time { get; set; }
        }
    }
}
