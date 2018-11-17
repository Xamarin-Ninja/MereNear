using Acr.UserDialogs;
using MereNear.Model;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class MyPostsViewModel : BindableBase, INavigationAware
	{
        #region Private Variable
        private readonly INavigationService _navigationService;
        private ObservableCollection<PostJobModel> _myPostItems = new ObservableCollection<PostJobModel>();
        private PostJobModel _selectedPost;
        #endregion

        #region Public Variable
        public PostJobModel jobModel = new PostJobModel();
        public ObservableCollection<PostJobModel> MyPostItems
        {
            get { return _myPostItems; }
            set { SetProperty(ref _myPostItems, value); }
        }

        public PostJobModel SelectedPost
        {
            get { return _selectedPost; }
            set
            {
                SetProperty(ref _selectedPost, value);
                if(_selectedPost == null)
                {
                    return;
                }
                else
                {
                    try
                    {
                        GetNavigation(SelectedPost);
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                }
            }
        }
        #endregion

        #region Constructor
        public MyPostsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //GetData();
        }
        #endregion

        #region Private Methods
        private void GetData()
        {
            MyPostItems.Add(new PostJobModel
            {
                CategoryName = jobModel.CategoryName,
                Address = jobModel.Address,
                Date = jobModel.Date,
                Time = jobModel.Time,
                Description = jobModel.Description,
                Name = "Pardeep",
                Image = "logo.png"
            });
            MyPostItems.Add(new PostJobModel
            {
                CategoryName = "Electrician",
                Address = "Mohali",
                Date = jobModel.Date,
                Time = jobModel.Time,
                Description = jobModel.Description,
                Name = "Pardeep",
                Image = "logo.png"
            });
            MyPostItems.Add(new PostJobModel
            {
                CategoryName = "Car Repair",
                Address = "Phase 5, Mohali",
                Date = jobModel.Date,
                Time = jobModel.Time,
                Description = jobModel.Description,
                Name = "Pardeep",
                Image = "logo.png"
            });
        }
        #endregion

        #region Public methods
        public async void GetNavigation(PostJobModel data)
        {
            var param = new NavigationParameters();
            param.Add("MyPostDetailed", data);
            await _navigationService.NavigateAsync(nameof(MyPostsDetail), param);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("PostJobData"))
            {
                jobModel = (PostJobModel)parameters["PostJobData"];
                GetData();
            }
        }
        #endregion
    }
}