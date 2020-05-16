using System;

namespace XF_FirstRun.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Примечания к товару
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Товар куплен
        /// </summary>
        public bool Bought { get; set; }

        /// <summary>
        /// Товар отсутствует
        /// </summary>
        public bool Absent { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Item()
        {
            Id = Guid.NewGuid().ToString();
            Bought = false;
            Absent = false;
        }
    }
}