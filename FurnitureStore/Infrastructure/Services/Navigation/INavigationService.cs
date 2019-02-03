using FurnitureStore.ViewModels.Base;
using System.Threading.Tasks;

namespace FurnitureStore.Infrastructure.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>()
            where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel, TNavParameter>(TNavParameter navParameter)
            where TViewModel : ViewModelBase, IInputData<TNavParameter>;
    }
}
