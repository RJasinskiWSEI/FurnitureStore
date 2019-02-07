using FurnitureStore.Models.Interfaces;
using System.Windows.Controls;

namespace FurnitureStore.Windows.Views
{
    /// <summary>
    /// Interaction logic for CategoryContentView.xaml
    /// </summary>
    public partial class CategoryContentView : Page, IPage
    {
        public CategoryContentView()
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
