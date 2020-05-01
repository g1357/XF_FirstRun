using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using XF_FirstRun.Models;

namespace XF_FirstRun.ViewModels
{
    public class ListView1ViewModel : BaseViewModel
    {
        // Сервис навигации между страницами
        private INavigation _navigation;
        // Отображаемая колекция
        public ObservableCollection<Item> Items { get; set; }

        public ICommand DeleteCommand => new Command<Item>(RemoveItem);
        public ICommand FavoriteCommand => new Command<Item>(FavoriteItem);

        public ListView1ViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = "Swiping List View";
            var items = DataStore.GetItemsAsync(true).Result;

            Items = new ObservableCollection<Item>();
            foreach (var item in items)
            {
                Items.Add(item);
            }

        }
        void RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

        void FavoriteItem(Item item)
        {
            //monkey.IsFavorite = !monkey.IsFavorite;
            Debug.Print("Mark as Favorite!");
        }

    }
}
