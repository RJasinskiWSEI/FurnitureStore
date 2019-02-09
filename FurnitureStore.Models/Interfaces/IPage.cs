namespace FurnitureStore.Models.Interfaces
{
    /// <summary>
    /// Defines an bindable page.
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// Bind provided context to page.
        /// </summary>
        void SetDataContext(object dataContext);
    }
}
