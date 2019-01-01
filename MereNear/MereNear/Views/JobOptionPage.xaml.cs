using MereNear.Interface;
using MereNear.Resources;
using MereNear.Views.Common;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class JobOptionPage : ContentPage
    {
        public JobOptionPage()
        {
            InitializeComponent();
            PostJobLabel.Text = AppResources.PostJob;
            LookingforJobLabel.Text = AppResources.LookingJob;
        }
    }
}
