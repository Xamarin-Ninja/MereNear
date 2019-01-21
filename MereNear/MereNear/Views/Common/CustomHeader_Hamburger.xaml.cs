using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.Common
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomHeader_Hamburger : ContentView
	{
		public CustomHeader_Hamburger ()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create("TitleText", typeof(string), typeof(Label), null, BindingMode.TwoWay);
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty HeaderLeftIconProperty = BindableProperty.Create("HeaderLeftIcon", typeof(string), typeof(Image), null, BindingMode.TwoWay);
        public string HeaderLeftIcon
        {
            get { return (string)GetValue(HeaderLeftIconProperty); }
            set { SetValue(HeaderLeftIconProperty, value); }
        }

        public static readonly BindableProperty RightIconImageProperty = BindableProperty.Create("RightIconImage", typeof(string), typeof(Image), null);
        public string RightIconImage
        {
            get { return (string)GetValue(RightIconImageProperty); }
            set { SetValue(RightIconImageProperty, value); }
        }
    }
}