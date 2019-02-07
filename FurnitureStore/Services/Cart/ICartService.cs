using FurnitureStore.Models;
using System.Collections.Generic;

namespace FurnitureStore.Services.Cart
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
