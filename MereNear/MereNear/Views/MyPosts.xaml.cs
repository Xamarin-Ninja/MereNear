using MereNear.Interface;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class MyPosts : ContentPage
    {
        public MyPosts()
        {
            InitializeComponent();
            
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            postListItems.SelectedItem = null;
        }

        protected override bool OnBackButtonPressed()
        {
            var result = DependencyService.Get<ToastMessage>().Show("Press back to close application.");
            if (!result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
