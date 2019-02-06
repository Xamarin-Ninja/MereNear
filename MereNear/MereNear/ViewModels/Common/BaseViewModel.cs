using LiteDB.LanguageModelDB;
using LiteDB.UserModelDB;
using MereNear.Model;
using MereNear.Services.ApiService.Common;
using MereNear.Services.LiteDB.ChatModelDB;
using MereNear.Services.LiteDB.NotificationModelDB;
using MereNear.Services.LiteDB.PostJobModelDB;
using Prism.Mvvm;
using Prism.Navigation;
using SignalR.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MereNear.ViewModels.Common
{
    public class BaseViewModel : BindableBase
    {
        protected static IChatServices _chatServices;
        protected readonly IChatModelDbService chatModelDbService;
        protected readonly IPostJobDBService postJobDBService;
        protected readonly IUserDBService userDBService;
        protected readonly ILanguageDBService languageDBService;
        protected readonly INotificationDBService notificationDBService;

        public BaseViewModel()
        {
            _chatServices = DependencyService.Get<IChatServices>();
            chatModelDbService = DependencyService.Get<IChatModelDbService>();
            postJobDBService = DependencyService.Get<IPostJobDBService>();
            userDBService = DependencyService.Get<IUserDBService>();
            languageDBService = DependencyService.Get<ILanguageDBService>();
            notificationDBService = DependencyService.Get<INotificationDBService>();
        }

        public static void setInt(String key, int value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static void setString(String key, String value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static void setBool(String key, bool value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static void setData(String key, GetCatApiModel value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static GetCatApiModel getData(String key)
        {

            if (Application.Current.Properties.ContainsKey(key))
            {
                return (GetCatApiModel)(Application.Current.Properties[key]);
            }
            else
            {
                return default(GetCatApiModel);
            }
        }

        public static bool getBool(String key)
        {

            if (Application.Current.Properties.ContainsKey(key))
            {
                return (bool)(Application.Current.Properties[key]);
            }
            else
            {
                return false;
            }
        }

        public static String getString(String key)
        {

            if (Application.Current.Properties.ContainsKey(key))
            {

                return (Application.Current.Properties[key].ToString());
            }
            else
            {
                return "";
            }
        }

        public static int getInt(String key)
        {

            if (Application.Current.Properties.ContainsKey(key))
            {
                return (Int32)(Application.Current.Properties[key]);
            }
            else
            {
                return 0;
            }
        }
    }
}
