using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XF_FirstRun.ViewModels;
using XF_FirstRun.Views;

namespace XF_FirstRun
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = new AppShellViewModel(Navigation);
            //_ = Navigation.PushModalAsync(new FirstRunPage());
        }
    }
}
