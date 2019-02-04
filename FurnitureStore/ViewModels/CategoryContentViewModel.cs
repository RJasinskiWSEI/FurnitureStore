using FurnitureStore.Infrastructure.Services.FurnitureItems;
using FurnitureStore.Infrastructure.Services.Navigation;
using FurnitureStore.ViewModels.Base;
using FurnitureStore.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public FurnitureItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetValue(ref _selectedItem, value);
            }
        }
        
        #endregion

        public CategoryContentViewModel(IFurnitureItemsService furnitureItemsService)
        {
            Items = new ObservableCollection<FurnitureItem>();

            _furnitureItemsService = furnitureItemsService;
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
