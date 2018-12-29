﻿using MereNear.Resources;
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
        private ObservableCollection<CategoryListModel> _postJobcategory = new ObservableCollection<CategoryListModel>();

        private CategoryListModel _selectedItemCommand;
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

        public CategoryListModel SelectedItemCommand
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

        public ObservableCollection<CategoryListModel> PostJobcategory
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
                        var data = (CategoryListModel)Application.Current.Properties["LastSelectedValue"];
                        var param = new NavigationParameters();
                        param.Add("Address", LocationAddress);
                        param.Add("Categoryname", data.ServiceCategoryName);
                        param.Add("AddressPosition", LocationAddressPosition);
                        await _navigationService.NavigateAsync(nameof(PostDescriptionPage),param);
                    }
                    if(IsLookingForAJob)
                    {
                        var data = (CategoryListModel)Application.Current.Properties["LastSelectedValue"];
                        var param = new NavigationParameters();
                        param.Add("Categoryname", data.ServiceCategoryName);
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
            for (int i = 0; i < 8; i++)
            {
                PostJobcategory.Add(new CategoryListModel
                {
                    ServiceCategoryImage = "plumbing.png",
                    ServiceCategoryName = "Plumber",
                    AvailableServiceProvider = "10",
                    FrameColor = Color.LightGray
                });
            }
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

    #region Models
    public class CategoryListModel: INotifyPropertyChanged
    {
        public string ServiceCategoryImage { get; set; }
        public string ServiceCategoryName { get; set; }
        public string AvailableServiceProvider { get; set; }
        private Color _frameColor = Color.LightGray;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Color FrameColor
        {
            get { return _frameColor; }
            set { _frameColor = value; OnPropertyChanged("FrameColor"); }
        }
    }
    #endregion
}
