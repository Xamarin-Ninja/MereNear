using Acr.UserDialogs;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MereNear.Services.ImagePickerService
{
    public class ImagePickerService : IImagePickerService
    {
        public async void CameraPicker()
        {
            // Start attaching photo / camera
            #region CAMERA INITILISATION
            await CrossMedia.Current.Initialize();
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }
            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await UserDialogs.Instance.AlertAsync("Couldn't find a Camera to access!", "No Camera", "OK");
                    return;
                }
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Unable to take photos", "Permissions Denied", "OK");
                return;
            }
            #endregion
            UserDialogs.Instance.ShowLoading("Loading image");
            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Custom,
                    CustomPhotoSize = 50,
                    CompressionQuality = 0,
                    SaveToAlbum = false,
                    Directory = "ProfilePhoto",
                    Name = Guid.NewGuid().ToString().Replace('-', '_').Substring(0, 8) + ".jpg"
                });
            try
            {
                if (file != null)
                {
                    var imagebyte = ConvertMediaFileToByteArray(file);
                    if (!CardPicPopUP)
                    {
                        // ProfilePic = ImageSource.FromStream(() => new MemoryStream(imagebyte.ToArray()));
                        ProfilePic = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            return stream;
                        });
                        MessagingCenter.Send<string, byte[]>("ProfilePicUpdate", "ProfilePicUpdate", imagebyte);
                        registrationModel.Photo = imagebyte;
                        ProfileLabelVisibility = false;
                        UpdataUser(registrationModel);
                    }
                    else
                    {
                        // CardIdentificationImage = ImageSource.FromStream(() => new MemoryStream(imagebyte.ToArray()));
                        CardIdentificationImage = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            return stream;
                        });
                        var idCardModel = new IDCardModel()
                        {
                            UserName = LocalSettings.UserName,
                            CreateDate = DateTimeOffset.Now,
                            Image = imagebyte
                        };
                        _secureStorage.Save("idCardModel", idCardModel);
                    }

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Message[] there is error in capturing photo :- " + ex.Message + " \n\n\n\n\n");
            }
            UserDialogs.Instance.HideLoading();
        }

        public void ImagePicker()
        {
            
        }
    }
}