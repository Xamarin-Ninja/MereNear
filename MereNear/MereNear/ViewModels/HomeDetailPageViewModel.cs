using Acr.UserDialogs;
using MereNear.Model;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ShowcaseImagesModel> _myDataSource = new ObservableCollection<ShowcaseImagesModel>();

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
        public ObservableCollection<ShowcaseImagesModel> MyDataSource
        {
            get
            {
                return _myDataSource;
            }
            set
            {
                SetProperty(ref _myDataSource, value);
            }
        }
        #endregion

        private int _position;
        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }

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

        public ICommand ContactCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {
                        await _navigationService.NavigateAsync(nameof(ChatPage));
                    }
                    catch (Exception)
                    {

                    }
                });
            }
        }


        public ICommand ProfileCommand
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    try
                    {
                        var param = new NavigationParameters();
                        param.Add("HomeDetailPage", "HomeDetailPage");
                        await _navigationService.NavigateAsync(nameof(ProfilePage),param);
                    }
                    catch (Exception)
                    {

                    }
                });
            }
        }
        #endregion
        
        #region Constructor
        public HomeDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            getCarouselData();
          
        }

        #endregion

        #region Private Methods

        private void getCarouselData()
        {
            var item = new ShowcaseImagesModel
            {
                showcaseImage = "Image1.jpg"
            };
            var item2 = new ShowcaseImagesModel
            {
                showcaseImage = "Image3.jpg"
            };
            MyDataSource.Add(item);
            MyDataSource.Add(item2);
            MyDataSource.Add(item);
            MyDataSource.Add(item2);
            MyDataSource.Add(item);
            MyDataSource.Add(item2);
            MyDataSource.Add(item);
            MyDataSource.Add(item2);
            MyDataSource.Add(item);
            MyDataSource.Add(item2);
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
            if (parameters.ContainsKey("HomePageDetail"))
            {
                DetailedData = (HomePageDataModel)parameters["HomePageDetail"];
                
            }
        }
        #endregion
    }
}
