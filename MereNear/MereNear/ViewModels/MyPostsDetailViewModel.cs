using MereNear.Model;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class MyPostsDetailViewModel : BindableBase, INavigationAware
	{
        #region Private Variable
        private readonly INavigationService _navigationService;
        private PostJobModel _postsModelDetail = new PostJobModel();
        private string _customHeaderTitle;
        private string _jobStatus;
        private Color _jobStatusColor;
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

        public string JobStatus
        {
            get { return _jobStatus; }
            set { SetProperty(ref _jobStatus, value); }
        }

        public Color JobStatusColor
        {
            get { return _jobStatusColor; }
            set { SetProperty(ref _jobStatusColor, value); }
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
                    await _navigationService.NavigateAsync(nameof(MyJobs));
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
                IsApplyButtonVisible = false;
                //CustomHeaderTitle = PostsModelDetail.WorkerJobType;
                //JobStatus = PostsModelDetail.WorkerJobStatus;
                //JobStatusColor = PostsModelDetail.JobStatusColor;
            }
            if (parameters.ContainsKey("AllJobsPageData"))
            {
                PostsModelDetail = (PostJobModel)parameters["MyPostsData"];
                IsApplyButtonVisible = true;
                //CustomHeaderTitle = PostsModelDetail.WorkerJobType;
                //JobStatus = PostsModelDetail.WorkerJobStatus;
                //JobStatusColor = PostsModelDetail.JobStatusColor;
            }
        }
        #endregion
    }
}
