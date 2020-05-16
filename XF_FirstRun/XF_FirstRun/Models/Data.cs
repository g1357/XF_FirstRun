using System;
using System.Collections.Generic;
using System.Text;

namespace XF_FirstRun.Models
{
    /// <summary>
    /// Данные приложения
    /// </summary>
    public class Data
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

        /// <summary>
        /// Товары
        /// </summary>
        public List<ShoppingListDetails> Details { get; set; }

        /// <summary>
        /// Словарь деиальной информации для списков покупок
        /// </summary>
        public Dictionary<string, List<Item>> DetailsDictionary { get; set; }
    }
}
