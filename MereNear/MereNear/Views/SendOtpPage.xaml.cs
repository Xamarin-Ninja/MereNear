using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class SendOtpPage : ContentPage
    {
        public SendOtpPage()
        {
            InitializeComponent();
        }
        private void BackIcon_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SubmitButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomeTabbedPage());
        }
    }
}
