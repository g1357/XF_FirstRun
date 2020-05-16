using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XF_FirstRun.Services;

namespace XF_FirstRun.Models
{
    /// <summary>
    /// Сптсок покупок
    /// </summary>
    public class ShoppingList : IItem
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

        /// <summary>
        /// Идентификатор детфльной информации
        /// </summary>
        public string DetailsId { get; set; }

        /// <summary>
        /// Список покупок
        /// </summary>
        [JsonIgnore]
        public List<Item> Items { get; set; }

        /// <summary>
        /// Конмтруктор класса
        /// </summary>
        public ShoppingList()
        {
            Id = Guid.NewGuid().ToString();
            DetailsId = string.Empty;
        }
    }
}
