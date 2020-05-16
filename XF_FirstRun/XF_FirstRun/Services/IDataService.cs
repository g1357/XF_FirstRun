using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XF_FirstRun.Services
{
    /// <summary>
    /// Интерфейс хранилища данных
    /// </summary>
    /// <typeparam name="T">Тип элемента</typeparam>
    public interface IDataService<T>
    {
        /// <summary>
        /// Получение данных из локаньного файла или в вёб-сервис
        /// </summary>
        /// <returns>Перечисление данных</returns>
        Task<IEnumerable<T>> GetDataAsync();

        /// <summary>
        /// Сохранение данных в локаньном файле или в вёб-сервисе
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<bool> SaveDataAsync(IEnumerable<T> items);

        /// <summary>
        /// Добавить элемент в хранилище
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Успешность операции</returns>
        Task<bool> AddItemAsync(T item);

        /// <summary>
        /// Обновить элемент в хранилище
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Успешность операции</returns>
        Task<bool> UpdateItemAsync(T item);

        /// <summary>
        /// Удалить элемент из хранилища
        /// </summary>
        /// <param name="id">Элемент</param>
        /// <returns>Успешность операции</returns>
        Task<bool> DeleteItemAsync(string id);

        /// <summary>
        /// Получить элемент из хранилища
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Успешность операции</returns>
        Task<T> GetItemAsync(string id);

        /// <summary>
        /// Получить все элементы из хранилища
        /// </summary>
        /// <param name="forceRefresh">Принудительное обновление</param>
        /// <returns>Перечисление элементов</returns>
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        /// <summary>
        /// Установка данных
        /// </summary>
        /// <param name="items">Перечисление элементов</param>
        /// <returns>нет</returns>
        Task SetDataAsync(IEnumerable<T> items);
    }
}
