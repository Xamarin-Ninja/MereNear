using MereNear.Model;
using MereNear.Resources;
using MereNear.Services.ApiService.Common;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class Login_Page2 : ContentPage
    {
        public IWebApiRestClient _webApiRestClient;
        public Login_Page2()
        {
            InitializeComponent();
            _webApiRestClient = new WebApiRestClient();
            MobileEntryTitle.Text = AppResources.MobileEntryTitle;
            MobileEntry.Placeholder = AppResources.LoginEntryPlaceHolder;
            NextButton.Text ="";
            NextButton.IsEnabled = false;
            //getCountryCode();
            
            countryCodeList.ItemSelected += CountryCodeList_ItemSelected;
            MessagingCenter.Subscribe<string>(this, "EntryFocus", (sender) =>
            {
                MobileEntry.Focus();
                
            });
        }

        private void CountryCodeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (CountryCodeModel)e.SelectedItem;
                CountryCodeListPopup.IsVisible = false;
                CountryCodePicker.Text = item.telpref;
                countryCodeList.SelectedItem = null;
                MainLayout.BackgroundColor = Color.White;
            }
            catch (Exception ex)
            {

            }
        }

        private async void getCountryCode()
        {
            try
            {
                var result = await _webApiRestClient.GetAsync<CountryStatusModel>("getCountryCode");
                if (result!=null)
                {
                    countryCodeList.ItemsSource = result.data; 
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "ok");
            }

        }

        private void BackIcon_Tapped(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception)
            {

            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(MobileEntry.Text != null)
            {
                if (MobileEntry.Text.Length == 10)
                {
                    NextButton.IsEnabled = true;
                    NextButton.Text = AppResources.NextButton;
                }
                else
                {
                    NextButton.IsEnabled = false;
                }
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }

        private void CountryCodePicker_Tapped(object sender, EventArgs e)
        {
            MainLayout.BackgroundColor = Color.LightGray;
            CountryCodeListPopup.IsVisible = true;
        }
    }
}
