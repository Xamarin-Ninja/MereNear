using MereNear.Model;
using Prism.Mvvm;
using SignalR.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MereNear.ViewModels.Common
{
    public class BaseViewModel : BindableBase
    {
        public static IChatServices _chatServices;

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

        public static void setPostData(String key, PostJobModel value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static PostJobModel getPostData(String key)
        {

            if (Application.Current.Properties.ContainsKey(key))
            {
                return (PostJobModel)(Application.Current.Properties[key]);
            }
            else
            {
                return default(PostJobModel);
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
