using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class MyJobs : ContentPage
    {
        public MyJobs()
        {
            InitializeComponent();
        }

        private void jobListItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            jobListItems.SelectedItem = null;
        }
    }
}
