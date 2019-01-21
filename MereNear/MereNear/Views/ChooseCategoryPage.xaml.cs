using MereNear.Model;
using MereNear.Resources;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class ChooseCategoryPage : ContentPage
    {
        public string Address;
        public ChooseCategoryPage()
        {
            InitializeComponent();
            ChooseCategoryLabel.Text = AppResources.ChooseCategoryLabel;
            NextButton.Text = AppResources.NextButton;
        }

        private void SelectedItemTap(object sender, ItemTappedEventArgs e)
        {
            var a = (HomePageModel)e.Item;
            a.FrameColor = Color.LightGreen;
            Xamarin.Forms.Application.Current.Properties["LastSelectedValue"] = a;
            NextButton.IsVisible = true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
