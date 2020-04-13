using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF_FirstRun.Helpers;

namespace XF_FirstRun.ViewModels
{
    public class AppUpdatedViewModel : BaseViewModel
    {
        public string IsFirstRun => SystemInformation.IsFirstRun ?
            "Первый запуск приложени" : "НЕ первый запуск приложения";

        private INavigation _navigation;

        public string Message => @"Добро пожаловть в обновлённое приложение MyApp.
Огоромное спасибо, что продолдаете быть с нами!
В новой редакции мы добавили соедующие возможномти:
- бла бла бла
- ещё бла бла бла
- и ещё бла бла бла.
";

        public AppUpdatedViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = "Первый запуск/First Run";
            CloseCommand = new Command(async () => await _navigation.PopModalAsync());
        }

        public ICommand CloseCommand { get; }
    }
}
