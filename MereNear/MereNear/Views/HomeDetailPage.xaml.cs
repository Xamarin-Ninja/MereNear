using MereNear.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
