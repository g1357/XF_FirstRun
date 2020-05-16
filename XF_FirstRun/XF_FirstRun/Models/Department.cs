using System;
using System.Collections.Generic;
using System.Text;

namespace XF_FirstRun.Models
{
    /// <summary>
    /// Отдел магазина
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание отдела
        /// </summary>
        public string Description { get; set; }
    }
}
