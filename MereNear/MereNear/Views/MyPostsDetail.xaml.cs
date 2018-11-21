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
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(30.711262, 76.686310), Distance.FromMiles(0.1)));
            //var detailedData = (MyPostsModel)sender;
            //customheader.TitleText = sender.WorkerJobType;
            //jobstatus.Text = sender.WorkerJobStatus;
            //jobstatus.TextColor = sender.JobStatusColor;
        }
    }
}
