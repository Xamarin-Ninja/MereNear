using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SenderLocationViewCell : ViewCell
	{
		public SenderLocationViewCell ()
		{
			InitializeComponent ();
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(30.711262, 76.686310), Distance.FromMiles(2)));
            customMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Address = "",
                Label = "",
                Position = new Position(30.711262, 76.686310),
            });
        }
	}
}