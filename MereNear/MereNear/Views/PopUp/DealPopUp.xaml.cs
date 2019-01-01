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
	public partial class DealPopUp : ContentView
	{
		public DealPopUp ()
		{
			InitializeComponent ();

            dealPopupTitle.Text = AppResources.MakeDealButton;
            vatValue.Text = AppResources.Vat + "5%";
            purchaseAmountEntry.Placeholder = AppResources.PurchaseAmountEntry;
            serviceChargeEntry.Placeholder = AppResources.ServiceChargeEntry;
            SubmitButton.Text = AppResources.SubmitButton;
		}
	}
}