using System;
using System.Collections.Generic;
using System.Text;
using XF_FirstRun.Services;

namespace XF_FirstRun.Models
{
    
    /// <summary>
    /// Детальная информация о списке покупок
    /// </summary>
    public class ShoppingListDetails : IItem
    {
        /// <summary>
        /// Идентификатор дектальной информации
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Список товаров
        /// </summary>
        public List<Item> ListItems { get; set; }
    }
}
