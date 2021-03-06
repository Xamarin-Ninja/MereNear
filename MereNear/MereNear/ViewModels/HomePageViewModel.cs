﻿using Acr.UserDialogs;
using MereNear.Helpers;
using MereNear.Model;
using MereNear.Resources;
using MereNear.Services.ApiService.Common;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class HomePageViewModel : BaseViewModel
    {
        #region Private Variables
        private readonly INavigationService _navigationService;
        protected readonly IWebApiRestClient _webApiRestClient;

        private ObservableCollection<HomePageModel> _newCategoryData = new ObservableCollection<HomePageModel>();
        private ObservableCollection<HomePageDataModel> _categoryDataList = new ObservableCollection<HomePageDataModel>();
        private int _listWidth;

        private Color _lookingJobButtonColor = Color.Transparent;
        private Color _lookingJobButtonTextColor = Color.Gray;

        private Color _postJobButtonTextColor = Color.White;
        private Color _postJobButtonColor = Color.FromHex("#3B92E7");

        private Color _myJobsBGColor = Color.Transparent;
        private Color _myPostsBGColor = Color.Transparent;
        private Color _messagesBGColor = Color.Transparent;
        private Color _notificationsBGColor = Color.Transparent;

        private Color _myJobsLabelColor = Color.Black;
        private Color _myPostsLabelColor = Color.Black;
        private Color _messagesLabelColor = Color.Black;
        private Color _notificationsLabelColor = Color.Black;

        private ImageSource _myJobsIcon = "post_job.png";   //Change icon
        private ImageSource _myPostsIcon = "my_post.png";
        private ImageSource _messagesIcon = "message.png";
        private ImageSource _notificationsIcon = "notification.png";

        private ImageSource _starRating1 = "star_2.png";
        private ImageSource _starRating2 = "star_2.png";
        private ImageSource _starRating3 = "star_2.png";
        private ImageSource _starRating4 = "star_2.png";
        private ImageSource _starRating5 = "star_2.png";

        private string _titleText;
        private string _headerLeft2ndIcon;
        
        #region HomePageView Data
        private bool _isInfoVisible = true;

        private string _workerName = "Pardeep";
        private string _workerCategoryName = "Plumber";
        private string _workerExperience = "Exp:- 10 Years";
        private string _workerDetail;
        #endregion

        #endregion

        #region Public Variables
        public int ListWidth
        {
            get { return _listWidth; }
            set { SetProperty(ref _listWidth, value); }
        }
        
        public ObservableCollection<HomePageModel> NewCategoryData
        {
            get { return _newCategoryData; }
            set { SetProperty(ref _newCategoryData, value); }
        }

        public ObservableCollection<HomePageDataModel> CategoryDataList
        {
            get { return _categoryDataList; }
            set { SetProperty(ref _categoryDataList, value); }
        }

        public Color LookingJobButtonColor
        {
            get { return _lookingJobButtonColor; }
            set { SetProperty(ref _lookingJobButtonColor, value); }
        }

        public Color LookingJobButtonTextColor
        {
            get { return _lookingJobButtonTextColor; }
            set { SetProperty(ref _lookingJobButtonTextColor, value); }
        }

        public Color PostJobButtonColor
        {
            get { return _postJobButtonColor; }
            set { SetProperty(ref _postJobButtonColor, value); }
        }

        public Color PostJobButtonTextColor
        {
            get { return _postJobButtonTextColor; }
            set { SetProperty(ref _postJobButtonTextColor, value); }
        }

        public Color MyJobsBGColor
        {
            get { return _myJobsBGColor; }
            set { SetProperty(ref _myJobsBGColor, value); }
        }

        public Color MyPostsBGColor
        {
            get { return _myPostsBGColor; }
            set { SetProperty(ref _myPostsBGColor, value); }
        }

        public Color MessagesBGColor
        {
            get { return _messagesBGColor; }
            set { SetProperty(ref _messagesBGColor, value); }
        }

        public Color NotificationsBGColor
        {
            get { return _notificationsBGColor; }
            set { SetProperty(ref _notificationsBGColor, value); }
        }

        public Color MyJobsLabelColor
        {
            get { return _myJobsLabelColor; }
            set { SetProperty(ref _myJobsLabelColor, value); }
        }

        public Color MyPostsLabelColor
        {
            get { return _myPostsLabelColor; }
            set { SetProperty(ref _myPostsLabelColor, value); }
        }

        public Color MessagesLabelColor
        {
            get { return _messagesLabelColor; }
            set { SetProperty(ref _messagesLabelColor, value); }
        }

        public Color NotificationsLabelColor
        {
            get { return _notificationsLabelColor; }
            set { SetProperty(ref _notificationsLabelColor, value); }
        }

        public ImageSource MyJobsIcon
        {
            get { return _myJobsIcon; }
            set { SetProperty(ref _myJobsIcon, value); }
        }

        public ImageSource MyPostsIcon
        {
            get { return _myPostsIcon; }
            set { SetProperty(ref _myPostsIcon, value); }
        }

        public ImageSource MessagesIcon
        {
            get { return _messagesIcon; }
            set { SetProperty(ref _messagesIcon, value); }
        }

        public ImageSource NotificationsIcon
        {
            get { return _notificationsIcon; }
            set { SetProperty(ref _notificationsIcon, value); }
        }

        public ImageSource StarRating1
        {
            get { return _starRating1; }
            set { SetProperty(ref _starRating1, value); }
        }

        public ImageSource StarRating2
        {
            get { return _starRating2; }
            set { SetProperty(ref _starRating2, value); }
        }

        public ImageSource StarRating3
        {
            get { return _starRating3; }
            set { SetProperty(ref _starRating3, value); }
        }

        public ImageSource StarRating4
        {
            get { return _starRating4; }
            set { SetProperty(ref _starRating4, value); }
        }

        public ImageSource StarRating5
        {
            get { return _starRating5; }
            set { SetProperty(ref _starRating5, value); }
        }

        public string TitleText
        {
            get { return _titleText; }
            set { SetProperty(ref _titleText, value); }
        }

        public string HeaderLeft2ndIcon
        {
            get { return _headerLeft2ndIcon; }
            set { SetProperty(ref _headerLeft2ndIcon, value); }
        }

        public bool IsInfoIconVisible
        {
            get { return _isInfoVisible; }
            set { SetProperty(ref _isInfoVisible, value); }
        }

        public string WorkerName
        {
            get { return _workerName; }
            set { SetProperty(ref _workerName, value); }
        }

        public string WorkerCategoryName
        {
            get { return _workerCategoryName; }
            set { SetProperty(ref _workerCategoryName, value); }
        }

        public string WorkerExperience
        {
            get { return _workerExperience; }
            set { SetProperty(ref _workerExperience, value); }
        }

        public string WorkerDetail
        {
            get { return _workerDetail; }
            set { SetProperty(ref _workerDetail, value); }
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

        public ICommand HomePageCategorySelectedCommand { get; set; }

        public ICommand InfoCommand { get; set; }

        //public ICommand InfoCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(async() =>
        //        {
        //            await _navigationService.NavigateAsync(nameof(HomeDetailPage));
        //        });
        //    }
        //}

        public ICommand HeaderRightIconCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {
                        await _navigationService.NavigateAsync(nameof(JobOptionPage));
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                    
                });
            }
        }
        #endregion

        #region Constructor
        public HomePageViewModel(INavigationService navigationService, IWebApiRestClient webApiRestClient)
        {
            try
            {
                _navigationService = navigationService;
                _webApiRestClient = webApiRestClient;
                HomePageCategorySelectedCommand = new Command(Categry_sel);
                InfoCommand = new Command(Info_Command);

                TitleText = AppResources.MereNear;
                GetCategoryApi();
                GetWorkerData();
                WorkerDetail = CategoryDataList.ElementAt(0).WorkerInformation;
                WorkerName = CategoryDataList.ElementAt(0).WorkerName;
                WorkerCategoryName = CategoryDataList.ElementAt(0).WorkerName;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Private/Public Methods
        private void Categry_sel(object sender)
        {
            var data = (HomePageModel)sender;
            if (Application.Current.Properties.ContainsKey("PreviousSelectedValue"))
            {
                var previousData = (HomePageModel)Application.Current.Properties["PreviousSelectedValue"];
                previousData.CategorySelected = false;
                data.CategorySelected = true;
                Application.Current.Properties["PreviousSelectedValue"] = data;
            }
            else
            {
                data.CategorySelected = true;
                Application.Current.Properties["PreviousSelectedValue"] = data;
            }
        }

        private void ClearTab()
        {
            MyJobsBGColor = Color.Transparent;
            MyPostsBGColor = Color.Transparent;
            MessagesBGColor = Color.Transparent;
            NotificationsBGColor = Color.Transparent;

            MyJobsLabelColor = Color.Black;
            MyPostsLabelColor = Color.Black;
            MessagesLabelColor = Color.Black;
            NotificationsLabelColor = Color.Black;

            MyJobsIcon = "post_job.png";
            MyPostsIcon = "my_post.png";
            MessagesIcon = "message.png"; 
             NotificationsIcon = "notification.png";

            TitleText = AppResources.MereNear;
            HeaderLeft2ndIcon = "";
        }

        private void SelectedTab()
        {
            HeaderLeft2ndIcon = "homewhite.png";
            if (Application.Current.Properties["TabClicked"].ToString() == "MyJobsTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                MyJobsBGColor = Color.FromHex("#3B92E7");
                MyJobsLabelColor = Color.White;
                MyJobsIcon = "post_job_selected.png";
                TitleText = AppResources.MyJobsTab;
                return;
            }
            if (Application.Current.Properties["TabClicked"].ToString() == "MyPostsTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                MyPostsBGColor = Color.FromHex("#3B92E7");
                MyPostsLabelColor = Color.White;
                MyPostsIcon = "my_post_select.png";
                TitleText = AppResources.MyPostsMenu;
                return;
            }
            if (Application.Current.Properties["TabClicked"].ToString() == "MessagesTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                MessagesBGColor = Color.FromHex("#3B92E7");
                MessagesLabelColor = Color.White;
                MessagesIcon = "message.png";
                TitleText = AppResources.MessagesTab;
                return;
            }
            if (Application.Current.Properties["TabClicked"].ToString() == "NotificationsTab")
            {
                Application.Current.Properties.Remove("TabClicked");
                NotificationsBGColor = Color.FromHex("#3B92E7");
                NotificationsLabelColor = Color.White;
                NotificationsIcon = "notification_selected.png";
                TitleText = AppResources.NotificationsTab;
                return;
            }
        }

        private void GetWorkerData()
        {
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image1.jpg", WorkerName = "Himanshu", WorkerCategory = "Plumber", WorkerInformation= "1st card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image2.jpg", WorkerName = "Himanshu", WorkerCategory = "Electrician", WorkerInformation = "2nd card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image3.jpg", WorkerName = "Himanshu", WorkerCategory = "Ac Repair", WorkerInformation = "3rd card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image4.jpg", WorkerName = "Himanshu", WorkerCategory = "Courier", WorkerInformation = "4th card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image5.jpg", WorkerName = "Himanshu", WorkerCategory = "Painter", WorkerInformation = "5th card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image6.jpg", WorkerName = "Himanshu", WorkerCategory = "Cleaning", WorkerInformation = "6th card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image7.jpg", WorkerName = "Himanshu", WorkerCategory = "Car Wash", WorkerInformation = "7th card" });
                CategoryDataList.Add(new HomePageDataModel { WorkerImage = "Image8.jpg", WorkerName = "Himanshu", WorkerCategory = "Mobile Repair", WorkerInformation = "8th card" });
           

        }

        private async void Info_Command(object obj)
        {
            var displayData = (HomePageDataModel)obj;
            var param = new NavigationParameters();
            param.Add("HomePageDetail", displayData);
            await _navigationService.NavigateAsync(nameof(HomeDetailPage), param);
        }
        #endregion

        #region ApiMethod
        public async void GetCategoryApi()
        {
            try
            {
                //var result = await _webApiRestClient.GetAsync<GetCatApiModel>("getCat");
                var result = await _webApiRestClient.GetAsync<GetCatApiModel>("?func=getcat");
                setData("CategoryListData", result);
                ListWidth = App.ScreenWidth;
                NewCategoryData = new ObservableCollection<HomePageModel>(result.data);
                var item = new HomePageModel()
                {
                    CategoryName = "All",
                    CategoryImage = "logo.png",
                    CategorySelected = true
                };
                Application.Current.Properties["PreviousSelectedValue"] = item;
                NewCategoryData.Insert(0, item);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message);
            }
        }
        #endregion
    }
}