using Acr.UserDialogs;
using MereNear.Services;
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

namespace MereNear.ViewModels
{
	public class ProfilePageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private ImageSource _starRating1 = "star_2.png";
        private ImageSource _starRating2 = "star_2.png";
        private ImageSource _starRating3 = "star_2.png";
        private ImageSource _starRating4 = "star_2.png";
        private ImageSource _starRating5 = "star_2.png";

        private string _starRatingText = "0.0";
        private string _personName;
        private string _personMobileNumber;
        #endregion

        #region Public Variables
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

        public string StarRatingText
        {
            get { return _starRatingText; }
            set { SetProperty(ref _starRatingText, value); }
        }

        public string PersonName
        {
            get { return _personName; }
            set { SetProperty(ref _personName, value); }
        }

        public string PersonMobileNumber
        {
            get { return _personMobileNumber; }
            set { SetProperty(ref _personMobileNumber, value); }
        }
        #endregion

        #region Command
        public ICommand StarRating1Command
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StarRating1 = "star_1.png";
                    StarRating2 = "star_2.png";
                    StarRating3 = "star_2.png";
                    StarRating4 = "star_2.png";
                    StarRating5 = "star_2.png";
                    StarRatingText = "1.0";
                });
            }
        }

        public ICommand StarRating2Command
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StarRating1 = "star_1.png";
                    StarRating2 = "star_1.png";
                    StarRating3 = "star_2.png";
                    StarRating4 = "star_2.png";
                    StarRating5 = "star_2.png";
                    StarRatingText = "2.0";
                });
            }
        }

        public ICommand StarRating3Command
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StarRating1 = "star_1.png";
                    StarRating2 = "star_1.png";
                    StarRating3 = "star_1.png";
                    StarRating4 = "star_2.png";
                    StarRating5 = "star_2.png";
                    StarRatingText = "3.0";
                });
            }
        }

        public ICommand StarRating4Command
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StarRating1 = "star_1.png";
                    StarRating2 = "star_1.png";
                    StarRating3 = "star_1.png";
                    StarRating4 = "star_1.png";
                    StarRating5 = "star_2.png";
                    StarRatingText = "4.0";
                });
            }
        }

        public ICommand StarRating5Command
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StarRating1 = "star_1.png";
                    StarRating2 = "star_1.png";
                    StarRating3 = "star_1.png";
                    StarRating4 = "star_1.png";
                    StarRating5 = "star_1.png";
                    StarRatingText = "5.0";
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        //_navigationService.NavigateAsync(nameof(MapIntegration), null, null, true);
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
        public ProfilePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
