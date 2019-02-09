using System.Threading.Tasks;

namespace FurnitureStore.ViewModels.Base
{
    /// <summary>
    /// Provides strongly typed navigation parameter for navigation.
    /// </summary>
    public interface IInputData<TNavParameter>
    {
        /// <summary>
        /// Initializes ViewModel with provided strongly typed parameter.
        /// </summary>
        Task<bool> InitializeAsync(TNavParameter navigationParameter);
    }
}
