using MereNear.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.Views
{
    public partial class MyPostsDetail : ContentPage
    {
        public MyPostsDetail()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<string,Position>(this, "PostJobLocation", (sender,position) =>
            {
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude,position.Longitude), Distance.FromMiles(0.5)));
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Address = "",
                    Label = ""
                };
                customMap.Pins.Add(pin);
            });
            //var detailedData = (MyPostsModel)sender;
            //customheader.TitleText = sender.WorkerJobType;
            //jobstatus.Text = sender.WorkerJobStatus;
            //jobstatus.TextColor = sender.JobStatusColor;
        }
    }
}
