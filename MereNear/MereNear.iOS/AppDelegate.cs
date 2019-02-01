using Acr.UserDialogs;
using CoreGraphics;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using MereNear.Interface;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin;
using Xamarin.Forms;

namespace MereNear.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            FormsMaps.Init();
            /*Screen height and width */
            App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(111, 218, 68);
            LoadApplication(new App(new iOSInitializer()));
           
            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.RegisterSingleton<IMD5Cryptor, MD5Cryptor>();
        }
    }
}
