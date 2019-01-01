using MereNear.ViewModels.Common;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class EditProfilePageViewModel : BaseViewModel
    {

        private ImageSource _cameraPicker = "upload_photo_icon.jpg";
        private ShowcaseListModel _selectedItemCommand;
        private readonly INavigationService _navigationService;
        private ObservableCollection<ShowcaseListModel> _showcase = new ObservableCollection<ShowcaseListModel>();


        public ImageSource CameraPicker
        {
            get { return _cameraPicker; }
            set { SetProperty(ref _cameraPicker, value); }
        }
        public ShowcaseListModel SelectedItemCommand
        {
            get { return _selectedItemCommand; }
            set
            {
                SetProperty(ref _selectedItemCommand, value);
                if (_selectedItemCommand == null)
                {
                    return;
                }
                else
                {
                    if(SelectedItemCommand.ShowcaseImages == "add_photo.png")
                    {
                        uploadpic();
                    }
                }
            }
        }

        private async void uploadpic()
        {
            try
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
                    Showcase.Add(new ShowcaseListModel
                    {
                        ShowcaseImages = file.Path,
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }

        public ObservableCollection<ShowcaseListModel> Showcase
        {
            get { return _showcase; }
            set { SetProperty(ref _showcase, value); }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.GoBackAsync();
                });
            }
        }

        public ICommand CameraPickerCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                            return;
                        }

                        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            Directory = "Profile Photo",
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Medium,
                            MaxWidthHeight = 2000,
                            DefaultCamera = CameraDevice.Rear
                        });


                        if (file == null)
                            return;

                        //await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

                        CameraPicker = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        public EditProfilePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetData();
        }
        private void GetData()
        {
             Showcase.Add(new ShowcaseListModel
             {
                    ShowcaseImages = "add_photo.png",
                    FrameColor = Color.LightGray
             });
        }

    }
    #region Models
    public class ShowcaseListModel : INotifyPropertyChanged
    {
        public string ShowcaseImages { get; set; }
        private Color _frameColor = Color.LightGray;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Color FrameColor
        {
            get { return _frameColor; }
            set { _frameColor = value; OnPropertyChanged("FrameColor"); }
        }
    }
    #endregion
}
