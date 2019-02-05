using System.Windows;
using System.Windows.Controls;

namespace FurnitureStore.Windows.Views
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
