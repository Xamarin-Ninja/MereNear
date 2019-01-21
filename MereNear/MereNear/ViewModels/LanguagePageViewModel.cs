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
        private readonly ILanguageDBService languageDBService;

        private LanguageModel _languageSelected;
        private ObservableCollection<LanguageModel> _languagePicker = new ObservableCollection<LanguageModel>();
        #endregion
        LiteDatabase _dataBase;
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

                        //_dataBase = new LiteDatabase(DependencyService.Get<Interface.IDataBase>().GetFilePath("Users.db"));
                        //language = _dataBase.GetCollection<User>();


                        //User lang = new User
                        //{
                        //    Language = LanguageSelected.ShortName

                        //};
                        App.Setlanguage(LanguageSelected.ShortName);
                        //setString("AppLanguage", LanguageSelected.ShortName);
                        //language.Update(lang);
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
            languageDBService = DependencyService.Get<ILanguageDBService>();
            //GetLanguages();
        }
        #endregion

        #region Private Methods
        private async void GoToHomePage()
        {
            //_navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
            if (string.IsNullOrEmpty(lastnavigatedpage)||string.IsNullOrWhiteSpace(lastnavigatedpage))
            {
                await _navigationService.NavigateAsync(nameof(Login_Page));
            }
            else
            {
                await _navigationService.NavigateAsync(new Uri("/MasterPage/NavigationPage/HomeTabbedPage", UriKind.Absolute));
            }
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
