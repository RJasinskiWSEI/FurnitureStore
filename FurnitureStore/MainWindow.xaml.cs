using FurnitureStore.Infrastructure.IoC;
using FurnitureStore.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private Page _loadedPage;

        public Page LoadedPage
        {


            get => _loadedPage;
            set
            {
                _loadedPage = value;
                Main.Content = value;
            }
        }

        #endregion


        public MainWindow()
        {
            InitializeComponent();
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
