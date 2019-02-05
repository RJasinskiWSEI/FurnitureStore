using Autofac;
using FurnitureStore.Infrastructure.Exceptions;
using FurnitureStore.ViewModels;
using FurnitureStore.ViewModels.Base;
using FurnitureStore.Windows;
using FurnitureStore.Windows.Views;
using System.Threading.Tasks;

namespace FurnitureStore.Infrastructure.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IComponentContext _context;
        private readonly IMainPageController _mainPageController;


        public NavigationService(IComponentContext context, IMainPageController mainPageController)
        {
            _context = context;
            _mainPageController = mainPageController;
        }

        public Task Initialize()
        {
            var mainWindow = _context.Resolve<MainWindow>();

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

            var page = viewModel.GetPage();

            page.DataContext = viewModel;

            _mainPageController.LoadedPage = page;
        }

        public async Task NavigateToAsync<TViewModel, TNavParameter>(TNavParameter navParameter)
            where TViewModel : ViewModelBase, IInputData<TNavParameter>
        {
            var viewModel = _context.Resolve<TViewModel>();

            if (!await viewModel.Initialize() || !await viewModel.Initialize(navParameter))
            {
                throw new ControlNotInitializedException(nameof(TViewModel));
            }

            var page = viewModel.GetPage();

            page.DataContext = viewModel;

            _mainPageController.LoadedPage = page;
        }
    }
}
