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
    }
}
