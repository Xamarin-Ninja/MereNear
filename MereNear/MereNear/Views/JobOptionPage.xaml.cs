using MereNear.Interface;
using MereNear.Resources;
using MereNear.Views.Common;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class JobOptionPage : ContentPage
    {
        public JobOptionPage()
        {
            InitializeComponent();
            PostJobLabel.Text = AppResources.PostJob;
            LookingforJobLabel.Text = AppResources.LookingJob;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
