using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class Login_Page2 : ContentPage
    {
        public Login_Page2()
        {
            InitializeComponent();
            NextButton.Text ="";
            MobileEntry.Focus();
        }

        private void BackIcon_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(MobileEntry.Text != null)
            {
                NextButton.Text = "NEXT";
                App.CurrentUser = MobileEntry.Text;
            }
        }

        private void NextButton_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new SendOtpPage(MobileEntry.Text), true);
            Navigation.PushAsync(new MessagesPage(), true);
        }
    }
}
