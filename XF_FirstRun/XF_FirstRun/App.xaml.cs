using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF_FirstRun.Helpers;
using XF_FirstRun.Services;
using XF_FirstRun.Views;

namespace XF_FirstRun
{
    public partial class App : Application
    {
        /// <summary>
        /// Текущий язык приложения
        /// </summary>
        public static string CurrentLanguage ="ru-RU";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //CurrentLanguage = SystemInformation.AppLang;
            MessagingCenter.Subscribe<object, string>(this,
                "Restart", Restart);

        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }

        protected void Restart(object s, string str)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //CurrentLanguage = SystemInformation.AppLang;

        }
    }
}
