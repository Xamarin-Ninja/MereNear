﻿using Acr.UserDialogs;
using MereNear.Model;
using MereNear.ViewModels.Common;
using MereNear.Views;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;

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
                if(LanguageSelected == null)
                {
                    return;
                }
                else
                {
                    var language = LanguageSelected;
                    setString("AppLanguage", language.ShortName);
                    App.Setlanguage(language.ShortName);
                    try
                    {
                        GoToHomePage();                        
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
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
                await _navigationService.GoBackAsync();
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
