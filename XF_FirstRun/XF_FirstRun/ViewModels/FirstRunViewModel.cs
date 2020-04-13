using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF_FirstRun.Helpers;

namespace XF_FirstRun.ViewModels
{
    public class FirstRunViewModel : BaseViewModel
    {
        public string IsFirstRun => SystemInformation.IsFirstRun ?
            "Первый запуск приложени" : "НЕ первый запуск приложения";

        private INavigation _navigation;

        public string Message => @"Добро пожаловть а приложение MyApp.
Огоромное спасибо, что выбрали наше приложение!
Мы делаем всё возмодное,
чтобы Вам было комфортно с ним работать.
";

        public FirstRunViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = "Первый запуск/First Run";
            CloseCommand = new Command(async () => await _navigation.PopModalAsync());
        }

        public ICommand CloseCommand { get; }
    }
}
