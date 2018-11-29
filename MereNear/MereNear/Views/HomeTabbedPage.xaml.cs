﻿using MereNear.Interface;
using System;
using Xamarin.Forms;

namespace MereNear.Views
{
    public partial class HomeTabbedPage : TabbedPage
    {
        
        public HomeTabbedPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<string>(this, "ChangeCurrentPage", (sender) =>
            {
                if (sender.Equals("HomePage"))
                {
                    CurrentPage = Children[0];
                    this.Title = CurrentPage.Title;
                }
                else if (sender.Equals("MyJobs"))
                {
                    CurrentPage = Children[1];
                    this.Title = this.CurrentPage.Title;
                }
                //else if (sender.Equals("PurchaseTabPage"))
                //{
                //    CurrentPage = Children[1];
                //    this.Title = this.CurrentPage.Title;
                //}
                //else if (sender.Equals("StoreTabPage"))
                //{
                //    CurrentPage = Children[0];
                //    this.Title = this.CurrentPage.Title;
                //}
                else
                {

                }

            });
        }
        int count = 0;
        protected override bool OnBackButtonPressed()
        {
            if(count == 0)
            {
                DependencyService.Get<ToastMessage>().Show("Press back again to EXIT app");
                count = 1;
                return true;
            }
            else if(count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
