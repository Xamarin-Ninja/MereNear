using MereNear.Model;
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
	public partial class PreviewPopup : ContentView
	{
		public PreviewPopup ()
		{
			InitializeComponent ();
            MessagingCenter.Subscribe<PostJobModel>(this, "PreviewData", (sender) =>
            {
                description.Text = sender.Description;
                address.Text = sender.Address;
            });
		}
	}
}