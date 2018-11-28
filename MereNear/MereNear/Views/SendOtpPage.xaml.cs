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
            //Navigation.PushAsync(new HomeTabbedPage());
        }

        //private void OTP1TextChange(object sender, TextChangedEventArgs e)
        //{
        //    OTP2.Focus();
        //}

        //private void OTP2TextChange(object sender, TextChangedEventArgs e)
        //{
        //    OTP3.Focus();
        //}

        //private void OTP3TextChange(object sender, TextChangedEventArgs e)
        //{
        //    OTP4.Focus();
        //}

        //private void OTP4TextChange(object sender, TextChangedEventArgs e)
        //{
        //    OTP4.Unfocus();
        //    //MessagingCenter.Send("OTPAutoFillComplete", "OTPAutoFillComplete");
        //}
    }
}
