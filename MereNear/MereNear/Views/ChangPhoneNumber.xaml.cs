using MereNear.Resources;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class ChangPhoneNumber : ContentPage
    {
        public ChangPhoneNumber()
        {
            InitializeComponent();
            NewNumberLabel.Text = AppResources.NewNumberLabel;
            MobileEntry.Placeholder = AppResources.MobileEntryPlaceholder;
            NumberMakeSure.Text = AppResources.ChnageNumberSureLabel;
            ContinueButton.Text = AppResources.ContinueButton;
        }
    }
}
