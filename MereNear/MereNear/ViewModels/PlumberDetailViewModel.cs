using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
	public class PlumberDetailViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private bool _isMapViewVisible = false;

        private ImageSource _starRating1 = "star_2.png";
        private ImageSource _starRating2 = "star_2.png";
        private ImageSource _starRating3 = "star_2.png";
        private ImageSource _starRating4 = "star_2.png";
        private ImageSource _starRating5 = "star_2.png";
        private ImageSource _workerPic = "user_without_shadow";

        private string _workerName = "Amar Singh";
        #endregion

        #region Public Variables
        public bool IsMapViewVisible
        {
            get { return _isMapViewVisible; }
            set { SetProperty(ref _isMapViewVisible, value); }
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

        public ImageSource WorkerPic
        {
            get { return _workerPic; }
            set { SetProperty(ref _workerPic, value); }
        }

        public string WorkerName
        {
            get { return _workerName; }
            set { SetProperty(ref _workerName, value); }
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
                });
            }
        }

        public ICommand WorkerCallingCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }

        public ICommand WorkerInfoCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }

        public ICommand WorkerLocationCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Loading Map");
                        await Task.Delay(500);
                        IsMapViewVisible = true;
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert(ex.Message);
                    }
                });
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (IsMapViewVisible)
                    {
                        IsMapViewVisible = false;
                        return;
                    }
                    else
                    {
                        _navigationService.GoBackAsync();
                    }
                });
            }
        }

        public ICommand ApplyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.NavigateAsync("/NavigationPage/RequestRecieved");
                });
            }
        }

        #endregion

        #region Constructor
        public PlumberDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
