using FurnitureStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureStore.Services.FurnitureItems
{
    public interface IFurnitureItemsService
    {
        Task<IEnumerable<FurnitureItem>> GetFurnitureItems(FurnitureCategory category);

        Task<FurnitureItem> GetFurnitureItem(int furnitureItemId);
    }
}
