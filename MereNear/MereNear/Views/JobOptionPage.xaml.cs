using MereNear.Views.Common;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class JobOptionPage : ContentPage
    {
        public JobOptionPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PickLocationMapPage());
        }

        private void LookingForJobTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChooseCategoryPage());
        }
    }
}
