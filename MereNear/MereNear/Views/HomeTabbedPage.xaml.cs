using MereNear.Interface;
using MereNear.Resources;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class HomeTabbedPage : TabbedPage
    {
        
        public HomeTabbedPage()
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
                else
                {

                }

            });
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
    }
}
