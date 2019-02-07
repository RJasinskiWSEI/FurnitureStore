using FurnitureStore.Models;
using FurnitureStore.Services.FurnitureItems;
using FurnitureStore.ViewModels.Base;
using System.Threading.Tasks;

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

        public override string GetDefaultPageName()
        {
            return "FurnitureItemPreviewView";
        }

        #endregion
    }
}
