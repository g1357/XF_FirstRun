using System;
using System.Collections.Generic;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF_FirstRun.Helpers;
using XF_FirstRun.Models;
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

            MessagingCenter.Subscribe<object, string>(this,
                "Restart", Restart);

            DependencyService.Register<FileManager>();
        }

        protected override void OnStart()
        {
            GetData();
        }

        protected override void OnSleep()
        {
            SaveData();
        }

        protected override void OnResume()
        {
            GetData();
        }

        protected void Restart(object s, string str)
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        private async void GetData()
        {
            var fileService = DependencyService.Get<IFileManager>();
            var fileExist = await fileService.FileExistAsync();
            if (fileExist)
            {
                string text = await fileService.ReadAllTextAsync();
                var dataService = DependencyService.Get<IDataStore<Item>>();
                var items = await Json.ToObjestAsync<List<Item>>(text);
                await dataService.SetDataAsync(items);
            }
            else
            {
                // GetDemoData();
            }
        }

        private async void SaveData()
        {
            var dataService = DependencyService.Get<IDataStore<Item>>();
            var items = await dataService.GetItemsAsync();
            var text = await Json.FromObjectAsync(items);
            var fileService = DependencyService.Get<IFileManager>();
            await fileService.WriteAllTextAsync(text);
        }
    }
}
