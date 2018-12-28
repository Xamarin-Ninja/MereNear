using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MereNear.ViewModels.Common
{
    public class BaseViewModel : BindableBase
    {
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
