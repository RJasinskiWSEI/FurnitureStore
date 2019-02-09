using FurnitureStore.Commands;
using FurnitureStore.Models;
using FurnitureStore.Services.Navigation;
using FurnitureStore.ViewModels.Base;
using System.Windows.Input;

namespace FurnitureStore.ViewModels
{
    /// <summary>
    /// Defines logic for the Main Application Page.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand OpenCartCommand => new Command(() => _navigationService.NavigateToAsync<CartViewModel>());

        public ICommand OpenCategoryCommand => new Command<FurnitureCategory>((parameter) => _navigationService.NavigateToAsync<CategoryContentViewModel, FurnitureCategory>(parameter));
        
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public override string GetDefaultPageName()
        {
            return "GetPageTypeName";
        }
    }
}
