using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_FirstRun.Models;
using XF_FirstRun.Services;

namespace XF_FirstRun.ViewModels
{
    public class ShoppingListsViewModel : BaseViewModel
    {
        /// <summary>
        /// Соответсвующая страница
        /// </summary>
        private Page _page;

        public ObservableCollection<ShoppingList> Items { get; set; }

        private Item _selewctedItem;
        public Item SelectedItem
        {
            get { return _selewctedItem; }
            set
            {
                SetProperty(ref _selewctedItem, value);
            }
        }

        public Command LoadItemsCommand { get; private set; }

        public ShoppingListsViewModel(Page page)
        {
            _page = page;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _ = ExecuteLoadItemsCommand();

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var dataService = DependencyService.Get<DataStore>();
                if (Items != null)
                {
                    Items.Clear();
                }
                else
                {
                    Items = new ObservableCollection<ShoppingList>();
                }
                var items = await dataService.ShoppingList.GetAllItemsAsync(true);
                //Items = new ObservableCollection<ShoppingList>(items);
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
