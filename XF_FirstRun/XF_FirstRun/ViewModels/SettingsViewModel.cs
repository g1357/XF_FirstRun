using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

using XF_FirstRun.Helpers;
using XF_FirstRun.Localization;
using XF_FirstRun.Resx;

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
        /// <summary>
        // Список доступных языков
        /// 
        /// </summary>
        public List<string> Languages { get; set; } =
            new List<string>() { "EN", "RU" };
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
                    SetLanguage();
                }
            }
        }

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

        
        /// <summary>
        /// Установка нового выбранного языка
        /// </summary>
        private void SetLanguage()
        {
            App.CurrentLanguage = SelectedLanguage;
            MessagingCenter.Send<object, string>(this,
                "Restart", "Restart");
        }
    }
}
