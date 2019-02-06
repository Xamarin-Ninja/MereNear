using Acr.UserDialogs;
using LiteDB;
using LiteDB.LanguageModelDB;
using MereNear.Model;
using MereNear.ViewModels.Common;
using MereNear.Views;
using System.Linq;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MereNear.ViewModels
{
    public class LanguagePageViewModel : BaseViewModel, INavigationAware
	{
        #region Private Variables
        private readonly INavigationService _navigationService;
        private LanguageModel _languageSelected;
        private ObservableCollection<LanguageModel> _languagePicker = new ObservableCollection<LanguageModel>();
        #endregion
        
        #region Public Variable
        public string lastnavigatedpage { get; set; }
        public LanguageModel LanguageSelected
        {
            get { return _languageSelected; }
            set
            {
                SetProperty(ref _languageSelected, value);
                if (LanguageSelected == null)
                {
                    return;
                }
                else
                {
                    try
                    {
                        var IsLanguageDBExist = languageDBService.IsLanguageDbPresentInDB();
                        if (IsLanguageDBExist)
                        {
                            var existinglanguage = languageDBService.ReadAllItems();
                            BsonValue bsonid = existinglanguage.First().ID;
                            languageDBService.UpdateLanguageModelInDb(bsonid,LanguageSelected);
                        }
                        else
                        {
                            languageDBService.CreateLanguageModelInDB(LanguageSelected);
                        }

                        App.Setlanguage(LanguageSelected.ShortName);
                        try
                        {
                            GoToHomePage();
                        }
                        catch (Exception ex)
                        {
                            var msg = ex.Message;
                        }
                    }
                    catch (Exception ex)
                    {
                        App.Current.MainPage.DisplayAlert("Exception", ex.Message, "Ok");
                    }
                }
            }
        }
        #endregion

        #region Command

        #endregion

        #region Constructor
        public LanguagePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }
        #endregion

        #region Private Methods
        private async void GoToHomePage()
        {
            if (string.IsNullOrEmpty(lastnavigatedpage)||string.IsNullOrWhiteSpace(lastnavigatedpage))
            {
                await _navigationService.NavigateAsync(nameof(Login_Page));
            }
            else
            {
                await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
            }
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
            if (parameters.ContainsKey("FromSettingPage"))
            {
                lastnavigatedpage = (string)parameters["FromSettingPage"];
            }
        }
        #endregion
    }
}
