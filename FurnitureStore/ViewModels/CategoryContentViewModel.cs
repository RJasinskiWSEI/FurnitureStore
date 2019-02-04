using FurnitureStore.Commands;
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
        private readonly IFurnitureItemsService _furnitureItemsService;
        private readonly INavigationService _navigationService;

        public FurnitureItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetValue(ref _selectedItem, value);
            }
        }

        public ICommand OpenFurnitureItemPreviewCommand => new Command<int>((furnitureItemId) => _navigationService.NavigateToAsync<FurnitureItemPreviewViewModel, int>(furnitureItemId));

        #endregion

        public CategoryContentViewModel(
            IFurnitureItemsService furnitureItemsService,
            INavigationService navigationService)
        {
            Items = new ObservableCollection<FurnitureItem>();

            _furnitureItemsService = furnitureItemsService;
            _navigationService = navigationService;
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
