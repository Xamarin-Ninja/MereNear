using System;
using System.Collections.Generic;
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
		}

        private void Entry_Focused(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new Login_Page2(), true);
            MessagingCenter.Send("EntryFocus", "EntryFocus");
        }
    }
}