using MereNear.Resources;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class MyJobs : ContentPage
    {
        public MyJobs()
        {
            try
            {
                InitializeComponent();
                MyJobTitle.TitleText = AppResources.MyJobsTab;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void jobListItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            jobListItems.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
