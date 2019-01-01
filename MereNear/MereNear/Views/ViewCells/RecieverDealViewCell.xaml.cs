using MereNear.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.ViewCells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecieverDealViewCell : ViewCell
	{
		public RecieverDealViewCell ()
		{
			InitializeComponent ();

            recieverdealmessage.Text = AppResources.DealMessage;

            vatValue.Text = AppResources.Vat + "5%";

            purchasecostdata.Text = AppResources.DealPopupPurchase + " (USD)";
            servicecostdata.Text = AppResources.ServiceCharge + " (USD)";
            subtotaldata.Text = AppResources.SubTotal + " (USD) ";
            totaldata.Text = AppResources.Total + " (USD) ()";

            acceptButton.Text = AppResources.AcceptButton;
            declineButton.Text = AppResources.DeclineButton;
        }
	}
}