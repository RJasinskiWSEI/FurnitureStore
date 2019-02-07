using FurnitureStore.ViewModels.Base;
using System.Threading.Tasks;

namespace FurnitureStore.Services.Navigation
{
    public interface INavigationService
    {
        Task Initialize();

        Task NavigateToAsync<TViewModel>()
            where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel, TNavParameter>(TNavParameter navParameter)
            where TViewModel : ViewModelBase, IInputData<TNavParameter>;
    }
}
