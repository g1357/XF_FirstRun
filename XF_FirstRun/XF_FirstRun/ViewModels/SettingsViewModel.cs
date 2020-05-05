﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

using XF_FirstRun.Helpers;
using XF_FirstRun.Resx;

namespace XF_FirstRun.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private Page _page;
        // Сервис навигации между страницами
        private INavigation _navigation;

        CultureInfo currentCulture;
        private string _cultureName;
        public string CultureName { 
            get => _cultureName;
            set => SetProperty(ref _cultureName, value);
        }
        private string _cultureDisplay;
        public string CultureDisplay { 
            get => _cultureDisplay;
            set => SetProperty(ref _cultureDisplay, value);
        }
        public Command LangChangeCommand { get; private set; }

        private string _selectedLang;
        public string SelectedLang { 
            get => _selectedLang;
            set => SetProperty(ref _selectedLang, value);
        }
        public SettingsViewModel(Page page, INavigation navigation)
        {
            _page = page;
            _navigation = navigation;
            Title = Resx.AppResx.SettingsPage_title;

            LangChangeCommand = new Command(() =>
            {
                SystemInformation.AppLang = SelectedLang;

                if (SelectedLang == "en-US")
                {
                    var newCulture = new CultureInfo("en-US");
                    CultureInfo.CurrentCulture = newCulture;
                    //AppResx.Culture = newCulture;

                }
                else if (SelectedLang == "ru-RU")
                {
                    var newCulture = new CultureInfo("ru-RU");
                    CultureInfo.CurrentCulture = newCulture;
                    //AppResx.Culture = newCulture;
                }
                Application.Current.Properties["AppLang"] = SelectedLang;

                currentCulture = System.Globalization.CultureInfo.CurrentCulture;
                CultureName = currentCulture.Name;
                CultureDisplay = currentCulture.DisplayName;

                OnPropertyChanged("Label1");

                RestartApp();

            });

            currentCulture = System.Globalization.CultureInfo.CurrentCulture;
            CultureName = currentCulture.Name;
            CultureDisplay = currentCulture.DisplayName;
            SelectedLang = CultureName;
        }

        async void RestartApp()
        {
            await _page.DisplayAlert("Alert", "Start App again to switch language!", "OK");
            //Application.Current.SendSleep();
            //Application.Current.Quit();
            await Application.Current.SavePropertiesAsync();

            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

        }
    }
}
