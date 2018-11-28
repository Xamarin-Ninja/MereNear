using MereNear.Interface;
using System;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class HomeTabbedPage : TabbedPage
    {
        
        public HomeTabbedPage()
        {
            InitializeComponent();
        }
        int count = 0;
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
