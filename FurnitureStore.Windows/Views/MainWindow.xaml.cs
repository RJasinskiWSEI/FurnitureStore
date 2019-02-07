using FurnitureStore.Models.Interfaces;
using System.Windows;

namespace FurnitureStore.Windows.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region IMainWindow Implementation

        public void LoadPage(object page)
        {
            Main.Content = page;
        } 

        #endregion
    }
}
