using Acr.UserDialogs;
using MereNear.Model;
using MereNear.ViewModels.Common;
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
	public class MyJobsViewModel : BaseViewModel, INavigationAware
	{
        private readonly INavigationService _navigationService;
        private ObservableCollection<PostJobModel> _myjobItems = new ObservableCollection<PostJobModel>();
        private PostJobModel _selectedMyJob;
        public PostJobModel myJobDetail = new PostJobModel();



        public ObservableCollection<PostJobModel> MyjobItems
        {
            get { return _myjobItems; }
            set { SetProperty(ref _myjobItems, value); }
        }
        public PostJobModel SelectedMyJob
        {
            get { return _selectedMyJob; }
            set
            {
                SetProperty(ref _selectedMyJob, value);
                if(_selectedMyJob == null)
                {
                    return;
                }
                else
                {
                    NavigateToDetailedPage(SelectedMyJob);
                }
            }
        }

        
        private async void NavigateToDetailedPage(PostJobModel selectedMyJob)
        {
            var param = new NavigationParameters();
            param.Add("MyJobData", selectedMyJob);
            await _navigationService.NavigateAsync(nameof(MyPostsDetail), param);
        }

        public MyJobsViewModel(INavigationService navigationService)
        {
            try
            {
                _navigationService = navigationService;
                var IsJobModelDBPresent = postJobDBService.IsPostJobDbPresentInDB();
                if (IsJobModelDBPresent)
                {
                    var AppliedJobData = postJobDBService.ReadAllItems().Where(x => x.IsApplied);
                    if (AppliedJobData!=null)
                    {
                        foreach (var item in AppliedJobData)
                        {
                            MyjobItems.Add(item);
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Currently There is no job applied");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public ICommand HeaderLeftIconCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessagingCenter.Send("HamburgurClick", "OpenMasterDetailPage");
                });
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            //if (parameters.ContainsKey("LookingJobFlow"))
            //{
            //    myJobDetail = (PostJobModel)parameters["LookingJobFlow"];
            //    MyjobItems.Add(myJobDetail);
            //}
        }
    }


    public class MyJobsModel
    {
        public string WorkerJobType { get; set; }
        public string WorkerJobStatus { get; set; }
        public string WorkerJobAddress { get; set; }
        public string WorkerJobDate { get; set; }
        public Color JobStatusColor { get; set; }
    }
}
