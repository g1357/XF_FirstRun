using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF_FirstRun.Helpers;
using XF_FirstRun.Views;

namespace XF_FirstRun.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private Page _page;

        public ICommand SettingsCommand => new Command(async () =>
            {
                await _navigation.PushAsync(new SettingsPage());
                ((AppShell)_page).FlyoutIsPresented = false;
            });
        public AppShellViewModel(Page page, INavigation navigation)
            : this(navigation)
        {
            _page = page;
        }
        public AppShellViewModel(INavigation navigation)
        {
            _navigation = navigation;

            if (SystemInformation.IsFirstRun)
            {
                _ = _navigation.PushModalAsync(new FirstRunPage());
            }
            else if (SystemInformation.IsAppUpdated)
            {
                _ = _navigation.PushModalAsync(new AppUpdatedPage());
            }
        }
    }
}
