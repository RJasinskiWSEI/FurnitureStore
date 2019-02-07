using FurnitureStore.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace FurnitureStore.Windows.Converters
{
    public class CartItemsSumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<CartItem> cartItems)
            {
                return cartItems.Sum(x => x.Count * x.Item.Price); // OR inject ICartService and get value through method
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
