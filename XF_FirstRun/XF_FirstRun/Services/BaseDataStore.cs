using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    public class BaseDataStore<T> where T : IItem // : IBaseDataStore<T>
    {
        private List<T> items = null;

        public BaseDataStore()
        {
        }

        public async Task<bool> AddAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            var oldItem = items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where((T arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task SetDataAsync(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

    }
}