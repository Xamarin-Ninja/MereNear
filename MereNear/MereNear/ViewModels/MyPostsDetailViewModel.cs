using MereNear.Model;
using MereNear.Resources;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class MyPostsDetailViewModel : BindableBase, INavigationAware
	{
        #region Private Variable
        private readonly INavigationService _navigationService;
        private PostJobModel _postsModelDetail = new PostJobModel();
        private string _customHeaderTitle;
        private string _status;
        private Color _statusColor;

        private bool _isDistanceVisible;

        private string _time;
        private Color _timeColor;

        private string _description;
        private string _categoryWork;

        private string _buttonTextChange;
        private string _address;
        private string _distance;

        private bool _isApplyButtonVisible;
        #endregion

        #region Public Variabel
        public PostJobModel PostsModelDetail
        {
            get { return _postsModelDetail; }
            set { SetProperty(ref _postsModelDetail, value); }
        }

        public string CustomHeaderTitle
        {
            get { return _customHeaderTitle; }
            set { SetProperty(ref _customHeaderTitle, value); }
        }

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public Color StatusColor
        {
            get { return _statusColor; }
            set { SetProperty(ref _statusColor, value); }
        }

        public bool IsDistanceVisible
        {
            get { return _isDistanceVisible; }
            set { SetProperty(ref _isDistanceVisible, value); }
        }

        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        public Color TimeColor
        {
            get { return _timeColor; }
            set { SetProperty(ref _timeColor, value); }
        }

        public string CategoryWork
        {
            get { return _categoryWork; }
            set { SetProperty(ref _categoryWork, value); }
        }

        public string Description
{
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string ButtonTextChange
        {
            get { return _buttonTextChange; }
            set { SetProperty(ref _buttonTextChange, value); }
        }

        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public string Distance
        {
            get { return _distance; }
            set { SetProperty(ref _distance, value); }
        }

        public bool IsApplyButtonVisible
        {
            get { return _isApplyButtonVisible; }
            set { SetProperty(ref _isApplyButtonVisible, value); }
        }
        #endregion

        #region Constructor
        public MyPostsDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Command
        public ICommand ApplyButton
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var param = new NavigationParameters();
                    param.Add("LookingJobFlow", PostsModelDetail);
                    //await _navigationService.NavigateAsync(nameof(MyJobs));
                    await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute),param);
                    MessagingCenter.Send("MyJobs", "ChangeCurrentPage");
                });
            }
        }

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

        #region Navigation Parameters
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("MyPostsData"))
            {
                PostsModelDetail = (PostJobModel)parameters["MyPostsData"];
                GetDetail();
                IsDistanceVisible = false;
                IsApplyButtonVisible = false;
                var position = PostsModelDetail.AddressPosition;
                MessagingCenter.Send("Location", "PostJobLocation", position);
            }
            if (parameters.ContainsKey("AllJobsPageData"))
            {
                PostsModelDetail = (PostJobModel)parameters["AllJobsPageData"];
                GetDetail();
                IsDistanceVisible = true;
                ButtonTextChange = AppResources.ApplyButton;
                IsApplyButtonVisible = true;
                var position = PostsModelDetail.AddressPosition;
                MessagingCenter.Send("Location", "PostJobLocation", position);
            }
        }
        #endregion

        #region Private Method
        private void GetDetail()
        {
            CustomHeaderTitle = PostsModelDetail.CategoryName;
            Status = PostsModelDetail.Status;
            StatusColor = PostsModelDetail.StatusColor;
            Address = PostsModelDetail.Address;
            Time = PostsModelDetail.Time;
            TimeColor = PostsModelDetail.TimeColor;
            CategoryWork = PostsModelDetail.CategoryWork;
            Description = PostsModelDetail.Description;
            Distance = PostsModelDetail.Distance;
        }
        #endregion
    }
}
