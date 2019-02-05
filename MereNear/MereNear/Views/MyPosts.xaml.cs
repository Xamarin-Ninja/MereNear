using MereNear.Interface;
using MereNear.Resources;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class MyPosts : ContentPage
    {
        public MyPosts()
        {
            InitializeComponent();
            Myposttitle.TitleText = AppResources.MyPostsMenu;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
