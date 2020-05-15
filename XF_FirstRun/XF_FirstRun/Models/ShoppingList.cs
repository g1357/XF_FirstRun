using System;
using System.Collections.Generic;
using System.Text;

namespace XF_FirstRun.Models
{
    /// <summary>
    /// Сптсок покупок
    /// </summary>
    public class ShoppingList
    {
        /// <summary>
        /// Идентификатор списка
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Название списка
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Примечания к списку
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Описание списка
        /// </summary>
        public string Description { get; set; }
    }
}
