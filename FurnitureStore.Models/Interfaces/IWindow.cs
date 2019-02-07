namespace FurnitureStore.Models.Interfaces
{
    public interface IMainWindow
    {
        object DataContext { get; set; }

        void Show();

        void LoadPage(object page);
    }
}
