using FurnitureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureStore.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cartItems;

        public CartService()
        {
            _cartItems = new List<CartItem>();
        }

        #region ICartService Implementation

        public IReadOnlyList<CartItem> GetCartItems()
        {
            return (new List<CartItem>(_cartItems)).AsReadOnly();
        }

        public void AddItem(FurnitureItem item)
        {
            var cartItem = FindByFurnitureItem(item);

            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                _cartItems.Add(new CartItem { Item = item });
            }
        }

        public void RemoveItem(FurnitureItem item)
        {
            var cartItem = FindByFurnitureItem(item);

            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }
        }

        public decimal GetTotalCost()
        {
            return _cartItems.Sum(x => x.Count * x.Item.Price);
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public bool Checkout()
        {
            throw new NotImplementedException();
        }

        #endregion

        private CartItem FindByFurnitureItem(FurnitureItem item)
        {
            var furnitureItem = _cartItems.FirstOrDefault(x => x.Item.Equals(item));

            return furnitureItem;
        }
    }
}
