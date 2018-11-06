using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class SendOtpPage : ContentPage
    {
        public SendOtpPage(string phone)
        {
            InitializeComponent();
            MainLabel.Text = "Please wait. We will auto verify the OTP sent to +91 - " + phone;
        }
        private void BackIcon_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SubmitButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomeTabbedPage());
        }

        private void OTP1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OTP2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
