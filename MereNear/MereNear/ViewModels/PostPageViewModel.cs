using Acr.UserDialogs;
using MereNear.Model;
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

namespace MereNear.ViewModels
{
	public class PostPageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private Color _myPostButtonColor = Color.Transparent;
        private Color _myPostButtonTextColor = Color.Gray;

        private Color _applyDataButtonTextColor = Color.White;
        private Color _applyDataButtonColor = Color.FromHex("#3498db");
        #endregion

        #region Public Variables
        public ObservableCollection<PostPageModel> PlumberListData = new ObservableCollection<PostPageModel>();

        public Color MyPostButtonColor
        {
            get { return _myPostButtonColor; }
            set { SetProperty(ref _myPostButtonColor, value); }
        }

        public Color MyPostButtonTextColor
        {
            get { return _myPostButtonTextColor; }
            set { SetProperty(ref _myPostButtonTextColor, value); }
        }

        public Color ApplyDataButtonColor
        {
            get { return _applyDataButtonColor; }
            set { SetProperty(ref _applyDataButtonColor, value); }
        }

        public Color ApplyDataButtonTextColor
        {
            get { return _applyDataButtonTextColor; }
            set { SetProperty(ref _applyDataButtonTextColor, value); }
        }
        #endregion

        #region Command
        public ICommand ApplyDataCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ApplyDataButtonColor = Color.FromHex("#3498db");
                    ApplyDataButtonTextColor = Color.White;
                    MyPostButtonColor = Color.Transparent;
                    MyPostButtonTextColor = Color.Gray;
                });
            }
        }

        public ICommand MyPostCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        MyPostButtonColor = Color.FromHex("#3498db");
                        MyPostButtonTextColor = Color.White;
                        ApplyDataButtonColor = Color.Transparent;
                        ApplyDataButtonTextColor = Color.Gray;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Ex:- Exception on going to SendOtp Page:" + ex.Message);
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
        }
        #endregion

        #region Constructor
        public PostPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //GetPlumberList();
        }
        #endregion

        #region Private Methods
        private void GetPlumberList()
        {
            for(int i = 0; i < 5; i++)
            {
                PlumberListData.Add(new PostPageModel
                {
                    PlumberName = "Plumber",
                    PlumberTask = "Completed",
                    PlumberTaskDate = Convert.ToString(DateTime.Today)
                });
            }
        }
        #endregion
    }
}
