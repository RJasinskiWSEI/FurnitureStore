using Autofac;
using FurnitureStore.Infrastructure.Exceptions;
using FurnitureStore.Models.Interfaces;
using FurnitureStore.ViewModels;
using FurnitureStore.ViewModels.Base;
using System.Threading.Tasks;

namespace FurnitureStore.Services.Navigation
{
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

        public Task Initialize()
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

            if (!await viewModel.Initialize())
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

            if (!await viewModel.Initialize() || !await viewModel.Initialize(navParameter))
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
