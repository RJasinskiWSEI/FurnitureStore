using FurnitureStore.Commands;
using FurnitureStore.Infrastructure.Services.Cart;
using FurnitureStore.Infrastructure.Services.FurnitureItems;
using FurnitureStore.Infrastructure.Services.Navigation;
using FurnitureStore.ViewModels.Base;
using FurnitureStore.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FurnitureStore.ViewModels
{
    public class CategoryContentViewModel : ViewModelBase, IInputData<FurnitureCategory>
    {
        private readonly IFurnitureItemsService _furnitureItemsService;
        private readonly INavigationService _navigationService;
        private readonly ICartService _cartService;

        #region Bindings

        private ObservableCollection<FurnitureItem> _items;

        public ObservableCollection<FurnitureItem> Items
        {
            get { return _items; }
            set
            {
                SetValue(ref _items, value);
            }
        }

        private FurnitureItem _selectedItem;

        public FurnitureItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetValue(ref _selectedItem, value);
            }
        }

        public ICommand OpenFurnitureItemPreviewCommand => new Command<int>((furnitureItemId) => _navigationService.NavigateToAsync<FurnitureItemPreviewViewModel, int>(furnitureItemId));
        public ICommand BuyItemCommand => new Command(() =>
        {
            if (SelectedItem == null)
                return;

            _cartService.AddItem(SelectedItem);
        });

        #endregion

        public CategoryContentViewModel(
            IFurnitureItemsService furnitureItemsService,
            INavigationService navigationService,
            ICartService cartService)
        {
            Items = new ObservableCollection<FurnitureItem>();

            _furnitureItemsService = furnitureItemsService;
            _navigationService = navigationService;
            _cartService = cartService;
        }

        public async Task<bool> Initialize(FurnitureCategory category)
        {
            Items = (await _furnitureItemsService.GetFurnitureItems(category)).ToObservableCollection();

            return true;
        }

        #region ViewModelBase Implementations

        public override Page GetPage()
        {
            return new CategoryContentView();
        }

        #endregion
    }
}
