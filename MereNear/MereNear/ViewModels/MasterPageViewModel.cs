using Acr.UserDialogs;
using Android.Content;
using MereNear.Model;
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

namespace MereNear.ViewModels
{
    public class MasterPageViewModel : BindableBase
    {
        #region Private Variables
        private readonly INavigationService _navigationService;

        private bool _isPresented;
        private MasterMenuModel _selectedItem;
        private ObservableCollection<MasterMenuModel> _masterMenuListData = new ObservableCollection<MasterMenuModel>();
        #endregion

        #region Public Variables
        public bool IsPresented
        {
            get { return _isPresented; }
            set { SetProperty(ref _isPresented, value); }
        }

        public MasterMenuModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                if (_selectedItem == null)
                {
                    return;
                }
                else
                {
                    if (SelectedItem.MasterMenuLabel == "Home")
                    {
                        _navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Relative));
                    }
                    if (SelectedItem.MasterMenuLabel == "Profile")
                    {
                        _navigationService.NavigateAsync(new Uri("NavigationPage/ProfilePage", UriKind.Relative));
                    }
                    if (SelectedItem.MasterMenuLabel == "Change Language")
                    {
                        _navigationService.NavigateAsync(new Uri("NavigationPage/LanguagePage", UriKind.Relative));
                    }
                    if (SelectedItem.MasterMenuLabel == "Rate Us")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "How Mere Near Work")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "Privacy Policy")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "Terms and Conditions")
                    {
                        _navigationService.NavigateAsync(new Uri("/NavigationPage/TermConditionPage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "Support/Complaints")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                    if (SelectedItem.MasterMenuLabel == "About Us")
                    {
                        //_navigationService.NavigateAsync(new Uri("NavigationPage/HomePage", UriKind.Absolute));
                    }
                }
            }
        }

        public ObservableCollection<MasterMenuModel> MasterMenuListData
        {
            get { return _masterMenuListData; }
            set { SetProperty(ref _masterMenuListData, value); }
        }
        #endregion

        #region Command

        public ICommand HomePageTappped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.NavigateAsync(new Uri("/NavigationPage/HomeTabbedPage", UriKind.Relative));
                    MessagingCenter.Send("HomePage", "ChangeCurrentPage");
                });
            }
        }

        public ICommand AboutUsTapped
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await _navigationService.NavigateAsync(new Uri("/NavigationPage/AboutPage", UriKind.Relative));
                });
            }
        }

        public ICommand MyJobTapped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.NavigateAsync(new Uri("/NavigationPage/HomeTabbedPage", UriKind.Relative));
                    MessagingCenter.Send("MyJobs", "ChangeCurrentPage");
                    //App.Current.MainPage.Navigation.PushAsync(new MyJobs());
                });
            }
        }

        public ICommand MyPostTapped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.NavigateAsync(new Uri("/NavigationPage/MyPosts", UriKind.Relative));
                    //App.Current.MainPage.Navigation.PushAsync(new MyPosts());
                });
            }
        }

        public ICommand PolicyTapped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                  await _navigationService.NavigateAsync(new Uri("/NavigationPage/TermConditionPage", UriKind.Relative));
                });
            }
        }
        
        public ICommand RateUsTapped
        {
            get
            {
                return new DelegateCommand(() =>
                {    
                    if(Device.RuntimePlatform == Device.Android)
                    {
                        Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.qservices.mereNear&hl=en"));
                    }
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        Device.OpenUri(new Uri("https://itunes.apple.com/in/app/fishdom/id1046482500?mt=12"));
                    }
                });
            }
        }
        
        public ICommand SupportTapped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    await _navigationService.NavigateAsync(new Uri("/NavigationPage/ChatPage", UriKind.Relative));
                });
            }
        }
        public ICommand SettingsTapped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                   await _navigationService.NavigateAsync(new Uri("/NavigationPage/SettingsPage", UriKind.Relative));
                });
            }
        }
        public ICommand LogOutTapped
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                  await _navigationService.NavigateAsync(new Uri("/NavigationPage/Login_page"));
                });
            }
        }
        #endregion

        #region Constructor
        public MasterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //GetMasterMenuList();
        }
        #endregion

        #region Private Methods
        private void GetMasterMenuList()
        {
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "&#xf2f5;",
                MasterMenuLabel = "Home"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "profile.png",
                MasterMenuLabel = "Profile"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "language.png",
                MasterMenuLabel = "Change Language"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Rate Us"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "youtube.png",
                MasterMenuLabel = "How Mere Near Work"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Privacy Policy"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Terms and Conditions"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "home.png",
                MasterMenuLabel = "Support/Complaints"
            });
            MasterMenuListData.Add(new MasterMenuModel
            {
                MasterMenuIcon = "about.png",
                MasterMenuLabel = "About Us"
            });
            //MasterMenuListData1 = MasterMenuListData;
            //for (int i = 0; i < 5; i++)
            //{
            //    MasterMenuListData.Add(new MasterMenuModel
            //    {
            //        MasterMenuIcon = "home.png",
            //        MasterMenuLabel = "Home"
            //    });
            //}
        }
        #endregion
    }
}
