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
    }
}
