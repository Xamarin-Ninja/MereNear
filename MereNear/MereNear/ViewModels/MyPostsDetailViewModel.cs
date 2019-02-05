using MereNear.Model;
using MereNear.ViewModels.Common;
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
using LiteDB;

namespace MereNear.ViewModels
{
	public class MyPostsDetailViewModel : BaseViewModel, INavigationAware
	{
        #region Private Variable
        private readonly INavigationService _navigationService;
        private PostJobModel _postsModelDetail = new PostJobModel();
        
        private bool _isDistanceVisible;
        private bool _isServicePhotoAvailable;
        private bool _isApplyButtonVisible;
        private bool _isDropLocationVisible;

        private string _buttonTextChange;
        #endregion

        #region Public Variabel
        public PostJobModel PostsModelDetail
        {
            get { return _postsModelDetail; }
            set { SetProperty(ref _postsModelDetail, value); }
        }

        public bool IsDistanceVisible
        {
            get { return _isDistanceVisible; }
            set { SetProperty(ref _isDistanceVisible, value); }
        }

        public bool IsDropLocationVisible
        {
            get { return _isDropLocationVisible; }
            set { SetProperty(ref _isDropLocationVisible, value); }
        }


        public bool IsServicePhotoAvailable
        {
            get { return _isServicePhotoAvailable; }
            set { SetProperty(ref _isServicePhotoAvailable, value); }
        }

        public string ButtonTextChange
        {
            get { return _buttonTextChange; }
            set { SetProperty(ref _buttonTextChange, value); }
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
                    PostsModelDetail.Status = AppResources.JobStatusProgress;
                    PostsModelDetail.IsApplied = true;
                    ButtonTextChange = "Already Applied";
                    BsonValue id = PostsModelDetail.ID;
                    postJobDBService.UpdatePostJobModelInDb(id, PostsModelDetail);
                    //param.Add("LookingJobFlow", PostsModelDetail);
                    //await _navigationService.NavigateAsync(nameof(MyJobs));
                    await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
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
                if (string.IsNullOrEmpty(PostsModelDetail.DropAddress) && string.IsNullOrWhiteSpace(PostsModelDetail.DropAddress))
                {
                    IsDropLocationVisible = false;
                }
                else
                {
                    IsDropLocationVisible = true;
                }
                if(string.IsNullOrWhiteSpace(PostsModelDetail.ServiceImage1) && string.IsNullOrEmpty(PostsModelDetail.ServiceImage1) && string.IsNullOrWhiteSpace(PostsModelDetail.ServiceImage2) && string.IsNullOrEmpty(PostsModelDetail.ServiceImage2))
                {
                    IsServicePhotoAvailable = false;
                }
                else
                {
                    IsServicePhotoAvailable = true;
                }
                //GetDetail();
                IsDistanceVisible = false;
                IsApplyButtonVisible = false;
                var position = PostsModelDetail.AddressPosition;
                MessagingCenter.Send("Location", "PostJobLocation", position);
            }
            if (parameters.ContainsKey("AllJobsPageData"))
            {
                PostsModelDetail = (PostJobModel)parameters["AllJobsPageData"];
                //GetDetail();
                IsDistanceVisible = true;
                ButtonTextChange = AppResources.ApplyButton;
                IsApplyButtonVisible = true;
                var position = PostsModelDetail.AddressPosition;
                MessagingCenter.Send("Location", "PostJobLocation", position);
            }
            if (parameters.ContainsKey("MyJobData"))
            {
                PostsModelDetail = (PostJobModel)parameters["MyJobData"];
                if (string.IsNullOrEmpty(PostsModelDetail.DropAddress) && string.IsNullOrWhiteSpace(PostsModelDetail.DropAddress))
                {
                    IsDropLocationVisible = false;
                }
                else
                {
                    IsDropLocationVisible = true;
                }
                if (string.IsNullOrWhiteSpace(PostsModelDetail.ServiceImage1) && string.IsNullOrEmpty(PostsModelDetail.ServiceImage1) && string.IsNullOrWhiteSpace(PostsModelDetail.ServiceImage2) && string.IsNullOrEmpty(PostsModelDetail.ServiceImage2))
                {
                    IsServicePhotoAvailable = false;
                }
                else
                {
                    IsServicePhotoAvailable = true;
                }
                //GetDetail();
                IsDistanceVisible = false;
                IsApplyButtonVisible = false;
                var position = PostsModelDetail.AddressPosition;
                MessagingCenter.Send("Location", "PostJobLocation", position);
            }
        }
        #endregion

        #region Private Method
        //private void GetDetail()
        //{
        //    CustomHeaderTitle = PostsModelDetail.CategoryName;
        //    Status = PostsModelDetail.Status;
        //    StatusColor = PostsModelDetail.StatusColor;
        //    Address = PostsModelDetail.Address;
        //    Time = PostsModelDetail.Time;
        //    TimeColor = PostsModelDetail.TimeColor;
        //    CategoryWork = PostsModelDetail.CategoryWork;
        //    Description = PostsModelDetail.Description;
        //    Distance = PostsModelDetail.Distance;
        //}
        #endregion
    }
}
