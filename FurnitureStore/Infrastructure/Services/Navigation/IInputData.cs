using System.Threading.Tasks;

namespace FurnitureStore.Infrastructure.Services.Navigation
{
    public interface IInputData<TNavParameter>
    {
        Task<bool> Initialize(TNavParameter navigationParameter);
    }
}
