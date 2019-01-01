using Acr.UserDialogs;
using MereNear.Model;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MereNear.ViewModels
{
	public class HomeDetailPageViewModel : BaseViewModel, INavigationAware
    {
        #region Private Variables
        private readonly INavigationService _navigationService;

        private HomePageDataModel _detailedData = new HomePageDataModel();

        private string _starRating1 = "star_active.png";
        private string _starRating2 = "star_active.png";
        private string _starRating3 = "star_active.png";
        private string _starRating4 = "star.png";
        private string _starRating5 = "star.png";
        #endregion

        #region Public Variables
        public HomePageDataModel DetailedData
        {
            get { return _detailedData; }
            set { SetProperty(ref _detailedData, value); }
        }
        
        public string StarRating1
        {
            get { return _starRating1; }
            set { SetProperty(ref _starRating1, value); }
        }

        public string StarRating2
        {
            get { return _starRating2; }
            set { SetProperty(ref _starRating2, value); }
        }

        public string StarRating3
        {
            get { return _starRating3; }
            set { SetProperty(ref _starRating3, value); }
        }

        public string StarRating4
        {
            get { return _starRating4; }
            set { SetProperty(ref _starRating4, value); }
        }

        public string StarRating5
        {
            get { return _starRating5; }
            set { SetProperty(ref _starRating5, value); }
        }
        #endregion

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.GoBackAsync();
                });
            }
        }
        #endregion

        #region Constructor
        public HomeDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

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
            if (parameters.ContainsKey("HomePageDetail"))
            {
                DetailedData = (HomePageDataModel)parameters["HomePageDetail"];
                
            }
        }
        #endregion
    }
}
