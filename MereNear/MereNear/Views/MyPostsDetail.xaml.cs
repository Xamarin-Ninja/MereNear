using MereNear.Model;
using MereNear.Resources;
using MereNear.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class MyPostsDetail : ContentPage
    {
        public MyPostsDetail()
        {
            InitializeComponent();
            JobtitleLabel.Text = AppResources.jobTitleLabel;
            jobdescriptionlabel.Text = AppResources.JobDescriptionLabel;
            Needservicelabel.Text = AppResources.NeedServiceLabel;
            jobstatuslabel.Text = AppResources.JobStatusLabel;
            PhotosLabel.Text = AppResources.PhotosLabel;
            MessagingCenter.Subscribe<string,LocationAddress>(this, "PostJobLocation", (sender,position) =>
            {
                Position savedPosition = new Position(position.Latitude, position.Longitude);
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(savedPosition, Distance.FromMiles(0.5)));
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = savedPosition,
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
