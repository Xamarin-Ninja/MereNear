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

        public static readonly BindableProperty HeaderLeftIconProperty = BindableProperty.Create("HeaderLeftIcon", typeof(string), typeof(Label), null, BindingMode.TwoWay);
        public string HeaderLeftIcon
        {
            get { return (string)GetValue(HeaderLeftIconProperty); }
            set { SetValue(HeaderLeftIconProperty, value); }
        }

        public static readonly BindableProperty HeaderLeft2ndIconProperty = BindableProperty.Create("HeaderLeft2ndIcon", typeof(string), typeof(Label), null, BindingMode.TwoWay);
        public string HeaderLeft2ndIcon
        {
            get { return (string)GetValue(HeaderLeft2ndIconProperty); }
            set { SetValue(HeaderLeft2ndIconProperty, value); }
        }

        public static readonly BindableProperty HeaderRight2ndIconProperty = BindableProperty.Create("HeaderRight2ndIcon", typeof(string), typeof(Label), null, BindingMode.TwoWay);
        public string HeaderRight2ndIcon
        {
            get { return (string)GetValue(HeaderRight2ndIconProperty); }
            set { SetValue(HeaderRight2ndIconProperty, value); }
        }

        public static readonly BindableProperty HeaderRightIconProperty = BindableProperty.Create("HeaderRightIcon", typeof(string), typeof(Label), null, BindingMode.TwoWay);
        public string HeaderRightIcon
        {
            get { return (string)GetValue(HeaderRightIconProperty); }
            set { SetValue(HeaderRightIconProperty, value); }
        }
    }
}