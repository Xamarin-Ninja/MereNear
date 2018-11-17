using MereNear.Model;
using MereNear.ViewModels;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class ChooseCategoryPage : ContentPage
    {
        public string Address;
        public ChooseCategoryPage()
        {
            InitializeComponent();
        }

        private void SelectedItemTap(object sender, ItemTappedEventArgs e)
        {
            var a = (CategoryListModel)e.Item;
            a.FrameColor = Color.LightGreen;
            Application.Current.Properties["LastSelectedValue"] = a;
            NextButton.IsVisible = true;
        }
    }
}
