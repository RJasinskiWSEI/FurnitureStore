namespace FurnitureStore.Models
{
    public class CartItem
    {
        public FurnitureItem Item { get; set; }

        public int Count { get; set; } = 1;
    }
}
