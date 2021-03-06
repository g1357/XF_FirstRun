﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

using XF_FirstRun.Helpers;
using XF_FirstRun.Localization;
using XF_FirstRun.Resx;
using XF_FirstRun.Services;
using XF_FirstRun;
using System.Threading.Tasks;

namespace XF_FirstRun.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        /// <summary>
        /// Соответсвующая страница
        /// </summary>
        private Page _page;
        /// <summary>
        /// Сервис навигации между страницами
        /// </summary>
        private INavigation _navigation;

        private string _LocalDirectory = string.Empty;
        private bool _LocalDirectoryChanged = false;
        public  string LocalDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_LocalDirectory))
                {
                    _LocalDirectory = SystemInformation.DirectoryName;
                }
                return _LocalDirectory;
            }
            set
            {
                if (SetProperty(ref _LocalDirectory, value))
                {
                    _LocalDirectoryChanged = true;
                    SaveDirCommand.ChangeCanExecute();
                }
            }
        }
        /// <summary>
        // Список доступных языков
        /// 
        /// </summary>
        public List<string> Languages { get; set; } =
            new List<string>() { "en-US", "ru-RU" };
       /// <summary>
       /// Поле для выбранного языка
       /// </summary>
        private string _SelectedLanguage;
        /// <summary>
        /// Свойство для выбранногоязыка
        /// </summary>
        public string SelectedLanguage
        {
            get => _SelectedLanguage;
            set
            {
                if (SetProperty(ref _SelectedLanguage, value))
                {
                    SetLanguageAsync();
                }
            }
        }
        public Command SaveDirCommand { get; private set; }
        public Command EraseDataCommand { get; private set; }


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
            _SelectedLanguage = App.CurrentLanguage;
            _page = page;
            _navigation = navigation;
            Title = Resx.AppResx.SettingsPage_title;

            SaveDirCommand = new Command(
                execute: async () =>
                {
                    var fileService = DependencyService.Get<IFileManager>();
                    await fileService.SetDirectoryAsync(LocalDirectory);
                    SystemInformation.DirectoryName = LocalDirectory;
                    _LocalDirectoryChanged = false;
                    SaveDirCommand.ChangeCanExecute();
                },
                canExecute: () =>
                {
                    return _LocalDirectoryChanged;
                }
            );

            EraseDataCommand = new Command(async () =>
            {
                var m1 = AppResx.Warning;
                var m2 = AppResx.DeleteData_txt;
                var m3 = AppResx.Yes;
                var m4 = AppResx.No;
                bool answer = await _page.DisplayAlert(AppResx.Warning, AppResx.DeleteData_txt, AppResx.Yes, AppResx.No);
                if (answer)
                {
                    var fileService = DependencyService.Get<IFileManager>();
                    await fileService.DeleteDataAsync();
                    await _page.DisplayAlert(AppResx.Message, AppResx.DataDeleted_txt, AppResx.Ok);
                }
                else
                {
                    await _page.DisplayAlert(AppResx.Warning, AppResx.DataNotDeleted_txt, AppResx.Ok);
                }
            });
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

        private async Task RestartApp()
        {
            await _page.DisplayAlert("Alert", "Start App again to switch language!", "OK");
            //Application.Current.SendSleep();
            //Application.Current.Quit();
            await Application.Current.SavePropertiesAsync();

            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        
        /// <summary>
        /// Установка нового выбранного языка
        /// </summary>
        private async System.Threading.Tasks.Task SetLanguageAsync()
        {
            App.CurrentLanguage = SelectedLanguage;
            SystemInformation.AppLang = SelectedLanguage;
            await Application.Current.SavePropertiesAsync();
            //MessagingCenter.Send<object, string>(this, "Restart", "Restart");
            await RestartApp();
        }
    }
}
