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
using MereNear.Helpers;
using Acr.UserDialogs;

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
            var IsPostjobAvail = postJobDBService.IsPostJobDbPresentInDB();
            if (IsPostjobAvail)
            {
                var jobdata = postJobDBService.ReadAllItems().Where(x => !x.IsApplied);
                foreach (var item in jobdata)
                {
                    if (item.Status == "Active")
                    {
                        item.StatusColor = Color.FromHex(ChangeColor.GreenColor);
                    }
                    //else if (item.Status == "Completed")
                    //{
                    //    item.StatusColor = Color.FromHex(ChangeColor.OrangeColor);
                    //}
                    //else if (item.Status == "Disabled")
                    //{
                    //    item.StatusColor = Color.FromHex(ChangeColor.RedColor);
                    //}

                    if (item.Time == "Now")
                    {
                        item.TimeColor = Color.FromHex(ChangeColor.BlueColor);
                        item.IsDateVisible = false;
                    }
                    else
                    {
                        item.TimeColor = Color.FromHex(ChangeColor.GrayColor);
                        item.IsDateVisible = true;
                    }
                    item.WhenLabel = AppResources.When;
                    item.PostedOnLabel = AppResources.PostedOn + " :-";
                    GetAllJobData(item);
                }
            }
            else
            {
                UserDialogs.Instance.Alert("Currently There is no job");
            }
        }
        #endregion

        #region Private Methods
        private void GetAllJobData(PostJobModel postJobData)
        {
            postJobData.Name = "Pardeep";
            AllJobItems.Add(postJobData);
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
