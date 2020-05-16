using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    public class LocalDataStore // : IDataStore<Item>
    {
        /// <summary>
        /// Единицы измерения
        /// </summary>
        public List<Unit> Units { get; set; }

        /// <summary>
        /// Отделы
        /// </summary>
        public List<Department> Departments { get; set; }

        /// <summary>
        /// Списки покупок
        /// </summary>
        public List<ShoppingList> ShoopingLists { get; set; }
        private bool ShoppingListsChanged = false;

        /// <summary>
        /// Товары
        /// </summary>
        public List<ShoppingListDetails> Details { get; set; }

        /// <summary>
        /// Словарь деиальной информации для списков покупок
        /// </summary>
        public Dictionary<string, List<Item>> DetailsDictionary { get; set; }

        public LocalDataStore()
        {
        }
        #region Общие операции
        public async Task<bool> LoadDataAsync()
        {

            return await Task.FromResult(true);
        }

        public async Task<bool> SaveDataAsync()
        {
            return await Task.FromResult(true);

        }
        #endregion Общие операции

        #region Операции со списками покупок

        public async Task<IEnumerable<ShoppingList>> GetAllShoppingListsAsync()
        {
            return await Task.FromResult(ShoopingLists);
        }
        public async Task<bool> AddShoppingListAsync(ShoppingList shoppingList)
        {
            ShoopingLists.Add(shoppingList);
            ShoppingListsChanged = true;
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateShoppingListAsync(ShoppingList shoppingList)
        {
            var oldItem = ShoopingLists.Where((ShoppingList arg) => arg.Id == shoppingList.Id).FirstOrDefault();
            ShoopingLists.Remove(oldItem);
            ShoopingLists.Add(shoppingList);

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteShoppingListAsync(string id)
        {
            var oldItem = ShoopingLists.Where((ShoppingList arg) => arg.Id == id).FirstOrDefault();
            ShoopingLists.Remove(oldItem);

            return await Task.FromResult(true);
        }
        #endregion Операции со списками покупок
        /*

public async Task<Item> GetItemAsync(string id)
{
    return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
}

public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
{
    return await Task.FromResult(items);
}
public async Task SetDataAsync(IEnumerable<Item> items)
{
    this.items = new List<Item>(items);
}
*/
    }
}