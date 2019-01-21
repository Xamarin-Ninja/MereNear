using MereNear.Interface;
using MereNear.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MereNear.Views
{
    public partial class SettingsPage : ContentPage
    {
        private double StepValue;
        public SettingsPage()
        {
            StepValue = 1.0;
            InitializeComponent();
            Settingstitle.TitleText = AppResources.SettingsMenu;
            AccountHeader.Text = AppResources.AccountHeading;
            ChangeLanguageLabel.Text = AppResources.ChangeLanguageLabel;
            NotificationHeader.Text = AppResources.NotificationHeading;
            NotificationLabel.Text = AppResources.NotificationLabel;
            DistanceHeaderLabel.Text = AppResources.DistanceHeader;
            AppNotificationLabel.Text = AppResources.AppNotificationLabel;
            MoreHeader.Text = AppResources.MoreHeader;
            ChangeMobileLabel.Text = AppResources.ChangeMobileNumberLabel;
        }

        private void Distance_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);
            DistanceValue.Text = newStep.ToString()+ " km";
        }

        protected override bool OnBackButtonPressed()
        {
            var result = DependencyService.Get<ToastMessage>().Show("Press back to close application.");
            if (!result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeAreaInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            this.Padding = safeAreaInset;
        }
    }
}
