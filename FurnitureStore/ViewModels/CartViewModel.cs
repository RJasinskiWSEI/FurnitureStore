using FurnitureStore.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FurnitureStore.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public override Page GetPage()
        {
            return new CartView();
        }
    }
}
