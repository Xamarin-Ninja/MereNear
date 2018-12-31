using MereNear.Resources;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class AllJobs : ContentPage
    {
        public AllJobs()
        {
            InitializeComponent();
            alljobstitle.TitleText = AppResources.AllJobstitle;
        }

        private void jobListItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            jobListItems.SelectedItem = null;
        }
    }
}
