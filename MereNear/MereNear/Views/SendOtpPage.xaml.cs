using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class SendOtpPage : ContentPage
    {
        public SendOtpPage()
        {
            InitializeComponent();
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
