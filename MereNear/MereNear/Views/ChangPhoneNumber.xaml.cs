using MereNear.Resources;
using MereNear.ViewModels.Common;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class ChangPhoneNumber : ContentPage
    {
        public ChangPhoneNumber()
        {
            InitializeComponent();
            existingNumber.Text = AppResources.CurrentNumberLabel + " " + BaseViewModel.getString("LoginMobileNumber");
            NewNumberLabel.Text = AppResources.NewNumberLabel;
            MobileEntry.Placeholder = AppResources.MobileEntryPlaceholder;
            NumberMakeSure.Text = AppResources.ChnageNumberSureLabel;
            ContinueButton.Text = AppResources.ContinueButton;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
