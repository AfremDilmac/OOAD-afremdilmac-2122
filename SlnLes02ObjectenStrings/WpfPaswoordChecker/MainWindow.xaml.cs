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

namespace WpfPaswoordChecker
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxWachtwoord.Text.Length >= 8)
            {
                lblLengte.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (tbxWachtwoord.Text.Any(char.IsUpper))
            {
                lblUpper.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (tbxWachtwoord.Text.Any(char.IsLower))
            {
                lblLower.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (tbxWachtwoord.Text.Any(char.IsDigit))
            {
                lblDigit.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (!tbxWachtwoord.Text.Any(char.IsLetterOrDigit))
            {
                lblSpecial.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (tbxWachtwoord.Text.Length >= 8 && tbxWachtwoord.Text.Any(char.IsUpper) && tbxWachtwoord.Text.Any(char.IsLower) && tbxWachtwoord.Text.Any(char.IsDigit) && !tbxWachtwoord.Text.Any(char.IsLetterOrDigit)) {
                btnRegister.IsEnabled = true;
            }
        }
    }
}
