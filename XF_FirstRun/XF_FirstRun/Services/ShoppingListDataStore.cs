using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XF_FirstRun.Models;

namespace XF_FirstRun.Services
{
    public class ShoppingListDataStore : BaseDataStore<ShoppingList>
    {
        public override Task SetDemoDataAsync()
        {
            return Task.Run(() =>
           {
               items = new List<ShoppingList>()
           {
                new ShoppingList { Name = "Еженедельные покупки в МЕТРО", Description="Закупка продуктов на неделю." },
                new ShoppingList { Name = "Покупки для офиса", Description="Хозяйственные и другие покупки для офиса." },
                new ShoppingList { Name = "Покупки продуктов для Миши", Description="Покупки продуктов для Миши в МЕТРО." },
                new ShoppingList { Name = "Покупки продуктов для Саши", Description="Покупки для Саши в МЕТРО + Н.С." },
                new ShoppingList { Name = "Покупки расходных материалов для дома", Description="Покупки расходных материалов для дома" },
                new ShoppingList { Name = "Покупки подарков", Description="Идеи подарков для родных и близких." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 7", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 8", Description="This is an item description." },
                //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 9", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 10", Text = "Tenth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 11", Text = "Eleventh item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 12", Text = "Twelveth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 13", Text = "Thirteenth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 14", Text = "Fourteenth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 15", Text = "Fifteenth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 16", Text = "Sixteenth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 17", Text = "Seventeenth item", Notes="This is an item notes.", Description="This is an item description." },
                   //new ShoppingList { Id = Guid.NewGuid().ToString(), Name = "Product 18", Text = "Eighteenth item", Notes="This is an item notes.", Description="This is an item description." }
               };
           });
        }
    }
}