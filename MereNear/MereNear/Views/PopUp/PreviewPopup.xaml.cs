using MereNear.Model;
using MereNear.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MereNear.Views.PopUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreviewPopup : ContentView
	{
		public PreviewPopup ()
		{
			InitializeComponent ();
            detailsLabel.Text = AppResources.DetailsLabel;
            CategoryLabel.Text = AppResources.CategoryNameLabel;
            JobtitleLabel.Text = AppResources.jobTitleLabel;
            jobdescriptionlabel.Text = AppResources.JobDescriptionLabel;
            NeedServiceLabel.Text = AppResources.NeedServiceLabel;
            PhotosLabel.Text = AppResources.PhotosLabel;
            submitbutton.Text = AppResources.SubmitButton;


            MessagingCenter.Subscribe<PostJobModel>(this, "PreviewData", (sender) =>
            {
                description.Text = sender.Description;
                jobTitle.Text = sender.CategoryWork;
                needService.Text = sender.Date;
                //address.Text = sender.Address;
            });
		}
	}
}