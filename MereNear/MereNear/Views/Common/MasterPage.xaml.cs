using MereNear.Model;
using MereNear.Resources;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.Views.Common
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            HomeMenu.Text = AppResources.HomeTab;
            AboutUsMenu.Text = AppResources.AboutUsMenu;
            MyJobsMenu.Text = AppResources.MyJobsTab;
            MyPostsMenu.Text = AppResources.MyPostsMenu;
            OurPoliciesMenu.Text = AppResources.OurPoliciesMenu;
            RateUsMenu.Text = AppResources.RateUsMenu;
            SettingsMenu.Text = AppResources.SettingsMenu;
            SupportMenu.Text = AppResources.SupportMenu;
            logoutMenu.Text = AppResources.LogoutMenu;
            MessagingCenter.Subscribe<string>(this, "OpenMasterDetailPage", (sender) => {
                if (!IsPresented)
                    IsPresented = true;
            });
        }

    }
}