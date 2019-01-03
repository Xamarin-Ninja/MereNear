using MereNear.Model;
using MereNear.Resources;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class ChooseCategoryPageViewModel : BaseViewModel, INavigationAware
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        private ObservableCollection<HomePageModel> _postJobcategory = new ObservableCollection<HomePageModel>();

        private HomePageModel _selectedItemCommand;
        private string _customHeaderTitle;
        #endregion

        #region Public Variable
        public bool IsPostAJob { get; set; }
        public bool IsLookingForAJob { get; set; }
        public string LocationAddress { get; set; }
        public string CustomHeaderTitle
        {
            get { return _customHeaderTitle; }
            set { SetProperty(ref _customHeaderTitle, value); }
        }
        public Position LocationAddressPosition { get; set; }

        public HomePageModel SelectedItemCommand
        {
            get { return _selectedItemCommand; }
            set
            {
                SetProperty(ref _selectedItemCommand, value);
                if (_selectedItemCommand == null)
                {
                    return;
                }
                else
                {
                    SelectedItemCommand.FrameColor = Color.LightGray;
                }
            }
        }

        public ObservableCollection<HomePageModel> PostJobcategory
        {
            get { return _postJobcategory; }
            set { SetProperty(ref _postJobcategory, value); }
        }
        #endregion

        #region Constructor
        public ChooseCategoryPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetData();
        }
        #endregion

        #region Command
        public ICommand NextButtonCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    if (IsPostAJob)
                    {
                        var data = (HomePageModel)Application.Current.Properties["LastSelectedValue"];
                        var param = new NavigationParameters();
                        param.Add("Address", LocationAddress);
                        param.Add("Categoryname", data.CategoryName);
                        param.Add("AddressPosition", LocationAddressPosition);
                        if (data.CategoryName == "Home Delivery")
                        {
                            param.Add("HomeDeliveryOption", "HomeDeliveryOption");
                            await _navigationService.NavigateAsync(nameof(PickLocationMapPage), param);
                        }
                        else
                        {
                            await _navigationService.NavigateAsync(nameof(PostDescriptionPage), param);
                        }
                    }
                    if(IsLookingForAJob)
                    {
                        var data = (HomePageModel)Application.Current.Properties["LastSelectedValue"];
                        var param = new NavigationParameters();
                        param.Add("Categoryname", data.CategoryName);
                        await _navigationService.NavigateAsync(nameof(AllJobs), param);
                    }

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

        #region Private Methods
        private void GetData()
        {
            var categoryData = getData("CategoryListData");
            foreach (var item in categoryData.data)
            {
                item.AvailableServiceProvider = "10";
                item.FrameColor = Color.LightGray;
            }
            PostJobcategory = new ObservableCollection<HomePageModel>(categoryData.data);
        }
        #endregion

        #region Navigation Parameter
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
                LocationAddress = (string)parameters["Address"];
                CustomHeaderTitle = AppResources.PostJob;
                IsPostAJob = true;
                if (parameters.ContainsKey("AddressPosition"))
                {
                    LocationAddressPosition = (Position)parameters["AddressPosition"];
                }
            }
            else
            {
                CustomHeaderTitle = AppResources.LookingJob;
                IsLookingForAJob = true;
            }
        }
        #endregion
    }
}
