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
	public partial class SenderDealViewCell : ViewCell
	{
		public SenderDealViewCell ()
		{
			InitializeComponent ();

            senderdealmessage.Text = AppResources.DealMessageSender;
            vatValue.Text = AppResources.Vat + "5%";
            purchasecostdata.Text = AppResources.DealPopupPurchase + " (USD)";
            servicecostdata.Text = AppResources.ServiceCharge + " (USD)";
            subtotaldata.Text = AppResources.SubTotal + " (USD) ";
            totaldata.Text = AppResources.Total + " (USD) ()";
		}
	}
}