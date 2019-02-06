using Acr.UserDialogs;
using MereNear.Services;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class ProfilePageViewModel : BaseViewModel, INavigationAware
    {
        #region Private Variables
        private MediaFile _mediaFile;
        private readonly INavigationService _navigationService;
        private bool _isCertifiedClicked = false;
        private string _personName;
        private string _personMobileNumber;
        private string _certificationText = "GET CERTIFIED";
        private string _cameraPicker = "upload_photo_icon.jpg";
        private string _headerLeftIcon;
        private string _rightIconImage;
        private bool _isCertificationPopupVisible = false;
        #endregion

       


        #region Public Variables
        public string lastnavigatedpage = "";
        public string CameraPicker
        {
            get { return _cameraPicker; }
            set { SetProperty(ref _cameraPicker, value); }
        }
        public bool IsCertificationPopupVisible
        {
            get { return _isCertificationPopupVisible; }
            set { SetProperty(ref _isCertificationPopupVisible, value); }
        }
        public string RightIconImage
        {
            get { return _rightIconImage; }
            set { SetProperty(ref _rightIconImage, value); }
        }

        public string HeaderLeftIcon
        {
            get { return _headerLeftIcon; }
            set { SetProperty(ref _headerLeftIcon, value); }
        }

        public string PersonName
        {
            get { return _personName; }
            set { SetProperty(ref _personName, value); }
        }

        public string PersonMobileNumber
        {
            get { return _personMobileNumber; }
            set { SetProperty(ref _personMobileNumber, value); }
        }
        public bool IsCertifiedClicked
        {
            get { return _isCertifiedClicked; }
            set { SetProperty(ref _isCertifiedClicked, value); }
        }
        public string CertificationText
        {
            get { return _certificationText; }
            set { SetProperty(ref _certificationText, value); }
        }
        #endregion

        #region Command
        public ICommand HeaderLeftIconCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    if (lastnavigatedpage != "HomeDetailPage")
                    {
                        MessagingCenter.Send("HamburgurClick", "OpenMasterDetailPage");
                    }
                    else
                    {
                        await _navigationService.GoBackAsync();
                    }
                });
            }
        }

        public ICommand GetCertifiedClicked
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    //IsCertifiedClicked = true;
                    IsCertificationPopupVisible = true;
                });
            }
        }
        
        public ICommand OverlayTapped
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsCertificationPopupVisible = false;
                });
            }
        }
        public ICommand CertificationSubmitCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CertificationText = "Applied";
                    IsCertificationPopupVisible = false;
                });
            }
        }
        public ICommand HeaderRightIconCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    if (lastnavigatedpage != "HomeDetailPage")
                    {
                        await _navigationService.NavigateAsync(nameof(EditProfilePage)); 
                    }
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
                        var action = await App.Current.MainPage.DisplayActionSheet("Add Photo", "Cancel", null, "Camera", "Gallery");
                        switch (action)
                        {
                            case "Camera":
                                CameraPicker = await CameraCommand();
                                break;
                            case "Gallery":
                                CameraPicker = await GalleryCommand();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }
        #endregion

        #region Constructor
        public ProfilePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods
        private async Task<string> GalleryCommand()
        {
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return null;
                }
                _mediaFile = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                });


                if (_mediaFile == null)
                    return null;

                return _mediaFile.Path;
                //ImagePicker = ImageSource.FromStream(() =>
                //{
                //    var stream = _mediaFile.GetStream();
                //    _mediaFile.Dispose();
                //    return stream;
                //});
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<string> CameraCommand()
        {
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return null;
                }

                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Profile Photo",
                    SaveToAlbum = true,
                    PhotoSize = PhotoSize.Medium,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Rear
                });


                if (_mediaFile == null)
                    return null;

                //await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");


                return _mediaFile.Path;
                //CameraPicker = ImageSource.FromStream(() =>
                // {
                //     var stream = _mediaFile.GetStream();
                //     _mediaFile.Dispose();
                //     return stream;
                // });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Navigation Parameters
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("HomeDetailPage"))
            {
                lastnavigatedpage = (string)parameters["HomeDetailPage"];
                HeaderLeftIcon = "back_arrow.png";
                RightIconImage = "";
            }
            else
            {
                HeaderLeftIcon = "menu.png";
                RightIconImage = "edit_profile.png";
            }
        }
        #endregion
    }
}
