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
        private PostJobModel _selectedJobs;
        public PostJobModel myJobDetail = new PostJobModel();



        public ObservableCollection<PostJobModel> MyjobItems
        {
            get { return _myjobItems; }
            set { SetProperty(ref _myjobItems, value); }
        }
        public PostJobModel SelectedJobs
        {
            get { return _selectedJobs; }
            set
            {
                SetProperty(ref _selectedJobs, value);
                if(_selectedJobs == null)
                {
                    return;
                }
                else
                {
                    
                }
            }
        }


        public MyJobsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //MyjobItems.Add(myJobDetail);
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
            if (parameters.ContainsKey("LookingJobFlow"))
            {
                myJobDetail = (PostJobModel)parameters["LookingJobFlow"];
                MyjobItems.Add(myJobDetail);
            }
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
