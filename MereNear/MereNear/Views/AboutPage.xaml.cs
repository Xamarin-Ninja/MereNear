using MereNear.Interface;
using MereNear.Resources;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            aboutustitle.TitleText = AppResources.AboutUsMenu;
            AboutMereNearLabel.Text = AppResources.AboutMereNearLabel;
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
