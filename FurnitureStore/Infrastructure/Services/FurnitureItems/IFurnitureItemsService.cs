using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureStore.Infrastructure.Services.FurnitureItems
{
    public interface IFurnitureItemsService
    {
        Task<IEnumerable<FurnitureItem>> GetFurnitureItems(FurnitureCategory category);
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
        Corners = 0,
        Beds = 1,
        Dressing = 2,
        Tables = 3,
        Shelfs = 4,
        Chairs = 5
    }
}
