using MereNear.ViewModels;
using Plugin.Media;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent(); 

            _showcase.Add(new ShowcaseListModel
            {

                ShowcaseImages = "add_photo.png"
            });

            showcaseList.FlowItemsSource = _showcase;
            double ListHeightValue = _showcase.Count / 2;
            var data = (int)Math.Round(ListHeightValue);
            showcaseList.HeightRequest = data * showcaseList.RowHeight;
            
        }

        public ObservableCollection<ShowcaseListModel> _showcase = new ObservableCollection<ShowcaseListModel>();

        private async void SelectedItemTap(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var frame = (ShowcaseListModel)e.Item;
                if (frame.ShowcaseImages == "add_photo.png")
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await App.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }
                    var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                    });


                    if (file == null)
                    {
                        return;
                    }
                    else
                    {
                        var item = new ShowcaseListModel()
                        {
                            ShowcaseImages = file.Path
                        };
                        if (_showcase.Count<2)
                        {
                            _showcase.Add(item);
                        }
                        else
                        {
                            _showcase.Insert(1, item);
                        }

                        showcaseList.FlowItemsSource = _showcase;
                        double ListHeightValue = _showcase.Count / 2;
                        var data = (int)Math.Round(ListHeightValue);
                        showcaseList.HeightRequest = data * showcaseList.RowHeight;
                    } 
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }

        
    }
}
