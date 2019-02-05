using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureStore.Infrastructure.Services.FurnitureItems
{
    public interface IFurnitureItemsService
    {
        Task<IEnumerable<FurnitureItem>> GetFurnitureItems(FurnitureCategory category);

        Task<FurnitureItem> GetFurnitureItem(int furnitureItemId);
    }

    public class FurnitureItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public FurnitureCategory Category { get; set; }
    }

    // In real App should be domain model, not enum
    public enum FurnitureCategory
    {
        Office = 0,
        Kitchen = 1,
        Bathroom = 2,
        Garden = 3,
        LivingRoom = 4
    }
}
