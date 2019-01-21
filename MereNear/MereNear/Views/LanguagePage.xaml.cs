using MereNear.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class LanguagePage : ContentPage
    {
        public ObservableCollection<LanguageModel> LanguagePicker = new ObservableCollection<LanguageModel>();
        public LanguagePage()
        {
            InitializeComponent();
            GetLanguages();
        }
        private void GetLanguages()
        {
            LanguagePicker.Add(new LanguageModel
            {
                DisplayName = "English",
                ShortName = "en"
            });
            LanguagePicker.Add(new LanguageModel
            {
                DisplayName = "हिंदी",
                ShortName = "hi"
            });
            LanguagePicker.Add(new LanguageModel
            {
                DisplayName = "ਪੰਜਾਬੀ",
                ShortName = "pa"
            });
            languagePicker.ItemsSource = LanguagePicker;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
