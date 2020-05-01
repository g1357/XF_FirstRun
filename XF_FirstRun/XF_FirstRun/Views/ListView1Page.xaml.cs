using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF_FirstRun.ViewModels;

namespace XF_FirstRun.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView1Page : ContentPage
    {
        ListView1ViewModel viewModel;
        public ListView1Page()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListView1ViewModel(Navigation);
        }
    }
}