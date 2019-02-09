using Autofac;
using FurnitureStore.Infrastructure.Exceptions;
using FurnitureStore.Models.Interfaces;
using FurnitureStore.ViewModels;
using FurnitureStore.ViewModels.Base;
using System.Threading.Tasks;

namespace FurnitureStore.Services.Navigation
{
    /// <summary>
    /// Provides the INavigationService implementation.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly IComponentContext _context;
        private readonly IPageResolver _pageResolver;
        private readonly IMainWindow _mainWindow;

        public NavigationService(IComponentContext context, IMainWindow mainWindow, IPageResolver pageResolver)
        {
            _context = context;
            _mainWindow = mainWindow;
            _pageResolver = pageResolver;
        }

        public Task InitializeAsync()
        {
            var mainWindow = _context.Resolve<IMainWindow>();

            mainWindow.DataContext = _context.Resolve<MainViewModel>();
            mainWindow.Show();

            return Task.CompletedTask;
        }

        public async Task NavigateToAsync<TViewModel>()
            where TViewModel : ViewModelBase
        {
            var viewModel = _context.Resolve<TViewModel>();

            if (!await viewModel.InitializeAsync())
            {
                throw new ControlNotInitializedException(nameof(TViewModel));
            }

            var pageTypeName = viewModel.GetDefaultPageName();
            var page = _pageResolver.ResolvePage(pageTypeName);

            page.SetDataContext(viewModel);

            _mainWindow.LoadPage(page);
        }

        public async Task NavigateToAsync<TViewModel, TNavParameter>(TNavParameter navParameter)
            where TViewModel : ViewModelBase, IInputData<TNavParameter>
        {
            var viewModel = _context.Resolve<TViewModel>();

            if (!await viewModel.InitializeAsync() || !await viewModel.InitializeAsync(navParameter))
            {
                throw new ControlNotInitializedException(nameof(TViewModel));
            }

            var pageTypeName = viewModel.GetDefaultPageName();
            var page = _pageResolver.ResolvePage(pageTypeName);

            page.SetDataContext(viewModel);

            _mainWindow.LoadPage(page);
        }
    }
}
