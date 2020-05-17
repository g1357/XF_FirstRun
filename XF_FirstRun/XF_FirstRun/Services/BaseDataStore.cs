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
    public class BaseDataStore<T> where T : IItem // : IBaseDataStore<T>
    {
        /// <summary>
        /// Список элементов
        /// </summary>
        private List<T> items = null;

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
        public async Task<bool> AddAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Обновление элемнта списка 
        /// </summary>
        /// <param name="item">Обновлённый элемент</param>
        /// <returns>Успешность операции</returns>
        public async Task<bool> UpdateAsync(T item)
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
        public async Task<bool> DeleteAsync(string id)
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
        public async Task<T> GetAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Получение всех элементов списка
        /// </summary>
        /// <param name="forceRefresh">Принудительное обнос=вление</param>
        /// <returns>Список элементов</returns>
        public async Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        /// <summary>
        /// Установить весь список элементов
        /// </summary>
        /// <param name="items">Все элементы</param>
        /// <returns>Успешность операции</returns>
        public async Task<bool> SetAsync(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            return await Task.FromResult(true);
        }

    }
}