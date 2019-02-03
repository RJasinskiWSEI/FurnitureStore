using Autofac;
using FurnitureStore.Infrastructure.Services.Navigation;
using FurnitureStore.ViewModels;
using FurnitureStore.Windows;
using System;

namespace FurnitureStore.Infrastructure.IoC
{
    public static class DependencyLocator
    {
        private static bool _initialized;
        private static IContainer _container;

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ViewModelsModule>();
            builder.RegisterModule<StartupModule>();

            _container = builder.Build();
            
            _initialized = true;
        }

        public static TService Resolve<TService>()
            where TService : class
        {
            if (!_initialized) { throw new NullReferenceException("Container was not initialized."); }

            return _container.Resolve<TService>();
        }
    }

    public class ViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<CartViewModel>().AsSelf();
        }
    }

    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>()
                .AsSelf()
                .As<IMainPageController>()
                .SingleInstance();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>();
        }
    }
}
