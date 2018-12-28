﻿using MereNear.Interface;
using MereNear.Resources;
using MereNear.Views.Common;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class JobOptionPage : ContentPage
    {
        public JobOptionPage()
        {
            InitializeComponent();
            PostJobLabel.Text = AppResources.PostJob;
            LookingforJobLabel.Text = AppResources.LookingJob;
        }
        int count = 0;
        protected override bool OnBackButtonPressed()
        {
            if (count == 0)
            {
                DependencyService.Get<ToastMessage>().Show("Press back again to EXIT app");
                count = 1;
                return true;
            }
            else if (count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PickLocationMapPage());
        }

        private void LookingForJobTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChooseCategoryPage());
        }
    }
}
