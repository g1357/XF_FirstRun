using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace XF_FirstRun.Helpers
{
    /// <summary>
    /// Операции с JSON
    /// </summary>
    public static class Json
    {
        /// <summary>
        /// Десериализация строки JSON в объект
        /// </summary>
        /// <typeparam name="T">Тп объекта</typeparam>
        /// <param name="json">Строка JSON</param>
        /// <returns>Десериализованный объект</returns>
        public static async Task<T> ToObjestAsync<T>(string json)
        {
            return await Task.Run<T>(() =>
            {
                return JsonSerializer.Deserialize<T>(json);
            });
        }
        /// <summary>
        /// Сериализация объекта в строку JSON
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Строка JSON</returns>
        public static async Task<string> FromObjectAsync(object obj)
        {
            return await Task.Run<string>(() =>
            {
                return JsonSerializer.Serialize(obj);
            });
        }
    }
}
