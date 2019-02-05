using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Common;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ImageCircle.Forms.Plugin.Droid;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;
using Xamarin;
using Xamarin.Forms;


namespace MereNear.Droid
{
    [Activity(Label = "MereNear", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            /*Screen height and width */
            App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);

            UserDialogs.Init(this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            FormsMaps.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            CheckForGoogleServices();

        }

        public bool CheckForGoogleServices()
        {
            var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode  != ConnectionResult.Success )
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    Toast.MakeText(Android.App.Application.Context, GoogleApiAvailability.Instance.GetErrorString(resultCode), ToastLength.Long);
                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, " This device does not support Google Play Services ", ToastLength.Long);
                }
                return false;
            }
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

