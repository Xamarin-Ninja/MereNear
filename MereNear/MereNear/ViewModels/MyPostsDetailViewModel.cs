using MereNear.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion

        #region Constructor
        public MyPostsDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
            if (parameters.ContainsKey("MyPostDetailed"))
            {
                PostsModelDetail = (PostJobModel)parameters["MyPostDetailed"];
                //CustomHeaderTitle = PostsModelDetail.WorkerJobType;
                //JobStatus = PostsModelDetail.WorkerJobStatus;
                //JobStatusColor = PostsModelDetail.JobStatusColor;
            }
        }
        #endregion
    }
}
