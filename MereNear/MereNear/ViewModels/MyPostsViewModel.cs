using Acr.UserDialogs;
using MereNear.Helpers;
using MereNear.Model;
using MereNear.ViewModels.Common;
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
	public class MyPostsViewModel : BaseViewModel, INavigationAware
	{
        #region Private Variable
        private readonly INavigationService _navigationService;
        private ObservableCollection<PostJobModel> _myPostItems = new ObservableCollection<PostJobModel>();
        private PostJobModel _selectedPost;
        #endregion

        #region Public Variable
        //public PostJobModel jobModel = new PostJobModel();
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
            var IsPostjobAvail = postJobDBService.IsPostJobDbPresentInDB();
            if (IsPostjobAvail)
            {
                var jobdata = postJobDBService.ReadAllItems();
                foreach(var item in jobdata)
                {
                    if (item.Status == "Active")
                    {
                        item.StatusColor = Color.FromHex(ChangeColor.GreenColor);
                    }
                    else if (item.Status == "Completed")
                    {
                        item.StatusColor = Color.FromHex(ChangeColor.OrangeColor);
                    }
                    else if (item.Status == "Disabled")
                    {
                        item.StatusColor = Color.FromHex(ChangeColor.RedColor);
                    }

                    if (item.Time == "Now")
                    {
                        item.TimeColor = Color.FromHex(ChangeColor.BlueColor);
                        item.IsDateVisible = false;
                    }
                    else
                    {
                        item.TimeColor = Color.FromHex(ChangeColor.GrayColor);
                        item.IsDateVisible = true;
                    }
                    item.WhenLabel = AppResources.When + ":";
                    item.PostedOnLabel = AppResources.PostedOn + " :";
                    GetData(item);
                }
            }
            else
            {
                UserDialogs.Instance.Alert("Currently There is no post");
            }
        }
        #endregion

        #region Private Methods
        private void GetData(PostJobModel data)
        {
            MyPostItems.Add(data);
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
            
        }
        #endregion
    }
}