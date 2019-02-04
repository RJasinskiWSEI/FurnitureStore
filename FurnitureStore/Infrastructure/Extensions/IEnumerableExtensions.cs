using System.Collections.ObjectModel;

namespace System.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
            return new ObservableCollection<TSource>(source);
        }
    }
}
