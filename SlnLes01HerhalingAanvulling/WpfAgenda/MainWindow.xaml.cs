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

namespace WpfAgenda
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

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int aantalFouten = 0;
            if (tbxTitel.Text == "")
            {
                aantalFouten += 1;
                lblFoutEen.Content = "Gelieve een titel in te vullen";
            }
            else
            {
                lblFoutEen.Content = "";
            }
            if (dtpDatum.SelectedDate == null)
            {
                lblFoutTwee.Content = "Gelieve een datum in te vullen";
                aantalFouten += 1;
            }
            else 
            {
                lblFoutTwee.Content = "";
            }
            if (cbxType.SelectedItem == null)
            {
                lblFoutDrie.Content = "Gelieve een type te selecteren";
                aantalFouten += 1;
            }
            else
            {
                lblFoutDrie.Content = "";
            }

            if (rdbEen.IsChecked == false && rdbTwee.IsChecked == false && rdbDrie.IsChecked == false && rdbGeen.IsChecked == false)
            {
                lblFoutVier.Content = "Gelieve een keuze te maken";
                aantalFouten += 1;
            }
            else 
            {
                lblFoutVier.Content = "";
            }
            if (cbxEmail.IsChecked == false && cbxNotificatie.IsChecked == false)
            {
                lblFoutVijf.Content = "Gelieve een keuze te maken";
                aantalFouten += 1;
            }
            else 
            {
                lblFoutVijf.Content = "";
            }

            lblFoutTotaal.Content = $"het formulier bevat {aantalFouten} fouten";

            if (aantalFouten == 0)
            {
                lbxAfspraken.Items.Add(dtpDatum.SelectedDate.Value.Date.ToShortDateString() + " - " + tbxTitel.Text);
                
                
            }
            
        }

    }
}
