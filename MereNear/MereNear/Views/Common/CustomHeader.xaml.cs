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
	public partial class CustomHeader : ContentView
	{
		public CustomHeader ()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create("TitleText", typeof(string), typeof(Label), null);
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty HeaderRightIconProperty = BindableProperty.Create("HeaderRightIcon", typeof(string), typeof(Label), null, BindingMode.TwoWay);
        public string HeaderRightIcon
        {
            get { return (string)GetValue(HeaderRightIconProperty); }
            set { SetValue(HeaderRightIconProperty, value); }
        }
    }
}