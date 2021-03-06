﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF_FirstRun.Models;
using XF_FirstRun.Views;

namespace XF_FirstRun.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        // Сервис навигации между страницами
        private INavigation _navigation;
        public ObservableCollection<Item> Items { get; set; }

        public string Icon1 { get; set; } = "\uf30c";
        public string Icon2 { get; set; } = "\uf2ba";

        private string _IsCtlsVisible = "false";
        public string IsCtlsVisible
        {
            get { return _IsCtlsVisible; }
            set
            {
                SetProperty(ref _IsCtlsVisible, value); 
            }
        }

        private Item _selewctedItem;
        public Item SelectedItem
        {
            get { return _selewctedItem; }
            set
            {
                SetProperty(ref _selewctedItem, value);
            }
        }

        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; private set; }
        public Command ShowCtlsCommand { get; private set; }
        public Command ItemTappedCommand { get; private set; }
        public Command SwipeLeftCommand { get; private set; }

        public bool _debug { get; private set; } = false;
        public ItemsViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(async () =>
            {
                await _navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
            });
            ShowCtlsCommand = new Command<Item>(async (item) =>
            {
                if (IsCtlsVisible == "true")
                {
                    IsCtlsVisible = "false";
                }
                else
                {
                    IsCtlsVisible = "true";
                }
                SelectedItem = item;
            });
            ItemTappedCommand = new Command<Item>(async (item) =>
            {
                //var layout = (BindableObject)sender;
                //var item = Items[1]; //(Item)layout.BindingContext;
                SelectedItem = item;
                await _navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            });
            SwipeLeftCommand = new Command<object>(async (item) =>
            {
                //var layout = (BindableObject)sender;
                //var item = Items[1]; //(Item)layout.BindingContext;
                //SelectedItem = item;
                //await _navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            });

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
#if DEBUG
            _debug = true;
#endif
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}