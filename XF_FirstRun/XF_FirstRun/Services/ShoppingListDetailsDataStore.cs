using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    public class ShoppingListDetailsDataStore : BaseDataStore<ShoppingListDetails>
    {
        public override async Task SetDemoDataAsync()
        {
            items = new List<ShoppingListDetails>();
            //{
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 1", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 2", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 3", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 4", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 5", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 6", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 7", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 8", Description="This is an item description." },
            //    new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 9", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 10", Text = "Tenth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 11", Text = "Eleventh item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 12", Text = "Twelveth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 13", Text = "Thirteenth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 14", Text = "Fourteenth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 15", Text = "Fifteenth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 16", Text = "Sixteenth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 17", Text = "Seventeenth item", Notes="This is an item notes.", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 18", Text = "Eighteenth item", Notes="This is an item notes.", Description="This is an item description." }
            //};
        }
    }
}