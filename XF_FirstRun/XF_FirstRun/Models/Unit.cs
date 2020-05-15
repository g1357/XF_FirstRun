using System;
using System.Collections.Generic;
using System.Text;

namespace XF_FirstRun.Models
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Идентификатор единицы измерения
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Сокращение единицы измерения
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Полное наименование единицы измерения
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Описание единицы измерения
        /// </summary>
        public string Description { get; set; }
    }
}
