using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class AllJobs : ContentPage
    {
        public AllJobs()
        {
            InitializeComponent();
        }

        private void jobListItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            jobListItems.SelectedItem = null;
        }
    }
}
