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
using System.Windows.Media;

namespace WpfFocusTab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void tbxVoornaam_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxVoornaam.Background = Brushes.LightGreen;
        }

        private void tbxVoornaam_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxVoornaam.Background = Brushes.White;
        }

        private void tbxStraat_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxStraat.Background = Brushes.LightGreen;
        }

        private void tbxStraat_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxStraat.Background = Brushes.White;
        }

        private void tbxPostcode_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxPostcode.Background = Brushes.LightGreen;
        }

        private void tbxPostcode_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxPostcode.Background = Brushes.White;
        }

        private void tbxAchternaam_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxAchternaam.Background = Brushes.LightGreen;
        }

        private void tbxAchternaam_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxAchternaam.Background = Brushes.White;
        }

        private void tbxNummer_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxNummer.Background = Brushes.LightGreen;
        }

        private void tbxNummer_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxNummer.Background = Brushes.White;
        }

        private void tbxBus_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxBus.Background = Brushes.LightGreen;
        }

        private void tbxBus_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxBus.Background = Brushes.White;
        }

        private void tbxStad_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxStad.Background = Brushes.LightGreen;
        }

        private void tbxStad_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxStad.Background = Brushes.White;
        }
    }
}
