using FurnitureStore.Models;
using System.Collections.Generic;

namespace FurnitureStore.Services.Cart
{
    /// <summary>
    /// Defines a service which provides accesibility to buy furniture items.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets items added to shopping cart.
        /// </summary>
        IReadOnlyList<CartItem> GetCartItems();

        /// <summary>
        /// Adds provided item to the shopping cart.
        /// </summary>
        void AddItem(FurnitureItem item);

        /// <summary>
        /// Removes provided item from shopping cart
        /// </summary>
        void RemoveItem(FurnitureItem item);

        /// <summary>
        /// Gets total cost of items added to the shopping cart.
        /// </summary>
        decimal GetTotalCost();

        /// <summary>
        /// Generated PDF Invoice for items added to the shopping cart.
        /// </summary>
        bool Checkout();

        /// <summary>
        /// Clears the shopping cart.
        /// </summary>
        void ClearCart();
    }
}
