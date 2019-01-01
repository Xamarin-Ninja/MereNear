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
	public partial class ReviewPopUp : ContentView
	{
		public ReviewPopUp ()
		{
			InitializeComponent ();

            reviewPopupTitle.Text = AppResources.ReviewPopupTitle;
            reviewPopupEditor.Placeholder = AppResources.ReviewPopupEditor;
            reviewButton.Text = AppResources.ReviewButton;
		}
	}
}