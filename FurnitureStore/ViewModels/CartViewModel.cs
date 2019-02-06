using FurnitureStore.Commands;
using FurnitureStore.Infrastructure.Services.Cart;
using FurnitureStore.ViewModels.Base;
using FurnitureStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static FurnitureStore.Infrastructure.Services.Cart.CartService;

namespace FurnitureStore.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private ObservableCollection<CartItem> _cartItems;
        private readonly ICartService _cartService;

        public ObservableCollection<CartItem> CartItems
        {
            get => _cartItems;
            set => SetValue(ref _cartItems, value);
        }

        public CartViewModel(ICartService cartService)
        {
            _cartItems = new ObservableCollection<CartItem>();
            _cartService = cartService;
        }

        public ICommand ClearShoppingCart => new Command(async () =>
        {
            _cartService.ClearCart();
            await Initialize();
        });

        public override Task<bool> Initialize()
        {
            CartItems = _cartService.GetCartItems().ToObservableCollection();

            return Task.FromResult(true);
        }

        public override Page GetPage()
        {
            return new CartView();
        }
    }
}
