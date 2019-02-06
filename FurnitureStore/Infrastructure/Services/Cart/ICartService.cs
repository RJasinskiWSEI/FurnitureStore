using FurnitureStore.Infrastructure.Services.FurnitureItems;
using System.Collections.Generic;
using static FurnitureStore.Infrastructure.Services.Cart.CartService;

namespace FurnitureStore.Infrastructure.Services.Cart
{
    public interface ICartService
    {
        IReadOnlyList<CartItem> GetCartItems();
        void AddItem(FurnitureItem item);
        void RemoveItem(FurnitureItem item);
        decimal GetTotalCost();
        bool Checkout();
        void ClearCart();
    }
}
