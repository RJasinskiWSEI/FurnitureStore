namespace FurnitureStore.Models.Interfaces
{
    /// <summary>
    /// Defines an Bindable Page resolver.
    /// </summary>
    public interface IPageResolver
    {
        /// <summary>
        /// Resolves bindable page of provided type name.
        /// </summary>
        IPage ResolvePage(string pageTypeName);
    }
}
