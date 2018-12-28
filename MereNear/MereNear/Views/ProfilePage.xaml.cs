using MereNear.Resources;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            ProfileTitle.TitleText = AppResources.ProfileTab;
        }
    }
}
