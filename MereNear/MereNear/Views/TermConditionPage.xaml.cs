using MereNear.Interface;
using MereNear.Resources;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class TermConditionPage : ContentPage
    {
        public TermConditionPage()
        {
            InitializeComponent();
            PolicyTitle.TitleText = AppResources.OurPoliciesMenu;
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
