using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    /// <summary>
    /// Сервис хранения данных.
    /// </summary>
    public class DataStore //: IDataStore<Item>
    {
        public ShoppingListDataStore ShoppingList { get; private set; }
        public ShoppingListDetailsDataStore ShppingListDetails { get; private set; }

        public DataStore()
        {
            ShoppingList = new ShoppingListDataStore();
            ShppingListDetails = new ShoppingListDetailsDataStore();
        }
    }
}