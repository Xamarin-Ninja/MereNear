using System;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class SettingsPage : ContentPage
    {
        private double StepValue;
        public SettingsPage()
        {
            StepValue = 1.0;
            InitializeComponent();
        }

        private void Distance_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);
            DistanceValue.Text = newStep.ToString()+ " km";
        }
    }
}
