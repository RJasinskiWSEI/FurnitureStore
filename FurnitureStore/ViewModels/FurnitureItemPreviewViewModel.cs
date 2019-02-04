using FurnitureStore.Infrastructure.Services.FurnitureItems;
using FurnitureStore.Infrastructure.Services.Navigation;
using FurnitureStore.ViewModels.Base;
using FurnitureStore.Views;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FurnitureStore.ViewModels
{
    public class FurnitureItemPreviewViewModel : ViewModelBase, IInputData<int>
    {
        private readonly IFurnitureItemsService _furnitureItemsService;

        #region Bindings

        private FurnitureItem _furnitureItem;
        public FurnitureItem FurnitureItem
        {
            get => _furnitureItem;
            set
            {
                SetValue(ref _furnitureItem, value);
            }
        } 

        #endregion

        public FurnitureItemPreviewViewModel(IFurnitureItemsService furnitureItemsService)
        {
            _furnitureItemsService = furnitureItemsService;
        }

        #region IInputData<int> Implementation

        public async Task<bool> Initialize(int furnitureItemId)
        {
            FurnitureItem = await _furnitureItemsService.GetFurnitureItem(furnitureItemId);

            return true;
        }

        #endregion

        #region ViewModelBase Implementation

        public override Page GetPage()
        {
            return new FurnitureItemPreviewView();
        }

        #endregion
    }
}
