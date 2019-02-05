using Acr.UserDialogs;
using DLToolkit.Forms.Controls;
using LiteDB.LanguageModelDB;
using LiteDB.UserModelDB;
using MereNear.Model;
using MereNear.Resources;
using MereNear.Services.ApiService.Common;
using MereNear.ViewModels;
using MereNear.Views;
using MereNear.Views.Common;
using Plugin.Connectivity;
using Plugin.Multilingual;
using Prism;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        private ILanguageDBService languageDBService;
        private IUserDBService userDBService;
        public bool a;
        public string shortname { get; set; }
        public App() : this(null)
        {

        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {

        }

        #region SignalR Chat Implement Part 1
        //public static IChatServices _chatServices;
        #endregion

        public static string CultureCode { get; set; }

        public static void Setlanguage(string name)
        {
            var culture = new CultureInfo(name);
            AppResources.Culture = culture;
            CrossMultilingual.Current.CurrentCultureInfo = culture;
        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
            languageDBService = DependencyService.Get<ILanguageDBService>();
            userDBService = DependencyService.Get<IUserDBService>();
            #region Check Network Connection
            var seconds = TimeSpan.FromSeconds(1);
            Device.StartTimer(seconds, () =>
             {
                 return CheckConnection();
             });
            #endregion

            #region SignalR Chat Implement Part 2
            //_chatServices = DependencyService.Get<IChatServices>();

            //_chatServices.Connect();
            #endregion

            FlowListView.Init();


            try
            {
                var IsLanguageDBExist = languageDBService.IsLanguageDbPresentInDB();
                var IsUserDBExist = userDBService.IsUserDbPresentInDB();
                if (IsLanguageDBExist)
                {
                    IEnumerable<LanguageModel> lang = languageDBService.ReadAllItems();
                    Setlanguage(lang.First().ShortName);
                    if (IsUserDBExist)
                    {
                        await NavigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
                    }
                    else
                    {
                        await NavigationService.NavigateAsync("NavigationPage/Login_Page");
                    }
                }
                else
                {
                    await NavigationService.NavigateAsync("NavigationPage/LanguagePage");
                }
            }
            catch (Exception ex)
            {
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
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HomeDetailPage, HomeDetailPageViewModel>();
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
    }
}
