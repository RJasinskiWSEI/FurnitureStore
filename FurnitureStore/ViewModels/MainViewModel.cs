using FurnitureStore.Commands;
using FurnitureStore.Infrastructure.Services.Navigation;
using FurnitureStore.ViewModels.Base;
using System.Windows.Controls;
using System.Windows.Input;

namespace FurnitureStore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand OpenCartCommand => new Command(() => _navigationService.NavigateToAsync<CartViewModel>());


        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public override Page GetPage()
        {
            return null;
        }
    }
}
