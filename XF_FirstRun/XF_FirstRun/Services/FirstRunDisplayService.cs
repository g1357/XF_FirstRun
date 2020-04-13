using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF_FirstRun.Services
{
    public static class FirstRunDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            App.Current.Dispatcher.BeginInvokeOnMainThread(
                () =>
                {

                });
        }
    }
}
