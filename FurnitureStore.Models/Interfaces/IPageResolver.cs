namespace FurnitureStore.Models.Interfaces
{
    public interface IPageResolver
    {
        IPage ResolvePage(string pageTypeName);
    }
}
