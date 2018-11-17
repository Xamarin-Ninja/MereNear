using Acr.UserDialogs;
using MereNear.Model;
using MereNear.Views;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;

namespace MereNear.ViewModels
{
    public class LanguagePageViewModel : BindableBase
	{
        #region Private Variables
        private readonly INavigationService _navigationService;

        private LanguageModel _languageSelected;
        private ObservableCollection<LanguageModel> _languagePicker = new ObservableCollection<LanguageModel>();
        #endregion

        #region Public Variable
        public LanguageModel LanguageSelected
        {
            get { return _languageSelected; }
            set
            {
                SetProperty(ref _languageSelected, value);
                if(LanguageSelected == null)
                {
                    return;
                }
                else
                {
                    var language = LanguageSelected;

                    try
                    {
                        //DependencyService.Get<ILocalize>().ChangeLocale("hi");
                        //App.CultureCode = "hi";
                        
                        //UserDialogs.Instance.ShowLoading("Loading");
                        ////_navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
                        GoToHomePage();
                        //UserDialogs.Instance.HideLoading();
                        
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                        UserDialogs.Instance.Alert(msg);
                    }
                }
            }
        }

        //public ObservableCollection<LanguageModel> LanguagePicker
        //{
        //    get { return _languagePicker; }
        //    set { SetProperty(ref _languagePicker, value); }
        //}
        #endregion

        #region Command

        #endregion

        #region Constructor
        public LanguagePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //GetLanguages();
        }
        #endregion

        #region Private Methods
        private async void GoToHomePage()
        {
            //_navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
            await _navigationService.NavigateAsync(nameof(Login_Page));
        }
        //private void GetLanguages()
        //{
        //    LanguagePicker.Add(new LanguageModel
        //    {
        //        DisplayName = "English",
        //        ShortName = "en"
        //    });
        //    LanguagePicker.Add(new LanguageModel
        //    {
        //        DisplayName = "Hindi",
        //        ShortName = "hi"
        //    });
        //}
        #endregion
    }
}
