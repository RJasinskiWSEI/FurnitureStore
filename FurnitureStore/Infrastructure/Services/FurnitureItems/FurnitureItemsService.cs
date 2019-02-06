using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FurnitureStore.Infrastructure.Services.FurnitureItems
{
    public class FurnitureItemsService : IFurnitureItemsService
    {
        private static readonly Dictionary<int, FurnitureItem> _furnitureItems;

        static FurnitureItemsService()
        {
            var serializer = new XmlSerializer(typeof(FurnitureItemsList));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "furniture_items.xml");
            
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var furnitures = (FurnitureItemsList)serializer.Deserialize(reader);

                    _furnitureItems = furnitures.FurnitureItems.ToDictionary(obj => obj.Id, obj => obj);
                }
            }
            catch (Exception ex)
            {
                //
            }
        }


        // In real App downloaded by REST Request or direct DB connection (not recommended in my opinion)
        public Task<IEnumerable<FurnitureItem>> GetFurnitureItems(FurnitureCategory category)
        {
            var categoryItems = _furnitureItems.Where(x => x.Value.Category == category).Select(x => x.Value);

            return Task.FromResult(categoryItems);
        }

        public Task<FurnitureItem> GetFurnitureItem(int furnitureItemId)
        {
            if (_furnitureItems.ContainsKey(furnitureItemId))
            {
                return Task.FromResult(_furnitureItems[furnitureItemId]);
            }

            throw new NullReferenceException($"Mebel o identyfikatorze {furnitureItemId} nie został znaleziony.");
        }
    }
}
