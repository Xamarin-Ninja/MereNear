using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.NotificationViewCell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationView : ViewCell
	{
		public NotificationView ()
		{
			InitializeComponent ();
		}

        private void ListViewLeftSwiped(object sender, SwipedEventArgs e)
        {
            Item.TranslateTo(-100, 0, 200, Easing.Linear);
        }

        private void ListViewRightSwiped(object sender, SwipedEventArgs e)
        {
            Item.TranslateTo(0, 0, 200, Easing.Linear);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}