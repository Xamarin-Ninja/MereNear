using MereNear.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

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
    }
}
