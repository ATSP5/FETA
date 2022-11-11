using FETA.ViewModel;
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

namespace FETA
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationMenu _navigationMenu;
        public MainWindow()
        {
            InitializeComponent();
            _navigationMenu = new NavigationMenu();
            DataContext = _navigationMenu.EncryptDecryptViewModel_O;
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            DataContext = _navigationMenu.AboutViewModel_O;
        }

        private void btnEncryptDecrypt_Click(object sender, RoutedEventArgs e)
        {
            DataContext = _navigationMenu.EncryptDecryptViewModel_O;
        }
    }
}
