using System.Collections.ObjectModel;

namespace System.Collections.Generic
{
    /// <summary>
    /// Defines an extensions method for generic collections.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Provides a IEnumerable to ObservableCollection conversion.
        /// </summary>
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
            return new ObservableCollection<TSource>(source);
        }
    }
}
