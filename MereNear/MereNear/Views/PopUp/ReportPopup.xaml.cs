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
	public partial class ReportPopup : ContentView
	{
		public ReportPopup ()
		{
			InitializeComponent ();

            reasonForReportLabel.Text = AppResources.ReasonForReportLabel;
            resaonReportPlaceholder.Placeholder = AppResources.ResaonReportPlaceholder;
            ReportButton.Text = AppResources.ReportButton;
		}
	}
}