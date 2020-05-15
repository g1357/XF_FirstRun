﻿using System;

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
    }
}