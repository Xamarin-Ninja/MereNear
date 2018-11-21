using MereNear.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class PostDescriptionPageViewModel : BindableBase, INavigationAware
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private string _immediatelyRadioButtonImage = "checked_circle";
        private string _scheduleRadioButtonImage = "unchecked_circle";
        private bool _isScheduleSelected = false;

        private string _description;
        private PostJobModel _jobModel = new PostJobModel();
        private DateTime _jobDate;
        private DateTime _jobTime;
        private string _categoryName;
        private string _locationAddress;

        private bool _isPreviewVisible = false;
        #endregion

        #region Public Variables
        public string LocationAddress
        {
            get { return _locationAddress; }
            set { SetProperty(ref _locationAddress, value); }
        }

        public Position LocationAddressPosition { get; set; }

        public string CategoryName
        {
            get { return _categoryName; }
            set { SetProperty(ref _categoryName, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        public PostJobModel JobModel
        {
            get { return _jobModel; }
            set { SetProperty(ref _jobModel, value); }
        }
        public DateTime JobDate
        {
            get { return _jobDate; }
            set { SetProperty(ref _jobDate, value); }
        }
        public DateTime JobTime
        {
            get { return _jobTime; }
            set { SetProperty(ref _jobTime, value); }
        }
        public bool IsPreviewVisible
        {
            get { return _isPreviewVisible; }
            set { SetProperty(ref _isPreviewVisible, value); }
        }


        public string ImmediatelyRadioButtonImage
        {
            get { return _immediatelyRadioButtonImage; }
            set { SetProperty(ref _immediatelyRadioButtonImage, value); }
        }

        public string ScheduleRadioButtonImage
        {
            get { return _scheduleRadioButtonImage; }
            set { SetProperty(ref _scheduleRadioButtonImage, value); }
        }

        public bool IsScheduleSelected
        {
            get { return _isScheduleSelected; }
            set { SetProperty(ref _isScheduleSelected, value); }
        }

        #endregion

        #region Command
        public ICommand ImmediatelySelected
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    clearcheck();
                    ImmediatelyRadioButtonImage = "checked_circle";
                    IsScheduleSelected = false;
                });
            }
        }

        public ICommand ScheduleSelected
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    clearcheck();
                    ScheduleRadioButtonImage = "checked_circle";
                    IsScheduleSelected = true;
                });
            }
        }
        public ICommand PopupCloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsPreviewVisible = false;
                });
            }
        }

        public ICommand SubmitPostCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    var param = new NavigationParameters();
                    param.Add("PostJobData", JobModel);
                    await _navigationService.NavigateAsync("/NavigationPage/MyPosts", param);
                });
            }
        }
        public ICommand PreviewClicked
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    JobModel.Address = LocationAddress;
                    JobModel.CategoryName = CategoryName;
                    JobModel.Description = Description;
                    if (IsScheduleSelected)
                    {
                        JobModel.Date = JobDate.ToString("dd/MM/yyyy");
                        JobModel.Time = JobTime.ToString("HH:mm");
                    }
                    else
                    {
                        JobModel.Date = DateTime.Now.Date.ToString("dd/MM/yyyy");
                       // JobModel.Time = DateTime.Now.TimeOfDay.ToString("HH:mm");
                    }

                    MessagingCenter.Send(JobModel, "PreviewData");

                    IsPreviewVisible = true;
                    //bool item = await App.Current.MainPage.DisplayAlert("Post Job", "Sure To Post a Job", "Post", "Cancel");
                    //if (item)
                    //{
                    //    var param = new NavigationParameters();
                    //    param.Add("PostJobData", JobModel);
                    //    await _navigationService.NavigateAsync("/NavigationPage/MyPosts",param);
                    //}
                    //else
                    //{
                    //    await _navigationService.GoBackToRootAsync();
                    //}
                });
            }
        }
        #endregion

        #region Constructor

        public PostDescriptionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
       
        #endregion

        #region Private Method
        private void clearcheck()
        {
            ImmediatelyRadioButtonImage = "unchecked_circle.png";
            ScheduleRadioButtonImage = "unchecked_circle.png";
        }
        #endregion

        #region Navigation Parameters
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Address"))
            {
                if (parameters.ContainsKey("Categoryname"))
                {
                    if (parameters.ContainsKey("AddressPosition"))
                    {
                        LocationAddress = (string)parameters["Address"];
                        CategoryName = (string)parameters["Categoryname"];
                        LocationAddressPosition = (Position)parameters["AddressPosition"];
                    }
                }
            }
        }
        #endregion
    }
}
