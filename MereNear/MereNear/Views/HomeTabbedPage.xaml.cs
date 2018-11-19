using MereNear.Interface;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class HomeTabbedPage : TabbedPage
    {
        int count = 0;
        public HomeTabbedPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            if(count == 0)
            {
                DependencyService.Get<ToastMessage>().Show("Press back again to EXIT app");
                count = 1;
                return true;
            }
            else if(count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
