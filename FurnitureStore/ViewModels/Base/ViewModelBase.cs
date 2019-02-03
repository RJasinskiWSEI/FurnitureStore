using System.Threading.Tasks;
using System.Windows.Controls;

namespace FurnitureStore.ViewModels.Base
{
    public abstract class ViewModelBase
    {
        public virtual Task<bool> Initialize()
        {
            return Task.FromResult(true);
        }

        public abstract Page GetPage();
    }
}
