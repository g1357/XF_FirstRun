using System;
using System.Collections.Generic;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
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

            CurrentLanguage = SystemInformation.AppLang;
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DataStore>();
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
            SaveData();

            //InitializeComponent();

            //MainPage = new AppShell();
        }

        private async void GetData()
        {
            var fileService = DependencyService.Get<IFileManager>();
            var fileExist = await fileService.FileExistAsync();
            if (fileExist)
            {
                string text = await fileService.ReadAllTextAsync();
                var dS = DependencyService.Get<IDataStore<Item>>();
                var items = await Json.ToObjestAsync<List<Item>>(text);
                await dS.SetDataAsync(items);
            }
            else
            {
                // GetDemoData();
            }

            var dataService = DependencyService.Get<DataStore>();
            string ShoppingListFileName = "ShoppingLst.json";
            fileExist = await fileService.FileExistAsync(ShoppingListFileName);
            if (fileExist)
            {
                string text = await fileService.ReadAllTextAsync(ShoppingListFileName);
                text = await fileService.ReadAllTextAsync("ShoppingLst.json");
                var sl = await Json.ToObjestAsync<List<ShoppingList>>(text);
                await dataService.ShoppingList.SetDataAsync(sl);
            }
            else
            {
                await dataService.ShoppingList.SetDemoDataAsync();
            }



        }

        internal async void SaveData()
        {
            await Application.Current.SavePropertiesAsync();
            var dataService = DependencyService.Get<IDataStore<Item>>();
            var items = await dataService.GetItemsAsync();
            var text = await Json.FromObjectAsync(items);
            var fileService = DependencyService.Get<IFileManager>();
            await fileService.WriteAllTextAsync(text);
        }
    }
}
