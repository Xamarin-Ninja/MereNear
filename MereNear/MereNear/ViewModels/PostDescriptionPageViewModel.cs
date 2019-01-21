﻿using Acr.UserDialogs;
using MereNear.Model;
using MereNear.ViewModels.Common;
using MereNear.Resources;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace MereNear.ViewModels
{
	public class PostDescriptionPageViewModel : BaseViewModel, INavigationAware
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private MediaFile _mediaFile;

        private string _immediatelyRadioButtonImage = "checked_circle";
        private string _scheduleRadioButtonImage = "unchecked_circle";
        private bool _isScheduleSelected = false;

        private DateTime _minimumDate = DateTime.Today;

        private string _description;
        private PostJobModel _jobModel = new PostJobModel();
        private DateTime _jobDate = DateTime.Today;
        private DateTime _jobTime;
        private string _categoryName;
        private string _categoryWork;
        private string _locationAddress;
        private string _dropLocationAddress;

        private bool _isPreviewVisible = false;

        private ImageSource _imagePicker1 = "upload_photo_icon.jpg";
        private ImageSource _imagePicker2 = "upload_photo_icon.jpg";
        #endregion

        #region Public Variables
        public ImageSource ImagePicker1
        {
            get { return _imagePicker1; }
            set { SetProperty(ref _imagePicker1, value); }
        }

        public ImageSource ImagePicker2
        {
            get { return _imagePicker2; }
            set { SetProperty(ref _imagePicker2, value); }
        }

        public string LocationAddress
        {
            get { return _locationAddress; }
            set { SetProperty(ref _locationAddress, value); }
        }
        public string DropLocationAddress
        {
            get { return _dropLocationAddress; }
            set { SetProperty(ref _dropLocationAddress, value); }
        }

        public DateTime MinimumDate
        {
            get { return _minimumDate; }
            set { SetProperty(ref _minimumDate, value); }
        }

        public Position LocationAddressPosition { get; set; }
        public Position DropLocationAddressPosition { get; set; }

        public string CategoryName
        {
            get { return _categoryName; }
            set { SetProperty(ref _categoryName, value); }
        }

        public string CategoryWork
        {
            get { return _categoryWork; }
            set { SetProperty(ref _categoryWork, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        public PostJobModel JobModel
        {
            get { return _jobModel; }
            set { SetProperty(ref _jobModel, value); }
        }
        public DateTime JobDate
        {
            get { return _jobDate; }
            set { SetProperty(ref _jobDate, value); }
        }
        public DateTime JobTime
        {
            get { return _jobTime; }
            set { SetProperty(ref _jobTime, value); }
        }
        public bool IsPreviewVisible
        {
            get { return _isPreviewVisible; }
            set { SetProperty(ref _isPreviewVisible, value); }
        }


        public string ImmediatelyRadioButtonImage
        {
            get { return _immediatelyRadioButtonImage; }
            set { SetProperty(ref _immediatelyRadioButtonImage, value); }
        }

        public string ScheduleRadioButtonImage
        {
            get { return _scheduleRadioButtonImage; }
            set { SetProperty(ref _scheduleRadioButtonImage, value); }
        }

        public bool IsScheduleSelected
        {
            get { return _isScheduleSelected; }
            set { SetProperty(ref _isScheduleSelected, value); }
        }

        #endregion

        #region Command


        //public ICommand CameraPickerCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(async () =>
        //        {
        //            try
        //            {
        //                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //                {
        //                    await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
        //                    return;
        //                }

        //                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        //                {
        //                    Directory = "Profile Photo",
        //                    SaveToAlbum = true,
        //                    PhotoSize = PhotoSize.Medium,
        //                    MaxWidthHeight = 2000,
        //                    DefaultCamera = CameraDevice.Rear
        //                });


        //                if (_mediaFile == null)
        //                    return;

        //                //await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");


        //                CameraPicker = _mediaFile.Path;
        //                //CameraPicker = ImageSource.FromStream(() =>
        //                // {
        //                //     var stream = _mediaFile.GetStream();
        //                //     _mediaFile.Dispose();
        //                //     return stream;
        //                // });
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        });
        //    }
        //}

        //public ICommand ImagePickerCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(async() =>
        //        {
        //            try
        //            {
        //                if (!CrossMedia.Current.IsPickPhotoSupported)
        //                {
        //                    await App.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
        //                    return;
        //                }
        //                _mediaFile = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        //                {
        //                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

        //                });


        //                if (_mediaFile == null)
        //                    return;

        //                ImagePicker = _mediaFile.Path;
        //                //ImagePicker = ImageSource.FromStream(() =>
        //                //{
        //                //    var stream = _mediaFile.GetStream();
        //                //    _mediaFile.Dispose();
        //                //    return stream;
        //                //});
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        });
        //    }
        //}

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

        public ICommand ImmediatelySelected
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    clearcheck();
                    ImmediatelyRadioButtonImage = "checked_circle";
                    IsScheduleSelected = false;
                });
            }
        }

        public ICommand ScheduleSelected
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    clearcheck();
                    ScheduleRadioButtonImage = "checked_circle";
                    IsScheduleSelected = true;
                });
            }
        }
        public ICommand PopupCloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsPreviewVisible = false;
                });
            }
        }
        public ICommand ImageUploadCommand1
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    
                    var action = await App.Current.MainPage.DisplayActionSheet("Add Photo", "Cancel", null, "Camera", "Gallery");
                    switch (action)
                    {
                        case "Camera":
                            ImagePicker1 = await CameraCommand();
                            break;
                        case "Gallery":
                            ImagePicker1 = await GalleryCommand();
                            break;
                        default:
                            break;
                    }
                });
            }
        }

        public ICommand ImageUploadCommand2
        {
            get
            {
                return new DelegateCommand(async () =>
                {

                    var action = await App.Current.MainPage.DisplayActionSheet("Add Photo", "Cancel", null, "Camera", "Gallery");
                    switch (action)
                    {
                        case "Camera":
                            ImagePicker2 = await CameraCommand();
                            break;
                        case "Gallery":
                            ImagePicker2 = await GalleryCommand();
                            break;
                        default:
                            break;
                    }
                });
            }
        }

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

        public ICommand SubmitPostCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    JobModel.PostedDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    setPostData("PostJobModel", JobModel);
                    var param = new NavigationParameters();
                    param.Add("PostJobData", JobModel);
                    //await _navigationService.NavigateAsync("/NavigationPage/MyPosts", param);
                    await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/MyPosts", UriKind.Absolute), param);
                });
            }
        }
        public ICommand PreviewClicked
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    JobModel.Image = "plumbing.png";
                    JobModel.Address = LocationAddress;
                    JobModel.AddressPosition = LocationAddressPosition;
                    JobModel.DropAddress = DropLocationAddress;
                    JobModel.DropAddressPosition = DropLocationAddressPosition;
                    JobModel.CategoryName = CategoryName;
                    JobModel.Description = Description;
                    JobModel.CategoryWork = CategoryWork;
                    JobModel.Distance = "20";
                    JobModel.Status = AppResources.JobStatusActive;
                    if (IsScheduleSelected)
                    {
                        JobModel.Date = JobDate.ToString("dd/MM/yyyy");
                        JobModel.Time = JobTime.ToString("HH:mm");
                    }
                    else
                    {
                        JobModel.Date = DateTime.Now.Date.ToString("dd/MM/yyyy");
                        JobModel.Time = AppResources.Now;
                        //JobModel.Time = DateTime.Now.TimeOfDay.ToString("HH:mm");
                    }

                    MessagingCenter.Send(JobModel, "PreviewData");

                    IsPreviewVisible = true;
                    //bool item = await App.Current.MainPage.DisplayAlert("Post Job", "Sure To Post a Job", "Post", "Cancel");
                    //if (item)
                    //{
                    //    var param = new NavigationParameters();
                    //    param.Add("PostJobData", JobModel);
                    //    await _navigationService.NavigateAsync("/NavigationPage/MyPosts",param);
                    //}
                    //else
                    //{
                    //    await _navigationService.GoBackToRootAsync();
                    //}
                });
            }
        }
        #endregion

        #region Constructor

        public PostDescriptionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
       
        #endregion

        #region Private Method
        private void clearcheck()
        {
            ImmediatelyRadioButtonImage = "unchecked_circle.png";
            ScheduleRadioButtonImage = "unchecked_circle.png";
        }

        private byte[] ConvertMediaFileToByteArray(MediaFile mediaFile)
        {

            using (var memoryStream = new MemoryStream())
            {
                var stream = mediaFile.GetStream();
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
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
            if (parameters.ContainsKey("Address"))
            {
                LocationAddress = (string)parameters["Address"];
            }
            if (parameters.ContainsKey("Categoryname"))
            {
                CategoryName = (string)parameters["Categoryname"];
            }
            if (parameters.ContainsKey("AddressPosition"))
            {
                LocationAddressPosition = (Position)parameters["AddressPosition"];
            }
            if (parameters.ContainsKey("DropAddress"))
            {
                DropLocationAddress = (string)parameters["DropAddress"];
            }
            if (parameters.ContainsKey("DropAddressPosition"))
            {
                DropLocationAddressPosition = (Position)parameters["DropAddressPosition"];
            }
        }
        #endregion
    }
}
