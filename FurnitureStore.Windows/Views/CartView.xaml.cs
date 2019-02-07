using FurnitureStore.Models.Interfaces;
using System.Windows.Controls;

namespace FurnitureStore.Windows.Views
{
    /// <summary>
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : Page, IPage
    {
        public CartView()
        {
            InitializeComponent();
        }

        #region IPage Implementation

        public void SetDataContext(object dataContext)
        {
            DataContext = dataContext;
        }

        #endregion
    }
}
