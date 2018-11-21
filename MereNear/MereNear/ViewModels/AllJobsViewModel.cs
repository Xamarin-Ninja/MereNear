using MereNear.Model;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class AllJobsViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private ObservableCollection<PostJobModel> _allJobItems = new ObservableCollection<PostJobModel>();
        private PostJobModel _selectedAllJobs;
        #endregion

        #region Public Variables

        public ObservableCollection<PostJobModel> AllJobItems
        {
            get { return _allJobItems; }
            set { SetProperty(ref _allJobItems, value); }
        }

        public PostJobModel SelectedAllJobs
        {
            get { return _selectedAllJobs; }
            set
            {
                SetProperty(ref _selectedAllJobs, value);
                if(_selectedAllJobs == null)
                {
                    return;
                }
                else
                {
                    NavigateToDetailPage(SelectedAllJobs);
                }
            }
        }
        #endregion

        #region Constructor
        public AllJobsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetAllJobData();
        }
        #endregion

        #region Private Methods
        private void GetAllJobData()
        {
            AllJobItems.Add(new PostJobModel
            {
                Address = "QServices Inc, Office no: 52, D-185, 2nd Floor, Phase 8b, SAS Nagar, Mohali",
                CategoryName = "Plumber",
                Date = "20/11/2018",
                Time = "11:40 AM",
                Name = "Pardeep",
                Status = "Active",
                StatusColor = Xamarin.Forms.Color.LightGreen,
                Distance = "20"
            });

            AllJobItems.Add(new PostJobModel
            {
                Address = "QServices Inc, Office no: 52, D-185, 2nd Floor, Phase 8b, SAS Nagar, Mohali",
                CategoryName = "Electrician",
                Date = "20/11/2018",
                Time = "Now",
                Name = "Pardeep",
                Status = "Active",
                StatusColor = Xamarin.Forms.Color.LightGreen,
                Distance = "5"
            });

            AllJobItems.Add(new PostJobModel
            {
                Address = "QServices Inc, Office no: 52, D-185, 2nd Floor, Phase 8b, SAS Nagar, Mohali",
                CategoryName = "Cleaning",
                Date = "20/11/2018",
                Time = "Now",
                Name = "Pardeep",
                Status = "Completed",
                StatusColor = Xamarin.Forms.Color.OrangeRed,
                Distance = "12"
            });

            AllJobItems.Add(new PostJobModel
            {
                Address = "QServices Inc, Office no: 52, D-185, 2nd Floor, Phase 8b, SAS Nagar, Mohali",
                CategoryName = "Ac Repairs",
                Date = "20/11/2018",
                Time = "06:00 PM",
                Name = "Pardeep",
                Status = "Disabled",
                StatusColor = Xamarin.Forms.Color.DarkRed,
                Distance = "10"
            });

            AllJobItems.Add(new PostJobModel
            {
                Address = "QServices Inc, Office no: 52, D-185, 2nd Floor, Phase 8b, SAS Nagar, Mohali",
                CategoryName = "Car Wash",
                Date = "20/11/2018",
                Time = "06:45 AM",
                Name = "Pardeep",
                Status = "Completed",
                StatusColor = Xamarin.Forms.Color.OrangeRed,
                Distance = "30"
            });
        }

        private async void NavigateToDetailPage(PostJobModel selectedjob)
        {
            var param = new NavigationParameters();
            param.Add("AllJobsPageData", selectedjob);
            await _navigationService.NavigateAsync(nameof(MyPostsDetail),param);
        }
        #endregion
    }
}
