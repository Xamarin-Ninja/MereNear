using MereNear.Resources;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class PostDescriptionPage : ContentPage
    {
        public PostDescriptionPage()
        {
            InitializeComponent();
            JobTitleLabel.Text = AppResources.jobTitleLabel;
            DescriptionLabel.Text = AppResources.DescriptionLabel;
            DescriptionEditor.Placeholder = AppResources.DescriptionEditorPlaceholder;
            immediatelyLabel.Text = AppResources.ImmediatelyLabel;
            SchedulejobLabel.Text = AppResources.ScheduleLabel;
            DateLabel.Text = AppResources.DateLabel;
            TimeLabel.Text = AppResources.TimeLabel;
            AddphotosLabel.Text = AppResources.AddPhotosLabel;
            previewbutton.Text = AppResources.PreviewButton;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
