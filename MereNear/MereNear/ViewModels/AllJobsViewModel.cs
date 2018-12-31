using MereNear.Model;
using MereNear.ViewModels.Common;
using MereNear.Resources;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class AllJobsViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;

        private ObservableCollection<PostJobModel> _allJobItems = new ObservableCollection<PostJobModel>();
        private PostJobModel _selectedAllJobs;
        #endregion

        #region Public Variables
        public PostJobModel postJobData = new PostJobModel();

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

        #region Commands
        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.GoBackAsync();
                });
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
            if (Application.Current.Properties.ContainsKey("PostJobModel"))
            {
                postJobData = (PostJobModel)Application.Current.Properties["PostJobModel"];
                AllJobItems.Add(new PostJobModel
                {
                    Image = postJobData.Image,
                    Description = postJobData.Description,
                    CategoryWork = postJobData.CategoryWork,
                    AddressPosition = postJobData.AddressPosition,
                    Address = postJobData.Address,
                    CategoryName = postJobData.CategoryName,
                    Date = postJobData.Date,
                    Time = postJobData.Time,
                    TimeColor = postJobData.TimeColor,
                    Name = "Pardeep",
                    Status = AppResources.JobStatusActive,
                    StatusColor = Xamarin.Forms.Color.LightGreen,
                    Distance = postJobData.Distance
                });
            }
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
