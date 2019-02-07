using FurnitureStore.Commands;
using FurnitureStore.Models;
using FurnitureStore.Services.Cart;
using FurnitureStore.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public override string GetDefaultPageName()
        {
            return "CartView";
        }
    }
}
