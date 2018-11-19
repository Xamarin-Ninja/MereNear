using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class MyJobsViewModel : BindableBase
	{
        private ObservableCollection<MyJobsModel> _myjobItems = new ObservableCollection<MyJobsModel>();
        private MyJobsModel _selectedJobs;



        public ObservableCollection<MyJobsModel> MyjobItems
        {
            get { return _myjobItems; }
            set { SetProperty(ref _myjobItems, value); }
        }
        public MyJobsModel SelectedJobs
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


        public MyJobsViewModel()
        {
            MyjobItems.Add(new MyJobsModel
            {
                WorkerJobType = "Electrician",
                WorkerJobDate = "01/10/2018",
                WorkerJobStatus = "Completed",
                WorkerJobAddress = "Mohali",
                JobStatusColor = Color.Green
            });
            MyjobItems.Add(new MyJobsModel
            {
                WorkerJobType = "Plumber",
                WorkerJobDate = "01/10/2018",
                WorkerJobStatus = "In-Progress",
                WorkerJobAddress = "Mohali",
                JobStatusColor = Color.OrangeRed
            });
            MyjobItems.Add(new MyJobsModel
            {
                WorkerJobType = "Car Wash",
                WorkerJobDate = "01/10/2018",
                WorkerJobStatus = "Cancelled",
                WorkerJobAddress = "Mohali",
                JobStatusColor = Color.Red
            });
            MyjobItems.Add(new MyJobsModel
            {
                WorkerJobType = "Repair",
                WorkerJobDate = "01/10/2018",
                WorkerJobStatus = "Completed",
                WorkerJobAddress = "Mohali",
                JobStatusColor = Color.Green
            });
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
