using Autofac;
using FurnitureStore.Models.Interfaces;
using FurnitureStore.Services;
using FurnitureStore.Services.Cart;
using FurnitureStore.Services.FurnitureItems;
using FurnitureStore.Services.Navigation;
using FurnitureStore.ViewModels;
using FurnitureStore.Windows.Views;
using System;

namespace FurnitureStore.Windows.IoC
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
            builder.RegisterType<CategoryContentViewModel>().AsSelf();
            builder.RegisterType<FurnitureItemPreviewViewModel>().AsSelf();
        }
    }

    public class StartupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>()
                .AsSelf()
                .As<IMainWindow>()
                .SingleInstance();

            builder.RegisterType<CartService>()
                .As<ICartService>()
                .SingleInstance();

            builder.RegisterType<PageResolver>()
                .As<IPageResolver>();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>();

            builder.RegisterType<FurnitureItemsService>()
                .As<IFurnitureItemsService>();
        }
    }
}
