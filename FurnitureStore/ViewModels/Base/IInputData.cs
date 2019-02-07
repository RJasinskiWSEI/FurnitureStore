using System.Threading.Tasks;

namespace FurnitureStore.ViewModels.Base
{
    public interface IInputData<TNavParameter>
    {
        Task<bool> Initialize(TNavParameter navigationParameter);
    }
}
