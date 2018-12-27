using Prism;
using Prism.Ioc;
using MereNear.ViewModels;
using MereNear.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MereNear.Views.Common;
using DLToolkit.Forms.Controls;
using MereNear.Services.ApiService.Common;
using MereNear.Localization;
using SignalR.Interface;
using System;
using Plugin.Connectivity;
using Acr.UserDialogs;
using MereNear.ViewModels.Common;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MereNear
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        #region SignalR Chat Implement Part 1
        private IChatServices _chatServices;
        public static string CurrentUser;
        #endregion

        public static string CultureCode { get; set; }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            #region Check Network Connection
            var seconds = TimeSpan.FromSeconds(1);
            Device.StartTimer(seconds,()=>
            {
                return CheckConnection();
            });
            #endregion

            #region SignalR Chat Implement Part 2
            _chatServices = DependencyService.Get<IChatServices>();
            //_chatServices.Connect();
            #endregion

            FlowListView.Init();
            DependencyService.Get<ILocalize>().SetLocale();
            App.CultureCode = string.Empty;

            var languageexist = BaseViewModel.getString("AppLanguage");
            var useralreadylogin = BaseViewModel.getString("LoginMobileNumber");
            if (string.IsNullOrEmpty(useralreadylogin) || string.IsNullOrWhiteSpace(useralreadylogin))
            {
                if (string.IsNullOrEmpty(languageexist) || string.IsNullOrWhiteSpace(languageexist))
                {
                    await NavigationService.NavigateAsync("NavigationPage/LanguagePage");
                }
                else
                {
                    await NavigationService.NavigateAsync("NavigationPage/Login_Page");
                }
            }
            else
            {
                await NavigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
            }
        }

        private bool CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                UserDialogs.Instance.Alert("Please Check your network Connection");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IWebApiRestClient, WebApiRestClient>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LanguagePage, LanguagePageViewModel>();
            containerRegistry.RegisterForNavigation<SendOtpPage, SendOtpPageViewModel>();
            containerRegistry.RegisterForNavigation<TermConditionPage, TermConditionPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<PostPage, PostPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<RequestRecieved, RequestRecievedViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HomeDetailPage, HomeDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<PlumberDetail, PlumberDetailViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<Login_Page, LoginMobilePageViewModel>();
            containerRegistry.RegisterForNavigation<Login_Page2, Login_Page2ViewModel>();
            containerRegistry.RegisterForNavigation<NotificationsPage, NotificationsPageViewModel>();
            containerRegistry.RegisterForNavigation<MessagesPage, MessagesPageViewModel>();
            containerRegistry.RegisterForNavigation<ChatPage, ChatPageViewModel>();
            containerRegistry.RegisterForNavigation<JobOptionPage, JobOptionPageViewModel>();
            containerRegistry.RegisterForNavigation<ChooseCategoryPage, ChooseCategoryPageViewModel>();
            containerRegistry.RegisterForNavigation<MyPosts, MyPostsViewModel>();
            containerRegistry.RegisterForNavigation<MyPostsDetail, MyPostsDetailViewModel>();
            containerRegistry.RegisterForNavigation<MyJobs, MyJobsViewModel>();
            containerRegistry.RegisterForNavigation<PostDescriptionPage, PostDescriptionPageViewModel>();
            containerRegistry.RegisterForNavigation<PickLocationMapPage, PickLocationMapPageViewModel>();
            containerRegistry.RegisterForNavigation<AllJobs, AllJobsViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<EditProfilePage, EditProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<ChangPhoneNumber, ChangPhoneNumberViewModel>();
        }

        //protected override void OnStart()
        //{
        //    CrossFirebasePushNotification.Current.Subscribe("general");
        //    CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
        //    {
        //        System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
        //    };
        //    System.Diagnostics.Debug.WriteLine($"TOKEN: {CrossFirebasePushNotification.Current.Token}");

        //    CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
        //    {
        //        try
        //        {
        //            System.Diagnostics.Debug.WriteLine("Received");
        //            if (p.Data.ContainsKey("body"))
        //            {
        //                //Device.BeginInvokeOnMainThread(() =>
        //                //{
        //                //    mPage.Message = $"{p.Data["body"]}";
        //                //});
        //                MessagingCenter.Send("Notification Recieved", "Notification Recieved");
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //    };

        //    CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
        //    {
        //        //System.Diagnostics.Debug.WriteLine(p.Identifier);

        //        System.Diagnostics.Debug.WriteLine("Opened");
        //        foreach (var data in p.Data)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
        //        }

        //        if (!string.IsNullOrEmpty(p.Identifier))
        //        {
        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                //mPage.Message = p.Identifier;
        //            });
        //        }
        //        else if (p.Data.ContainsKey("color"))
        //        {
        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                //mPage.Navigation.PushAsync(new ContentPage()
        //                //{
        //                //    BackgroundColor = Color.FromHex($"{p.Data["color"]}")

        //                //});
        //            });

        //        }
        //        else if (p.Data.ContainsKey("aps.alert.title"))
        //        {
        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                //mPage.Message = $"{p.Data["aps.alert.title"]}";
        //            });

        //        }
        //    };

        //    CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
        //    {
        //        System.Diagnostics.Debug.WriteLine("Action");

        //        if (!string.IsNullOrEmpty(p.Identifier))
        //        {
        //            System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
        //            foreach (var data in p.Data)
        //            {
        //                System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
        //            }

        //        }

        //    };

        //    CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
        //    {
        //        System.Diagnostics.Debug.WriteLine("Dismissed");
        //    };
        //    base.OnStart();
        //}

        //protected override void OnSleep()
        //{
        //    base.OnSleep();
        //}

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //}
    }
}
