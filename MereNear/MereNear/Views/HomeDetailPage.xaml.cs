using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.Views
{
    public partial class HomeDetailPage : ContentPage
    {
        public HomeDetailPage()
        {
            InitializeComponent();
        }

        private void SearchClicked(object sender, System.EventArgs e)
        {
            MessagingCenter.Send("SearchKeyboardClicked","SearchBarKeyboard");
        }
    }
}
