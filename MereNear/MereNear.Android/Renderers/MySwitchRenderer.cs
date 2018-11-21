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
using MereNear.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(Xamarin.Forms.Switch),typeof(MySwitchRenderer))]
namespace MereNear.Droid.Renderers
{
    public class MySwitchRenderer : SwitchRenderer
    {
        protected override Android.Widget.Switch CreateNativeControl()
        {
            return new Android.Widget.Switch(new Android.Views.ContextThemeWrapper(this.Context,Resource.Style.MyTheme_Switch /* <- Custom Switch Style */));
        }
    }
}