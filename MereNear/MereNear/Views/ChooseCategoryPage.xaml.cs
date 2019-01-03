using MereNear.Model;
using MereNear.Resources;
using Xamarin.Forms;

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
            Application.Current.Properties["LastSelectedValue"] = a;
            NextButton.IsVisible = true;
        }
    }
}
