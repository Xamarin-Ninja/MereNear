using MereNear.ViewModels.Common;
using MereNear.Resources;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MereNear.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login_Page : ContentPage
	{
		public Login_Page ()
		{
			InitializeComponent ();
            AppSlogan.Text = AppResources.AppSlogan;
            MobileEntryTitle.Text = AppResources.MobileEntryTitle;
            MobileEntryPlaceholer.Text = AppResources.MobileEntryPlaceholder;
        }

        private void Entry_Focused(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new Login_Page2(), true);
            MessagingCenter.Send("EntryFocus", "EntryFocus");
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}