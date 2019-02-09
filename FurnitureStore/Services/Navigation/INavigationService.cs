using FurnitureStore.ViewModels.Base;
using System.Threading.Tasks;

namespace FurnitureStore.Services.Navigation
{
    /// <summary>
    /// Defines internal application navigation based on ViewModels.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Initializes application navigation and sets first page.
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Navigates onto ViewModel's type page.
        /// </summary>
        Task NavigateToAsync<TViewModel>()
            where TViewModel : ViewModelBase;

        /// <summary>
        /// Navigates onto ViewModel's type page and initializes it with provided parameter.
        /// </summary>
        Task NavigateToAsync<TViewModel, TNavParameter>(TNavParameter navParameter)
            where TViewModel : ViewModelBase, IInputData<TNavParameter>;
    }
}
