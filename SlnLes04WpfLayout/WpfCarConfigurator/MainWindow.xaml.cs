﻿using System;
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

namespace WpfCarConfigurator
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


        int prijs = 0;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Hier selecteert men Model3
            if (cbxList.SelectedItem == cbxModel3)
            {
                imgGroot.Source = new BitmapImage(new Uri("/Model3.jpg", UriKind.Relative));
                prijs += 38000;
            }
            //Hier selecteert men ModelS
            else if (cbxList.SelectedItem == cbxModelS)
            {
                imgGroot.Source = new BitmapImage(new Uri("/modelS.jpg", UriKind.Relative));
                prijs += 70000;
            }
            //Hier selecteert men ModelX
            else if (cbxList.SelectedItem == cbxModelX)
            {
                imgGroot.Source = new BitmapImage(new Uri("/modelX.jpg", UriKind.Relative));
                prijs += 80000;
            }
            lblPrijs.Content = prijs + "euro";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Color voor ModelX
            if (cbxList.SelectedItem == cbxModelX && rbnBlack.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/ModelXBlack.jpg", UriKind.Relative));
                prijs += 1050;
            }
            if (cbxList.SelectedItem == cbxModelX && rbnRed.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/ModelXRed.jpg", UriKind.Relative));
                prijs += 2700;
            }
            if (cbxList.SelectedItem == cbxModelX && rbnWhite.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/ModelXWhite.jpg", UriKind.Relative));
                prijs += 1600;
            }

            //Color voor Model3
            if (cbxList.SelectedItem == cbxModel3 && rbnBlack.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/Model3Black.jpg", UriKind.Relative));
                prijs += 1050;
            }
            if (cbxList.SelectedItem == cbxModel3 && rbnRed.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/Model3Red.jpg", UriKind.Relative));
                prijs += 2700;
            }
            if (cbxList.SelectedItem == cbxModel3 && rbnWhite.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/Model3White.jpg", UriKind.Relative));
                prijs += 1600;
            }

            //Color voor ModelS
            if (cbxList.SelectedItem == cbxModelS && rbnBlack.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/ModelSBlack.jpg", UriKind.Relative));
                prijs += 1050;
            }
            if (cbxList.SelectedItem == cbxModelS && rbnRed.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/ModelSRed.jpg", UriKind.Relative));
                prijs += 2700;
            }
            if (cbxList.SelectedItem == cbxModelS && rbnWhite.IsChecked == true)
            {
                imgGroot.Source = new BitmapImage(new Uri("/ModelSWhite.jpg", UriKind.Relative));
                prijs += 1600;
            }

            lblPrijs.Content = prijs + "euro";
        }

        private void cbxColor_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxColor.IsChecked == true)
            {
                imgInterior.Opacity = 1;
                imgRims.Opacity = 0.3;
                imgPilot.Opacity = 0.3;
                prijs += 2100;
            }
            if (cbxRims.IsChecked == true)
            {
                imgInterior.Opacity = 0.3;
                imgRims.Opacity = 1;
                imgPilot.Opacity = 0.3;
                prijs += 4800;
            }
            if (cbxPilot.IsChecked == true)
            {
                imgInterior.Opacity = 0.3;
                imgRims.Opacity = 0.3;
                imgPilot.Opacity = 1;
                prijs += 7500;
            }

            if (cbxColor.IsChecked == true && cbxRims.IsChecked == true)
            {
                imgInterior.Opacity = 1;
                imgRims.Opacity = 1;
                imgPilot.Opacity = 0.3;

            }
            if (cbxColor.IsChecked == true && cbxPilot.IsChecked == true)
            {
                imgInterior.Opacity = 1;
                imgRims.Opacity = 0.3;
                imgPilot.Opacity = 1;

            }
            if (cbxRims.IsChecked == true && cbxPilot.IsChecked == true)
            {
                imgInterior.Opacity = 0.3;
                imgRims.Opacity = 1;
                imgPilot.Opacity = 1;

            }

            if (cbxColor.IsChecked == true && cbxPilot.IsChecked == true)
            {
                if (cbxRims.IsChecked == true)
                {
                    imgInterior.Opacity = 1;
                    imgRims.Opacity = 1;
                    imgPilot.Opacity = 1;
                }
            }
            lblPrijs.Content = prijs + "euro";
        }

        private void cbxColor_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxColor.IsChecked == false)
            {
                imgInterior.Opacity = 0.3;
                prijs -= 2100;
            }
        }

        private void cbxRims_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxRims.IsChecked == false)
            {
                imgRims.Opacity = 0.3;
                prijs -= 4800;
            }

        }

        private void cbxPilot_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxPilot.IsChecked == false)
            {
                imgPilot.Opacity = 0.3;
                prijs -= 7500;
            }

        }
    }
}
