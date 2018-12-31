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
            purchasecostdata.Text = "Purchase cost: (USD) ";
            servicecostdata.Text = "Service charge: (USD) ";
            subtotaldata.Text = "Sub Total: (USD) ";
            totaldata.Text = "Total: (USD) ()";
		}
	}
}