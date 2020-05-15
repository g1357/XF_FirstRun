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
        public Unit[] Units { get; set; }
        /// <summary>
        /// Отделы
        /// </summary>
        public Department[] Departments { get; set; }
        /// <summary>
        /// Списки покупок
        /// </summary>
        public ShoppingList[] ShoopingLists { get; set; }
        /// <summary>
        /// Товары
        /// </summary>
        public Item[] Items { get; set; }
    }
}
