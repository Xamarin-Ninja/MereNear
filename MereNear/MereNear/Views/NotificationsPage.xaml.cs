using ContextMenu;
using MereNear.Resources;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class NotificationsPage : ContentPage
    {
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
