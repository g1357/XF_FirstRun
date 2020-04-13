using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF_FirstRun.Helpers;

namespace XF_FirstRun.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string IsFirstRun => SystemInformation.IsFirstRun ?
            "Первый запуск приложени" : "НЕ первый запуск приложения";

        public string AppName => SystemInformation.ApplicationName;
        public string AppVersionString => SystemInformation.ApplicationVersionString;

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}