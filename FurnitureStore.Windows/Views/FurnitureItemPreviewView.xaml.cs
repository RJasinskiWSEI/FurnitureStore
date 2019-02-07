using FurnitureStore.Models.Interfaces;
using System.Windows.Controls;

namespace FurnitureStore.Windows.Views
{
    /// <summary>
    /// Interaction logic for FurnitureItemPreviewView.xaml
    /// </summary>
    public partial class FurnitureItemPreviewView : Page, IPage
    {
        public FurnitureItemPreviewView()
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
