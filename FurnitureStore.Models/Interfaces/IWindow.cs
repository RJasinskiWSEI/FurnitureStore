namespace FurnitureStore.Models.Interfaces
{
    /// <summary>
    /// Defines an ApplicationMainWindow.
    /// </summary>
    public interface IMainWindow
    {
        /// <summary>
        /// Bindable data context.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        /// Shows main application window.
        /// </summary>
        void Show();

        /// <summary>
        /// Sets currently visible page of the application.
        /// </summary>
        /// <param name="page"></param>
        void LoadPage(object page);
    }
}
