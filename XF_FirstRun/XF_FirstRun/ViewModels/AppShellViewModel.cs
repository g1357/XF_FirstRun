using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF_FirstRun.Helpers;
using XF_FirstRun.Views;

namespace XF_FirstRun.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private INavigation _navigation;
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
