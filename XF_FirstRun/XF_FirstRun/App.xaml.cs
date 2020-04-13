using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_FirstRun.Services;
using XF_FirstRun.Views;

namespace XF_FirstRun
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
    }
}
