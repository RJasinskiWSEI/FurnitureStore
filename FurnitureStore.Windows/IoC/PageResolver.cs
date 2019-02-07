using FurnitureStore.Models.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace FurnitureStore.Windows.IoC
{
    public class PageResolver : IPageResolver
    {
        public IPage ResolvePage(string pageTypeName)
        {
            var pageFullName = string.Concat(GetViewsNamespace(), pageTypeName);

            var pageType = Type.GetType(pageFullName);

            if (pageType == null)
                throw new NotSupportedException($"Page of type {pageTypeName} not found.");

            var pageInstance = Activator.CreateInstance(pageType);
            if (!pageInstance.GetType().GetInterfaces().Contains(typeof(IPage)))
                throw new NotSupportedException($"{pageTypeName} not implements IPage interface.");

            return (IPage)pageInstance;
        }

        private string GetViewsNamespace()
        {
            var baseNamespace = this.GetType().Namespace.Remove(this.GetType().Namespace.IndexOf("IoC"));

            baseNamespace += "Views.";

            return baseNamespace;
        }
    }
}
