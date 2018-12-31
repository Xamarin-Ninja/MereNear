using MereNear.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.PopUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangeNumberPopup : ContentView
	{
		public ChangeNumberPopup ()
		{
			InitializeComponent ();
            IsYourNumberLabel.Text = AppResources.IsThisPhoneNumberLabel;
            recievesmsLabel.Text = AppResources.ReceiveSMS;
            EditButton.Text = AppResources.EditButton;
            YesButton.Text = AppResources.YesButton;
		}
    }
}