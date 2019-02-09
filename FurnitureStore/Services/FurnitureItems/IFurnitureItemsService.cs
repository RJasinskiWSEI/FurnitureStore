using FurnitureStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureStore.Services.FurnitureItems
{
    /// <summary>
    /// Defines an repository for managing furniture items data.
    /// </summary>
    public interface IFurnitureItemsService
    {
        /// <summary>
        /// Gets furniture items from category with provided type.
        /// </summary>
        Task<IEnumerable<FurnitureItem>> GetFurnitureItems(FurnitureCategory category);

        /// <summary>
        /// Gets the FurnitureItem of specified ID.
        /// </summary>
        Task<FurnitureItem> GetFurnitureItem(int furnitureItemId);
    }
}
