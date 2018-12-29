using Acr.UserDialogs;
using MereNear.Helpers;
using MereNear.Model;
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

        #region Command
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
            MyPostItems.Add(jobModel);
        }
        #endregion

        #region Public methods
        public async void GetNavigation(PostJobModel data)
        {
            var param = new NavigationParameters();
            param.Add("MyPostsData", data);
            await _navigationService.NavigateAsync(nameof(MyPostsDetail), param);
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
            if (parameters.ContainsKey("PostJobData"))
            {
                jobModel = (PostJobModel)parameters["PostJobData"];
                if(jobModel.Status == "Active")
                {
                    jobModel.StatusColor = Color.FromHex(ChangeColor.GreenColor);
                }
                else if(jobModel.Status == "Completed")
                {
                    jobModel.StatusColor = Color.FromHex(ChangeColor.OrangeColor);
                }
                else if(jobModel.Status == "Disabled")
                {
                    jobModel.StatusColor = Color.FromHex(ChangeColor.RedColor);
                }

                if(jobModel.Time == "Now")
                {
                    jobModel.TimeColor = Color.FromHex(ChangeColor.BlueColor);
                    jobModel.IsDateVisible = false;
                }
                else
                {
                    jobModel.TimeColor = Color.FromHex(ChangeColor.GrayColor);
                    jobModel.IsDateVisible = true;
                }
                jobModel.WhenLabel = AppResources.When;
                jobModel.PostedOnLabel = AppResources.PostedOn + " :-";
                GetData();
            }
        }
        #endregion
    }
}