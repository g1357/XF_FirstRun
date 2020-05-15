using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    /// <summary>
    /// Сервис хранения данных.
    /// </summary>
    public class DataStore : IDataStore<Item>
    {
        private List<Item> items = null;

        public DataStore()
        {
            if (items != null) return;

            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 1", Text = "First item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 2", Text = "Second item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 3", Text = "Third item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 4", Text = "Fourth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 5", Text = "Fifth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 6", Text = "Sixth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 7", Text = "Seventh item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 8", Text = "Eighth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 9", Text = "Nineth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 10", Text = "Tenth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 11", Text = "Eleventh item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 12", Text = "Twelveth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 13", Text = "Thirteenth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 14", Text = "Fourteenth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 15", Text = "Fifteenth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 16", Text = "Sixteenth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 17", Text = "Seventeenth item", Notes="This is an item notes.", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Product 18", Text = "Eighteenth item", Notes="This is an item notes.", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task SetDataAsync(IEnumerable<Item> items)
        {
            this.items = new List<Item>(items);
        }

    }
}