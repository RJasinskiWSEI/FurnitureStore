using FurnitureStore.Services.Navigation;
using FurnitureStore.Windows.IoC;
using System.Windows;

namespace FurnitureStore.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeIoC();
            InitializeNavigation();

            base.OnStartup(e);
        }

        private void InitializeIoC()
        {
            DependencyLocator.Initialize();
        }

        private async void InitializeNavigation()
        {
            var navigation = DependencyLocator.Resolve<INavigationService>();

            await navigation.Initialize();
        }
    }
}
