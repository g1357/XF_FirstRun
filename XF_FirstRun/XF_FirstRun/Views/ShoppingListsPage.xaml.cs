﻿using System;
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
    public partial class ShoppingListsPage : ContentPage
    {
        ShoppingListsViewModel viewModel;
        public ShoppingListsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ShoppingListsViewModel(this);
        }
    }
}