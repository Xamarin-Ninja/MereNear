using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MereNear.Droid;
using MereNear.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(ToastService))]
namespace MereNear.Droid
{
    public class ToastService : ToastMessage
    {
        public Toast mtoast
        {
            get;
            set;
        }

        public ToastService()
        {
            mtoast = null;
        }

        public bool Show(string message)
        {
            if (mtoast == null)
            {
                mtoast = Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);
                mtoast.Show();
                return false;
            }
            else
            {
                if (mtoast.View.IsShown)
                {
                    return true;
                }
                else
                {

                    mtoast.Show();
                    return false;
                }
            }
        }
    }
}