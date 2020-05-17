using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    /// <summary>
    /// Базовый сервис хранения даггых
    /// </summary>
    /// <typeparam name="T">Класс модели</typeparam>
    abstract public class BaseDataStore<T> : IBaseDataStore<T> where T : IItem
    {
        /// <summary>
        /// Список элементов
        /// </summary>
        internal List<T> items = null;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public BaseDataStore()
        {
        }

        /// <summary>
        /// Асинхронное добавление элемента в конец списока
        /// </summary>
        /// <param name="item">Новый элемент</param>
        /// <returns>Успешность операции</returns>
        public async Task<bool> AddItemAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Обновление элемнта списка 
        /// </summary>
        /// <param name="item">Обновлённый элемент</param>
        /// <returns>Успешность операции</returns>
        public async Task<bool> UpdateItemAsync(T item)
        {
            //var oldItem = items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            //items.Add(item);
            bool result = false;
            var index = items.FindIndex((T arg) => arg.Id == item.Id);
            if (index >= 0)
            {
                items[index] = item;
                result = true;
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Успешность операции</returns>
        public async Task<bool> DeleteItemAsync(string id)
        {
            bool result = false;
            var oldItem = items.Where((T arg) => arg.Id == id).FirstOrDefault();
            if (oldItem != null)
            {
                items.Remove(oldItem);
                result = true;
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Получуние элемента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Элемент</returns>
        public async Task<T> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Получение всех элементов списка
        /// </summary>
        /// <param name="forceRefresh">Принудительное обнос=вление</param>
        /// <returns>Список элементов</returns>
        public async Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        /// <summary>
        /// Установка нового списока элементов
        /// </summary>
        /// <param name="items">Все элементы</param>
        /// <returns>Успешность операции</returns>
        public async Task<bool> SetDataAsync(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Перемещение элемента на один вверх
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Перемещение успешно выполнено</returns>
        public async Task<bool> MoveItemUpAsync(T item)
        {
            return await Task.Run(() =>
            {
                bool result = false;
                var index = items.FindIndex((T arg) => arg.Id == item.Id);
                if (index > 0)
                {
                    T tempItem = items[index - 1];
                    items[index - 1] = items[index];
                    items[index] = tempItem;
                    result = true;
                }
                return result;
            });
        }

        /// <summary>
        /// Перемещение элемента на один вниз
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Перемещение успешно выполнено</returns>
        public async Task<bool> MovItemDownAsync(T item)
        {
            return await Task.Run(() =>
            {
                bool result = false;
                var index = items.FindIndex((T arg) => arg.Id == item.Id);
                if (index >= 0 && index < items.Count - 2)
                {
                    T tempItem = items[index + 1];
                    items[index + 1] = items[index];
                    items[index] = tempItem;
                    result = true;
                }
                return result;
            });
        }

        abstract public Task SetDemoDataAsync();
    }
}