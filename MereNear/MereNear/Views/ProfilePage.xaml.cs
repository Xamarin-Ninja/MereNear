using MereNear.Model;
using MereNear.Resources;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ObservableCollection<ShowcaseImagesModel> _showcaseList = new ObservableCollection<ShowcaseImagesModel>();

        public ProfilePage()
        {
            InitializeComponent();
            ProfileTitle.TitleText = AppResources.ProfileTab;

            var item = new ShowcaseImagesModel
            {
                showcaseImage = "Image1.jpg"
            };
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            _showcaseList.Add(item);
            showcaselist.FlowItemsSource = _showcaseList;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
