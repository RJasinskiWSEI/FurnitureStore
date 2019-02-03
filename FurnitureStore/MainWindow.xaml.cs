using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FurnitureStore.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainPageController
    {
        #region IMainPageController

        public Page LoadedPage { get; set; } 
        
        #endregion


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            Main.Content = new CategoryItems();
        }
    }

    /// <summary>
    /// Defines an application entry point for pages.
    /// </summary>
    public interface IMainPageController
    {
        /// <summary>
        /// Current loaded page.
        /// </summary>
        Page LoadedPage { get; set; }
    }
}
