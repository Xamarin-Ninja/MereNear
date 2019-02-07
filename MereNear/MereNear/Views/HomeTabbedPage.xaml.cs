using MereNear.Interface;
using MereNear.Resources;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class HomeTabbedPage : TabbedPage
    {
        
        public HomeTabbedPage()
        {
            try
            {
                InitializeComponent();
                HomeTab.Title = AppResources.HomeTab;
                MyJobsTab.Title = AppResources.MyJobsTab;
                NotificationTab.Title = AppResources.NotificationsTab;
                MessageTab.Title = AppResources.MessagesTab;
                ProfileTab.Title = AppResources.ProfileTab;
                MessagingCenter.Subscribe<string>(this, "ChangeCurrentPage", (sender) =>
                {
                    if (sender.Equals("HomePage"))
                    {
                        CurrentPage = Children[0];
                        this.Title = CurrentPage.Title;
                    }
                    else if (sender.Equals("MyJobs"))
                    {
                        CurrentPage = Children[1];
                        this.Title = this.CurrentPage.Title;
                    }
                    else if (sender.Equals("Notifications"))
                    {
                        CurrentPage = Children[2];
                        this.Title = this.CurrentPage.Title;
                    }
                    else if (sender.Equals("Messages"))
                    {
                        CurrentPage = Children[3];
                        this.Title = this.CurrentPage.Title;
                    }
                    else if (sender.Equals("MyProfile"))
                    {
                        CurrentPage = Children[4];
                        this.Title = this.CurrentPage.Title;
                    }
                    else
                    {

                    }

                });
            }
            catch (System.Exception ex)
            {

            }
        }
        
        protected override bool OnBackButtonPressed()
        {
            var result = DependencyService.Get<ToastMessage>().Show("Press back to close application.");
            if (!result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
