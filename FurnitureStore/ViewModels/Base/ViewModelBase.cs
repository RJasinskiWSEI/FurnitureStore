using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FurnitureStore.ViewModels.Base
{
    /// <summary>
    /// Defines an abstract class for ViewModels which provides basic functionallity and implements INotifyPropertyChanged.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        /// <summary>
        /// Initializes ViewModel and returns boolean initialization result.
        /// </summary>
        public virtual Task<bool> InitializeAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Gets the name of default page associated to this ViewModel type.
        /// </summary>
        public abstract string GetDefaultPageName();

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets value of the specified ViewModel field.
        /// Raises PropertyChanged when value changed.
        /// </summary>
        protected void SetValue<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        } 

        #endregion
    }
}
